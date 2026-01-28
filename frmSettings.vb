Imports System.Windows.Forms

Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Public Class frmSettings

	Private _ltcPanel As Panel
	Private _cbLtcEnabled As CheckBox
	Private _cbLtcUnmute As CheckBox
	Private _cmbLtcFps As ComboBox
	Private _cmbLtcDevice As ComboBox
	Private _ltcDevices As List(Of Tuple(Of Integer, String))

	Private Sub EnsureLtcControls()
		If _ltcPanel IsNot Nothing Then Return

		_ltcPanel = New Panel() With {
			.Left = 12,
			.Top = Me.ClientSize.Height - 120,
			.Width = Me.ClientSize.Width - 24,
			.Height = 108,
			.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
		}

		_cbLtcEnabled = New CheckBox() With {
			.Left = 0,
			.Top = 0,
			.Width = _ltcPanel.Width,
			.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top,
			.Text = "Enable LTC (Left channel)"
		}

		_cbLtcUnmute = New CheckBox() With {
			.Left = 0,
			.Top = 20,
			.Width = _ltcPanel.Width,
			.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top,
			.Text = "Unmute LTC output (manual sync)"
		}

		Dim lblFps As New Label() With {
			.Left = 0,
			.Top = 44,
			.Width = 110,
			.Text = "LTC FPS:"
		}

		_cmbLtcFps = New ComboBox() With {
			.Left = 120,
			.Top = 40,
			.Width = 120,
			.DropDownStyle = ComboBoxStyle.DropDownList
		}
		_cmbLtcFps.Items.AddRange(New Object() {"23.976", "24", "25", "30"})

		Dim lblDev As New Label() With {
			.Left = 0,
			.Top = 76,
			.Width = 110,
			.Text = "Output device:"
		}

		_cmbLtcDevice = New ComboBox() With {
			.Left = 120,
			.Top = 72,
			.Width = _ltcPanel.Width - 120,
			.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top,
			.DropDownStyle = ComboBoxStyle.DropDownList
		}

		_ltcPanel.Controls.Add(_cbLtcEnabled)
		_ltcPanel.Controls.Add(_cbLtcUnmute)
		_ltcPanel.Controls.Add(lblFps)
		_ltcPanel.Controls.Add(_cmbLtcFps)
		_ltcPanel.Controls.Add(lblDev)
		_ltcPanel.Controls.Add(_cmbLtcDevice)
		Me.Controls.Add(_ltcPanel)
	End Sub

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

		' Persist
		My.Settings.cfgBeepCount = World.vMain.beepCount
		My.Settings.cfgCountdownCount = World.vMain.countdownCount
		My.Settings.cfgDisplayCaps = World.vMain.displayCaps

		' LTC settings (optional)
		If _cbLtcEnabled IsNot Nothing Then
			World.vMain.ltcEnabled = If(_cbLtcEnabled.Checked, 1, 0)
			World.vMain.ltcUnmute = If(_cbLtcUnmute IsNot Nothing AndAlso _cbLtcUnmute.Checked, 1, 0)
			World.vMain.ltcFpsMode = Math.Max(0, _cmbLtcFps.SelectedIndex)
			Dim selected = TryCast(_cmbLtcDevice.SelectedItem, Tuple(Of Integer, String))
			World.vMain.ltcOutputDeviceId = If(selected IsNot Nothing, selected.Item1, -1)
			My.Settings.cfgLtcEnabled = World.vMain.ltcEnabled
			My.Settings.cfgLtcFpsMode = World.vMain.ltcFpsMode
			My.Settings.cfgLtcOutputDeviceId = World.vMain.ltcOutputDeviceId
			My.Settings.cfgLtcUnmute = World.vMain.ltcUnmute
		End If
		My.Settings.Save()

		refreshSlate()
		Hide()
		frmDigitalSlate.Select()
	End Sub

	Private Sub frmSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		' Load into runtime state
		World.vMain.beepCount = My.Settings.cfgBeepCount
		World.vMain.countdownCount = My.Settings.cfgCountdownCount
		World.vMain.displayCaps = My.Settings.cfgDisplayCaps
		World.vMain.ltcEnabled = My.Settings.cfgLtcEnabled
		World.vMain.ltcFpsMode = My.Settings.cfgLtcFpsMode
		World.vMain.ltcOutputDeviceId = My.Settings.cfgLtcOutputDeviceId
		World.vMain.ltcUnmute = My.Settings.cfgLtcUnmute

		EnsureLtcControls()
		_cbLtcEnabled.Checked = (World.vMain.ltcEnabled = 1)
		If _cbLtcUnmute IsNot Nothing Then _cbLtcUnmute.Checked = (World.vMain.ltcUnmute = 1)
		Dim idx As Integer = World.vMain.ltcFpsMode
		If idx < 0 OrElse idx > 3 Then idx = 1
		_cmbLtcFps.SelectedIndex = idx

		_cmbLtcDevice.Items.Clear()
		_ltcDevices = LtcAudioOutputService.GetOutputDevices()
		_cmbLtcDevice.Items.Add(Tuple.Create(-1, "Default"))
		For Each d In _ltcDevices
			_cmbLtcDevice.Items.Add(d)
		Next
		_cmbLtcDevice.DisplayMember = "Item2"
		Dim desiredId As Integer = World.vMain.ltcOutputDeviceId
		Dim selectedIndex As Integer = 0
		For i As Integer = 0 To _cmbLtcDevice.Items.Count - 1
			Dim item = TryCast(_cmbLtcDevice.Items(i), Tuple(Of Integer, String))
			If item IsNot Nothing AndAlso item.Item1 = desiredId Then
				selectedIndex = i
				Exit For
			End If
		Next
		_cmbLtcDevice.SelectedIndex = selectedIndex

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

End Class