Imports System.Windows.Forms
Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib

Public Class DlgReportsConfiguration

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        UpdateGridData()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgReportsConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        oGrid.Rows.Clear()
        Try
            sQuery = "SELECT * FROM tbl_reportsconfiguration ORDER BY reportid"

            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    Dim nReportType As ReportType
                    nReportType = oReader("reporttype")

                    If nReportType = MactusReportLib.ReportType.DataReport Then
                        nRow = oGrid.Rows.Add()
                        oGrid.Rows(nRow).Cells(0).Value = oReader("reportid")
                        oGrid.Rows(nRow).Cells(1).Value = GetTemplateName(oReader("templateid"))
                        oGrid.Rows(nRow).Cells(1).ReadOnly = True
                        oGrid.Rows(nRow).Cells(2).Value = nReportType.ToString
                        oGrid.Rows(nRow).Cells(3).Value = GetGroupName(oReader("almgroupid"))
                        oGrid.Rows(nRow).Cells(4).Value = oReader("reporttitle")
                        oGrid.Rows(nRow).Cells(5).Value = oReader("reportheader")
                        oGrid.Rows(nRow).Cells(6).Value = CBool(oReader("generatedtime"))
                        oGrid.Rows(nRow).Cells(7).Value = CBool(oReader("generatedby"))
                        oGrid.Rows(nRow).Cells(8).Value = CBool(oReader("fromtodatesprinted"))
                        oGrid.Rows(nRow).Cells(9).Value = oReader("timeintervalinmin").ToString()
                        Try
                            Dim nAggType As DataAgg = oReader("dataaggregationtype")
                            oGrid.Rows(nRow).Cells(10).Value = nAggType.ToString()
                        Catch ex As Exception

                        End Try
                        oGrid.Rows(nRow).Cells(12).Value = CBool(oReader("PrintMinMaxRows"))
                        oGrid.Rows(nRow).Cells(13).Value = CBool(oReader("PrintAlarmSpRows"))

                    End If
                End While
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Function UpdateGridData() As Boolean
        Dim sQuery As String
        Dim nRow As Integer
        Dim nReportID As Integer

        UpdateGridData = False

        Try
            For nRow = 0 To oGrid.Rows.Count - 1

                nReportID = oGrid.Rows(nRow).Cells(0).Value

                sQuery = "UPDATE tbl_reportsconfiguration SET templateid=?, almgroupid=?,reporttitle=?,reportheader=?,generatedtime=?,generatedby=?,fromtodatesprinted=?,timeintervalinmin=?,dataaggregationtype=?,PrintMinMaxRows=?,PrintAlarmSpRows=? WHERE reportid=" + nReportID.ToString()
                Using oUpdateConnection As New OdbcConnection(g_sConString)
                    oUpdateConnection.Open()
                    Dim oUpdateCmd As New OdbcCommand(sQuery, oUpdateConnection)
                    oUpdateCmd.Parameters.Add("@0", OdbcType.Int).Value = GetTemplateID(oGrid.Rows(nRow).Cells(1).Value) 'templateid
                    oUpdateCmd.Parameters.Add("@1", OdbcType.Int).Value = GetGroupID(oGrid.Rows(nRow).Cells(3).Value) 'almgroupid
                    oUpdateCmd.Parameters.Add("@2", OdbcType.VarChar).Value = oGrid.Rows(nRow).Cells(4).Value 'reporttitle
                    oUpdateCmd.Parameters.Add("@3", OdbcType.VarChar).Value = oGrid.Rows(nRow).Cells(5).Value 'reportheader

                    If oGrid.Rows(nRow).Cells(6).Value Then
                        oUpdateCmd.Parameters.Add("@4", OdbcType.Int).Value = 1 'generatedtime
                    Else
                        oUpdateCmd.Parameters.Add("@4", OdbcType.Int).Value = 0 'generatedtime
                    End If

                    If oGrid.Rows(nRow).Cells(7).Value Then 'generatedby
                        oUpdateCmd.Parameters.Add("@5", OdbcType.Int).Value = 1
                    Else
                        oUpdateCmd.Parameters.Add("@5", OdbcType.Int).Value = 1
                    End If

                    If oGrid.Rows(nRow).Cells(8).Value Then 'fromtodatesprinted
                        oUpdateCmd.Parameters.Add("@6", OdbcType.Int).Value = 1
                    Else
                        oUpdateCmd.Parameters.Add("@6", OdbcType.Int).Value = 1
                    End If

                    oUpdateCmd.Parameters.Add("@7", OdbcType.Int).Value = oGrid.Rows(nRow).Cells(9).Value 'timeintervalinmin

                    Dim nAggtype As DataAgg = [Enum].Parse(GetType(DataAgg), oGrid.Rows(nRow).Cells(10).Value.ToString)
                    oUpdateCmd.Parameters.Add("@8", OdbcType.Int).Value = nAggtype 'dataaggregationtype


                    If oGrid.Rows(nRow).Cells(12).Value Then 'PrintMinMaxRows
                        oUpdateCmd.Parameters.Add("@9", OdbcType.Int).Value = 1
                    Else
                        oUpdateCmd.Parameters.Add("@9", OdbcType.Int).Value = 1
                    End If

                    If oGrid.Rows(nRow).Cells(13).Value Then 'PrintAlarmSpRows
                        oUpdateCmd.Parameters.Add("@10", OdbcType.Int).Value = 1
                    Else
                        oUpdateCmd.Parameters.Add("@10", OdbcType.Int).Value = 1
                    End If

                    oUpdateCmd.ExecuteNonQuery()
                    oUpdateConnection.Close()
                End Using
            Next

        Catch ex As Exception
            UpdateGridData = False
        End Try


    End Function



    Private Sub oGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles oGrid.DataError
        e.Cancel = True
    End Sub

    Private Sub bAddNewReport_Click(sender As Object, e As EventArgs) Handles bAddNewReport.Click
        Dim nRow As Integer
        Dim sQuery As String
        Dim nReportID As Integer

        Dim oDlg As New DlgSelectReportGroupTemplate

        If oDlg.ShowDialog() = DialogResult.OK Then

            sQuery = "INSERT INTO tbl_reportsconfiguration (templateid, reporttype, almgroupid, reporttitle, reportheader, generatedtime, generatedby, fromtodatesprinted, datatablename, timeintervalinmin, dataaggregationtype,PrintAlarmSpRows,PrintMinMaxRows )VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"

            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oCmd.Parameters.Add("@0", OdbcType.Int).Value = GetTemplateID(oDlg.cTemplate.Text) 'templateid
                oCmd.Parameters.Add("@1", OdbcType.Int).Value = MactusReportLib.ReportType.DataReport 'reporttype
                oCmd.Parameters.Add("@2", OdbcType.Int).Value = GetGroupID(oDlg.cGroup.Text) 'almgroupid
                oCmd.Parameters.Add("@3", OdbcType.VarChar).Value = oDlg.tReportTitle.Text 'reporttitle
                oCmd.Parameters.Add("@4", OdbcType.VarChar).Value = "New Report Second Title" 'reportheader
                oCmd.Parameters.Add("@5", OdbcType.Int).Value = 1 'generatedtime
                oCmd.Parameters.Add("@6", OdbcType.Int).Value = 1 'generatedby
                oCmd.Parameters.Add("@7", OdbcType.Int).Value = 1 'fromtodatesprinted
                If g_bIsBMS Then 'datatablename
                    oCmd.Parameters.Add("@8", OdbcType.VarChar).Value = "trend_data"
                Else
                    oCmd.Parameters.Add("@8", OdbcType.VarChar).Value = "TREND001"
                End If
                oCmd.Parameters.Add("@9", OdbcType.Int).Value = 1 'timeintervalinmin
                oCmd.Parameters.Add("@10", OdbcType.Int).Value = MactusReportLib.DataAgg.Instance 'dataaggregationtype
                oCmd.Parameters.Add("@11", OdbcType.Int).Value = 0 'PrintAlarmSpRows
                oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0 'PrintMinMaxRows
                oCmd.ExecuteNonQuery()
                sQuery = "SELECT @@Identity "
                oCmd.Parameters.Clear()
                oCmd.CommandText = sQuery
                nReportID = oCmd.ExecuteScalar
                If nReportID > 0 Then
                    AddDateTimeColumnToReport(nReportID)
                End If
                oConnection.Close()


                nRow = oGrid.Rows.Add()
                oGrid.Rows(nRow).Cells(0).Value = nReportID
                oGrid.Rows(nRow).Cells(1).Value = oDlg.cTemplate.Text
                oGrid.Rows(nRow).Cells(2).Value = "Data Report"
                oGrid.Rows(nRow).Cells(3).Value = oDlg.cGroup.Text
                oGrid.Rows(nRow).Cells(4).Value = oDlg.tReportTitle.Text
                oGrid.Rows(nRow).Cells(5).Value = "New Report Second Title"
                oGrid.Rows(nRow).Cells(6).Value = True
                oGrid.Rows(nRow).Cells(7).Value = True
                oGrid.Rows(nRow).Cells(8).Value = True
                oGrid.Rows(nRow).Cells(9).Value = 1
                Try
                    oGrid.Rows(nRow).Cells(10).Value = MactusReportLib.DataAgg.Instance.ToString()
                Catch ex As Exception

                End Try
                oGrid.Rows(nRow).Cells(12).Value = False
                oGrid.Rows(nRow).Cells(13).Value = False
            End Using
        End If



    End Sub

    Private Sub oGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellClick
        Dim nReportID As Integer
        If e.RowIndex <> -1 Then
            nReportID = oGrid.Rows(e.RowIndex).Cells(0).Value
            If e.ColumnIndex = 11 And nReportID <> 0 Then

                Dim oDlg As New dlgColumnsConfiguration
                oDlg.m_nReportID = nReportID
                oDlg.ShowDialog()
            End If
        End If
    End Sub


    Private Sub bDeleteReport_Click(sender As Object, e As EventArgs) Handles bDeleteReport.Click
        Dim nReportID As Integer
        Dim sReportTitle As String
        Dim sQuery As String

        If oGrid.SelectedRows.Count <= 0 Then
            MsgBox("No Row Selected")
            Exit Sub
        End If
        For nRow = 0 To oGrid.SelectedRows.Count - 1
            nReportID = oGrid.SelectedRows(nRow).Cells(0).Value
            sReportTitle = oGrid.SelectedRows(nRow).Cells(4).Value
            If nReportID > 0 Then
                If MessageBox.Show(sReportTitle + " : Do you Really Want To Delete The Report and Columns?", "Reports Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    sQuery = "DELETE FROM tbl_reportcolumns WHERE reportid=" + nReportID.ToString()
                    ExecuteSQLInDb(sQuery)
                    sQuery = "DELETE FROM tbl_reportsconfiguration WHERE reportid=" + nReportID.ToString()
                    ExecuteSQLInDb(sQuery)
                    RefreshGrid()

                End If
            Else
                MessageBox.Show(sReportTitle + " :New Report Not Yet Saved In The Database?", "Reports Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub
End Class