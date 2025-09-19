
Imports System.Windows.Forms

Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults

Public Class frmSettings
	Dim myMainClass As New World.mainClass()
	Dim mySlate As New frmDigitalSlate()

	Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
		Dim checkedRadioButton1 As RadioButton = GetCheckedRadioButton(gbCountdown)
		Dim checkedRadioButton2 As RadioButton = GetCheckedRadioButton(gbSyncBeeps)
		Dim checkedRadioButton3 As RadioButton = GetCheckedRadioButton(gbCaps)

		If checkedRadioButton1 IsNot Nothing And checkedRadioButton2 IsNot Nothing And checkedRadioButton3 IsNot Nothing Then
			myMainClass.beepCount = CInt(checkedRadioButton1.Text)
			myMainClass.countdownCount = CInt(checkedRadioButton2.Text)
			If checkedRadioButton3.Text = "No" Then
				myMainClass.displayCaps = 0
			ElseIf checkedRadioButton3.Text = "Yes" Then
				myMainClass.displayCaps = 1
			Else
				myMainClass.displayCaps = 0
			End If

			My.Settings.cfgBeepCount = myMainClass.beepCount
			My.Settings.cfgCountdownCount = myMainClass.countdownCount
			My.Settings.cfgDisplayCaps = myMainClass.displayCaps
		Else
			MessageBox.Show("No Radio Button is checked. Using old settings.")
		End If

		My.Settings.Save()
		refreshSlate()
		Hide()
		frmDigitalSlate.Select()
	End Sub

	Private Sub frmSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		' Read settings
		myMainClass.beepCount = My.Settings.cfgBeepCount
		myMainClass.countdownCount = My.Settings.cfgCountdownCount
		myMainClass.displayCaps = My.Settings.cfgDisplayCaps

		' Dictionary to map beepCount values to radio buttons
		Dim beepCountToRadioButton As New Dictionary(Of Integer, RadioButton) From {
		 {0, rb0CD},
		 {1, rb1CD},
		 {2, rb2CD},
		 {3, rb3CD},
		 {4, rb4CD}
	}

		' Dictionary to map countdownCount values to radio buttons
		Dim countdownCountToRadioButton As New Dictionary(Of Integer, RadioButton) From {
		 {0, rb0SB},
		 {1, rb1SB},
		 {2, rb2SB}
	}

		' Set the appropriate radio button for beepCount
		If beepCountToRadioButton.ContainsKey(myMainClass.beepCount) Then
			beepCountToRadioButton(myMainClass.beepCount).Checked = True
		Else
			rb3CD.Checked = True ' Default radio button if beepCount is not in the dictionary
		End If

		' Set the appropriate radio button for countdownCount
		If countdownCountToRadioButton.ContainsKey(myMainClass.countdownCount) Then
			countdownCountToRadioButton(myMainClass.countdownCount).Checked = True
		Else
			rb1SB.Checked = True ' Default radio button if countdownCount is not in the dictionary
		End If

		If myMainClass.displayCaps = 0 Then
			rbNoCaps.Checked = True
		ElseIf myMainClass.displayCaps = 1 Then
			rbYesCaps.Checked = True
		Else
			rbNoCaps.Checked = True
		End If

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