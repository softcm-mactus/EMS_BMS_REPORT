Imports System.Data.Odbc
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
        nReportStatusID = InsertNewReportStatusRecord(nReportID, oFromDate, oToDate, nInterval, m_sUserName)
        Response.Redirect("ReportProgress.aspx?ReportStatusID=" + nReportStatusID.ToString())


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