Imports Newtonsoft.Json
Imports digitalSlate.World.Functions
Imports System.IO

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
			World.vMain.take = CInt(settings.Take)
			World.vMain.roll = settings.Roll
			World.vMain.cameraNum = settings.CameraNum
			World.vMain.camCardNum = CInt(settings.CamCardNum)
			World.vMain.production = settings.Production
			World.vMain.director = settings.Director
			World.vMain.dop = settings.DOP
			World.vMain.fps = CInt(settings.FPS)
			World.vMain.custDate = settings.CustDate
			World.vMain.currentDate = settings.CurrentDate
			World.vMain.int = CInt(settings.Int)
			World.vMain.day = CInt(settings.Day)
			World.vMain.sync = CInt(settings.Sync)
		Else
			' Handle the case where the profile does not exist
		End If
	End Sub

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
			Return Nothing ' Handle the case where the file does not exist
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
End Class

Public Class SettingsProfileWrapper
	Public Property Profiles As Dictionary(Of Integer, SettingsProfile)
End Class
