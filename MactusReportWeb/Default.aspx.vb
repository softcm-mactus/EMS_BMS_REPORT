Imports System.Data.Odbc
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

        Dim sQuery = "SELECT status.id id, 
                             status.reportId reportid, 
                             rc.ReportTitle reporttitle, 
                             rc.ReportHeader reportheader, 
                             status.username username, 
                             status.fromdate fromdate, 
                             status.todate todate, 
                             status.status status, 
                             status.progress progress, 
                             errormessage errormessage, 
                             filename     filename
                        FROM tbl_reportstatus as status
                        Join TBL_ReportsConfiguration rc on rc.ReportID = status.reportid
                        WHERE Status < 3"
        Try
            Dim oConnection = New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd = New OdbcCommand(sQuery, oConnection)
            Dim oReader = oCmd.ExecuteReader()
            While (oReader.Read())
                Dim r As New TableRow()
                Dim c As TableCell

                c = New TableCell()
                c.Controls.Add(New LiteralControl(oReader("reportheader")))
                r.Cells.Add(c)

                c = New TableCell()
                c.Controls.Add(New LiteralControl(oReader("reporttitle")))
                r.Cells.Add(c)

                c = New TableCell()
                c.Controls.Add(New LiteralControl(oReader("fromdate")))
                r.Cells.Add(c)

                c = New TableCell()
                c.Controls.Add(New LiteralControl(oReader("todate")))
                r.Cells.Add(c)

                c = New TableCell()
                c.Controls.Add(New LiteralControl(oReader("username")))
                r.Cells.Add(c)

                c = New TableCell()
                c.Controls.Add(New LiteralControl(oReader("progress")))
                r.Cells.Add(c)

                c = New TableCell()
                Dim path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/output/"
                If oReader("status") = "3" Then
                    Dim hl As New HyperLink()
                    hl.Text = oReader("filename")
                    hl.NavigateUrl = path + oReader("filename")
                    hl.CssClass = "thickbox"
                    hl.ToolTip = "open report"
                    c.Controls.Add(hl)
                Else
                    c.Controls.Add(New LiteralControl("Pending"))
                End If
                r.Cells.Add(c)

                StatusTable.Rows.Add(r)
            End While
        Catch ex As Exception
            'Response.Redirect("DBError.aspx", False)
        End Try

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