Imports MactusReportLib
Imports System.Data.Odbc

Public Class EBOReportMainForm
    Private m_nSelectedReportType As ReportType
    Private m_nIntervalMin As Integer = 1
    Private m_nReportID As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""
        Dim oTime As DateTime = DateTime.Now
        If ReadDatabaseConnection(sError) = False Then
            MsgBox(sError)
            End
        End If
        bAreaReports.Checked = True
        bAlarmReports.Checked = False
        bEventReport.Checked = False
        LoadReportsIntoListBox(oReportGrid, ReportType.DataReport)
        cInterval.SelectedIndex = 0
        m_nSelectedReportType = ReportType.DataReport
        oTime = oTime.AddMilliseconds(-oTime.Millisecond)
        oTime = oTime.AddSeconds(-oTime.Second)
        tr_FromDate.Value = oTime.AddHours(-7)
        tr_ToDate.Value = oTime
        bGenerate.Enabled = False
        oTimer.Enabled = True
    End Sub
    Public Sub LoadReportsIntoListBox(ByRef oReportGrid As DataGridView, ByVal nReportType As Integer)
        oReportGrid.Rows.Clear()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        Try
            sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE ReportType=" + nReportType.ToString
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

    Private Sub bAreaReports_CheckedChanged(sender As Object, e As EventArgs) Handles bAreaReports.CheckedChanged
        LoadReportsIntoListBox(oReportGrid, ReportType.DataReport)
        Label5.Visible = False
        m_nSelectedReportType = ReportType.DataReport
    End Sub

    Private Sub bAlarmReports_CheckedChanged(sender As Object, e As EventArgs) Handles bAlarmReports.CheckedChanged
        LoadReportsIntoListBox(oReportGrid, ReportType.AlarmReport)
        Label5.Visible = False
        m_nIntervalMin = 1
        m_nSelectedReportType = ReportType.AlarmReport
    End Sub

    Private Sub bEventReport_CheckedChanged(sender As Object, e As EventArgs) Handles bEventReport.CheckedChanged
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

End Class
