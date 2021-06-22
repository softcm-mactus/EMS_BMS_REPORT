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
        Dim oReader As OdbcDataReader
        Dim nRow As Integer
        Dim nReportType As ReportType
        Dim nReportID As Integer

        UpdateGridData = False

        Try
            sQuery = "SELECT * FROM tbl_reportsconfiguration  ORDER BY reportid"

            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    nReportType = oReader("reporttype")
                    nReportID = oReader("reportid")
                    If nReportType = MactusReportLib.ReportType.DataReport Then
                        Dim bFound As Boolean = False
                        For nRow = 0 To oGrid.Rows.Count - 1
                            If oGrid.Rows(nRow).Cells(0).Value = oReader("reportid") Then
                                sQuery = "UPDATE tbl_reportsconfiguration "
                                sQuery += " SET templateid=" + GetTemplateID(oGrid.Rows(nRow).Cells(1).Value).ToString
                                'sQuery += " SET reporttype=" + GetTemplateID(oGrid.Rows(nRow).Cells(2).Value).ToString
                                sQuery += ", almgroupid=" + GetGroupID(oGrid.Rows(nRow).Cells(3).Value).ToString
                                sQuery += ", reporttitle='" + oGrid.Rows(nRow).Cells(4).Value.ToString + "'"
                                sQuery += ", reportheader='" + oGrid.Rows(nRow).Cells(5).Value.ToString + "'"
                                If oGrid.Rows(nRow).Cells(6).Value Then
                                    sQuery += ", generatedtime=1"
                                Else
                                    sQuery += ", generatedtime=0"
                                End If
                                If oGrid.Rows(nRow).Cells(7).Value Then
                                    sQuery += ", generatedby=1"
                                Else
                                    sQuery += ", generatedby=0"
                                End If
                                If oGrid.Rows(nRow).Cells(8).Value Then
                                    sQuery += ", fromtodatesprinted=1"
                                Else
                                    sQuery += ", fromtodatesprinted=0"
                                End If

                                sQuery += ",  timeintervalinmin=" + oGrid.Rows(nRow).Cells(9).Value.ToString

                                Dim nAggtype As DataAgg = [Enum].Parse(GetType(DataAgg), oGrid.Rows(nRow).Cells(10).Value.ToString)
                                sQuery += ",  dataaggregationtype=" + Str(nAggtype)

                                If oGrid.Rows(nRow).Cells(12).Value Then
                                    sQuery += ", PrintMinMaxRows=1"
                                Else
                                    sQuery += ", PrintMinMaxRows=0"
                                End If
                                If oGrid.Rows(nRow).Cells(13).Value Then
                                    sQuery += ", PrintAlarmSpRows=1"
                                Else
                                    sQuery += ", PrintAlarmSpRows=0"
                                End If

                            sQuery += " where reportid=" + nReportID.ToString()
                                ExecuteSQLInDb(sQuery)
                                bFound = True
                            End If
                        Next

                        If bFound = False Then
                            sQuery = "DELETE FROM tbl_reportcolumns WHERE reportid=" + nReportID.ToString()
                            ExecuteSQLInDb(sQuery)
                            sQuery = "DELETE FROM tbl_reportsconfiguration WHERE reportid=" + nReportID.ToString()
                            ExecuteSQLInDb(sQuery)
                        End If
                    End If
                End While
                oConnection.Close()
            End Using
        Catch ex As Exception
            UpdateGridData = False
        End Try

        Dim nTemp As Integer
        Dim sTemp As String

        For nRow = 0 To oGrid.Rows.Count - 1
            Try
                nReportID = oGrid.Rows(nRow).Cells(0).Value
                If nReportID = 0 Then
                    sQuery = "INSERT INTO tbl_reportsconfiguration (templateid, reporttype, almgroupid, reporttitle, reportheader, generatedtime, generatedby, fromtodatesprinted, datatablename, timeintervalinmin, dataaggregationtype,PrintAlarmSpRows,PrintMinMaxRows )VALUES ("
                    Try
                        sTemp = oGrid.Rows(nRow).Cells(1).Value
                    Catch ex As Exception
                        sTemp = ""
                    End Try
                    nTemp = GetTemplateID(sTemp)
                    sQuery += nTemp.ToString + ",0," 'Template ID, Report Type

                    Try
                        sTemp = oGrid.Rows(nRow).Cells(3).Value
                    Catch ex As Exception
                        sTemp = 0
                    End Try
                    sQuery += GetGroupID(sTemp).ToString() + "," 'almgroupid

                    Try
                        sTemp = oGrid.Rows(nRow).Cells(4).Value.ToString() 'reporttitle
                        If sTemp Is Nothing Then
                            sTemp = ""
                        End If
                    Catch ex As Exception
                        sTemp = ""
                    End Try
                    If sTemp.Length() <= 5 Then
                        MsgBox("Title Should Be Minimum 5 characters")
                        Exit For
                    End If


                    sQuery += "'" + sTemp + "',"    'reportheader

                    Try
                        sTemp = oGrid.Rows(nRow).Cells(5).Value
                    Catch ex As Exception
                        sTemp = ""
                    End Try
                    If sTemp Is Nothing Then
                        sTemp = ""
                    End If
                    sQuery += "'" + sTemp + "',"

                    If oGrid.Rows(nRow).Cells(6).Value Then
                        sQuery += "1,"
                    Else
                        sQuery += "0,"
                    End If

                    If oGrid.Rows(nRow).Cells(7).Value Then
                        sQuery += "1,"
                    Else
                        sQuery += "0,"
                    End If
                    If oGrid.Rows(nRow).Cells(8).Value Then
                        sQuery += "1,"
                    Else
                        sQuery += "0,"
                    End If
                    If g_bIsBMS Then
                        sQuery += "'trend_data',"
                    Else
                        sQuery += "'TREND001',"
                    End If

                    Dim nAggtype As DataAgg = [Enum].Parse(GetType(DataAgg), oGrid.Rows(nRow).Cells(10).Value.ToString)

                    sQuery += oGrid.Rows(nRow).Cells(9).Value.ToString() + "," + Str(nAggtype) + ",0,0)"
                    Try


                            Using oConnection As New OdbcConnection(g_sConString)
                                oConnection.Open()
                                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                                oCmd.ExecuteNonQuery()
                                sQuery = "SELECT @@Identity "
                                oCmd.Parameters.Clear()
                                oCmd.CommandText = sQuery
                                nReportID = oCmd.ExecuteScalar

                                oConnection.Close()
                            End Using

                        Catch ex As Exception
                        nReportID = 0
                        MsgBox(ex.Message)
                    End Try
                    If nReportID > 0 Then
                        AddDateTimeColumnToReport(nReportID)
                    End If

                    UpdateGridData = True
                    End If
            Catch ex As Exception
                nReportID = 0
                UpdateGridData = False
                MsgBox(ex.Message)
            End Try
        Next
    End Function



    Private Sub oGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles oGrid.DataError
        e.Cancel = True
    End Sub

    Private Sub bAddNewReport_Click(sender As Object, e As EventArgs) Handles bAddNewReport.Click
        Dim nRow As Integer

        Dim oDlg As New DlgSelectReportGroupTemplate

        If oDlg.ShowDialog() = DialogResult.OK Then

            nRow = oGrid.Rows.Add()
            oGrid.Rows(nRow).Cells(0).Value = 0
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