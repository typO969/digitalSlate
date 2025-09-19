Imports Newtonsoft.Json
Imports digitalSlate.World.Functions
Imports digitalSlate.World.mainClass
Imports digitalSlate.World.Vars.vDefaults
Imports System.IO
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class SettingsProfile
	Public Property Scene As String
	Public Property ScenePre As String
	Public Property SceneNum As Integer
	Public Property Shot As String
	' numeric types
	Public Property Take As Integer
	Public Property Roll As String
	Public Property CameraNum As String
	Public Property CamCardNum As Integer
	Public Property Production As String
	Public Property Director As String
	Public Property DOP As String
	Public Property FPS As Double
	Public Property CustDate As String
	Public Property CurrentDate As String
	Public Property [Int] As Integer
	Public Property [Day] As Integer
	Public Property [Sync] As Integer
End Class

Public Class JsonSettingsManager

	' Centralized file path constants
	Private Const ProfilesFileName As String = "allProfiles.json"
	Private Const SettingsProfileFormat As String = "settingsProfile{0}.json"

	' Simple wrappers kept Shared for convenience
	Public Shared Function SerializeSettings(settings As SettingsProfile) As String
		Return Newtonsoft.Json.JsonConvert.SerializeObject(settings)
	End Function

	Public Shared Function DeserializeSettings(json As String) As SettingsProfile
		Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of SettingsProfile)(json)
	End Function

	' Consolidated single pair for saving/loading all profiles
	Public Shared Sub SaveAllProfilesToFile(profiles As SettingsProfileWrapper, Optional filePath As String = ProfilesFileName)
		Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(profiles, Newtonsoft.Json.Formatting.Indented)
		System.IO.File.WriteAllText(filePath, json)
	End Sub

	Public Shared Function LoadAllProfilesFromFile(Optional filePath As String = ProfilesFileName) As SettingsProfileWrapper
		Try
			If System.IO.File.Exists(filePath) Then
				Dim json As String = System.IO.File.ReadAllText(filePath)
				Dim loaded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of SettingsProfileWrapper)(json)
				If loaded Is Nothing Then
					Return New SettingsProfileWrapper() With {.Profiles = New Dictionary(Of Integer, SettingsProfile)}
				End If
				If loaded.Profiles Is Nothing Then
					loaded.Profiles = New Dictionary(Of Integer, SettingsProfile)
				End If
				Return loaded
			Else
				Return New SettingsProfileWrapper() With {.Profiles = New Dictionary(Of Integer, SettingsProfile)}
			End If
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"LoadAllProfilesFromFile: exception reading {filePath}: {ex.Message}")
			Return New SettingsProfileWrapper() With {.Profiles = New Dictionary(Of Integer, SettingsProfile)}
		End Try
	End Function

	' Save/load a single profile inside the consolidated allProfiles file.
	' Return Boolean; UI layer should handle user messaging.
	Public Shared Function SaveProfile(profileNumber As Integer) As Boolean
		Try
			Dim profilesWrapper = LoadAllProfilesFromFile(ProfilesFileName)
			Dim settings As New SettingsProfile With {
				.Scene = World.vMain.scene,
				.ScenePre = World.vMain.scenePre,
				.SceneNum = World.vMain.sceneNum,
				.Shot = World.vMain.shot,
				.Take = World.vMain.take,
				.Roll = World.vMain.roll,
				.CameraNum = World.vMain.cameraNum,
				.CamCardNum = World.vMain.camCardNum,
				.Production = World.vMain.production,
				.Director = World.vMain.director,
				.DOP = World.vMain.dop,
				.FPS = World.vMain.fps,
				.CustDate = World.vMain.custDate,
				.CurrentDate = World.vMain.currentDate,
				.Int = World.vMain.int,
				.Day = World.vMain.day,
				.Sync = World.vMain.sync
			}

			profilesWrapper.Profiles(profileNumber) = settings
			SaveAllProfilesToFile(profilesWrapper, ProfilesFileName)
			Return True
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"SaveProfile: failed to save profile {profileNumber}: {ex.Message}")
			Return False
		End Try
	End Function

	Public Shared Function LoadProfile(profileNumber As Integer) As Boolean
		Try
			Dim profilesWrapper = LoadAllProfilesFromFile(ProfilesFileName)
			If profilesWrapper.Profiles.ContainsKey(profileNumber) Then
				Dim settings As SettingsProfile = profilesWrapper.Profiles(profileNumber)

				World.vMain.scene = settings.Scene
				World.vMain.scenePre = settings.ScenePre
				World.vMain.sceneNum = settings.SceneNum
				World.vMain.shot = settings.Shot
				World.vMain.take = settings.Take
				World.vMain.roll = settings.Roll
				World.vMain.cameraNum = settings.CameraNum
				World.vMain.camCardNum = settings.CamCardNum
				World.vMain.production = settings.Production
				World.vMain.director = settings.Director
				World.vMain.dop = settings.DOP
				World.vMain.fps = settings.FPS
				World.vMain.custDate = settings.CustDate
				World.vMain.currentDate = settings.CurrentDate
				World.vMain.int = settings.Int
				World.vMain.day = settings.Day
				World.vMain.sync = settings.Sync

				Return True
			Else
				System.Diagnostics.Debug.WriteLine($"LoadProfile: requested profile {profileNumber} not found in {ProfilesFileName}.")
				Return False
			End If
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"LoadProfile: exception loading profile {profileNumber}: {ex.Message}")
			Return False
		End Try
	End Function

	' Single-file operations for one-profile-per-file
	Public Shared Sub SaveSlateToFile(settings As SettingsProfile, filePath As String)
		Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented)
		System.IO.File.WriteAllText(filePath, json)
	End Sub

	Public Shared Function TryLoadSlateFromFile(filePath As String, ByRef settingsOut As SettingsProfile) As Boolean
		settingsOut = Nothing
		Try
			If Not System.IO.File.Exists(filePath) Then
				Return False
			End If
			Dim json As String = System.IO.File.ReadAllText(filePath)
			Dim loaded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of SettingsProfile)(json)
			If loaded Is Nothing Then
				Return False
			End If
			If loaded.SceneNum < 0 Then
				Return False
			End If
			settingsOut = loaded
			Return True
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"TryLoadSlateFromFile: exception reading {filePath}: {ex.Message}")
			Return False
		End Try
	End Function

	Public Shared Sub SaveSettingsProfileToFile(settings As SettingsProfile, profileNumber As Integer)
		Dim filePath As String = String.Format(SettingsProfileFormat, profileNumber)
		SaveSlateToFile(settings, filePath)
	End Sub

	Public Shared Function TryLoadSettingsProfileFromFile(profileNumber As Integer, ByRef settingsOut As SettingsProfile) As Boolean
		Dim filePath As String = String.Format(SettingsProfileFormat, profileNumber)
		Return TryLoadSlateFromFile(filePath, settingsOut)
	End Function

	' Reflection helpers retained for runtime defaults
	Private Shared Function GetWorldDefaultsInstance() As Object
		Try
			Dim worldType = GetType(World.vDefaults)
			Dim fi = worldType.GetField("vDefaults", Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Static)
			If fi IsNot Nothing Then
				Return fi.GetValue(Nothing)
			End If
			Dim pi = worldType.GetProperty("vDefaults", Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Static)
			If pi IsNot Nothing Then
				Return pi.GetValue(Nothing, Nothing)
			End If
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"GetWorldDefaultsInstance: reflection failed: {ex.Message}")
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
			System.Diagnostics.Debug.WriteLine($"GetMemberValue: failed to read '{memberName}': {ex.Message}")
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
			Return CType(Convert.ChangeType(val, GetType(T)), T)
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"GetDefaultAs: failed for '{memberName}': {ex.Message}")
			Return fallback
		End Try
	End Function

	Public Shared Function CreateDefaultSettingsProfile() As SettingsProfile
		Try
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
				.Take = 1,
				.Roll = String.Empty,
				.CameraNum = defaultCameraNum,
				.CamCardNum = defaultCamCardNum,
				.Production = defaultProduction,
				.Director = defaultDirector,
				.DOP = String.Empty,
				.FPS = defaultFPS,
				.CustDate = String.Empty,
				.CurrentDate = String.Empty,
				.Int = 0,
				.Day = 0,
				.Sync = 0
			}
		Catch ex As Exception
			System.Diagnostics.Debug.WriteLine($"CreateDefaultSettingsProfile: failed: {ex.Message}")
			Return New SettingsProfile()
		End Try
	End Function

End Class

Public Class SettingsProfileWrapper
	Public Property Profiles As Dictionary(Of Integer, SettingsProfile)
End Class
