Imports System.Collections.ObjectModel
Imports System.IO

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
     Private Shared Function TryGetClapPath(commandLine As ReadOnlyCollection(Of String)) As String
         If commandLine Is Nothing Then Return String.Empty

         For Each arg As String In commandLine
            If String.IsNullOrWhiteSpace(arg) Then Continue For
            If Not File.Exists(arg) Then Continue For
            If String.Equals(Path.GetExtension(arg), ".clap", StringComparison.OrdinalIgnoreCase) Then
               Return arg
            End If
         Next

         Return String.Empty
      End Function

      Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
         Dim clapPath As String = TryGetClapPath(e.CommandLine)
         If String.IsNullOrWhiteSpace(clapPath) Then Return

         World.Functions.PendingExternalSlateFilePath = clapPath
      End Sub

      Private Sub MyApplication_StartupNextInstance(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
         Dim clapPath As String = TryGetClapPath(e.CommandLine)
         If String.IsNullOrWhiteSpace(clapPath) Then Return

         World.Functions.LoadSlateFromFilePath(clapPath)

         Try
            If frmDigitalSlate IsNot Nothing Then
               frmDigitalSlate.WindowState = FormWindowState.Maximized
               frmDigitalSlate.Activate()
            End If
         Catch
         End Try
      End Sub
    End Class
End Namespace
