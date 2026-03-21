Imports System.IO
Imports System.Diagnostics
Imports System.Media
Imports System.Reflection.Emit
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Partial Public Class frmDigitalSlate
	Private ReadOnly _ltcOut As New LtcAudioOutputService()
	Private _targetValue As Integer = 1
	Private _timecodeFreezeUntilUtc As DateTime = DateTime.MinValue
	Private _frozenTimecodeText As String = zeroTC
	Private _timecodeOverlayUntilUtc As DateTime = DateTime.MinValue
	Private _timecodeOverlayText As String = String.Empty
	Private _timecodeLabelBaseFont As Font
	Private _logoOverlay As PictureBox
	Private _currentLogoImage As Image
	Private _ltcCurrentDeviceId As Integer = Integer.MinValue
	Private _ltcCurrentFpsMode As LtcFpsMode = CType(-1, LtcFpsMode)
   Private _ltcLastError As String = String.Empty
	Private _isPlayingCalibrationTone As Boolean = False
	Private WithEvents _ltcHealthTimer As New Windows.Forms.Timer With {.Interval = 1500}
	Private _resolveLogFilePathCache As String = String.Empty
	Private ReadOnly _resolveSessionToken As String = Date.Now.ToString("yyyyMMdd_HHmmss")
	Private _slateScaleInitialized As Boolean = False
	Private _slateDesignSize As Size = Size.Empty
	Private ReadOnly _slateControlBounds As New Dictionary(Of Control, Rectangle)
	Private ReadOnly _slateControlFonts As New Dictionary(Of Control, Font)

	Private Const LogoMaxWidthPx As Integer = 430
	Private Const LogoMaxHeightPx As Integer = 115
	Private Const ShowLogoDiagnostics As Boolean = False
	Private Shared ReadOnly DefaultLogoBounds As New Rectangle(16, 126, 88, 96)

	Private Shared Function GetCustomLogoPersistPath() As String
		Dim baseFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "digitalSlate")
		Return Path.Combine(baseFolder, "custom-logo.png")
	End Function

	Private Sub EnsureLogoOverlayControl()
		If _logoOverlay IsNot Nothing Then Return
		Dim logoBounds As Rectangle = If(pbLogoSlot IsNot Nothing, pbLogoSlot.Bounds, DefaultLogoBounds)
		Dim overlayParent As Control = plPrimary
		Dim overlayLocation As Point = logoBounds.Location

		If pbSlateBody IsNot Nothing AndAlso pbSlateBody.Bounds.Contains(logoBounds) Then
			overlayParent = pbSlateBody
			overlayLocation = New Point(logoBounds.X - pbSlateBody.Left, logoBounds.Y - pbSlateBody.Top)
		ElseIf pbClapper IsNot Nothing AndAlso pbClapper.Bounds.Contains(logoBounds) Then
			overlayParent = pbClapper
			overlayLocation = New Point(logoBounds.X - pbClapper.Left, logoBounds.Y - pbClapper.Top)
		End If

		_logoOverlay = New PictureBox With {
			.Name = "pbCustomLogoOverlay",
			.Location = overlayLocation,
			.Size = New Size(logoBounds.Width, logoBounds.Height),
			.SizeMode = PictureBoxSizeMode.Zoom,
			.BackColor = Color.Transparent,
			.Visible = False,
			.TabStop = False
		}

		overlayParent.Controls.Add(_logoOverlay)
		_logoOverlay.BringToFront()
	End Sub




	Private Function GetDesiredLtcFpsMode() As LtcFpsMode
		Return CType(Math.Max(0, Math.Min(3, World.vMain.ltcFpsMode)), LtcFpsMode)
	End Function

	Private Function GetLtcDeviceName(deviceId As Integer) As String
		If deviceId < 0 Then Return "Default"
		Try
			For Each d In LtcAudioOutputService.GetOutputDevices()
				If d.Item1 = deviceId Then Return d.Item2
			Next
		Catch
		End Try
		Return $"Device {deviceId}"
	End Function

	Private Sub EnsureSessionMetadataDefaults()
		ApplySessionMetadataPolicy()
	End Sub

	Private Sub SyncLtcOutputState()
		If _isPlayingCalibrationTone Then Return

		If World.vMain.ltcEnabled <> 1 Then
			_ltcOut.Stop()
			_ltcCurrentDeviceId = Integer.MinValue
			_ltcCurrentFpsMode = CType(-1, LtcFpsMode)
			_ltcLastError = String.Empty
			UpdateLtcIndicator()
			Return
		End If

		Try
			Dim desiredDeviceId As Integer = World.vMain.ltcOutputDeviceId
			Dim desiredFpsMode As LtcFpsMode = GetDesiredLtcFpsMode()

			If (Not _ltcOut.IsRunning) OrElse _ltcCurrentDeviceId <> desiredDeviceId OrElse _ltcCurrentFpsMode <> desiredFpsMode Then
				_ltcOut.Stop()
				_ltcOut.Start(desiredDeviceId, desiredFpsMode)
				_ltcCurrentDeviceId = desiredDeviceId
				_ltcCurrentFpsMode = desiredFpsMode
			End If

			_ltcOut.SetMuted(World.vMain.ltcUnmute <> 1)
			_ltcLastError = String.Empty
		Catch ex As Exception
			_ltcOut.Stop()
			_ltcCurrentDeviceId = Integer.MinValue
			_ltcCurrentFpsMode = CType(-1, LtcFpsMode)
			_ltcLastError = ex.Message
		End Try

		UpdateLtcIndicator()
	End Sub

	Private Sub SetLogoImage(image As Image)
		If _currentLogoImage IsNot Nothing Then
			_currentLogoImage.Dispose()
			_currentLogoImage = Nothing
		End If

		If image Is Nothing Then
			If _logoOverlay IsNot Nothing Then
				_logoOverlay.Image = Nothing
				_logoOverlay.Visible = False
			End If
			Return
		End If

		_currentLogoImage = CType(image.Clone(), Image)
		_logoOverlay.Image = _currentLogoImage
		_logoOverlay.Visible = True
	End Sub

	Private Function LoadImageUnlocked(filePath As String) As Image
		Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)
			Using img As Image = Image.FromStream(fs)
				Return CType(img.Clone(), Image)
			End Using
		End Using
	End Function

	Private Sub TryLoadPersistedLogo()
		Try
			EnsureLogoOverlayControl()
			Dim logoPath As String = GetCustomLogoPersistPath()
			If File.Exists(logoPath) Then
				Using loaded As Image = LoadImageUnlocked(logoPath)
					SetLogoImage(loaded)
					If ShowLogoDiagnostics Then
						MessageBox.Show($"Logo loaded from saved file: {loaded.Width}x{loaded.Height}", "Logo Diagnostic", MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
				End Using
				Return
			End If

			If pbLogoSlot IsNot Nothing AndAlso pbLogoSlot.Image IsNot Nothing Then
				Using fallback As Image = CType(pbLogoSlot.Image.Clone(), Image)
					SetLogoImage(fallback)
					If ShowLogoDiagnostics Then
						MessageBox.Show($"Logo loaded from designer fallback: {fallback.Width}x{fallback.Height}", "Logo Diagnostic", MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
				End Using
			Else
				SetLogoImage(Nothing)
				If ShowLogoDiagnostics Then
					MessageBox.Show("No persisted logo and no designer fallback image found.", "Logo Diagnostic", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
			End If
		Catch ex As Exception
			SetLogoImage(Nothing)
			If ShowLogoDiagnostics Then
				MessageBox.Show("Logo load failed: " & ex.Message, "Logo Diagnostic", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		End Try
	End Sub



	Private Function ValidateLogoDimensions(candidate As Image) As Boolean
		Return candidate.Width <= LogoMaxWidthPx AndAlso candidate.Height <= LogoMaxHeightPx
	End Function

	Private Sub SaveSelectedLogo(selectedPath As String)
		Dim persistPath As String = GetCustomLogoPersistPath()
		Dim persistDirectory As String = Path.GetDirectoryName(persistPath)
		If Not Directory.Exists(persistDirectory) Then
			Directory.CreateDirectory(persistDirectory)
		End If

		Using img As Image = LoadImageUnlocked(selectedPath)
			If Not ValidateLogoDimensions(img) Then
				MessageBox.Show($"Logo is too large ({img.Width}x{img.Height}). Max allowed is {LogoMaxWidthPx}x{LogoMaxHeightPx}.", "Invalid logo size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return
			End If

			If File.Exists(persistPath) Then
				File.Delete(persistPath)
			End If

			img.Save(persistPath, ImageFormat.Png)
			SetLogoImage(img)
			If ShowLogoDiagnostics Then
				MessageBox.Show($"Logo saved and applied: {img.Width}x{img.Height}", "Logo Diagnostic", MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Using
	End Sub


	Private Sub UpdateLtcIndicator()
		If lblLtcStatus Is Nothing Then Return

		If World.vMain.ltcEnabled <> 1 Then
			lblLtcStatus.Text = "LTC: OFF"
			lblLtcStatus.ForeColor = Color.Gray
			Return
		End If

		Dim fpsLabel As String = GetDesiredLtcFpsMode().ToString()
		Dim deviceLabel As String = GetLtcDeviceName(World.vMain.ltcOutputDeviceId)
		Dim muteLabel As String = If(World.vMain.ltcUnmute = 1, "AUD", "MUT")
		Dim baseText As String = $"LTC {fpsLabel} | {deviceLabel} | {muteLabel}"

		If Timer1 IsNot Nothing AndAlso Timer1.Enabled Then
			If World.vMain.ltcUnmute = 1 Then
				lblLtcStatus.Text = "LTC: LIVE | " & baseText
				lblLtcStatus.ForeColor = Color.Lime
			Else
				lblLtcStatus.Text = "LTC: MUTED | " & baseText
				lblLtcStatus.ForeColor = Color.Gold
			End If
		ElseIf _ltcOut IsNot Nothing AndAlso _ltcOut.IsRunning Then
			lblLtcStatus.Text = "LTC: READY | " & baseText
			lblLtcStatus.ForeColor = Color.Green
		Else
			lblLtcStatus.Text = "LTC: RECOVERING | " & baseText
			lblLtcStatus.ForeColor = Color.Orange
		End If

		If Not String.IsNullOrWhiteSpace(_ltcLastError) Then
			lblLtcStatus.Text &= " | ERR"
			lblLtcStatus.ForeColor = Color.OrangeRed
		End If
	End Sub


	Private Sub frmDigitalSlate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		loadFromSettings()
		EnsureSessionMetadataDefaults()
		framesPerSecond = If(World.vMain.fps > 0, World.vMain.fps, World.vDefaults.fps)
		loadToForm(Me)
		If pbLogoSlot IsNot Nothing Then pbLogoSlot.Visible = False
		TryLoadPersistedLogo()
		InitializeSlateScaling()
		_timecodeLabelBaseFont = New Font(lblTimecode.Font.FontFamily, lblTimecode.Font.Size, lblTimecode.Font.Style)
		SyncLtcOutputState()
		_ltcHealthTimer.Start()

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
		EnsureSessionMetadataDefaults()
		framesPerSecond = If(World.vMain.fps > 0, World.vMain.fps, World.vDefaults.fps)
		loadToForm(Me)
		If pbLogoSlot IsNot Nothing Then pbLogoSlot.Visible = False
		TryLoadPersistedLogo()
		ApplySlateScaleLayout()
		SyncLtcOutputState()
		If Not _ltcHealthTimer.Enabled Then _ltcHealthTimer.Start()

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

	Private Sub InitializeSlateScaling()
		If _slateScaleInitialized Then Return
		If plPrimary Is Nothing Then Return

     ClearControlSizeConstraintsRecursive(plPrimary)

		_slateDesignSize = plPrimary.Size
		_slateControlBounds.Clear()
		_slateControlFonts.Clear()
		CaptureSlateControlMetrics(plPrimary)

		_slateScaleInitialized = True
		ApplySlateScaleLayout()
	End Sub

	Private Sub ClearControlSizeConstraintsRecursive(parent As Control)
		parent.MinimumSize = Size.Empty
		parent.MaximumSize = Size.Empty

		For Each child As Control In parent.Controls
			ClearControlSizeConstraintsRecursive(child)
		Next
	End Sub

	Private Sub CaptureSlateControlMetrics(parent As Control)
		For Each child As Control In parent.Controls
			_slateControlBounds(child) = child.Bounds
			If child.Font IsNot Nothing Then
				_slateControlFonts(child) = CType(child.Font.Clone(), Font)
			End If

			If child.HasChildren Then
				CaptureSlateControlMetrics(child)
			End If
		Next
	End Sub

	Private Sub ApplySlateScaleLayout()
		If Not _slateScaleInitialized Then Return
		If _slateDesignSize.Width <= 0 OrElse _slateDesignSize.Height <= 0 Then Return
		If Me.ClientSize.Width <= 0 OrElse Me.ClientSize.Height <= 0 Then Return

		Dim fitScaleX As Double = Me.ClientSize.Width / CDbl(_slateDesignSize.Width)
		Dim fitScaleY As Double = Me.ClientSize.Height / CDbl(_slateDesignSize.Height)
		Dim fitScale As Double = Math.Min(fitScaleX, fitScaleY)

		Dim userScale As Double = If(World.vMain.slateScaleMultiplier > 0, World.vMain.slateScaleMultiplier, 1.0)
		Dim finalScale As Single = CSng(Math.Max(0.1, Math.Min(fitScale, fitScale * userScale)))

		Dim scaledWidth As Integer = Math.Max(1, CInt(Math.Round(_slateDesignSize.Width * finalScale)))
		Dim scaledHeight As Integer = Math.Max(1, CInt(Math.Round(_slateDesignSize.Height * finalScale)))

		plPrimary.SuspendLayout()
		plPrimary.Size = New Size(scaledWidth, scaledHeight)

		For Each kvp In _slateControlBounds
			Dim ctl As Control = kvp.Key
			Dim baseBounds As Rectangle = kvp.Value
			ctl.Bounds = New Rectangle(
				CInt(Math.Round(baseBounds.X * finalScale)),
				CInt(Math.Round(baseBounds.Y * finalScale)),
				Math.Max(1, CInt(Math.Round(baseBounds.Width * finalScale))),
				Math.Max(1, CInt(Math.Round(baseBounds.Height * finalScale))))

			Dim baseFont As Font = Nothing
			If _slateControlFonts.TryGetValue(ctl, baseFont) AndAlso baseFont IsNot Nothing Then
				Dim scaledFontSize As Single = Math.Max(1.0F, CSng(baseFont.Size * finalScale))
				ctl.Font = New Font(baseFont.FontFamily, scaledFontSize, baseFont.Style, baseFont.Unit)
			End If
		Next

		plPrimary.ResumeLayout()
		CenterPanel()

		If lblTimecode IsNot Nothing AndAlso DateTime.UtcNow >= _timecodeOverlayUntilUtc Then
			_timecodeLabelBaseFont = New Font(lblTimecode.Font.FontFamily, lblTimecode.Font.Size, lblTimecode.Font.Style)
		End If
	End Sub

	Private Sub frmDigitalSlate_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		ApplySlateScaleLayout()
	End Sub

	Public Sub ApplyCurrentSlateScale()
		ApplySlateScaleLayout()
	End Sub

	Public Function GetLtcDiagnosticsSummary() As String
		Dim enabled As Boolean = (World.vMain.ltcEnabled = 1)
		Dim running As Boolean = (_ltcOut IsNot Nothing AndAlso _ltcOut.IsRunning)
		Dim deviceLabel As String = GetLtcDeviceName(World.vMain.ltcOutputDeviceId)
		Dim fpsLabel As String = GetDesiredLtcFpsMode().ToString()
		Dim muteLabel As String = If(World.vMain.ltcUnmute = 1, "Unmuted", "Muted")

		Dim stateLabel As String
		If Not enabled Then
			stateLabel = "OFF"
		ElseIf running Then
			stateLabel = "RUNNING"
		Else
			stateLabel = "RECOVERING"
		End If

		Dim summary As String = $"State: {stateLabel} | FPS: {fpsLabel} | Device: {deviceLabel} | Audio: {muteLabel}"
		If Not String.IsNullOrWhiteSpace(_ltcLastError) Then
			summary &= $" | Last error: {_ltcLastError}"
		End If

		Return summary
	End Function

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
     Dim applyCaps As Func(Of String, String) = Function(value As String)
			If World.vMain.displayCaps = 1 Then
				Return If(value, String.Empty).ToUpperInvariant()
			End If
			Return If(value, String.Empty)
		End Function

		If Not String.IsNullOrWhiteSpace(World.vMain.custDate) Then
         Return applyCaps(World.vMain.custDate)
		End If

		If Not String.IsNullOrWhiteSpace(World.vMain.currentDate) Then
          Return applyCaps(World.vMain.currentDate)
		End If

     Return applyCaps(Date.Now.ToString("dd MMM yyyy"))
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
		WriteResolveInMarkerLog(clapTc)
	End Sub

	Private Shared Function SanitizeFilePart(value As String) As String
		If String.IsNullOrWhiteSpace(value) Then Return "UNTITLED"
		Dim cleaned As String = value.Trim()
		For Each ch In Path.GetInvalidFileNameChars()
			cleaned = cleaned.Replace(ch, "_"c)
		Next
		Return cleaned
	End Function

	Private Shared Function EscapeCsv(value As String) As String
		If value Is Nothing Then Return """"""
		Return """" & value.Replace("""", """""") & """"
	End Function

	Private Function NormalizeTimecode(tc As String) As String
		If String.IsNullOrWhiteSpace(tc) Then Return "00:00:00:00"
		Return tc.Replace(" ", String.Empty)
	End Function

	Private Function GetResolveLogFilePath() As String
		If Not String.IsNullOrWhiteSpace(_resolveLogFilePathCache) Then Return _resolveLogFilePathCache
		If String.IsNullOrWhiteSpace(World.vMain.logOutputFolder) Then Return String.Empty

		Dim productionPart As String = SanitizeFilePart(World.vMain.production)
		Dim scenePart As String = SanitizeFilePart(World.vMain.scene)
		Dim rollPart As String = SanitizeFilePart(World.vMain.roll)
        Dim sessionPart As String = If(IsSessionMetadataEnabled(), SanitizeFilePart(World.vMain.sessionId), "NOSESSION")
		Dim baseName As String

		If World.vMain.markerAppendDaily = 1 Then
			Dim dayPart As String = Date.Now.ToString("yyyyMMdd")
			baseName = $"{productionPart}_{dayPart}_SlateMarkers"
		Else
			baseName = $"{productionPart}_{scenePart}_{rollPart}_{sessionPart}_SlateMarkers_{_resolveSessionToken}"
		End If

		Dim candidatePath As String = Path.Combine(World.vMain.logOutputFolder, baseName & ".csv")
		Dim suffix As Integer = 1
    Do While World.vMain.markerAppendDaily <> 1 AndAlso File.Exists(candidatePath)
			candidatePath = Path.Combine(World.vMain.logOutputFolder, $"{baseName}_{suffix:00}.csv")
			suffix += 1
		Loop

		_resolveLogFilePathCache = candidatePath
		Return _resolveLogFilePathCache
	End Function

	Private Sub ResetResolveLogFilePathCache()
		_resolveLogFilePathCache = String.Empty
	End Sub

	Private Function EnsureLogFolderWritable() As Boolean
		Try
			If String.IsNullOrWhiteSpace(World.vMain.logOutputFolder) Then Return False
			If Not Directory.Exists(World.vMain.logOutputFolder) Then
				Directory.CreateDirectory(World.vMain.logOutputFolder)
			End If

			Dim probePath As String = Path.Combine(World.vMain.logOutputFolder, ".write-test.tmp")
			File.WriteAllText(probePath, Date.Now.ToString("O"))
			File.Delete(probePath)
			Return True
		Catch
			Return False
		End Try
	End Function

	Private Sub ExportResolveMarkerLogFromSession()
		If World.vMain.logOutToFile <> 1 Then
			MessageBox.Show("Marker log export is disabled in Settings.", "Export markers", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Return
		End If

		If Not EnsureLogFolderWritable() Then
			MessageBox.Show("Marker log folder is not writable. Check Settings.", "Export markers", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return
		End If

		Try
			Dim filePath As String = GetResolveLogFilePath()
			If String.IsNullOrWhiteSpace(filePath) Then
				MessageBox.Show("No marker log output path is configured.", "Export markers", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return
			End If

			Dim lines As New List(Of String) From {
				"Marker Name,Description,In,Out,Duration,Marker Color,Marker Type"
			}

			For i As Integer = 0 To World.vMain.clapTimecodeLog.Count - 1
				Dim inTc As String = NormalizeTimecode(World.vMain.clapTimecodeLog(i))
				Dim markerName As String = $"{World.vMain.scene}_T{i + 1}"
				Dim description As String = $"Roll {World.vMain.roll}; FPS {framesPerSecond:0.###}"
				Dim row As String = String.Join(",", New String() {
					EscapeCsv(markerName),
					EscapeCsv(description),
					EscapeCsv(inTc),
					EscapeCsv(inTc),
					EscapeCsv("00:00:00:01"),
					EscapeCsv("Blue"),
					EscapeCsv("Comment")
				})
				lines.Add(row)
			Next

			File.WriteAllLines(filePath, lines)
			MessageBox.Show($"Exported {World.vMain.clapTimecodeLog.Count} marker(s) to:`n{filePath}", "Export markers", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("Error exporting Resolve marker log: " & ex.Message, "Export markers", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try
	End Sub

	Private Sub WriteResolveInMarkerLog(inTcRaw As String)
		If World.vMain.logOutToFile <> 1 Then Return
		If Not EnsureLogFolderWritable() Then Return

		Try
			Dim filePath As String = GetResolveLogFilePath()
			If String.IsNullOrWhiteSpace(filePath) Then Return

			Dim folder As String = Path.GetDirectoryName(filePath)
			If String.IsNullOrWhiteSpace(folder) Then Return
			If Not Directory.Exists(folder) Then
				Directory.CreateDirectory(folder)
			End If

			Dim inTc As String = NormalizeTimecode(inTcRaw)
       Dim markerName As String = $"{World.vMain.scene}_T{World.vMain.take}"
		Dim description As String = $"Roll {World.vMain.roll}; FPS {framesPerSecond:0.###}"
		If IsSessionMetadataEnabled() Then
			description &= $"; Unit {World.vMain.unitName}; Op {World.vMain.operatorName}; Session {World.vMain.sessionId}"
		End If

			If Not File.Exists(filePath) Then
				Dim header As String = "Marker Name,Description,In,Out,Duration,Marker Color,Marker Type"
				File.WriteAllLines(filePath, New String() {header})
			End If

			Dim row As String = String.Join(",", New String() {
				EscapeCsv(markerName),
				EscapeCsv(description),
				EscapeCsv(inTc),
				EscapeCsv(inTc),
				EscapeCsv("00:00:00:01"),
				EscapeCsv("Blue"),
				EscapeCsv("Comment")
			})

			File.AppendAllLines(filePath, New String() {row})
		Catch ex As Exception
			MessageBox.Show("Error writing Resolve log: " & ex.Message, "Log output error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try
	End Sub

	Private Async Sub StartClapPulse()
		Try
			Await TriggerVisualPulseAsync(1, True)
		Catch
		End Try
	End Sub

	Private Sub StartTakeAtSyncPoint()
		If Timer1.Enabled Then Return

		SyncLtcOutputState()

		SaveClapTimecodeToSessionLog()
		BeginTimecodeFreeze(5)
		StartClapPulse()

		Timer1.Start()
		tsiZeroTC.Enabled = False
		UpdateLtcIndicator()

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
     If Timer1.Enabled Then Return
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
     If Timer1.Enabled Then Return
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

	Private Sub _ltcHealthTimer_Tick(sender As Object, e As EventArgs) Handles _ltcHealthTimer.Tick
		SyncLtcOutputState()
	End Sub

	Private Async Sub pbClapper_Click(sender As Object, e As EventArgs) Handles pbClapper.Click
		' Will need to change this to all the clapper action calls
		World.vMain.tcTimerGo = 1 - World.vMain.tcTimerGo
		Dim metadataCountdownEligible As Boolean = False

		If World.vMain.tcTimerGo = 1 Then
			Dim startedAtSyncPoint As Boolean = False
			Dim preloadedSyncPlayer As SoundPlayer = Nothing
			Dim startAtSync As Action =
				Sub()
					If startedAtSyncPoint Then Return
					startedAtSyncPoint = True
					StartTakeAtSyncPoint()
				End Sub

			Try
				If World.vMain.skipSound = 1 Then
					Await ShowMetadataFlashSequenceAsync()
					startAtSync()
				Else
					Dim useFullPreroll As Boolean = (World.vMain.alwaysFullPreroll = 1)
					Dim shouldRunCountdown As Boolean = useFullPreroll OrElse (lblTimecode.Text = zeroTC)
					metadataCountdownEligible = (shouldRunCountdown AndAlso World.vMain.showCountdownNumbers <> 1 AndAlso World.vMain.countdownCount >= GetMetadataItems().Count)

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

					If Not metadataCountdownEligible Then
						Await ShowMetadataFlashSequenceAsync()
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
			SyncLtcOutputState()
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
       _ltcHealthTimer.Stop()
		Catch
		End Try

		Try
			_ltcOut.Stop()
		Catch
		End Try

		If _currentLogoImage IsNot Nothing Then
			_currentLogoImage.Dispose()
			_currentLogoImage = Nothing
		End If

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
		ResetResolveLogFilePathCache()
		SyncLtcOutputState()
	End Sub

	Private Sub tsiOpenLogFolder_Click(sender As Object, e As EventArgs) Handles tsiOpenLogFolder.Click
		If String.IsNullOrWhiteSpace(World.vMain.logOutputFolder) OrElse Not Directory.Exists(World.vMain.logOutputFolder) Then
			MessageBox.Show("No marker log folder is configured.", "Open marker log folder", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Return
		End If

		Try
			Process.Start("explorer.exe", World.vMain.logOutputFolder)
		Catch ex As Exception
			MessageBox.Show("Unable to open marker log folder: " & ex.Message, "Open marker log folder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try
	End Sub

	Private Sub tsiRevealCurrentMarkerFile_Click(sender As Object, e As EventArgs) Handles tsiRevealCurrentMarkerFile.Click
		Dim filePath As String = GetResolveLogFilePath()
		If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
			MessageBox.Show("No current marker file exists yet.", "Reveal marker file", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Return
		End If

		Try
			Process.Start("explorer.exe", "/select,""" & filePath & """")
		Catch ex As Exception
			MessageBox.Show("Unable to reveal marker file: " & ex.Message, "Reveal marker file", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try
	End Sub

	Private Sub tsiValidateMarkerCsv_Click(sender As Object, e As EventArgs) Handles tsiValidateMarkerCsv.Click
		Dim filePath As String = GetResolveLogFilePath()
		If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
			MessageBox.Show("No marker CSV file exists yet.", "Validate marker CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Return
		End If

		Try
			Dim lines As String() = File.ReadAllLines(filePath)
			If lines.Length = 0 Then Throw New InvalidDataException("CSV file is empty.")
			If Not lines(0).StartsWith("Marker Name,Description,In,Out,Duration,Marker Color,Marker Type", StringComparison.OrdinalIgnoreCase) Then
				Throw New InvalidDataException("Header row does not match expected Resolve marker schema.")
			End If

			For i As Integer = 1 To lines.Length - 1
				If String.IsNullOrWhiteSpace(lines(i)) Then Continue For
				Dim quoteCount As Integer = lines(i).Count(Function(c) c = """"c)
				If quoteCount Mod 2 <> 0 Then
					Throw New InvalidDataException($"Row {i + 1} has unbalanced quotes.")
				End If
			Next

			MessageBox.Show($"CSV valid: {Path.GetFileName(filePath)}", "Validate marker CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("CSV validation failed: " & ex.Message, "Validate marker CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try
	End Sub

	Private Async Sub tsiLtcCalibrationTone_Click(sender As Object, e As EventArgs) Handles tsiLtcCalibrationTone.Click
		If World.vMain.ltcEnabled <> 1 Then
			MessageBox.Show("Enable LTC first to calibrate output path.", "LTC calibration", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Return
		End If

		Dim deviceId As Integer = World.vMain.ltcOutputDeviceId
		Dim resumeAfter As Boolean = _ltcOut IsNot Nothing AndAlso _ltcOut.IsRunning
		Dim resumeMuted As Boolean = (World.vMain.ltcUnmute <> 1)
		Dim resumeFpsMode As LtcFpsMode = GetDesiredLtcFpsMode()

		Try
			_isPlayingCalibrationTone = True
			_ltcOut.Stop()

			Using waveOut As New NAudio.Wave.WaveOutEvent()
				waveOut.DeviceNumber = deviceId
				waveOut.Init(New RightChannelToneProvider(48000, 1000.0, 0.2F))
				waveOut.Play()
				Await Task.Delay(2000)
				waveOut.Stop()
			End Using

			MessageBox.Show("Played 1 kHz reference tone on RIGHT channel for 2 seconds.", "LTC calibration", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("Calibration tone failed: " & ex.Message, "LTC calibration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		Finally
			If resumeAfter Then
				Try
					_ltcOut.Start(deviceId, resumeFpsMode)
					_ltcOut.SetMuted(resumeMuted)
				Catch
				End Try
			End If
			_isPlayingCalibrationTone = False
			SyncLtcOutputState()
		End Try
	End Sub

	Private Sub tsiExportMarkersNow_Click(sender As Object, e As EventArgs) Handles tsiExportMarkersNow.Click
		ExportResolveMarkerLogFromSession()
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

	Private Sub tsiChangeLogo_Click(sender As Object, e As EventArgs) Handles tsiChangeLogo.Click
		Using ofd As New OpenFileDialog()
			ofd.Filter = "PNG files (*.png)|*.png"
			ofd.Title = "Select logo image"
			ofd.CheckFileExists = True
			ofd.Multiselect = False

			If ofd.ShowDialog() <> DialogResult.OK Then Return

			Try
				SaveSelectedLogo(ofd.FileName)
			Catch ex As Exception
				MessageBox.Show("Unable to apply logo: " & ex.Message, "Logo error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Using
	End Sub

	Private Class RightChannelToneProvider
		Implements NAudio.Wave.IWaveProvider

		Private ReadOnly _sampleRate As Integer
		Private ReadOnly _frequency As Double
		Private ReadOnly _amplitude As Single
		Private _sampleIndex As Integer

		Public Sub New(sampleRate As Integer, frequency As Double, amplitude As Single)
			_sampleRate = sampleRate
			_frequency = frequency
			_amplitude = Math.Max(0.0F, Math.Min(0.9F, amplitude))
		End Sub

		Public ReadOnly Property WaveFormat As NAudio.Wave.WaveFormat Implements NAudio.Wave.IWaveProvider.WaveFormat
			Get
				Return New NAudio.Wave.WaveFormat(_sampleRate, 16, 2)
			End Get
		End Property

		Public Function Read(buffer As Byte(), offset As Integer, count As Integer) As Integer Implements NAudio.Wave.IWaveProvider.Read
			Dim bytesPerFrame As Integer = 4
			Dim frames As Integer = count \ bytesPerFrame
			Dim o As Integer = offset

			For i As Integer = 0 To frames - 1
				Dim t As Double = _sampleIndex / CDbl(_sampleRate)
				Dim sampleVal As Integer = CInt(Math.Sin(2.0 * Math.PI * _frequency * t) * _amplitude * Short.MaxValue)
				_sampleIndex += 1

				buffer(o) = 0
				buffer(o + 1) = 0
				buffer(o + 2) = CByte(sampleVal And &HFF)
				buffer(o + 3) = CByte((sampleVal >> 8) And &HFF)
				o += 4
			Next

			Return frames * bytesPerFrame
		End Function
	End Class

End Class



'1818 x 1364    Max size
'1.33       aspect
