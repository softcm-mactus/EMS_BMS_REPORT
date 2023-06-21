Imports MactusReportLib

Public Class MainPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If g_bIsBMS = 2 Then
        '    btnTrendDataAlarmReport.Visible = True
        '    bAlarmReports.Visible = False
        '    btnCDUDeviceBateeryStatus.Visible = True
        'Else
        '    btnTrendDataAlarmReport.Visible = False
        '    bAlarmReports.Visible = True
        '    btnCDUDeviceBateeryStatus.Visible = False

        'End If
        Dim sTemp As String = ""
        lblReportName.Text = ConfigurationManager.AppSettings("AppName").ToString
        If g_bError = False Then
            g_sOutputFileDir = Server.MapPath("Output")
            g_sInFileDir = Server.MapPath("~")
        Else
            Response.Redirect("DBError.aspx", False)
        End If
    End Sub


    Protected Sub bDataReports_Click(sender As Object, e As EventArgs) Handles bDataReports.Click
        Response.Redirect("DataTrendReport.aspx?UserName=Raghu", False)

    End Sub

    Protected Sub bEventReport_Click(sender As Object, e As EventArgs) Handles bEventReport.Click
        Response.Redirect("EventReport.aspx?UserName=Raghu", False)

    End Sub

    Protected Sub bAlarmReports_Click(sender As Object, e As EventArgs) Handles bAlarmReports.Click
        Response.Redirect("AlarmReport.aspx?UserName=Raghu", False)

    End Sub

    Protected Sub btnExcursionReport_Click(sender As Object, e As EventArgs)
        Response.Redirect("ExcursionReport.aspx?UserName=Raghu", False)
    End Sub

    Protected Sub btnTrendDataAlarmReport_Click(sender As Object, e As EventArgs)
        Response.Redirect("TrendDataAlarmReport.aspx?UserName=Raghu", False)
    End Sub

    Protected Sub btnCDUDeviceBateeryStatus_Click(sender As Object, e As EventArgs)
        Response.Redirect("WirelessCDUDeviceBatteryPercentage.aspx?UserName=Raghu", False)
    End Sub
End Class