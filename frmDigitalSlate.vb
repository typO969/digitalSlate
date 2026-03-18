Imports System.IO
Imports System.Diagnostics
Imports System.Media
Imports System.Reflection.Emit
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Public Class frmDigitalSlate
	Private ReadOnly _ltcOut As New LtcAudioOutputService()
	Private _targetValue As Integer = 1
	Private _timecodeFreezeUntilUtc As DateTime = DateTime.MinValue
	Private _frozenTimecodeText As String = zeroTC
	Private _timecodeOverlayUntilUtc As DateTime = DateTime.MinValue
	Private _timecodeOverlayText As String = String.Empty
	Private _timecodeLabelBaseFont As Font


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
		_timecodeLabelBaseFont = New Font(lblTimecode.Font.FontFamily, lblTimecode.Font.Size, lblTimecode.Font.Style)
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

	Private Function GetFrameDurationMs(frameCount As Integer) As Integer
		Dim safeFps As Double = If(framesPerSecond > 0, framesPerSecond, World.vDefaults.fps)
		Return Math.Max(1, CInt(Math.Round((frameCount * 1000.0) / safeFps)))
	End Function

	Private Sub BeginTimecodeFreeze(frames As Integer)
		_frozenTimecodeText = TimecodeGenerator.GenerateTimecode(Date.Now, framesPerSecond).ToString()
		_timecodeFreezeUntilUtc = DateTime.UtcNow.AddMilliseconds(GetFrameDurationMs(frames))
	End Sub

	Private Function GetSlateDateForOverlay() As String
		If Not String.IsNullOrWhiteSpace(World.vMain.custDate) Then
			Return World.vMain.custDate
		End If

		If Not String.IsNullOrWhiteSpace(World.vMain.currentDate) Then
			Return World.vMain.currentDate
		End If

		Return Date.Now.ToString("dd MMM yyyy")
	End Function

	Private Function GetMetadataItems() As List(Of String)
		Dim items As New List(Of String)

		If World.vMain.metadataFlashFpsEnabled = 1 Then
			items.Add($"FPS {framesPerSecond:0.###}")
		End If

		If World.vMain.metadataFlashDateEnabled = 1 Then
			items.Add(GetSlateDateForOverlay())
		End If

		Return items
	End Function

	Private Sub SaveClapTimecodeToSessionLog()
		Dim clapTc As String = TimecodeGenerator.GenerateTimecode(Date.Now, framesPerSecond).ToString()
		World.vMain.clapTimecodeLog.Add(clapTc)
	End Sub

	Private Async Sub StartClapPulse()
		Try
			Await TriggerVisualPulseAsync(1, True)
		Catch
		End Try
	End Sub

	Private Sub StartTakeAtSyncPoint(showMetadataFallback As Boolean)
		If Timer1.Enabled Then Return

		If World.vMain.ltcEnabled = 1 Then
			Dim deviceId As Integer = World.vMain.ltcOutputDeviceId
			Dim fpsMode As LtcFpsMode = CType(Math.Max(0, Math.Min(3, World.vMain.ltcFpsMode)), LtcFpsMode)
			_ltcOut.Start(deviceId, fpsMode)
			_ltcOut.SetMuted(World.vMain.ltcUnmute <> 1)
		End If

		SaveClapTimecodeToSessionLog()
		BeginTimecodeFreeze(5)
		StartClapPulse()

		Timer1.Start()
		tsiZeroTC.Enabled = False
		UpdateLtcIndicator()
		If showMetadataFallback Then
			StartMetadataFlashSequence()
		End If

		Try
			tsiSaveProfile.Enabled = False
			tsiLoadProfile.Enabled = False
		Catch ex As Exception
		End Try
	End Sub

	Private Async Function ShowTimecodeOverlayAsync(text As String, durationMs As Integer, Optional useLargeFont As Boolean = False) As Task
		_timecodeOverlayText = text
		_timecodeOverlayUntilUtc = DateTime.UtcNow.AddMilliseconds(Math.Max(1, durationMs))

		If useLargeFont Then
			lblTimecode.Font = New Font(lblTimecode.Font.FontFamily, 88.0F, FontStyle.Bold)
		ElseIf _timecodeLabelBaseFont IsNot Nothing Then
			lblTimecode.Font = _timecodeLabelBaseFont
		End If

		lblTimecode.Text = text
		Await Task.Delay(Math.Max(1, durationMs))

		If DateTime.UtcNow >= _timecodeOverlayUntilUtc AndAlso _timecodeLabelBaseFont IsNot Nothing Then
			lblTimecode.Font = _timecodeLabelBaseFont
		End If
	End Function

	Private Async Function ShowCountdownNumberOverlayAsync(number As Integer, durationMs As Integer) As Task
		Using overlay As New Form()
			overlay.FormBorderStyle = FormBorderStyle.None
			overlay.StartPosition = FormStartPosition.Manual
			overlay.Bounds = Screen.FromControl(Me).Bounds
			overlay.ShowInTaskbar = False
			overlay.TopMost = True
			overlay.BackColor = Color.Magenta
			overlay.TransparencyKey = Color.Magenta

			AddHandler overlay.Paint,
				Sub(sender As Object, e As PaintEventArgs)
					e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
					e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit

					Dim sf As New StringFormat With {
						.Alignment = StringAlignment.Center,
						.LineAlignment = StringAlignment.Center
					}

					Dim textValue As String = number.ToString()
					Dim textRect As New Rectangle(0, 0, overlay.ClientSize.Width, overlay.ClientSize.Height)
					Dim emSize As Single = CSng(Math.Min(overlay.ClientSize.Width, overlay.ClientSize.Height) * 0.55)

					Using path As New GraphicsPath()
						Using arialFamily As New FontFamily("Arial")
							path.AddString(textValue,
						  arialFamily,
							CInt(FontStyle.Bold),
							emSize,
							textRect,
							sf)
						End Using

						Using strokePen As New Pen(Color.Black, 5.0F)
							strokePen.LineJoin = LineJoin.Round
							e.Graphics.DrawPath(strokePen, path)
						End Using

						Using fillBrush As New SolidBrush(Color.Yellow)
							e.Graphics.FillPath(fillBrush, path)
						End Using
					End Using
				End Sub

			overlay.Show()
			overlay.Refresh()
			Await Task.Delay(Math.Max(1, durationMs))
			overlay.Close()
		End Using
	End Function

	Private Function GetMetadataFlashDurationMs() As Integer
		Return GetFrameDurationMs(3)
	End Function

	Private Async Function ShowMetadataFlashSequenceAsync() As Task
		Dim items As List(Of String) = GetMetadataItems()
		If items.Count = 0 Then Return

		For Each item In items
			Await ShowTimecodeOverlayAsync(item, GetMetadataFlashDurationMs())
		Next
	End Function

	Private Async Sub StartMetadataFlashSequence()
		Try
			Await ShowMetadataFlashSequenceAsync()
		Catch
		End Try
	End Sub

	Private Async Sub StartCountdownMetadataFlash(index As Integer, total As Integer)
		Try
			Dim items As List(Of String) = GetMetadataItems()
			If items.Count = 0 Then Return
			If total < items.Count Then Return
			If index < 1 OrElse index > items.Count Then Return

			Await ShowTimecodeOverlayAsync(items(index - 1), GetMetadataFlashDurationMs())
		Catch
		End Try
	End Sub

	Private Async Function TriggerVisualPulseAsync(frameCount As Integer, Optional forceWhite As Boolean = False) As Task
		Dim pulseColor As Color = Color.White

		Using pulseForm As New Form()
			pulseForm.FormBorderStyle = FormBorderStyle.None
			pulseForm.StartPosition = FormStartPosition.Manual
			pulseForm.Bounds = Screen.FromControl(Me).Bounds
			pulseForm.ShowInTaskbar = False
			pulseForm.TopMost = True
			pulseForm.BackColor = pulseColor
			pulseForm.Opacity = 1.0
			pulseForm.Show()

			Await Task.Delay(GetFrameDurationMs(frameCount))
			pulseForm.Close()
		End Using
	End Function

	Private Async Function HandleBeepVisualsAsync(index As Integer, total As Integer, isCountdown As Boolean) As Task
		Dim pulseTask As Task = TriggerVisualPulseAsync(1)

		If isCountdown AndAlso World.vMain.showCountdownNumbers <> 1 Then
			StartCountdownMetadataFlash(index, total)
		End If

		If isCountdown AndAlso total >= 2 AndAlso World.vMain.showCountdownNumbers = 1 Then
			Dim countNumber As Integer = Math.Max(0, total - index + 1)
			Await ShowCountdownNumberOverlayAsync(countNumber, 350)
		End If

		Await pulseTask
	End Function

	Private Async Function WaitUntilElapsedMsAsync(clock As Stopwatch, targetMs As Integer) As Task
		Dim remainingMs As Integer = targetMs - CInt(clock.ElapsedMilliseconds)
		If remainingMs > 1 Then
			Await Task.Delay(remainingMs)
		End If

		Do While clock.ElapsedMilliseconds < targetMs
			Await Task.Yield()
		Loop
	End Function

	Private Async Function runCountDown(count As Integer) As Task
    If count <= 0 Then Return

		Dim filePath = GetAudioPath("countdown.wav")
		If Not File.Exists(filePath) Then
			MessageBox.Show("Missing audio file: " & filePath)
			Return
		End If

		Using cdPlayer As New SoundPlayer(filePath)
			Try
				Await Task.Run(Sub() cdPlayer.Load())
          Dim cadenceClock As Stopwatch = Stopwatch.StartNew()
				Const CountdownCadenceMs As Integer = 1000

				For i As Integer = 1 To count
             Await WaitUntilElapsedMsAsync(cadenceClock, (i - 1) * CountdownCadenceMs)
					Dim visualsTask As Task = HandleBeepVisualsAsync(i, count, True)
					Await Task.Run(Sub() cdPlayer.PlaySync())
              Await visualsTask
				Next

				Await WaitUntilElapsedMsAsync(cadenceClock, count * CountdownCadenceMs)
			Catch ex As Exception
				MessageBox.Show("Error playing countdown: " & ex.Message)
			End Try
		End Using
	End Function

	Private Async Function TryCreateLoadedPlayer(relativeFile As String, missingFileMessagePrefix As String, loadErrorMessagePrefix As String) As Task(Of SoundPlayer)
		Dim filePath = GetAudioPath(relativeFile)
		If Not File.Exists(filePath) Then
			MessageBox.Show(missingFileMessagePrefix & filePath)
			Return Nothing
		End If

		Dim player As New SoundPlayer(filePath)
		Try
			Await Task.Run(Sub() player.Load())
			Return player
		Catch ex As Exception
			player.Dispose()
			MessageBox.Show(loadErrorMessagePrefix & ex.Message)
			Return Nothing
		End Try
	End Function

	Private Async Function playSyncBeep(count As Integer, Optional onFinalBeepStart As Action = Nothing, Optional preloadedPlayer As SoundPlayer = Nothing) As Task
		If preloadedPlayer IsNot Nothing Then
			Try
				For i As Integer = 1 To count
					Await HandleBeepVisualsAsync(i, count, False)
					If i = count AndAlso onFinalBeepStart IsNot Nothing Then
						onFinalBeepStart()
					End If
					Await Task.Run(Sub() preloadedPlayer.PlaySync())
				Next
			Catch ex As Exception
				MessageBox.Show("Error playing sync beep: " & ex.Message)
			End Try
			Return
		End If

		Using beepPlayer As SoundPlayer = Await TryCreateLoadedPlayer("syncBeep.wav", "Missing audio file: ", "Error loading sync beep: ")
			If beepPlayer Is Nothing Then Return

			Try
				For i As Integer = 1 To count
					Await HandleBeepVisualsAsync(i, count, False)
					If i = count AndAlso onFinalBeepStart IsNot Nothing Then
						onFinalBeepStart()
					End If
					Await Task.Run(Sub() beepPlayer.PlaySync())
				Next
			Catch ex As Exception
				MessageBox.Show("Error playing sync beep: " & ex.Message)
			End Try
		End Using
	End Function

	Private Sub updateTimecodeDisplay()
		If DateTime.UtcNow < _timecodeOverlayUntilUtc Then
			lblTimecode.Text = _timecodeOverlayText
			Return
		End If

		If DateTime.UtcNow < _timecodeFreezeUntilUtc Then
			lblTimecode.Text = _frozenTimecodeText
			Return
		End If

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
		Dim metadataCountdownEligible As Boolean = False

		If World.vMain.tcTimerGo = 1 Then
			Dim startedAtSyncPoint As Boolean = False
			Dim showMetadataFallback As Boolean = True
			Dim preloadedSyncPlayer As SoundPlayer = Nothing
			Dim startAtSync As Action =
				Sub()
					If startedAtSyncPoint Then Return
					startedAtSyncPoint = True
					StartTakeAtSyncPoint(showMetadataFallback)
				End Sub

			Try
				If World.vMain.skipSound = 1 Then
					' no pre-roll beeps
					showMetadataFallback = True
					startAtSync()
				Else
					Dim useFullPreroll As Boolean = (World.vMain.alwaysFullPreroll = 1)
					Dim shouldRunCountdown As Boolean = useFullPreroll OrElse (lblTimecode.Text = zeroTC)
					metadataCountdownEligible = (shouldRunCountdown AndAlso World.vMain.showCountdownNumbers <> 1 AndAlso World.vMain.countdownCount >= GetMetadataItems().Count)
					showMetadataFallback = Not metadataCountdownEligible

					If World.vMain.beepCount > 0 Then
						preloadedSyncPlayer = Await TryCreateLoadedPlayer("syncBeep.wav", "Missing audio file: ", "Error loading sync beep: ")
						If preloadedSyncPlayer Is Nothing Then
							World.vMain.tcTimerGo = 0
							Return
						End If
					End If

					If shouldRunCountdown Then
						Await runCountDown(World.vMain.countdownCount)
					End If

					If World.vMain.beepCount > 0 Then
						Await playSyncBeep(World.vMain.beepCount, startAtSync, preloadedSyncPlayer)
					Else
						startAtSync()
					End If

					tsiZeroTC.Enabled = False
				End If
			Finally
				If preloadedSyncPlayer IsNot Nothing Then
					preloadedSyncPlayer.Dispose()
				End If
			End Try

			If Not startedAtSyncPoint Then
				startAtSync()
			End If

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
