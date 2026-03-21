Imports System.Windows.Forms
Imports System.IO

Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Public Class frmSettings

	Private _ltcDevices As List(Of Tuple(Of Integer, String))

	Private Sub UpdateLtcDiagnosticsPanel()
		Try
			lblLtcDiagnostics.Text = frmDigitalSlate.GetLtcDiagnosticsSummary()
		Catch ex As Exception
			lblLtcDiagnostics.Text = "LTC diagnostics unavailable."
		End Try
	End Sub

	Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
		Try
			Hide()
			frmDigitalSlate.Select()
		Catch
			Hide()
		End Try
	End Sub

	Private Function IsFolderWritable(folderPath As String) As Boolean
		Try
			If String.IsNullOrWhiteSpace(folderPath) Then Return False
			If Not Directory.Exists(folderPath) Then Directory.CreateDirectory(folderPath)
			Dim probeFile As String = Path.Combine(folderPath, ".write-test.tmp")
			File.WriteAllText(probeFile, Date.Now.ToString("O"))
			File.Delete(probeFile)
			Return True
		Catch
			Return False
		End Try
	End Function

	Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
		Dim crbCountdown As RadioButton = GetCheckedRadioButton(gbCountdown)
		Dim crbSyncBeeps As RadioButton = GetCheckedRadioButton(gbSyncBeeps)
		Dim crbCaps As RadioButton = GetCheckedRadioButton(gbCaps)

		If crbCountdown Is Nothing OrElse crbSyncBeeps Is Nothing OrElse crbCaps Is Nothing Then
			MessageBox.Show("No Radio Button is checked. Using old settings.")
			Return
		End If

		' Apply to the app's actual runtime state
		World.vMain.countdownCount = CInt(crbCountdown.Text) ' Countdown Beep Count
		World.vMain.beepCount = CInt(crbSyncBeeps.Text)      ' Sync Beep Count
		World.vMain.displayCaps = If(String.Equals(crbCaps.Text, "Yes", StringComparison.OrdinalIgnoreCase), 1, 0)
		World.vMain.slateScaleMultiplier = CDbl(nudSlateScale.Value)

		' Persist
		My.Settings.cfgBeepCount = World.vMain.beepCount
		My.Settings.cfgCountdownCount = World.vMain.countdownCount
		My.Settings.cfgDisplayCaps = World.vMain.displayCaps
		My.Settings.cfgSlateScaleMultiplier = World.vMain.slateScaleMultiplier

		' LTC settings
		World.vMain.ltcEnabled = If(cbLtcEnabled.Checked, 1, 0)
		World.vMain.ltcUnmute = If(cbLtcUnmute.Checked, 1, 0)
		World.vMain.ltcFpsMode = Math.Max(0, cmbLtcFps.SelectedIndex)
		Dim selected = TryCast(cmbLtcDevice.SelectedItem, Tuple(Of Integer, String))
		World.vMain.ltcOutputDeviceId = If(selected IsNot Nothing, selected.Item1, -1)
		My.Settings.cfgLtcEnabled = World.vMain.ltcEnabled
		My.Settings.cfgLtcFpsMode = World.vMain.ltcFpsMode
		My.Settings.cfgLtcOutputDeviceId = World.vMain.ltcOutputDeviceId
		My.Settings.cfgLtcUnmute = World.vMain.ltcUnmute

		World.vMain.skipSound = If(cbQuietSticks.Checked, 1, 0)
		World.vMain.showCountdownNumbers = If(cbShowCountdownNumbers.Checked, 1, 0)
		World.vMain.alwaysFullPreroll = If(cbAlwaysFullPreroll.Checked, 1, 0)
		World.vMain.metadataFlashFpsEnabled = If(cbMetadataFps.Checked, 1, 0)
		World.vMain.metadataFlashDateEnabled = If(cbMetadataDate.Checked, 1, 0)
		World.vMain.logOutToFile = If(cbLogOut2File.Checked, 1, 0)
		World.vMain.markerAppendDaily = If(cbAppendDailyMarkers.Checked, 1, 0)
		World.vMain.sessionMetadataEnabled = If(cbSessionMetadata.Checked, 1, 0)
		ApplySessionMetadataPolicy()

		If World.vMain.logOutToFile = 1 Then
			Dim currentFolder As String = txtLogFolder.Text.Trim()
			If String.IsNullOrWhiteSpace(currentFolder) OrElse Not Directory.Exists(currentFolder) Then
				fbdLogOut.Description = "Choose folder for Resolve marker log output"
				fbdLogOut.ShowNewFolderButton = True
				If Not String.IsNullOrWhiteSpace(currentFolder) AndAlso Directory.Exists(currentFolder) Then
					fbdLogOut.SelectedPath = currentFolder
				End If

				If fbdLogOut.ShowDialog() <> DialogResult.OK OrElse String.IsNullOrWhiteSpace(fbdLogOut.SelectedPath) Then
					MessageBox.Show("Log output is enabled, but no folder was selected.")
					Return
				End If

				currentFolder = fbdLogOut.SelectedPath
			End If

			If Not IsFolderWritable(currentFolder) Then
				MessageBox.Show("Selected log folder is not writable.", "Log output error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return
			End If

			World.vMain.logOutputFolder = currentFolder
		Else
			World.vMain.logOutputFolder = txtLogFolder.Text.Trim()
		End If

		My.Settings.cfgSkipSound = World.vMain.skipSound
		My.Settings.cfgShowCountdownNumbers = World.vMain.showCountdownNumbers
		My.Settings.cfgAlwaysFullPreroll = World.vMain.alwaysFullPreroll
		My.Settings.cfgMetadataFlashFpsEnabled = World.vMain.metadataFlashFpsEnabled
		My.Settings.cfgMetadataFlashDateEnabled = World.vMain.metadataFlashDateEnabled
		My.Settings.cfgLogOutToFile = World.vMain.logOutToFile
		My.Settings.cfgLogOutputFolder = World.vMain.logOutputFolder
		My.Settings.cfgMarkerAppendDaily = World.vMain.markerAppendDaily
		My.Settings.cfgSessionMetadataEnabled = World.vMain.sessionMetadataEnabled
		My.Settings.cfgSessionId = World.vMain.sessionId
		My.Settings.cfgUnitName = World.vMain.unitName
		My.Settings.cfgOperatorName = World.vMain.operatorName
		My.Settings.Save()

		refreshSlate()
		frmDigitalSlate.ApplyCurrentSlateScale()
		Hide()
		frmDigitalSlate.Select()
	End Sub

	Private Sub frmSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		' Load into runtime state
		World.vMain.beepCount = My.Settings.cfgBeepCount
		World.vMain.countdownCount = My.Settings.cfgCountdownCount
		World.vMain.displayCaps = My.Settings.cfgDisplayCaps
		World.vMain.slateScaleMultiplier = If(My.Settings.cfgSlateScaleMultiplier > 0, My.Settings.cfgSlateScaleMultiplier, World.vDefaults.slateScaleMultiplier)
		World.vMain.ltcEnabled = My.Settings.cfgLtcEnabled
		World.vMain.ltcFpsMode = My.Settings.cfgLtcFpsMode
		World.vMain.ltcOutputDeviceId = My.Settings.cfgLtcOutputDeviceId
		World.vMain.ltcUnmute = My.Settings.cfgLtcUnmute
		World.vMain.skipSound = My.Settings.cfgSkipSound
		World.vMain.showCountdownNumbers = My.Settings.cfgShowCountdownNumbers
		World.vMain.alwaysFullPreroll = My.Settings.cfgAlwaysFullPreroll
		World.vMain.metadataFlashFpsEnabled = My.Settings.cfgMetadataFlashFpsEnabled
		World.vMain.metadataFlashDateEnabled = My.Settings.cfgMetadataFlashDateEnabled
		World.vMain.logOutToFile = My.Settings.cfgLogOutToFile
		World.vMain.logOutputFolder = My.Settings.cfgLogOutputFolder
		World.vMain.markerAppendDaily = My.Settings.cfgMarkerAppendDaily
		World.vMain.sessionMetadataEnabled = My.Settings.cfgSessionMetadataEnabled
		World.vMain.sessionId = My.Settings.cfgSessionId
		World.vMain.unitName = My.Settings.cfgUnitName
		World.vMain.operatorName = My.Settings.cfgOperatorName
		ApplySessionMetadataPolicy()

		cbLtcEnabled.Checked = (World.vMain.ltcEnabled = 1)
		cbLtcUnmute.Checked = (World.vMain.ltcUnmute = 1)
		cbQuietSticks.Checked = (World.vMain.skipSound = 1)
		cbShowCountdownNumbers.Checked = (World.vMain.showCountdownNumbers = 1)
		cbAlwaysFullPreroll.Checked = (World.vMain.alwaysFullPreroll = 1)
		cbMetadataFps.Checked = (World.vMain.metadataFlashFpsEnabled = 1)
		cbMetadataDate.Checked = (World.vMain.metadataFlashDateEnabled = 1)
		cbLogOut2File.Checked = (World.vMain.logOutToFile = 1)
		cbAppendDailyMarkers.Checked = (World.vMain.markerAppendDaily = 1)
		cbSessionMetadata.Checked = (World.vMain.sessionMetadataEnabled = 1)
		Dim safeScale As Decimal = CDec(Math.Max(0.5, Math.Min(1.0, World.vMain.slateScaleMultiplier)))
		nudSlateScale.Value = safeScale
		txtLogFolder.Text = World.vMain.logOutputFolder
		Dim idx As Integer = World.vMain.ltcFpsMode
		If idx < 0 OrElse idx > 3 Then idx = 1
		cmbLtcFps.SelectedIndex = idx

		cmbLtcDevice.Items.Clear()
		_ltcDevices = LtcAudioOutputService.GetOutputDevices()
		cmbLtcDevice.Items.Add(Tuple.Create(-1, "Default"))
		For Each d In _ltcDevices
			cmbLtcDevice.Items.Add(d)
		Next
		cmbLtcDevice.DisplayMember = "Item2"
		Dim desiredId As Integer = World.vMain.ltcOutputDeviceId
		Dim selectedIndex As Integer = 0
		For i As Integer = 0 To cmbLtcDevice.Items.Count - 1
			Dim item = TryCast(cmbLtcDevice.Items(i), Tuple(Of Integer, String))
			If item IsNot Nothing AndAlso item.Item1 = desiredId Then
				selectedIndex = i
				Exit For
			End If
		Next
		cmbLtcDevice.SelectedIndex = selectedIndex

		Dim countdownCountToRadioButton As New Dictionary(Of Integer, RadioButton) From {
			{0, rb0CD},
			{1, rb1CD},
			{2, rb2CD},
			{3, rb3CD},
			{4, rb4CD}
		}

		Dim beepCountToRadioButton As New Dictionary(Of Integer, RadioButton) From {
			{0, rb0SB},
			{1, rb1SB},
			{2, rb2SB}
		}

		If countdownCountToRadioButton.ContainsKey(World.vMain.countdownCount) Then
			countdownCountToRadioButton(World.vMain.countdownCount).Checked = True
		Else
			rb3CD.Checked = True
		End If

		If beepCountToRadioButton.ContainsKey(World.vMain.beepCount) Then
			beepCountToRadioButton(World.vMain.beepCount).Checked = True
		Else
			rb1SB.Checked = True
		End If

		rbYesCaps.Checked = (World.vMain.displayCaps = 1)
		rbNoCaps.Checked = Not rbYesCaps.Checked
		lblBuildVersion.Text = "Build: " & Application.ProductVersion
		UpdateLtcDiagnosticsPanel()
	End Sub

	Private Sub butResetSlateScale_Click(sender As Object, e As EventArgs) Handles butResetSlateScale.Click
		nudSlateScale.Value = 1D
	End Sub

	Private Sub butRefreshLtcDiagnostics_Click(sender As Object, e As EventArgs) Handles butRefreshLtcDiagnostics.Click
		UpdateLtcDiagnosticsPanel()
	End Sub

	Private Sub LtcDiagnosticsSourceChanged(sender As Object, e As EventArgs) Handles cbLtcEnabled.CheckedChanged, cbLtcUnmute.CheckedChanged, cmbLtcFps.SelectedIndexChanged, cmbLtcDevice.SelectedIndexChanged
		UpdateLtcDiagnosticsPanel()
	End Sub

	Private Function GetCheckedRadioButton(container As Control) As RadioButton
		For Each control As Control In container.Controls
			If TypeOf control Is RadioButton Then
				Dim radioButton As RadioButton = CType(control, RadioButton)
				If radioButton.Checked Then
					Return radioButton
				End If
			End If
		Next
		Return Nothing
	End Function

	Private Sub butBrowseLogFolder_Click(sender As Object, e As EventArgs) Handles butBrowseLogFolder.Click
		fbdLogOut.Description = "Choose folder for Resolve marker log output"
		fbdLogOut.ShowNewFolderButton = True
		If Not String.IsNullOrWhiteSpace(txtLogFolder.Text) AndAlso Directory.Exists(txtLogFolder.Text) Then
			fbdLogOut.SelectedPath = txtLogFolder.Text
		End If

		If fbdLogOut.ShowDialog() = DialogResult.OK Then
			txtLogFolder.Text = fbdLogOut.SelectedPath
		End If
	End Sub

	Private Sub butTestLogFolder_Click(sender As Object, e As EventArgs) Handles butTestLogFolder.Click
		Dim folder As String = txtLogFolder.Text.Trim()
		If IsFolderWritable(folder) Then
			MessageBox.Show("Log folder is writable.", "Log output", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			MessageBox.Show("Log folder is not writable.", "Log output", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
	End Sub

End Class