Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib

Public Class TrendDataAlarmReport
    Inherits System.Web.UI.Page

    Private m_sUserName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            tToDate.Text = Now
            tFromDate.Text = Now.AddDays(-1)
        End If
        Try
            m_sUserName = Request.QueryString("UserName")
        Catch ex As Exception
            m_sUserName = "Not Provided"
        End Try

        If IsPostBack = False Then
            LoadReportGroupCombo()
            LoadReportsCombo(0)
        End If



    End Sub

    Private Sub LoadReportsCombo(ByRef nGoupID As Integer)
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim oDataTable As New DataTable
        Dim nID As Integer
        Dim sName As String

        oCombo.Items.Clear()

        oDataTable.Columns.Add("ID", GetType(Integer))
        oDataTable.Columns.Add("ReportName", GetType(String))
        Try
            sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE AlmGroupID=" + nGoupID.ToString() + " AND ReportType=" + Str(ReportType.DataTrendAlarmReport)
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
            LogError("DataTrendReport.aspx.vb", "LoadReportsCombo()", ex.Message)
            Exit Sub
        End Try


        oCombo.DataSource = oDataTable
        oCombo.DataBind()
    End Sub

    Private Sub LoadReportGroupCombo()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim oDataTable As New DataTable
        Dim nID As Integer
        Dim sName As String

        cReportGroup.Items.Clear()

        oDataTable.Columns.Add("GroupID", GetType(Integer))
        oDataTable.Columns.Add("GroupName", GetType(String))
        Try
            sQuery = "SELECT * FROM TBL_DataGroups WHERE grouptype=0"
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            While oReader.Read()
                nID = oReader("GroupID")
                sName = oReader("GroupName")
                oDataTable.Rows.Add(nID, sName)
            End While
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            LogError("ExcursionReport.aspx.vb", "LoadReportGroupCombo()", ex.Message)
            Exit Sub
        End Try

        cReportGroup.DataSource = oDataTable
        cReportGroup.DataBind()

        cReportGroup.SelectedIndex = 0

    End Sub

    Protected Sub oCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles oCombo.SelectedIndexChanged
        Dim sMessage As String

        sMessage = oCombo.SelectedItem.Text + " " + oCombo.SelectedItem.Value
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & sMessage & "');", True)
    End Sub

    Protected Sub bGenerateReport_Click(sender As Object, e As EventArgs) Handles bGenerateReport.Click
        Dim oFromDate As Date
        Dim oToDate As Date
        Dim nReportID As Integer
        Dim nInterval As Integer
        Try


            oFromDate = tFromDate.Text
            oToDate = tToDate.Text
            If oFromDate >= oToDate Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('From Date Time Should Be Less Than To Date Time');", True)
                Exit Sub
            End If



            nReportID = Convert.ToInt32(oCombo.SelectedItem.Value)
            nInterval = Convert.ToInt32(1)


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try


        Dim nReportStatusID As Long
        nReportStatusID = InsertNewReportStatusRecord(nReportID, oFromDate, oToDate, nInterval, m_sUserName, ReportType.DataTrendAlarmReport)
        Response.Redirect("ReportProgress.aspx?ReportStatusID=" + nReportStatusID.ToString())


    End Sub

    Protected Sub cReportGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cReportGroup.SelectedIndexChanged
        Dim nGroupID As Integer
        nGroupID = Convert.ToInt32(cReportGroup.SelectedItem.Value)
        LoadReportsCombo(nGroupID)
    End Sub

    Protected Sub tFromDate_TextChanged(sender As Object, e As EventArgs) Handles tFromDate.TextChanged

    End Sub

End Class