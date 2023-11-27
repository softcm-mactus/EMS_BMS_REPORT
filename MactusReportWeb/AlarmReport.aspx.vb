﻿Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib

Public Class AlarmReport
    Inherits System.Web.UI.Page

    Private m_sUserName As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            LoadReportsCombo()
            tToDate.Text = Now.ToString(MactusReportLib.g_sTimeFormatIndian)
            tFromDate.Text = Now.AddDays(-1).ToString(MactusReportLib.g_sTimeFormatIndian)
        End If

        Try
            m_sUserName = Request.QueryString("UserName")
        Catch ex As Exception
            m_sUserName = "Not Provided"
        End Try

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
                c.Controls.Add(New LiteralControl(oReader("progress").ToString() + "%"))
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
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            Response.Redirect("DBError.aspx", False)
        End Try

    End Sub

    Private Sub LoadReportsCombo()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim oDataTable As New DataTable
        Dim nID As Integer
        Dim sName As String

        oCombo.Items.Clear()

        oDataTable.Columns.Add("ID", GetType(Integer))
        oDataTable.Columns.Add("ReportName", GetType(String))
        Try
            sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE ReportType=" + Str(ReportType.AlarmReport)
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            While oReader.Read()
                nID = oReader("ReportID")
                sName = oReader("ReportTitle")
                oDataTable.Rows.Add(nID, sName)
            End While
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try


        oCombo.DataSource = oDataTable
        oCombo.DataBind()
    End Sub

    Protected Sub bGenerateReport_Click(sender As Object, e As EventArgs) Handles bGenerateReport.Click
        Dim oFromDate As Date
        Dim oToDate As Date
        Dim nReportID As Integer
        Dim nInterval As Integer
        Try



            oFromDate = DateTime.ParseExact(tFromDate.Text, MactusReportLib.g_sTimeFormatIndian, Nothing)
            oToDate = DateTime.ParseExact(tToDate.Text, MactusReportLib.g_sTimeFormatIndian, Nothing)
            If oFromDate >= oToDate Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('From Date Time Should Be Less Than To Date Time');", True)
                Exit Sub
            End If



            nReportID = Convert.ToInt32(oCombo.SelectedItem.Value)
            nInterval = 1


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try

        Dim nReportStatusID As Long
        nReportStatusID = InsertNewReportStatusRecord(nReportID, oFromDate, oToDate, nInterval, m_sUserName, ReportType.AlarmReport)
        Response.Redirect("ReportProgress.aspx?ReportStatusID=" + nReportStatusID.ToString(), False)


        'If MactusReportLib.g_bIsBMS Then
        '    Dim oReport As New MactusReportLib.EBOReport()
        '    If oReport.GenerateReport(nReportID, oFromDate, oToDate, m_sUserName, sFileName, sPathName, nInterval, sError) Then
        '        Response.Redirect("Output\" + sFileName)
        '        Exit Sub
        '    Else
        '        sError = "alert('" + sError + +"');"
        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", sError, True)
        '    End If
        'Else


        '    'Dim oReport As New MactusReportLib.IndusoftEMSReport()
        '    'If oReport.GenerateReport(nReportID, oFromDate, oToDate, m_sUserName, sFileName, sPathName, nInterval, sError) Then
        '    '    Response.Redirect("Output\" + sFileName)
        '    '    Exit Sub
        '    'Else
        '    '    sError = "alert('" + sError + +"');"
        '    '    ClientScript.RegisterStartupScript(Me.GetType(), "alert", sError, True)
        '    'End If

        'End If
    End Sub
End Class