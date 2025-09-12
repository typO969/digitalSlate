Imports Newtonsoft.Json
Imports digitalSlate.World.Functions
Imports System.IO
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class SettingsProfile
	Public Property Scene As String
	Public Property ScenePre As String
	Public Property SceneNum As Integer
	Public Property Shot As String
	Public Property Take As String
	Public Property Roll As String
	Public Property CameraNum As String
	Public Property CamCardNum As String
	Public Property Production As String
	Public Property Director As String
	Public Property DOP As String
	Public Property FPS As String
	Public Property CustDate As String
	Public Property CurrentDate As String
	Public Property Int As String
	Public Property Day As String
	Public Property Sync As String

End Class

Public Class JsonSettingsManager

	Public Function SerializeSettings(settings As SettingsProfile) As String
		Return JsonConvert.SerializeObject(settings)
	End Function

	Public Function DeserializeSettings(json As String) As SettingsProfile
		Return JsonConvert.DeserializeObject(Of SettingsProfile)(json)
	End Function

	Public Sub SaveAllProfilesToFile(profiles As SettingsProfileWrapper, filePath As String)
		Dim json As String = JsonConvert.SerializeObject(profiles)
		File.WriteAllText(filePath, json)
	End Sub

	Public Function LoadAllProfilesFromFile(filePath As String) As SettingsProfileWrapper
		If File.Exists(filePath) Then
			Dim json As String = File.ReadAllText(filePath)
			Return JsonConvert.DeserializeObject(Of SettingsProfileWrapper)(json)
		Else
			Return New SettingsProfileWrapper() With {.Profiles = New Dictionary(Of Integer, SettingsProfile)}
		End If
	End Function

	Public Sub SaveProfile(profileNumber As Integer)
		Dim profilesWrapper As SettingsProfileWrapper = Me.LoadAllProfilesFromFile("allProfiles.json")

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

		profilesWrapper.Profiles(profileNumber) = settings
		Me.SaveAllProfilesToFile(profilesWrapper, "allProfiles.json")
	End Sub

	Public Sub LoadProfile(profileNumber As Integer)
		Dim profilesWrapper As SettingsProfileWrapper = Me.LoadAllProfilesFromFile("allProfiles.json")
		If profilesWrapper.Profiles.ContainsKey(profileNumber) Then
			Dim settings As SettingsProfile = profilesWrapper.Profiles(profileNumber)

			World.vMain.scene = settings.Scene
			World.vMain.scenePre = settings.ScenePre
			World.vMain.sceneNum = settings.SceneNum
			World.vMain.shot = settings.Shot

			' Use TryParse to avoid exceptions on malformed or missing numeric strings
			Dim tmpInt As Integer
			If Integer.TryParse(settings.Take, tmpInt) Then
				World.vMain.take = tmpInt
			Else
				Debug.WriteLine($"LoadProfile: unable to parse Take='{settings.Take}' - leaving World.vMain.take unchanged.")
			End If

			World.vMain.roll = settings.Roll
			World.vMain.cameraNum = settings.CameraNum

			If Integer.TryParse(settings.CamCardNum, tmpInt) Then
				World.vMain.camCardNum = tmpInt
			Else
				Debug.WriteLine($"LoadProfile: unable to parse CamCardNum='{settings.CamCardNum}' - leaving World.vMain.camCardNum unchanged.")
			End If

			World.vMain.production = settings.Production
			World.vMain.director = settings.Director
			World.vMain.dop = settings.DOP

			Dim tmpDouble As Double
			If Double.TryParse(settings.FPS, tmpDouble) Then
				World.vMain.fps = tmpDouble
			Else
				Debug.WriteLine($"LoadProfile: unable to parse FPS='{settings.FPS}' - leaving World.vMain.fps unchanged.")
			End If

			World.vMain.custDate = settings.CustDate
			World.vMain.currentDate = settings.CurrentDate

			If Integer.TryParse(settings.Int, tmpInt) Then
				World.vMain.int = tmpInt
			Else
				Debug.WriteLine($"LoadProfile: unable to parse Int='{settings.Int}' - leaving World.vMain.int unchanged.")
			End If

			If Integer.TryParse(settings.Day, tmpInt) Then
				World.vMain.day = tmpInt
			Else
				Debug.WriteLine($"LoadProfile: unable to parse Day='{settings.Day}' - leaving World.vMain.day unchanged.")
			End If

			If Integer.TryParse(settings.Sync, tmpInt) Then
				World.vMain.sync = tmpInt
			Else
				Debug.WriteLine($"LoadProfile: unable to parse Sync='{settings.Sync}' - leaving World.vMain.sync unchanged.")
			End If
		Else
			' Fallback: inform the user and leave current settings unchanged
			MessageBox.Show($"Profile {profileNumber} not found. No changes were made.", "Profile not found", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Debug.WriteLine($"LoadProfile: requested profile {profileNumber} not found in allProfiles.json.")
		End If
	End Sub

	' Save a single slate configuration to an arbitrary file path (1:1 file)
	Public Shared Sub SaveSlateToFile(settings As SettingsProfile, filePath As String)
		Dim json As String = JsonConvert.SerializeObject(settings, Formatting.Indented)
		File.WriteAllText(filePath, json)
	End Sub

	' Try to read and validate a slate file; returns True and out parameter when valid
	Public Shared Function TryLoadSlateFromFile(filePath As String, ByRef settingsOut As SettingsProfile) As Boolean
		settingsOut = Nothing
		Try
			If Not File.Exists(filePath) Then
				Return False
			End If
			Dim json As String = File.ReadAllText(filePath)
			Dim loaded = JsonConvert.DeserializeObject(Of SettingsProfile)(json)
			' Basic validation: must deserialize and have at least a shot or scene (adjust as needed)
			If loaded Is Nothing Then
				Return False
			End If
			' Allow Scene/Shot to be empty, but ensure numeric fields are parseable (robustness)
			' Validate scene number
			If loaded.SceneNum < 0 Then
				Return False
			End If
			settingsOut = loaded
			Return True
		Catch ex As Exception
			Debug.WriteLine($"TryLoadSlateFromFile: exception reading {filePath}: {ex.Message}")
			Return False
		End Try
	End Function

	Public Shared Sub SaveSettingsToFile(settings As SettingsProfile, profileNumber As Integer)
		Dim filePath As String = $"settingsProfile{profileNumber}.json"
		Dim json As String = JsonConvert.SerializeObject(settings)
		File.WriteAllText(filePath, json)
	End Sub

	Public Shared Function LoadSettingsFromFile(profileNumber As Integer) As SettingsProfile
		Dim filePath As String = $"settingsProfile{profileNumber}.json"
		If File.Exists(filePath) Then
			Dim json As String = File.ReadAllText(filePath)
			Return JsonConvert.DeserializeObject(Of SettingsProfile)(json)
		Else
			' Return a sensible default profile rather than Nothing
			Try
				' Attempt to read defaults at runtime via reflection; fall back to constants on any failure.
				Dim defaultSceneNum As Integer = GetDefaultAs(Of Integer)("sceneNum", 1)
				Dim defaultShot As String = GetDefaultAs(Of String)("shot", String.Empty)
				Dim defaultCameraNum As String = GetDefaultAs(Of String)("cameraNum", String.Empty)
				Dim defaultCamCardNum As Integer = GetDefaultAs(Of Integer)("camCardNum", 0)
				Dim defaultProduction As String = GetDefaultAs(Of String)("production", String.Empty)
				Dim defaultDirector As String = GetDefaultAs(Of String)("director", String.Empty)
				Dim defaultFPS As Double = GetDefaultAs(Of Double)("fps", 24)

				Return New SettingsProfile() With {
					.Scene = String.Empty,
					.ScenePre = String.Empty,
					.SceneNum = defaultSceneNum,
					.Shot = defaultShot,
					.Take = "1",
					.Roll = String.Empty,
					.CameraNum = defaultCameraNum,
					.CamCardNum = defaultCamCardNum.ToString(),
					.Production = defaultProduction,
					.Director = defaultDirector,
					.DOP = String.Empty,
					.FPS = defaultFPS.ToString(),
					.CustDate = String.Empty,
					.CurrentDate = String.Empty,
					.Int = "0",
					.Day = "0",
					.Sync = "0"
				}
			Catch ex As Exception
				Debug.WriteLine($"LoadSettingsFromFile: failed to create default SettingsProfile: {ex.Message}")
				' As a last resort return an empty profile
				Return New SettingsProfile()
			End Try
		End If
	End Function

	' For Approach 2: Save all profiles in one JSON file
	Public Shared Sub SaveAllProfilesToFileShared(profiles As SettingsProfileWrapper, filePath As String)
		Dim json As String = JsonConvert.SerializeObject(profiles)
		File.WriteAllText(filePath, json)
	End Sub

	Public Shared Function LoadAllProfilesFromFileShared(filePath As String) As SettingsProfileWrapper
		If File.Exists(filePath) Then
			Dim json As String = File.ReadAllText(filePath)
			Return JsonConvert.DeserializeObject(Of SettingsProfileWrapper)(json)
		Else
			Return New SettingsProfileWrapper() With {.Profiles = New Dictionary(Of Integer, SettingsProfile)}
		End If
	End Function

	' --- Reflection helper methods to safely obtain defaults at runtime without compile-time references ---
	Private Shared Function GetWorldDefaultsInstance() As Object
		Try
			Dim worldType = GetType(World.vDefaults)
			' Try to find a Shared/Shared field named "vDefaults"
			Dim fi = worldType.GetField("vDefaults", Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Static)
			If fi IsNot Nothing Then
				Return fi.GetValue(Nothing)
			End If
			' Try a Shared property named "vDefaults"
			Dim pi = worldType.GetProperty("vDefaults", Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Static)
			If pi IsNot Nothing Then
				Return pi.GetValue(Nothing, Nothing)
			End If
		Catch ex As Exception
			Debug.WriteLine($"GetWorldDefaultsInstance: reflection failed: {ex.Message}")
		End Try
		Return Nothing
	End Function

	Private Shared Function GetMemberValue(obj As Object, memberName As String) As Object
		If obj Is Nothing Then Return Nothing
		Try
			Dim t = obj.GetType()
			Dim fi = t.GetField(memberName, Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
			If fi IsNot Nothing Then
				Return fi.GetValue(obj)
			End If
			Dim pi = t.GetProperty(memberName, Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
			If pi IsNot Nothing Then
				Return pi.GetValue(obj, Nothing)
			End If
		Catch ex As Exception
			Debug.WriteLine($"GetMemberValue: failed to read '{memberName}': {ex.Message}")
		End Try
		Return Nothing
	End Function

	Private Shared Function GetDefaultAs(Of T)(memberName As String, fallback As T) As T
		Try
			Dim defaultsObj = GetWorldDefaultsInstance()
			If defaultsObj Is Nothing Then
				Return fallback
			End If
			Dim val = GetMemberValue(defaultsObj, memberName)
			If val Is Nothing Then
				Return fallback
			End If
			' Handle direct conversion; if incompatible, fallback.
			Return CType(Convert.ChangeType(val, GetType(T)), T)
		Catch ex As Exception
			Debug.WriteLine($"GetDefaultAs: failed for '{memberName}': {ex.Message}")
			Return fallback
		End Try
	End Function

End Class

Public Class SettingsProfileWrapper
	Public Property Profiles As Dictionary(Of Integer, SettingsProfile)
End Class
