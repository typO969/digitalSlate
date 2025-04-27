Imports digitalSlate.World.Functions

Namespace World

	Module Vars


		'Public Class vMain
		Public vMain As New mainClass()

		Public Class mainClass

			Public Property tcTimerGo As Integer = 0

			Public Property currentDate As String = Date.Now.ToString("dd MMM yyyy")
			Public Property custDate As String = ""

			Public Property scene As String = ""
			Public Property scenePre As String = ""     'can be: V, R, X. (vfx, reshoot, 2nd unit)
			Public Property sceneNum As Integer
			Public Property shot As String = ""

			Public Property take As Integer
			Public Property roll As String = ""
			Public Property cameraNum As String = ""
			Public Property camCardNum As Integer

			Public Property production As String = ""
			Public Property director As String = ""
			Public Property dop As String = ""
			Public Property fps As Double
			Public Property int As Integer
			Public Property day As Integer
			Public Property sync As Integer

			Public Property skipSound As Integer = 1

			Public Property beepCount As Integer = 1
			Public Property countdownCount As Integer = 2
			Public Property displayCaps As Integer = 0

			Public Property autoUpTake As Integer = 0

		End Class

		Public Class vDefaults
			Public Const custDate As String = ""

			Public Const scene As String = "01A"
			Public Const sceneNum As Integer = 1
			Public Const shot As String = "A"

			Public Const take As Integer = 1
			Public Const roll As String = "A001"
			Public Const cameraNum As String = "A"
			Public Const camCardNum As Integer = 1

			Public Const production As String = "Your Film Name"
			Public Const director As String = "Ian Knight"
			Public Const dop As String = "Steve Perry"
			Public Const fps As Double = 24
			Public Const int As Integer = 1
			Public Const day As Integer = 1
			Public Const sync As Integer = 1

			Public Const beepCount As Integer = 1
			Public Const countdownCount As Integer = 2
			Public Const displayCaps As Integer = 0

			Public Const autoUpTake As Integer = 0

			Public Const zeroTC As String = "00 : 00 : 00 : 00"
		End Class

	End Module

End Namespace
