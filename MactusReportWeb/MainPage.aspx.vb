Imports MactusReportLib

Public Class MainPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sTemp As String = ""
        If g_bError = False Then
            g_sOutputFileDir = Server.MapPath("Output")
            g_sInFileDir = Server.MapPath("~")
        Else
            Response.Redirect("DBError.aspx")
        End If
    End Sub


    Protected Sub bDataReports_Click(sender As Object, e As EventArgs) Handles bDataReports.Click
        Response.Redirect("DataTrendReport.aspx?UserName=Raghu")

    End Sub

    Protected Sub bEventReport_Click(sender As Object, e As EventArgs) Handles bEventReport.Click
        Response.Redirect("EventReport.aspx?UserName=Raghu")

    End Sub

    Protected Sub bAlarmReports_Click(sender As Object, e As EventArgs) Handles bAlarmReports.Click
        Response.Redirect("AlarmReport.aspx?UserName=Raghu")

    End Sub


End Class