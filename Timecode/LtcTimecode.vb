Imports System.Runtime.CompilerServices

Public Enum LtcFpsMode
	Fps23_976
	Fps24
	Fps25
	Fps30
End Enum

Public Module LtcFpsModeExtensions
	<Extension>
	Public Function ToFps(mode As LtcFpsMode) As Double
		Select Case mode
			Case LtcFpsMode.Fps23_976
				Return 23.976
			Case LtcFpsMode.Fps24
				Return 24.0
			Case LtcFpsMode.Fps25
				Return 25.0
			Case LtcFpsMode.Fps30
				Return 30.0
			Case Else
				Return 24.0
		End Select
	End Function
End Module

Public Class LtcTimecode
	Public Property Hours As Integer
	Public Property Minutes As Integer
	Public Property Seconds As Integer
	Public Property Frames As Integer

	Public Sub New(hours As Integer, minutes As Integer, seconds As Integer, frames As Integer)
		Me.Hours = hours
		Me.Minutes = minutes
		Me.Seconds = seconds
		Me.Frames = frames
	End Sub

	Public Shared Function FromDateTime(now As Date, fpsMode As LtcFpsMode) As LtcTimecode
		Dim fps = fpsMode.ToFps()
		Dim f As Integer = CInt(Math.Floor((now.Millisecond / 1000.0) * fps))
		Dim maxFrame As Integer = CInt(Math.Floor(fps))
		If f < 0 Then f = 0
		If f >= maxFrame Then f = maxFrame - 1
		Return New LtcTimecode(now.Hour, now.Minute, now.Second, f)
	End Function

	Public Sub Increment(fpsMode As LtcFpsMode)
		Dim fps = fpsMode.ToFps()
		Dim maxFrame = CInt(Math.Floor(fps))
		Frames += 1
		If Frames >= maxFrame Then
			Frames = 0
			Seconds += 1
			If Seconds >= 60 Then
				Seconds = 0
				Minutes += 1
				If Minutes >= 60 Then
					Minutes = 0
					Hours = (Hours + 1) Mod 24
				End If
			End If
		End If
	End Sub
End Class
