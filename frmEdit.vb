Imports System.IO
Imports System.Media

Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass

Public Class frmEdit
	Dim myMainClass As New World.mainClass()
	Dim mySlate As New frmDigitalSlate()

	Private tmpScPreDis As String
	Private tmpScPre As String
	Private tmpCustDate As Integer
	Private tmpIsDay As Integer
	Private tmpIsInt As Integer
	Private tmpIsSync As Integer

	Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'Initialize the TextBox state based on the CheckBox state
		UpdateTextBoxState()
	End Sub

	Private Sub cbTodaysDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbTodaysDate.CheckedChanged
		'Update the TextBox state when the CheckBox state changes
		UpdateTextBoxState()
	End Sub

	Private Sub UpdateTextBoxState()
		' Enable or disable the TextBox based on the CheckBox state
		txtCustDate.Enabled = Not cbTodaysDate.Checked
	End Sub

	Private Sub updateDisplay(source As String)
		Select Case source
			Case "s"
				If txtSceneNum.Text.Length = 1 Then
					If txtSceneNum.Text <> "0" Then
						txtSceneNum.Text = "0" & txtSceneNum.Text
					Else
						SystemSounds.Asterisk.Play()
						txtSceneNum.Focus()
						Return
					End If
				End If

				If cbScR.Checked Or cbScV.Checked Or cbScX.Checked Then
					tmpScPreDis = "" ' Reset the prefix display variable

					If cbScR.Checked Then
						tmpScPreDis &= "R"
					End If
					If cbScV.Checked Then
						tmpScPreDis &= "V"
					End If
					If cbScX.Checked Then
						tmpScPreDis &= "X"
					End If

					txtScene.Text = tmpScPreDis & txtSceneNum.Text & txtShot.Text
				Else
					txtScene.Text = txtSceneNum.Text & txtShot.Text
				End If

			Case "r"
				If txtCardNum.Text.Length < 3 Then
					If txtCardNum.Text <> "0" And txtCardNum.Text <> "00" Then
						If txtCardNum.Text.Length = 2 Then
							txtCardNum.Text = "0" & txtCardNum.Text
						ElseIf txtCardNum.Text.Length = 1 Then
							txtCardNum.Text = "00" & txtCardNum.Text
						End If
					Else
						SystemSounds.Asterisk.Play()
						txtCardNum.Focus()
						Return
					End If
				End If

				txtRoll.Text = txtCameraNum.Text & txtCardNum.Text
		End Select
	End Sub


	Public Sub CheckSettings()
		' Trim the text of all relevant text boxes
		txtSceneNum.Text = txtSceneNum.Text.Trim()
		txtShot.Text = txtShot.Text.Trim()
		txtTake.Text = txtTake.Text.Trim()
		txtCameraNum.Text = txtCameraNum.Text.Trim()
		txtCardNum.Text = txtCardNum.Text.Trim()
		txtFPS.Text = txtFPS.Text.Trim()
		txtCustDate.Text = txtCustDate.Text.Trim()

		' Set tmpScPre based on checked checkboxes
		tmpScPre = ""
		If cbScR.Checked Then tmpScPre += "R"
		If cbScV.Checked Then tmpScPre += "V"
		If cbScX.Checked Then tmpScPre += "X"

		' Set default values if text boxes are empty or contain "0"
		If String.IsNullOrEmpty(txtSceneNum.Text) Or txtSceneNum.Text = "0" Then txtSceneNum.Text = World.vDefaults.sceneNum.ToString()
		If String.IsNullOrEmpty(txtShot.Text) Then txtShot.Text = World.vDefaults.shot
		If String.IsNullOrEmpty(txtCameraNum.Text) Then txtCameraNum.Text = World.vDefaults.cameraNum
		If String.IsNullOrEmpty(txtCardNum.Text) Or txtCardNum.Text = "0" Then txtCardNum.Text = World.vDefaults.camCardNum.ToString()
		If String.IsNullOrEmpty(txtTake.Text) Or txtTake.Text = "0" Then txtTake.Text = "1"
		If String.IsNullOrEmpty(txtProduction.Text) Then txtProduction.Text = World.vDefaults.production
		If String.IsNullOrEmpty(txtDirector.Text) Then txtDirector.Text = World.vDefaults.director
		If String.IsNullOrEmpty(txtFPS.Text) Or txtFPS.Text = "0" Then txtFPS.Text = World.vDefaults.fps.ToString()

		' Handle custom date logic
		If Not cbTodaysDate.Checked Then
			If String.IsNullOrEmpty(txtCustDate.Text) Or txtCustDate.Text = "0" Then
				txtCustDate.Text = ""
				cbTodaysDate.Checked = True
				tmpCustDate = 0
			Else
				tmpCustDate = 1
			End If
		End If

		' Set temporary values based on radio buttons
		tmpIsDay = If(rbDay.Checked, 1, 0)
		tmpIsInt = If(rbInt.Checked, 1, 0)
		tmpIsSync = If(rbSync.Checked, 1, 0)
	End Sub


	Public Sub getSettings()
		myMainClass.scene = txtScene.Text
		myMainClass.sceneNum = CInt(txtSceneNum.Text)
		myMainClass.shot = txtShot.Text
		myMainClass.roll = txtRoll.Text
		myMainClass.cameraNum = txtCameraNum.Text
		myMainClass.camCardNum = CInt(txtCardNum.Text)
		myMainClass.take = CInt(txtTake.Text)
		myMainClass.production = txtProduction.Text
		myMainClass.director = txtDirector.Text
		myMainClass.dop = txtDOP.Text
		myMainClass.fps = Convert.ToDouble(txtFPS.Text)
		If tmpCustDate = 1 Then myMainClass.custDate = txtCustDate.Text
		myMainClass.scenePre = tmpScPre
		myMainClass.day = tmpIsDay
		myMainClass.int = tmpIsInt
		myMainClass.sync = tmpIsSync
	End Sub

	Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
		'Dim mySlate As New frmDigitalSlate()
		checkSettings()
		getSettings()
		saveToSettings()
		My.Settings.Save()
		refreshSlate()
		Hide()
		frmDigitalSlate.Select()
	End Sub

	Private Sub frmEdit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		'Get Data from App Settings
		loadFromSettings()
		loadToForm(Me)
	End Sub

	Private Sub txtSceneNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSceneNum.KeyPress
		' Allow only digits and control keys
		If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub txtShot_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShot.KeyPress
		' Allow only letters and control keys
		If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub txtCameraNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCameraNum.KeyPress
		' Allow only letters and control keys
		If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub txtCardNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCardNum.KeyPress
		' Allow only digits and control keys
		If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub txtFPS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFPS.KeyPress
		' Allow only digits and control keys
		If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub txtTake_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTake.KeyPress
		' Allow only digits and control keys
		If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub txtSceneNum_LostFocus(sender As Object, e As EventArgs) Handles txtSceneNum.LostFocus
		If txtSceneNum.Text = "" Then
			SystemSounds.Asterisk.Play()
			txtSceneNum.Focus()
		Else
			updateDisplay("s")
		End If
	End Sub

	Private Sub txtShot_LostFocus(sender As Object, e As EventArgs) Handles txtShot.LostFocus
		If txtShot.Text = "" Then
			SystemSounds.Asterisk.Play()
			txtShot.Focus()
		Else
			txtShot.Text = txtShot.Text.ToUpper()
			updateDisplay("s")
		End If
	End Sub

	Private Sub txtCameraNum_LostFocus(sender As Object, e As EventArgs) Handles txtCameraNum.LostFocus
		If txtCameraNum.Text = "" Then
			SystemSounds.Asterisk.Play()
			txtCameraNum.Focus()
		Else
			txtCameraNum.Text = txtCameraNum.Text.ToUpper()
			updateDisplay("r")
		End If
	End Sub

	Private Sub txtCardNum_LostFocus(sender As Object, e As EventArgs) Handles txtCardNum.LostFocus
		If txtCardNum.Text = "" Then
			SystemSounds.Asterisk.Play()
			txtCardNum.Focus()
		Else
			updateDisplay("r")
		End If
	End Sub

	Private Sub cbScV_CheckedChanged(sender As Object, e As EventArgs) Handles cbScV.CheckedChanged
		updateDisplay("s")
	End Sub

	Private Sub cbScR_CheckedChanged(sender As Object, e As EventArgs) Handles cbScR.CheckedChanged
		updateDisplay("s")
	End Sub

	Private Sub cbScX_CheckedChanged(sender As Object, e As EventArgs) Handles cbScX.CheckedChanged
		updateDisplay("s")
	End Sub


	'Private Sub UpdateDisplay(source As String)
	'If source = "s" Then
	'	If txtSceneNum.Text.Length = 1 Then
	'		If txtSceneNum.Text <> "0" Then
	'			Dim paddedScNum As String = "0" + txtSceneNum.Text
	'			txtSceneNum.Text = paddedScNum
	'		ElseIf txtSceneNum.Text = "0" Then
	'			SystemSounds.Asterisk.Play()
	'			txtSceneNum.Focus()
	'			Return
	'		End If
	'	End If

	'	If cbScR.Checked = True Or cbScV.Checked = True Or cbScX.Checked = True Then
	'		If cbScR.Checked = True Then
	'			If tmpScPreDis = "R" Or tmpScPreDis = "" Then
	'				tmpScPreDis = "R"
	'			Else
	'				tmpScPreDis += "R"
	'			End If
	'		ElseIf cbScV.Checked = True Then
	'			If tmpScPreDis = "V" Or tmpScPreDis = "" Then
	'				tmpScPreDis = "V"
	'			Else
	'				tmpScPreDis += "V"
	'			End If
	'		ElseIf cbScX.Checked = True Then
	'			If tmpScPreDis = "X" Or tmpScPreDis = "" Then
	'				tmpScPreDis = "X"
	'			Else
	'				tmpScPreDis += "X"
	'			End If
	'		End If

	'		txtScene.Text = String.Concat(tmpScPreDis, txtSceneNum.Text, txtShot.Text)
	'		tmpScPreDis = ""
	'	Else
	'		txtScene.Text = String.Concat(txtSceneNum.Text, txtShot.Text)
	'	End If

	'ElseIf source = "r" Then
	'	If txtCardNum.Text.Length < 3 Then
	'		If txtCardNum.Text <> "0" Or txtCardNum.Text <> "00" Then
	'			If txtCardNum.Text.Length = 2 Then
	'				Dim paddedCardNum As String = "0" + txtCardNum.Text
	'				txtCardNum.Text = paddedCardNum
	'			ElseIf txtCardNum.Text.Length = 1 Then
	'				Dim paddedCardNum As String = "00" + txtCardNum.Text
	'				txtCardNum.Text = paddedCardNum
	'			End If
	'		ElseIf txtSceneNum.Text = "0" Then
	'			SystemSounds.Asterisk.Play()
	'			txtSceneNum.Focus()
	'			Return
	'		End If
	'	End If

	'	txtRoll.Text = String.Concat(txtCameraNum.Text, txtCardNum.Text)
	'End If
	'end sub


	'///////////////////////////


	'Public Sub checkSettings()
	'	txtSceneNum.Text.Trim()
	'	txtShot.Text.Trim()
	'	txtTake.Text.Trim()
	'	txtCameraNum.Text.Trim()
	'	txtCardNum.Text.Trim()
	'	txtFPS.Text.Trim()
	'	txtCustDate.Text.Trim()

	'	If cbScR.Checked = True Then
	'		tmpScPre += "R"
	'	ElseIf cbScV.Checked = True Then
	'		tmpScPre += "V"
	'	ElseIf cbScX.Checked = True Then
	'		tmpScPre += "X"
	'	End If
	'	If txtSceneNum.Text = "0" Or txtSceneNum.Text = "" Then txtSceneNum.Text = World.vDefaults.sceneNum.ToString()
	'	If txtShot.Text = "" Then txtShot.Text = World.vDefaults.shot
	'	If txtCameraNum.Text = "" Then txtCameraNum.Text = World.vDefaults.cameraNum
	'	If txtCardNum.Text = "0" Or txtCardNum.Text = "" Then txtCardNum.Text = World.vDefaults.camCardNum.ToString()
	'	If txtTake.Text = "0" Or txtTake.Text = "" Then txtTake.Text = "1"
	'	If txtProduction.Text = "" Then txtProduction.Text = World.vDefaults.production
	'	If txtDirector.Text = "" Then txtDirector.Text = World.vDefaults.director
	'	If txtFPS.Text = "0" Or txtFPS.Text = "" Then txtFPS.Text = World.vDefaults.fps.ToString()
	'	If cbTodaysDate.Checked = False Then
	'		If txtCustDate.Text = "0" Or txtCustDate.Text = "" Then
	'			txtCustDate.Text = ""
	'			cbTodaysDate.Checked = True
	'			tmpCustDate = 0
	'		Else
	'			tmpCustDate = 1
	'		End If
	'	End If

	'	'If(condition, trueValue, falseValue)
	'	tmpIsDay = If(rbDay.Checked, 1, 0)
	'	tmpIsInt = If(rbInt.Checked, 1, 0)
	'	tmpIsSync = If(rbSync.Checked, 1, 0)

	'End Sub


End Class


'LABEL			TXTBOX			VAR			CFG
'----------------------------------------------------
'lblScene		txtScene			scene			cfgScene
'   X				txtScenePre		scenePre		cfgScPre
'   X				txtSceneNum		sceneNum		cfgScNum
'   X				txtShot			shot			cfgShot
'lblTake			txtTake			take			cfgTake
'lblRoll			txtRoll			roll			cfgRoll
'   X				txtCameraNum	cameraNum	cfgCamNum
'   X				txtCardNum		camCardNum	cfgCardNum

'lblProduction	txtProduction	production	cfgProduction
'lblDirector	txtDirector		director		cfgDirector
'lblDOP			txtDOP			dop			cfgDOP
'lblFPS			txtFPS			fps			cfgFPS
'lblDate			txtCustDate		custDate		cfgDate
'	-->			cbTodaysDate	currentDate	cfgCurrDate

'lblHideInt		rbInt				int(0)		cfgInt
'lblHideExt		rbExt				int(1)		
'lblHideDay		rbDay				day(0)		cfgDay
'lblHideNite	rbNite			day(1)		
'lblHideSYnc	rbSync			sync(0)		cfgSync
'lblHideMos		rbMos				sync(1)		