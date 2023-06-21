Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib
Imports MactusReportLib.IndusoftEMSReport
Imports System.ComponentModel

Public Class MainForm

    Private m_nSelectedReportType As ReportType
    Private m_nIntervalMin As Integer = 1
    Private m_nReportID As Integer = 0
    Private m_nReportStatusID As Long = 0

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'If g_sCurrent_login_UserID.Length > 0 Then
            Dim sError As String = ""

            Dim oTime As DateTime = DateTime.Now
            If ReadDatabaseConnection(sError) = False Then
                MsgBox(sError)
                End
            End If

            bCOnfigureReports.Visible = True
            bConfigureAlarmReports.Visible = True 'g_bEnableConfiguration

            Dim sQuery As String
            sQuery = "UPDATE tbl_reportstatus SET status=4 where status=3"
            ExecuteSQLInDb(sQuery)

            m_oEBOReprots = New MactusReportLib.EBOReport()
            m_oIndusoftReports = New MactusReportLib.NewInduSoftReport()

            bAreaReports.Checked = True
            bAlarmReports.Checked = False
            bEventReport.Checked = False
            If g_bIsBMS = 2 Then
                btnBatteryPercentage.Visible = True
                btnExcursionReport.Visible = True
            End If
            LoadReportsIntoListBox(oReportGrid, ReportType.DataReport)
            cInterval.SelectedIndex = 0
            m_nSelectedReportType = ReportType.DataReport
            oTime = oTime.AddMilliseconds(-oTime.Millisecond)
            oTime = oTime.AddSeconds(-oTime.Second)
            oTime = oTime.AddMinutes(-oTime.Minute)
            oTime = oTime.AddHours(-oTime.Hour)
            oTime = oTime.AddDays(-7)
            tr_FromDate.Value = oTime
            tr_ToDate.Value = oTime.AddDays(1)
            bGenerate.Enabled = False

            ' Dim sQuery As String
            Dim oReader As OdbcDataReader
            sQuery = "SELECT * FROM TBL_DataGroups WHERE grouptype=0 ORDER BY groupid"

            Try
                Using oConnection As New OdbcConnection(g_sConString)
                    oConnection.Open()
                    Dim oCmd As New OdbcCommand(sQuery, oConnection)
                    oReader = oCmd.ExecuteReader()
                    While oReader.Read()
                        cGroup.Items.Add(oReader("groupname"))
                    End While
                    oConnection.Close()
                End Using
            Catch ex As Exception

            End Try

            Try
                cGroup.SelectedIndex = 0
            Catch ex As Exception

            End Try

            UpdateGrid()
            StartThread()


            oTimer.Enabled = True

            '  Else

            '  End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub bGenerate_Click(sender As Object, e As EventArgs) Handles bGenerate.Click
        If m_nReportID = 0 Then
            MsgBox("No Report Selected")
            Exit Sub
        End If
        oProgress.Value = 0
        Dim nTimeInterval As Integer

        nTimeInterval = Convert.ToInt16(cInterval.Text)

        m_nReportStatusID = InsertNewReportStatusRecord(m_nReportID, tr_FromDate.Value, tr_ToDate.Value, nTimeInterval, "user Name", m_nSelectedReportType)



    End Sub

    Private Sub oReportGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oReportGrid.CellClick

        Try
            m_nReportID = oReportGrid.Rows(e.RowIndex).Cells(0).Value
            If m_nSelectedReportType = ReportType.DataReport Then
                cInterval.Text = oReportGrid.Rows(e.RowIndex).Cells(2).Value.ToString
                Label5.Visible = True
                cInterval.Visible = True
                m_nIntervalMin = Convert.ToInt16(oReportGrid.Rows(e.RowIndex).Cells(2).Value)
                AdjustTimeMinuetsToInterval(tr_FromDate.Value)
                AdjustTimeMinuetsToInterval(tr_ToDate.Value)
                bGenerateChart.Enabled = True
            Else
                Label5.Visible = False
                m_nIntervalMin = 1
                bGenerateChart.Enabled = False
            End If
            bGenerate.Enabled = True
        Catch ex As Exception
            m_nReportID = 0
            Label5.Visible = False
            m_nIntervalMin = 1
            bGenerate.Enabled = False
            cInterval.Visible = False
            bGenerateChart.Enabled = False
        End Try

    End Sub

    Private Sub bAreaReports_CheckedChanged(sender As Object, e As EventArgs) Handles bAreaReports.CheckedChanged

        cGroup.Enabled = True
        LoadReportsIntoListBox(oReportGrid, ReportType.DataReport)
        Label5.Visible = False
        m_nSelectedReportType = ReportType.DataReport
    End Sub

    Private Sub bAlarmReports_CheckedChanged(sender As Object, e As EventArgs) Handles bAlarmReports.CheckedChanged
        cGroup.SelectedIndex = -1
        cGroup.Enabled = False
        LoadReportsIntoListBox(oReportGrid, ReportType.AlarmReport)
        Label5.Visible = False
        m_nIntervalMin = 1
        m_nSelectedReportType = ReportType.AlarmReport
    End Sub

    Private Sub bEventReport_CheckedChanged(sender As Object, e As EventArgs) Handles bEventReport.CheckedChanged
        cGroup.SelectedIndex = -1
        cGroup.Enabled = False
        LoadReportsIntoListBox(oReportGrid, ReportType.EventReport)
        Label5.Visible = False
        m_nIntervalMin = 1
        m_nSelectedReportType = ReportType.EventReport
    End Sub

    Private Sub AdjustTimeMinuetsToInterval(ByRef oDateTime As DateTime)
        Try
            Dim nTemp As Integer

            If m_nIntervalMin = 1 Then
                Exit Sub
            End If
            nTemp = oDateTime.Minute / m_nIntervalMin

            nTemp = oDateTime.Minute - nTemp * m_nIntervalMin

            oDateTime = oDateTime.AddMinutes(-nTemp)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tr_FromDate_LostFocus(sender As Object, e As EventArgs) Handles tr_FromDate.LostFocus
        AdjustTimeMinuetsToInterval(tr_FromDate.Value)
    End Sub

    Private Sub tr_ToDate_LostFocus(sender As Object, e As EventArgs) Handles tr_ToDate.LostFocus
        AdjustTimeMinuetsToInterval(tr_ToDate.Value)
    End Sub

    Public Sub LoadReportsIntoListBox(ByRef oReportGrid As DataGridView, ByVal nReportType As Integer)
        oReportGrid.Rows.Clear()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        Try
            If nReportType = ReportType.DataReport Then
                sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE AlmGroupID=" + cGroup.SelectedIndex.ToString + " AND ReportType=" + nReportType.ToString + " ORDER BY ReportTitle"
            Else
                sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE ReportType=" + nReportType.ToString + " ORDER BY ReportTitle"
            End If
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            While oReader.Read()
                nRow = oReportGrid.Rows.Add
                oReportGrid.Rows(nRow).Cells(0).Value = oReader("ReportID")
                oReportGrid.Rows(nRow).Cells(1).Value = oReader("ReportTitle")
                Try
                    oReportGrid.Rows(nRow).Cells(2).Value = oReader("TimeIntervalInMin")
                Catch ex As Exception
                    oReportGrid.Rows(nRow).Cells(2).Value = "1"
                End Try

            End While
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        oReportGrid.ClearSelection()
        oReportGrid.Refresh()
    End Sub

    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        oTimer.Enabled = False

        If m_nReportStatusID <> 0 Then
            oProgress.Value = GetReportProgress(m_nReportStatusID)
            If oProgress.Value = 100 Then
                UpdateGrid()
            End If
        End If


        oTimer.Enabled = True
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        m_bStopThread = True
    End Sub

    Private Sub UpdateGrid()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        sQuery = "SELECT * FROM tbl_reportstatus WHERE Status=3"
        oGrid.Rows.Clear()
        Try
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    nRow = oGrid.Rows.Add()
                    oGrid.Rows(nRow).Cells(0).Value = oReader("id")
                    oGrid.Rows(nRow).Cells(1).Value = oReader("outputfilename")
                    oGrid.Rows(nRow).Cells(2).Value = oReader("outputfilename")

                End While
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try

        oGrid.ClearSelection()
        oGrid.Refresh()
    End Sub

    Private Sub oGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellClick
        If e.RowIndex = -1 Or e.ColumnIndex <> 3 Then
            Exit Sub
        End If
        Try
            Dim sQuery As String
            sQuery = "UPDATE tbl_reportstatus SET  Status=4 WHERE id=" + oGrid.Rows(e.RowIndex).Cells(0).Value.ToString()
            ExecuteSQLInDb(sQuery)
            Process.Start(oGrid.Rows(e.RowIndex).Cells(2).Value)

        Catch ex As Exception

        End Try
        UpdateGrid()
    End Sub

    Private Sub cGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cGroup.SelectedIndexChanged
        LoadReportsIntoListBox(oReportGrid, ReportType.DataReport)
    End Sub

    Private Sub bCOnfigureReports_Click(sender As Object, e As EventArgs) Handles bCOnfigureReports.Click
        Dim oDlg As New DlgReportsConfiguration
        oDlg.ShowDialog()
    End Sub

    Private Sub bConfigureAlarmReports_Click(sender As Object, e As EventArgs) Handles bConfigureAlarmReports.Click
        Dim oDlg As New DlgAlarmReportConfiguration()
        oDlg.ShowDialog()
    End Sub

    Private Sub bGenerateChart_Click(sender As Object, e As EventArgs) Handles bGenerateChart.Click

        m_nReportStatusID = InsertNewReportStatusRecord(m_nReportID, tr_FromDate.Value, tr_ToDate.Value, 1, "user Name", 1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If g_bIsBMS = 1 Then
            MactusReportLib.MactusReportLib.SynchronizeEBOPointIDNamesTable()
        ElseIf g_bIsBMS = 2 Then
            SynchronizeWirelessCDUPointIDNamesTable()
        Else
            SynchronizeIndusoftPointIDNamesTable()
        End If
        MsgBox("Data Synchronization Completed")
    End Sub

    Private Sub bConfigure_Click(sender As Object, e As EventArgs) Handles bConfigure.Click
        Dim oDlg As New DlgAppConfiguration()
        oDlg.ShowDialog()
    End Sub

    Private Sub btnExcursionReport_Click(sender As Object, e As EventArgs) Handles btnExcursionReport.Click
        Dim oDlg As New DlgExcursionConfiguration()
        oDlg.ShowDialog()
    End Sub

    Private Sub btnBatteryPercentage_Click(sender As Object, e As EventArgs) Handles btnBatteryPercentage.Click
        Dim oDlg As New DlgBatteryReportConfiguration()
        oDlg.ShowDialog()
    End Sub
End Class
