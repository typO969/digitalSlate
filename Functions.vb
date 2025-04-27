Imports digitalSlate.World.mainClass

Imports Newtonsoft.Json

Namespace World

	Public Class Functions

		Public Shared Sub loadFromSettings()
			Try
				World.vMain.scene = My.Settings.cfgScene
				World.vMain.scenePre = My.Settings.cfgScenePre
				World.vMain.sceneNum = My.Settings.cfgSceneNum
				World.vMain.shot = My.Settings.cfgShot
				World.vMain.take = My.Settings.cfgTake
				World.vMain.roll = My.Settings.cfgRoll
				World.vMain.cameraNum = My.Settings.cfgCameraNum
				World.vMain.camCardNum = My.Settings.cfgCamCardNum
				World.vMain.production = My.Settings.cfgProduction
				World.vMain.director = My.Settings.cfgDirector
				World.vMain.dop = My.Settings.cfgDOP
				World.vMain.fps = My.Settings.cfgFPS
				World.vMain.custDate = My.Settings.cfgCustDate
				World.vMain.currentDate = My.Settings.cfgCurrentDate
				World.vMain.int = My.Settings.cfgInt
				World.vMain.day = My.Settings.cfgDay
				World.vMain.sync = My.Settings.cfgSync
				World.vMain.beepCount = My.Settings.cfgBeepCount
				World.vMain.countdownCount = My.Settings.cfgCountdownCount
				World.vMain.displayCaps = My.Settings.cfgDisplayCaps
			Catch ex As Exception
				' Handle the error (e.g., log it, show a message to the user)
				MessageBox.Show("Error loading settings: " & ex.Message)
			End Try
		End Sub

		Public Shared Sub SaveToSettings()
			Try
				My.Settings.cfgScene = World.vMain.scene
				My.Settings.cfgScenePre = World.vMain.scenePre
				My.Settings.cfgSceneNum = World.vMain.sceneNum
				My.Settings.cfgShot = World.vMain.shot
				My.Settings.cfgTake = World.vMain.take
				My.Settings.cfgRoll = World.vMain.roll
				My.Settings.cfgCameraNum = World.vMain.cameraNum
				My.Settings.cfgCamCardNum = World.vMain.camCardNum
				My.Settings.cfgProduction = World.vMain.production
				My.Settings.cfgDirector = World.vMain.director
				My.Settings.cfgDOP = World.vMain.dop
				My.Settings.cfgFPS = World.vMain.fps
				My.Settings.cfgCustDate = World.vMain.custDate
				My.Settings.cfgCurrentDate = World.vMain.currentDate
				My.Settings.cfgInt = World.vMain.int
				My.Settings.cfgDay = World.vMain.day
				My.Settings.cfgSync = World.vMain.sync
				My.Settings.cfgBeepCount = World.vMain.beepCount
				My.Settings.cfgCountdownCount = World.vMain.countdownCount
				My.Settings.cfgDisplayCaps = World.vMain.displayCaps
				My.Settings.Save()
			Catch ex As Exception
				' Handle the error (e.g., log it, show a message to the user)
				MessageBox.Show("Error saving settings: " & ex.Message)
			End Try
		End Sub


		Public Shared Sub loadToForm(source As Form)
			Dim myParse As New Functions()

			If source.Name.ToString() = "frmDigitalSlate" Then
				refreshSlate()

			ElseIf source.name.ToString() = "frmEdit" Then
				With frmEdit
					'Send to Editor outputs
					.txtScene.Text = World.vMain.scene
					.txtSceneNum.Text = CStr(World.vMain.sceneNum)
					.txtShot.Text = World.vMain.shot
					.txtTake.Text = CStr(World.vMain.take)
					.txtRoll.Text = World.vMain.roll
					.txtCameraNum.Text = World.vMain.cameraNum
					.txtCardNum.Text = CStr(World.vMain.camCardNum)
					.txtProduction.Text = World.vMain.production
					.txtDirector.Text = World.vMain.director
					.txtDOP.Text = World.vMain.dop
					.txtFPS.Text = CStr(World.vMain.fps)

					myParse.parseScene()

					If Not String.IsNullOrEmpty(World.vMain.currentDate) And String.IsNullOrEmpty(World.vMain.custDate) Then
						.cbTodaysDate.Checked = True
						.txtCustDate.Text = ""
					ElseIf Not String.IsNullOrEmpty(World.vMain.custDate) Then
						.cbTodaysDate.Checked = False
						.txtCustDate.Text = World.vMain.custDate
					End If

					If World.vMain.int = 1 Then .rbInt.Checked = True
					If World.vMain.int = 0 Then .rbExt.Checked = True
					If World.vMain.day = 1 Then .rbDay.Checked = True
					If World.vMain.day = 0 Then .rbNite.Checked = True
					If World.vMain.sync = 1 Then .rbSync.Checked = True
					If World.vMain.sync = 0 Then .rbMOS.Checked = True
				End With
			End If

		End Sub

		Public Shared Sub resetSlate()
			With frmDigitalSlate
				'Erase
				.lblDate.Text = ""
				.lblScene.Text = ""
				.lblTake.Text = ""
				.lblRoll.Text = ""
				.lblProduction.Text = ""
				.lblDirector.Text = ""
				.lblDOP.Text = ""
				.lblFPS.Text = ""
				.lblHideInt.Visible = False
				.lblHideExt.Visible = False
				.lblHideDay.Visible = False
				.lblHideNite.Visible = False
				.lblHideSync.Visible = False
				.lblHideMos.Visible = False

				.lblDate.Text = World.vMain.currentDate
				.lblScene.Text = World.vDefaults.scene
				.lblTake.Text = World.vDefaults.take.ToString()
				.lblRoll.Text = World.vDefaults.roll.ToString()
				.lblProduction.Text = World.vDefaults.production
				.lblDirector.Text = World.vDefaults.director
				.lblDOP.Text = World.vDefaults.dop
				.lblFPS.Text = World.vDefaults.fps.ToString()
				.lblTimecode.Text = World.vDefaults.zeroTC

				AdjustFontSizeToFitText(.lblScene)
				AdjustFontSizeToFitText(.lblTake)
				AdjustFontSizeToFitText(.lblRoll)
				AdjustFontSizeToFitText(.lblProduction)
				AdjustFontSizeToFitText(.lblDirector)
				AdjustFontSizeToFitText(.lblDOP)

				If World.vDefaults.int = 0 Then .lblHideInt.Visible = True
				If World.vDefaults.int = 1 Then .lblHideExt.Visible = True
				If World.vDefaults.day = 0 Then .lblHideDay.Visible = True
				If World.vDefaults.day = 1 Then .lblHideNite.Visible = True
				If World.vDefaults.sync = 0 Then .lblHideSync.Visible = True
				If World.vDefaults.sync = 1 Then .lblHideMos.Visible = True

				.tsiZeroTC.Enabled = True

				If .WindowState = FormWindowState.Normal Then
					.WindowState = FormWindowState.Maximized
				End If
			End With
		End Sub

		Public Shared Sub refreshSlate()
			With frmDigitalSlate
				.lblProduction.Text = World.vMain.production
				.lblDirector.Text = World.vMain.director
				.lblDOP.Text = World.vMain.dop
				.lblFPS.Text = CStr(World.vMain.fps)
				.lblTake.Text = World.vMain.take.ToString()
				.lblHideInt.Visible = False
				.lblHideExt.Visible = False
				.lblHideDay.Visible = False
				.lblHideNite.Visible = False
				.lblHideSync.Visible = False
				.lblHideMos.Visible = False

				If World.vMain.custDate = "" Then
					.lblDate.Text = World.vMain.currentDate
				Else
					.lblDate.Text = World.vMain.custDate
				End If

				updateScene()
				updateRoll()

				.lblRoll.Text = World.vMain.roll
				.lblScene.Text = World.vMain.scene

				If World.vMain.int = 0 Then .lblHideInt.Visible = True
				If World.vMain.int = 1 Then .lblHideExt.Visible = True
				If World.vMain.day = 0 Then .lblHideDay.Visible = True
				If World.vMain.day = 1 Then .lblHideNite.Visible = True
				If World.vMain.sync = 0 Then .lblHideSync.Visible = True
				If World.vMain.sync = 1 Then .lblHideMos.Visible = True

				AdjustFontSizeToFitText(.lblScene)
				AdjustFontSizeToFitText(.lblTake)
				AdjustFontSizeToFitText(.lblRoll)
				AdjustFontSizeToFitText(.lblProduction)
				AdjustFontSizeToFitText(.lblDirector)
				AdjustFontSizeToFitText(.lblDOP)
			End With
		End Sub

		Public Shared Sub updateScene()
			Dim paddedScNum As String = World.vMain.sceneNum.ToString("D2")
			World.vMain.scene = String.Concat(World.vMain.scenePre, paddedScNum, World.vMain.shot)
		End Sub

		Public Shared Sub updateRoll()
			Dim paddedCard As String = World.vMain.camCardNum.ToString("D3")
			World.vMain.roll = String.Concat(World.vMain.cameraNum, paddedCard)
		End Sub

		Public Sub parseScene()
			With frmEdit
				' Reset all checkboxes initially
				.cbScV.Checked = False
				.cbScR.Checked = False
				.cbScX.Checked = False

				If Not String.IsNullOrEmpty(World.vMain.scenePre) Then
					Dim editScPre As String = World.vMain.scenePre
					Dim result As Integer = containsChars(editScPre)

					Select Case editScPre.Length
						Case 3
							If result = 6 Then
								.cbScV.Checked = True
								.cbScR.Checked = True
								.cbScX.Checked = True
							End If
						Case 2
							Select Case result
								Case 3
									.cbScV.Checked = True
									.cbScR.Checked = True
								Case 4
									.cbScV.Checked = True
									.cbScX.Checked = True
								Case 5
									.cbScR.Checked = True
									.cbScX.Checked = True
							End Select
						Case 1
							Select Case editScPre
								Case "V"
									.cbScV.Checked = True
								Case "R"
									.cbScR.Checked = True
								Case "X"
									.cbScX.Checked = True
							End Select
					End Select
				End If
			End With
		End Sub


		Public Function containsChars(input As String) As Integer
			Dim letterValues As New Dictionary(Of Char, Integer) From {
					{"V"c, 1},
					{"R"c, 2},
					{"X"c, 3}
			  }
			Dim sum As Integer = 0
			For Each letter As Char In letterValues.Keys
				If input.Contains(letter) Then
					sum += letterValues(letter)
				End If
			Next

			Return sum
		End Function

		Public Shared Sub AdjustFontSizeToFitText(label As Label)
			Dim maxFontSize As Single = 60.0F ' Maximum font size
			Dim minFontSize As Single = 20.0F ' Minimum font size
			Dim text As String = label.Text

			' Measure the size of the string
			Dim size As SizeF
			Using g As Graphics = label.CreateGraphics()
				Dim font As Font = label.Font
				size = g.MeasureString(text, font)
			End Using

			' Adjust font size until the text fits within the label's width
			Dim fontSize As Single = maxFontSize
			Using g As Graphics = label.CreateGraphics()
				While fontSize > minFontSize
					Dim font As New Font(label.Font.FontFamily, fontSize, label.Font.Style)
					size = g.MeasureString(text, font)
					If size.Width <= label.Width Then
						label.Font = font
						Exit While
					End If
					fontSize -= 0.5F
				End While
			End Using
		End Sub


		'Public Sub parseScene()
		'	With frmEdit
		'		If Not String.IsNullOrEmpty(World.vMain.scenePre) Then  'Variables not empty & not Nothing
		'			Dim editScPre As String = World.vMain.scenePre

		'			If editScPre.Length > 1 And editScPre.Length < 4 Then    '3 chars
		'				Dim result3 As Integer = containsChars(editScPre)
		'				If result3 = 6 Then
		'					.cbScV.Checked = True
		'					.cbScR.Checked = True
		'					.cbScX.Checked = True
		'				Else
		'					.cbScV.Checked = False
		'					.cbScR.Checked = False
		'					.cbScX.Checked = False
		'				End If

		'			ElseIf editScPre.Length > 1 And editScPre.Length < 3 Then   '2 chars
		'				Dim result2 As Integer = containsChars(editScPre)
		'				Select Case result2
		'					Case 3            'MessageBox.Show("Detected Letters: V and R")
		'						.cbScV.Checked = True
		'						.cbScR.Checked = True
		'					Case 4            'MessageBox.Show("Detected Letters: V and X")
		'						.cbScV.Checked = True
		'						.cbScX.Checked = True
		'					Case 5            'MessageBox.Show("Detected Letters: R and X")
		'						.cbScR.Checked = True
		'						.cbScX.Checked = True
		'					Case Else         'MessageBox.Show("The string does not contain the required combination of letters.")
		'						.cbScV.Checked = False
		'						.cbScR.Checked = False
		'						.cbScX.Checked = False
		'				End Select

		'			ElseIf editScPre.Length = 1 Then                         '1 char
		'				Select Case editScPre
		'					Case "V"
		'						.cbScV.Checked = True
		'					Case "R"
		'						.cbScR.Checked = True
		'					Case "X"
		'						.cbScX.Checked = True
		'					Case Else
		'						.cbScV.Checked = False
		'						.cbScR.Checked = False
		'						.cbScX.Checked = False
		'				End Select
		'			Else
		'				'if we end up here, who knows wtf is going on!
		'			End If
		'		Else
		'			.cbScV.Checked = False
		'			.cbScR.Checked = False
		'			.cbScX.Checked = False
		'		End If
		'	End With
		'End Sub

	End Class


End Namespace