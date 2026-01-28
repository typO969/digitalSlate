Imports System.IO
Imports System.Media
Imports System.Reflection.Emit
Imports System.Windows.Forms
Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Public Class frmDigitalSlate
	Private ReadOnly _ltcOut As New LtcAudioOutputService()
	Private _targetValue As Integer = 1


	Private Sub UpdateLtcIndicator()
		If lblLtcStatus Is Nothing Then Return

		If World.vMain.ltcEnabled <> 1 Then
			lblLtcStatus.Text = "LTC: OFF"
			lblLtcStatus.ForeColor = Color.Gray
			Return
		End If

		If Timer1 IsNot Nothing AndAlso Timer1.Enabled Then
			If World.vMain.ltcUnmute = 1 Then
				lblLtcStatus.Text = "LTC: LIVE"
				lblLtcStatus.ForeColor = Color.Lime
			Else
				lblLtcStatus.Text = "LTC: MUTED"
				lblLtcStatus.ForeColor = Color.Gold
			End If
		Else
			' Enabled but not currently running
			lblLtcStatus.Text = "LTC: READY"
			lblLtcStatus.ForeColor = Color.Green
		End If
	End Sub


	Private Sub frmDigitalSlate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		loadFromSettings()
		framesPerSecond = If(World.vMain.fps > 0, World.vMain.fps, World.vDefaults.fps)
		loadToForm(Me)
		UpdateLtcIndicator()

		' Ensure save/load menu items reflect current timer state
		Try
			tsiSaveProfile.Enabled = Not Timer1.Enabled
			tsiLoadProfile.Enabled = Not Timer1.Enabled
		Catch ex As Exception
			' Ignore if menu items are not present in designer yet
		End Try

		nudTakes.Value = _targetValue
		RefreshTargetLabel()
	End Sub

	Private Sub RefreshTargetLabel()
		lblTake.Text = _targetValue.ToString()
	End Sub



	Private framesPerSecond As Double = World.vDefaults.fps     'default is 24 fps

	Private Sub frmDigitalSlate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		loadFromSettings()
		framesPerSecond = If(World.vMain.fps > 0, World.vMain.fps, World.vDefaults.fps)
		loadToForm(Me)
		UpdateLtcIndicator()

		Try
			tsiSaveProfile.Enabled = Not Timer1.Enabled
			tsiLoadProfile.Enabled = Not Timer1.Enabled
		Catch ex As Exception
			' Ignore if menu items are not present in designer yet
		End Try
	End Sub

	Public Sub CenterPanel()
		If plPrimary IsNot Nothing Then
			plPrimary.Left = (Me.ClientSize.Width - plPrimary.Width) \ 2
			plPrimary.Top = (Me.ClientSize.Height - plPrimary.Height) \ 2
		End If
	End Sub

	Private Shared Function GetAudioPath(relativeFile As String) As String
		Return Path.Combine(Application.StartupPath, "audio", relativeFile)
	End Function

	Private Async Function runCountDown(count As Integer) As Task
		Await Task.Run(Sub()
						   Dim filePath = GetAudioPath("countdown.wav")
						   If Not File.Exists(filePath) Then
							   MessageBox.Show("Missing audio file: " & filePath)
							   Return
						   End If

						   Using cdPlayer As New SoundPlayer(filePath)
							   Try
								   cdPlayer.Load()
								   For i As Integer = 1 To count
									   cdPlayer.PlaySync()
								   Next
							   Catch ex As Exception
								   MessageBox.Show("Error playing countdown: " & ex.Message)
							   End Try
						   End Using
					   End Sub)
	End Function

	Private Async Function playSyncBeep(count As Integer) As Task
		Await Task.Run(Sub()
						   Dim filePath = GetAudioPath("syncBeep.wav")
						   If Not File.Exists(filePath) Then
							   MessageBox.Show("Missing audio file: " & filePath)
							   Return
						   End If

						   Using beepPlayer As New SoundPlayer(filePath)
							   Try
								   beepPlayer.Load()
								   For i As Integer = 1 To count
									   beepPlayer.PlaySync()
								   Next
							   Catch ex As Exception
								   MessageBox.Show("Error playing sync beep: " & ex.Message)
							   End Try
						   End Using
					   End Sub)
	End Function

	Private Sub updateTimecodeDisplay()
		Dim currentTime As Date = Date.Now

		Dim generatedTimecode As Timecode = TimecodeGenerator.GenerateTimecode(currentTime, framesPerSecond)
		lblTimecode.Text = generatedTimecode.ToString()
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		updateTimecodeDisplay()
	End Sub

	Private Async Sub pbClapper_Click(sender As Object, e As EventArgs) Handles pbClapper.Click
		' Will need to change this to all the clapper action calls
		World.vMain.tcTimerGo = 1 - World.vMain.tcTimerGo

		If World.vMain.tcTimerGo = 1 Then

			If World.vMain.skipSound = 1 Then
				' no pre-roll beeps
			Else

				If lblTimecode.Text = zeroTC Then
					Await runCountDown(World.vMain.countdownCount)
					Await playSyncBeep(World.vMain.beepCount)
				Else
					Await playSyncBeep(World.vMain.beepCount)
				End If

				tsiZeroTC.Enabled = False
			End If

			If World.vMain.ltcEnabled = 1 Then
				Dim deviceId As Integer = World.vMain.ltcOutputDeviceId
				Dim fpsMode As LtcFpsMode = CType(Math.Max(0, Math.Min(3, World.vMain.ltcFpsMode)), LtcFpsMode)
				_ltcOut.Start(deviceId, fpsMode)
				_ltcOut.SetMuted(World.vMain.ltcUnmute <> 1)
			End If

			Timer1.Start()
			tsiZeroTC.Enabled = False
			UpdateLtcIndicator()

			' disable save/load while running
			Try
				tsiSaveProfile.Enabled = False
				tsiLoadProfile.Enabled = False
			Catch ex As Exception
				' ignore if controls missing
			End Try

		Else
			Timer1.Stop()
			_ltcOut.Stop()
			addTake()
			tsiZeroTC.Enabled = True
			UpdateLtcIndicator()

			' re-enable save/load now that timer stopped
			Try
				tsiSaveProfile.Enabled = True
				tsiLoadProfile.Enabled = True
			Catch ex As Exception
				' ignore if controls missing
			End Try
		End If

	End Sub

	Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
		Try
			_ltcOut.Stop()
		Catch
		End Try
		MyBase.OnFormClosing(e)
	End Sub

	Private Sub addTake()
		If World.vMain.autoUpTake = 1 Then
			World.vMain.take += 1
			lblTake.Text = World.vMain.take.ToString()
		End If
	End Sub

	Private Function GetArea(size As Size) As Integer
		Return size.Height * size.Width
	End Function

	Private Async Function ResetTimecodeAsync() As Task

		lblTimecode.Text = String.Empty        ' Set the label text to blank
		Await Task.Delay(300)   ' Wait 

		lblTimecode.Text = "R E S E T"         ' Set label to "RESET"
		Await Task.Delay(500)   ' Wait for 1/2 second

		lblTimecode.Text = String.Empty        ' Set the label text to blank
		Await Task.Delay(200)   ' Wait

		lblTimecode.Text = zeroTC              ' Set the label text to zeroTC

	End Function

	Private Sub butSwIntExt_Click(sender As Object, e As EventArgs) Handles butSwIntExt.Click
		World.vMain.int = 1 - World.vMain.int

		lblHideInt.Visible = (World.vMain.int = 0)
		lblHideExt.Visible = (World.vMain.int = 1)
	End Sub

	Private Sub butSwDayNit_Click(sender As Object, e As EventArgs) Handles butSwDayNit.Click
		World.vMain.day = 1 - World.vMain.day

		lblHideDay.Visible = (World.vMain.day = 0)
		lblHideNite.Visible = (World.vMain.day = 1)
	End Sub

	Private Sub butSwAudio_Click(sender As Object, e As EventArgs) Handles butSwAudio.Click
		World.vMain.sync = 1 - World.vMain.sync

		lblHideSync.Visible = (World.vMain.sync = 0)
		lblHideMos.Visible = (World.vMain.sync = 1)
	End Sub

	Private Sub cbTakeInc_CheckedChanged(sender As Object, e As EventArgs) Handles cbTakeInc.CheckedChanged

		autoIncrementTakes(If(cbTakeInc.Checked, 1, 0))
	End Sub

	Private Sub autoIncrementTakes(power As Integer)
		If power = 0 Then
			World.vMain.autoUpTake = 0
		Else
			World.vMain.autoUpTake = 1
		End If
	End Sub

	Private Async Sub tsiZeroTC_Click(sender As Object, e As EventArgs) Handles tsiZeroTC.Click

		If Timer1.Enabled = False Then
			Await ResetTimecodeAsync()
		Else
			MessageBox.Show("ERROR: Cannot reset Timecode while it is running.")
		End If

	End Sub

	Private Sub tsiExit_Click(sender As Object, e As EventArgs) Handles tsiExit.Click
		My.Settings.Save()
		Application.Exit()
	End Sub

	Private Sub tsiOptions_Click(sender As Object, e As EventArgs) Handles tsiOptions.Click
		frmSettings.ShowDialog()
		UpdateLtcIndicator()
	End Sub

	Private Sub tsiReset_Click(sender As Object, e As EventArgs) Handles tsiReset.Click
		resetSlate()
	End Sub

	Private Sub tsiEdit_Click(sender As Object, e As EventArgs) Handles tsiEdit.Click
		frmEdit.ShowDialog()
	End Sub

	Private Sub butEdit_Click(sender As Object, e As EventArgs) Handles butEdit.Click
		frmEdit.ShowDialog()
	End Sub

	Private Sub butQuit_Click(sender As Object, e As EventArgs) Handles butQuit.Click
		My.Settings.Save()
		Application.Exit()
	End Sub

	Private Sub lblScene_Click(sender As Object, e As EventArgs) Handles lblScene.Click
		refreshSlate()
	End Sub

	' Menu handlers for save/load profile files (.clap)
	Private Sub tsiSaveProfile_Click(sender As Object, e As EventArgs) Handles tsiSaveProfile.Click
		' Delegate to shared Functions handler (which presents SaveFileDialog and verifies file)
		Try
			World.Functions.SaveSlateWithDialog()
		Catch ex As Exception
			MessageBox.Show("Error initiating save: " & ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub tsiLoadProfile_Click(sender As Object, e As EventArgs) Handles tsiLoadProfile.Click
		' Delegate to shared Functions handler (which presents OpenFileDialog and verifies file)
		Try
			World.Functions.LoadSlateWithDialog()
		Catch ex As Exception
			MessageBox.Show("Error initiating load: " & ex.Message, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub tsiImport_Click(sender As Object, e As EventArgs)

	End Sub

	Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

	End Sub

	Private Sub NudTakes_ValueChanged(sender As Object, e As EventArgs) Handles nudTakes.ValueChanged
		_targetValue = CInt(nudTakes.Value)
		RefreshTargetLabel()
	End Sub
End Class



'1818 x 1364    Max size
'1.33       aspect
