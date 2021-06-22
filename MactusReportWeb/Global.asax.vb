Imports MactusReportLib.MactusReportLib
Public Class Global_asax
    Inherits HttpApplication


    Sub Application_Start(sender As Object, e As EventArgs)
        Dim sTemp As String = ""
        If ReadDatabaseConnection(sTemp) Then
            g_sOutputFileDir = Server.MapPath("Output")
            g_sInFileDir = Server.MapPath("~")
            g_bError = False
            StartThread()
        Else
            g_bError = True
            g_sErrorText = sTemp
        End If
    End Sub
End Class