Imports digitalSlate.World.mainClass
Imports Newtonsoft.Json
Imports System.Threading.Tasks
Imports System.IO

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

		' Flash message on lblTimecode for a duration (ms)
		Private Shared Async Function FlashTimecodeAsync(message As String, durationMs As Integer) As Task
			Try
				Dim prevText As String = String.Empty
				If frmDigitalSlate IsNot Nothing AndAlso frmDigitalSlate.lblTimecode IsNot Nothing Then
					prevText = frmDigitalSlate.lblTimecode.Text
					frmDigitalSlate.lblTimecode.Text = message
					Await Task.Delay(durationMs)
					If frmDigitalSlate IsNot Nothing AndAlso frmDigitalSlate.lblTimecode IsNot Nothing Then
						frmDigitalSlate.lblTimecode.Text = prevText
					End If
				End If
			Catch ex As Exception
				Debug.WriteLine($"FlashTimecodeAsync error: {ex.Message}")
			End Try
		End Function

		' Save current slate using SaveFileDialog (1 file per slate). Disallowed while Timer1 is running.
		Public Shared Async Sub SaveSlateWithDialog()
			Try
				' Prevent save while running
				If frmDigitalSlate.Timer1.Enabled Then
					MessageBox.Show("Cannot save while timecode is running.", "Save disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Return
				End If

				Using sfd As New SaveFileDialog()
					sfd.Filter = "Clapper files (*.clap)|*.clap|All files (*.*)|*.*"
					sfd.DefaultExt = "clap"
					sfd.AddExtension = True
					sfd.Title = "Save slate configuration"

					If sfd.ShowDialog() = DialogResult.OK Then
						Dim mgr As New JsonSettingsManager()
						Dim settings As New SettingsProfile With {
							.Scene = World.vMain.scene,
							.ScenePre = World.vMain.scenePre,
							.SceneNum = World.vMain.sceneNum,
							.Shot = World.vMain.shot,
							.Take = CStr(World.vMain.take),
							.Roll = World.vMain.roll,
							.CameraNum = World.vMain.cameraNum,
							.CamCardNum = CStr(World.vMain.camCardNum),
							.Production = World.vMain.production,
							.Director = World.vMain.director,
							.DOP = World.vMain.dop,
							.FPS = CStr(World.vMain.fps),
							.CustDate = World.vMain.custDate,
							.CurrentDate = World.vMain.currentDate,
							.Int = CStr(World.vMain.int),
							.Day = CStr(World.vMain.day),
							.Sync = CStr(World.vMain.sync)
						}

						Try
							JsonSettingsManager.SaveSlateToFile(settings, sfd.FileName)
						Catch ex As Exception
							MessageBox.Show("Error saving file: " & ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Return
						End Try

						' verify file
						Dim verified As SettingsProfile = Nothing
						If JsonSettingsManager.TryLoadSlateFromFile(sfd.FileName, verified) Then
							' Success: flash message for 3 seconds
							Await FlashTimecodeAsync("FILE SAVED!", 3000)
						Else
							MessageBox.Show("File saved but verification failed. The file may be corrupted.", "Verification failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
						End If
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("Unexpected error saving slate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		' Load a slate file chosen by the user. Disallowed while Timer1 is running.
		Public Shared Async Sub LoadSlateWithDialog()
			Try
				If frmDigitalSlate.Timer1.Enabled Then
					MessageBox.Show("Cannot load while timecode is running.", "Load disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Return
				End If

				Using ofd As New OpenFileDialog()
					ofd.Filter = "Clapper files (*.clap)|*.clap|All files (*.*)|*.*"
					ofd.Title = "Open slate configuration"
					If ofd.ShowDialog() = DialogResult.OK Then
						Dim settings As SettingsProfile = Nothing
						If Not JsonSettingsManager.TryLoadSlateFromFile(ofd.FileName, settings) Then
							MessageBox.Show("Selected file is not a valid slate configuration.", "Invalid file", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Return
						End If

						' Apply to active slate (World.vMain) using TryParse where appropriate
						Try
							World.vMain.scene = settings.Scene
							World.vMain.scenePre = settings.ScenePre
							World.vMain.sceneNum = settings.SceneNum
							World.vMain.shot = settings.Shot

							Dim tmpInt As Integer
							If Integer.TryParse(settings.Take, tmpInt) Then World.vMain.take = tmpInt
							World.vMain.roll = settings.Roll
							World.vMain.cameraNum = settings.CameraNum
							If Integer.TryParse(settings.CamCardNum, tmpInt) Then World.vMain.camCardNum = tmpInt
							World.vMain.production = settings.Production
							World.vMain.director = settings.Director
							World.vMain.dop = settings.DOP
							Dim tmpDouble As Double
							If Double.TryParse(settings.FPS, tmpDouble) Then World.vMain.fps = tmpDouble
							World.vMain.custDate = settings.CustDate
							World.vMain.currentDate = settings.CurrentDate
							If Integer.TryParse(settings.Int, tmpInt) Then World.vMain.int = tmpInt
							If Integer.TryParse(settings.Day, tmpInt) Then World.vMain.day = tmpInt
							If Integer.TryParse(settings.Sync, tmpInt) Then World.vMain.sync = tmpInt

							' Update UI
							refreshSlate()

							' flash file loaded
							Await FlashTimecodeAsync("FILE LOADED", 3000)
						Catch ex As Exception
							MessageBox.Show("Error applying loaded slate: " & ex.Message, "Apply error", MessageBoxButtons.OK, MessageBoxIcon.Error)
						End Try
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("Unexpected error loading slate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
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
			If label Is Nothing Then Return
			Dim text As String = label.Text
			If String.IsNullOrEmpty(text) Then Return

			' Use a small vertical padding to avoid ascender/descender clipping
			Dim verticalPadding As Integer = CInt(Math.Max(2, label.Height * 0.06)) ' ~6% of height or min 2px

			Dim maxFontSize As Single = Math.Min(65.0F, label.Font.Size) ' don't jump larger than current font
			Dim minFontSize As Single = 8.0F
			Dim flags As System.Windows.Forms.TextFormatFlags = System.Windows.Forms.TextFormatFlags.SingleLine Or System.Windows.Forms.TextFormatFlags.NoPadding Or System.Windows.Forms.TextFormatFlags.NoPrefix

			' Try decreasing font sizes until text fits both width and height (respect padding)
			Using g As Graphics = label.CreateGraphics()
				For fontSize As Single = maxFontSize To minFontSize Step -0.5F
					Using testFont As New Font(label.Font.FontFamily, fontSize, label.Font.Style)
						' Measure using TextRenderer to account for WinForms rendering
						Dim measured As Size = TextRenderer.MeasureText(text, testFont, New Size(label.Width, Integer.MaxValue), flags)

						If measured.Width <= label.ClientSize.Width AndAlso measured.Height <= (label.ClientSize.Height - verticalPadding) Then
							' Found a size that fits; apply and exit
							label.Font = New Font(label.Font.FontFamily, fontSize, label.Font.Style)
							Return
						End If
					End Using
				Next

				' If nothing fits, apply the minimum readable size
				label.Font = New Font(label.Font.FontFamily, minFontSize, label.Font.Style)
			End Using
		End Sub

	End Class


End Namespace