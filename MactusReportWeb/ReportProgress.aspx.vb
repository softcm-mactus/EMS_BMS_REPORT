
Public Class ReportProgress
    Inherits System.Web.UI.Page
    Public m_nRepotStatusID As Long
    Dim sReportFilePath As String
    Dim sFileName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Try
                Dim sTemp As String
                sTemp = Request.QueryString("ReportStatusID")
                m_nRepotStatusID = CInt(sTemp)
            Catch ex As Exception
                m_nRepotStatusID = 0
            End Try
            Dim nProgress As Integer
            nProgress = MactusReportLib.GetReportProgress(m_nRepotStatusID)



            lReportName.Text = MactusReportLib.GetReportName(m_nRepotStatusID)

            If nProgress >= 100 Then

                sFileName = MactusReportLib.GetReportFileName(m_nRepotStatusID, sReportFilePath)
                System.Threading.Thread.Sleep(300)

                Response.Redirect("Output\" + sFileName, False)

            Else
                tProgress.Text = "Report Generation Progress = " + nProgress.ToString() + " %"
            End If

        Catch ex As Exception
            Response.Redirect("Output\" + sFileName, False)
        End Try

    End Sub

    Protected Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick

    End Sub
End Class