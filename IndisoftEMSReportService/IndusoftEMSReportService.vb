Imports MactusReportLib.MactusReportLib

Public Class IndusoftEMSReportService

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Dim sError As String = ""
        ReadDatabaseConnection(sError)
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        oTimer.Enabled = False

        '  GenerateEMSReports()

        oTimer.Enabled = True
    End Sub
End Class
