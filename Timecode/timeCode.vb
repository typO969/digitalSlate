Public Class Timecode
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

	Public Overrides Function ToString() As String
		Return $"{Hours:D2} : {Minutes:D2} : {Seconds:D2} : {Frames:D2}"
	End Function

End Class

Public Class TimecodeGenerator
	Public Shared Function GenerateTimecode(currentTime As Date, framesPerSecond As Double) As Timecode
		' Calculate the timecode components
		Dim hours As Integer = currentTime.Hour
		Dim minutes As Integer = currentTime.Minute
		Dim seconds As Integer = currentTime.Second
		Dim frames As Integer = CInt((currentTime.Millisecond / 1000.0) * framesPerSecond)

		Return New Timecode(hours, minutes, seconds, frames)
	End Function
End Class

' Timecode generation based on total frames
'Dim frames = totalFrames Mod framesPerSecond
'Dim seconds = (totalFrames \ framesPerSecond) Mod 60
'Dim minutes = ((totalFrames \ framesPerSecond) \ 60) Mod 60
'Dim hours = (((totalFrames \ framesPerSecond) \ 60) \ 60) Mod 24