Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Imports System.Media


Public Class frmDigitalSlate

	Dim myMainClass As New World.mainClass()

	Private Sub frmDigitalSlate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		loadFromSettings()
		loadToForm(Me)

		' Ensure save/load menu items reflect current timer state
		Try
			tsiSaveProfile.Enabled = Not Timer1.Enabled
			tsiLoadProfile.Enabled = Not Timer1.Enabled
		Catch ex As Exception
			' Ignore if menu items are not present in designer yet
		End Try
	End Sub

	Private framesPerSecond As Double = World.vDefaults.fps     'default is 24 fps

	Private Sub frmDigitalSlate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		loadFromSettings()
		loadToForm(Me)

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

	Private Async Function runCountDown(count As Integer) As Task
		Await Task.Run(Sub()
								' Create a new instance of SoundPlayer
								Dim cdPlayer As New SoundPlayer("audio\countdown.wav")

								Try
									' Load the WAV file
									cdPlayer.Load()

									' Play the WAV file
									For i As Integer = 1 To count
										cdPlayer.PlaySync()
									Next
								Catch ex As Exception
									' Handle any errors that might occur
									MessageBox.Show("An error occurred while trying to play the sound: " & ex.Message)
								End Try
							End Sub)
	End Function

	Private Async Function playSyncBeep(count As Integer) As Task
		Await Task.Run(Sub()
								' Create a new instance of SoundPlayer
								Dim beepPlayer As New SoundPlayer("audio\syncBeep.wav")

								Try
									' Load the WAV file
									beepPlayer.Load()

									' Play the WAV file
									For i As Integer = 1 To count
										beepPlayer.PlaySync()
									Next
								Catch ex As Exception
									' Handle any errors that might occur
									MessageBox.Show("An error occurred while trying to play the sound: " & ex.Message)
								End Try
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
		myMainClass.tcTimerGo = 1 - myMainClass.tcTimerGo

		If myMainClass.tcTimerGo = 1 Then

			If myMainClass.skipSound = 1 Then
				Timer1.Start()
				tsiZeroTC.Enabled = False
			Else

				If lblTimecode.Text = zeroTC Then
					Await runCountDown(World.vMain.countdownCount)
					Await playSyncBeep(World.vMain.beepCount)
				Else
					Await playSyncBeep(World.vMain.beepCount)
				End If

				Timer1.Start()
				tsiZeroTC.Enabled = False
			End If

			' disable save/load while running
			Try
				tsiSaveProfile.Enabled = False
				tsiLoadProfile.Enabled = False
			Catch ex As Exception
				' ignore if controls missing
			End Try

		Else
			Timer1.Stop()
			addTake()
			tsiZeroTC.Enabled = True

			' re-enable save/load now that timer stopped
			Try
				tsiSaveProfile.Enabled = True
				tsiLoadProfile.Enabled = True
			Catch ex As Exception
				' ignore if controls missing
			End Try
		End If

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
End Class



'1818 x 1364    Max size
'1.33       aspect
