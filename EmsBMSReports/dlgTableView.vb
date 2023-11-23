Imports System.ComponentModel.Design
Imports System.Data.Odbc
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MactusReportLib.MactusReportLib

Public Class dlgTableView
    Dim colMap = New Dictionary(Of String, Integer)
    Public Class ReportInfo
        Public id As String
        Public name As String
        Public type As String
        Public Overrides Function ToString() As String
            ToString = name
        End Function
    End Class
    Public Class CellInfo
        Public seqNo As String
        Public colIndex As Integer
        Public timestamp As DateTime
        Public value As String
    End Class
    Public m_nReportID As Integer = 0
    Public isLoaded = False

    Private Sub dlgTableView_load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim sQuery = "SELECT * FROM TBL_DataGroups WHERE grouptype=0 ORDER BY groupid"
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            Dim oReader = oCmd.ExecuteReader()
            While oReader.Read()
                Dim o = New ReportInfo
                o.id = oReader("GroupId")
                o.name = oReader("GroupName")
                o.type = oReader("GroupType")
                cGroup.Items.Add(o)
            End While
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim sQuery = "SELECT distinct(CategoryName) CatName FROM TBL_ReportGroups" + cGroup.SelectedText
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            Dim oReader = oCmd.ExecuteReader()
            While oReader.Read()
                Dim o = New ReportInfo
                o.name = oReader("CatName")
            End While
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If cGroup.Items.Count > 0 Then
            cGroup.SelectedIndex = 0
            cGroup_SelectedIndexChanged(Nothing, Nothing)
        End If
        oStartDate.Checked = True
        oStartTime.Checked = True
        oEndDate.Checked = True
        oEndTime.Checked = True

        oStartDate.Value = Global.EmsBMSReports.My.MySettings.Default.StartDate
        oStartTime.Value = Global.EmsBMSReports.My.MySettings.Default.StartTime
        oEndDate.Value = Global.EmsBMSReports.My.MySettings.Default.EndDate
        oEndTime.Value = Global.EmsBMSReports.My.MySettings.Default.EndTime

        oTolerance.Value = Global.EmsBMSReports.My.MySettings.Default.Tolerance
        oPrecision.Value = Global.EmsBMSReports.My.MySettings.Default.Precision
        If Global.EmsBMSReports.My.MySettings.Default.IncludeEvents > 0 Then
            oIncludeEvents.Checked = True
        Else
            oIncludeEvents.Checked = False
        End If
        isLoaded = True
    End Sub
    Private Sub cGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cGroup.SelectedIndexChanged
        oReports.Items.Clear()
        Dim oReader As OdbcDataReader
        Dim group As ReportInfo = cGroup.SelectedItem
        Try
            If group.id.Length > 0 Then
                Dim sQuery As String = "SELECT * FROM TBL_ReportsConfiguration WHERE AlmGroupID=" + group.id + " AND ReportType = 0 " + " ORDER BY ReportTitle"
                Dim oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    Dim o = New ReportInfo
                    o.id = oReader("ReportID")
                    o.name = oReader("ReportTitle")
                    oReports.Items.Add(o)
                End While
                oReader.Close()
                oConnection.Close()
            Else
                Dim sQuery As String = "SELECT distinct(GroupName) GroupName FROM TBL_ReportGroups where CategoryName = " + group.name
                Dim oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    Dim o = New ReportInfo
                    o.name = oReader("GroupName")
                    oReports.Items.Add(o)
                End While
                oReader.Close()
                oConnection.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If oReports.Items.Count > 0 Then
            oReports.SelectedIndex = 0
        End If
    End Sub

    Private Sub Reports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles oReports.SelectedIndexChanged
        g_oColList.Clear()
        Try
            Dim sQuery As String
            Dim oReader As OdbcDataReader
            Dim report As ReportInfo = oReports.SelectedItem
            If report.id.Length > 0 Then
                sQuery = "SELECT * FROM TBL_ReportColumns WHERE ReportID=" + report.id + " ORDER BY ColSeq"
                Dim oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader

                While oReader.Read()
                    Dim oCol As New ReportColumn
                    If String.Compare(oReader("ColNameInDB"), "timestamp", True) <> 0 Then
                        getColDetails(oReader, oCol)
                        oCol.m_bshowAlarmCol = True
                        g_oColList.Add(oCol)
                    End If
                End While
                oReader.Close()
                oConnection.Close()
            Else
                sQuery = "SELECT * FROM TBL_ReportGroups WHERE ReportName=" + report.name + " ORDER BY ExternalLogId"
                Dim oConnection As New OdbcConnection(g_sConString)
                Dim eConnection As New OdbcConnection(g_sEMSDbConString)
                oConnection.Open()
                eConnection.Open()
                Dim oGroupCmd As New OdbcCommand(sQuery, oConnection)
                Dim oGroupReader = oGroupCmd.ExecuteReader

                While oGroupReader.Read()
                    Dim ExternalLogId = oGroupReader("ExternalLogId")
                    sQuery = "SELECT * FROM TBL_ReportColumns WHERE ColNameInDB = " + ExternalLogId
                    Dim oCmd As New OdbcCommand(sQuery, oConnection)
                    oReader = oCmd.ExecuteReader
                    Dim oCol As New ReportColumn
                    If oReader.Read() Then
                        getColDetails(oReader, oCol)
                    Else
                        oCol.m_sColumnNameinTable = ExternalLogId
                        oCol.m_sColTitle = oGroupReader("ColumnName")
                        'sQuery = "SELECT * from nsp.Trend_Meta where ExternalLogId = " + ExternalLogId
                        'Dim cmd As New OdbcCommand(sQuery, oConnection)
                        'oReader = cmd.ExecuteReader
                        'If oReader.Read() Then
                        '    oCol.m_sColTitle = oReader("Source")
                        '    oCol.m_sColTitle.Split("/").Last
                        'End If
                    End If
                    oCol.m_bshowAlarmCol = True
                    g_oColList.Add(oCol)
                    oReader.Close()
                End While
                oGroupReader.Close()
                oConnection.Close()
                eConnection.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Shared Sub getColDetails(oReader As OdbcDataReader, oCol As ReportColumn)
        oCol.m_nID = oReader("ColumnID")
        Try
            oCol.m_sColType = oReader("ColType")
        Catch ex As Exception
            oCol.m_sColType = ""
        End Try

        Try
            oCol.m_sColTitle = oReader("ColTitle")
        Catch ex As Exception
            oCol.m_sColTitle = ""
        End Try

        Try
            oCol.m_sColWidth = oReader("ColWidth")
        Catch ex As Exception
            oCol.m_sColWidth = 1.0
        End Try

        Try
            oCol.m_nColJust = oReader("ColJust")
        Catch ex As Exception
            oCol.m_nColJust = 0
        End Try

        Try
            oCol.m_sColumnNameinTable = oReader("ColNameInDB")
        Catch ex As Exception
            oCol.m_sColumnNameinTable = ""
        End Try

        Try
            oCol.m_bLowCheck = oReader("LowCheck")
        Catch ex As Exception
            oCol.m_bLowCheck = False
        End Try
        Try
            oCol.m_nLowCheckType = oReader("LowCheckType")
        Catch ex As Exception
            oCol.m_bLowCheck = False
            oCol.m_nLowCheckType = 0
        End Try

        Try
            oCol.m_fLow = oReader("LowCheckValue")
        Catch ex As Exception
            oCol.m_bLowCheck = False
            oCol.m_fLow = 0
        End Try

        Try
            oCol.m_bHighCheck = oReader("HighCheck")
        Catch ex As Exception
            oCol.m_bHighCheck = False
        End Try

        Try
            oCol.m_nHighCheckType = oReader("HighCheckType")
        Catch ex As Exception
            oCol.m_bHighCheck = False
            oCol.m_nHighCheckType = 0
        End Try

        Try
            oCol.m_fHigh = oReader("HighCheckValue")
        Catch ex As Exception
            oCol.m_bHighCheck = False
            oCol.m_fHigh = 0
        End Try

        Try
            oCol.m_bSPCheck = oReader("SetPointCheck")
        Catch ex As Exception
            oCol.m_bSPCheck = False
        End Try

        Try
            oCol.m_nSPCheckType = oReader("SetPointType")
        Catch ex As Exception
            oCol.m_bHighCheck = False
            oCol.m_nSPCheckType = 0
        End Try

        Try
            oCol.m_fSP = oReader("SetPointValue")
        Catch ex As Exception
            oCol.m_bSPCheck = False
            oCol.m_fSP = 0
        End Try

        If oCol.m_nColType = ColType.DateTime Or oCol.m_nColType = ColType.Other Then
            oCol.m_bLowCheck = False
            oCol.m_bHighCheck = False
        End If

        Try
            oCol.m_nEnumID = oReader("enumid")
        Catch ex As Exception
            oCol.m_nEnumID = 0
        End Try


        oCol.m_fReportMax = -9999.0
        oCol.m_fReportMin = 9999.0
        oCol.m_bReportMinAdded = False
        oCol.m_bReportMaxAdded = False
        oCol.m_dKMT = 0.0
        oCol.m_nKMTCount = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SelectColumn.Click
        Dim columnSelector = New dlgSelectColumns
        columnSelector.ShowDialog()
    End Sub

    Private Sub ViewData_Click(sender As Object, e As EventArgs) Handles viewData.Click
        oGrid.Columns.Clear()
        oGrid.Rows.Clear()

        populateData()
    End Sub

    Private Sub populateData()
        colMap = New Dictionary(Of String, Integer)
        Dim oCol = New DataGridViewTextBoxColumn()
        Dim columnIds = ""
        oCol.Name = "Timestamp"
        oCol.Width = 140
        oCol.HeaderCell.Style.WrapMode = DataGridViewTriState.True
        oCol.DefaultCellStyle = New DataGridViewCellStyle
        oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        oGrid.Columns.Add(oCol)

        For Each col In g_oColList
            If col.m_bshowAlarmCol Then
                oCol = New DataGridViewTextBoxColumn()
                oCol.Name = col.m_sColTitle
                If (col.m_sColWidth > 60) Then
                    oCol.Width = col.m_sColWidth
                Else
                    oCol.Width = 100
                End If
                oCol.HeaderCell.Style.WrapMode = DataGridViewTriState.True
                oCol.DefaultCellStyle = New DataGridViewCellStyle
                oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                oGrid.Columns.Add(oCol)
                If columnIds.Length > 0 Then
                    columnIds += ","
                End If
                columnIds += col.m_sColumnNameinTable
                colMap.Add(col.m_sColumnNameinTable, oGrid.Columns.Count - 1)
            End If
        Next
        oGrid.AutoResizeColumnHeadersHeight()

        Dim StartTime = oStartDate.Value.Date + oStartTime.Value.TimeOfDay
        Dim EndTime = oEndDate.Value.Date + oEndTime.Value.TimeOfDay
        Dim includeEventsClause = ""
        If Not oIncludeEvents.Checked Then
            includeEventsClause = " and Event is null "
        End If

        Dim sQuery = "select ExternalSeqNo, ExternalLogId, Timestamp, Value from nsp.Trend_Data where ExternalLogId in (" +
            columnIds +
            ") and Timestamp >= '" +
            StartTime.ToUniversalTime.ToString("s") +
            "' and Timestamp <='" + EndTime.ToUniversalTime.ToString("s") + "'" +
            includeEventsClause +
            " order by Timestamp"

        Dim eConnection As New OdbcConnection(g_sEMSDbConString)
        eConnection.Open()
        Dim oCmd As New OdbcCommand(sQuery, eConnection)
        Dim oReader = oCmd.ExecuteReader
        Dim oLastTime As New DateTime
        Dim index = 0
        Dim currentTime = New DateTime()
        oLastTime = oLastTime.ToUniversalTime()
        While oReader.Read()
            Try
                Dim timestamp = DateTime.Parse(oReader("Timestamp"))
                If (oLastTime > timestamp) Or (timestamp - oLastTime).TotalMilliseconds > oTolerance.Value Then
                    index = oGrid.Rows.Add()
                    oLastTime = timestamp
                    oGrid.Rows(index).Cells(0).Value = DateTime.Parse(timestamp).ToLocalTime.ToString("yyyy/MM/dd hh:mm:ss")
                    If (DateTime.Now - currentTime).TotalSeconds > 2 Then
                        Dim totalDiff = (EndTime - StartTime).TotalSeconds
                        Dim curDiff = (DateTime.Parse(timestamp) - StartTime).TotalSeconds
                        Dim val As String = Math.Ceiling((curDiff * 1.0 / totalDiff) * 100).ToString() + "% complete"
                        CheckInfo.Text = val
                        CheckInfo.Update()
                        currentTime = New DateTime()
                    End If
                End If
                Dim id = oReader("ExternalLogId")
                Dim colId = colMap(id)
                If Not IsDBNull(oReader("Value")) Then
                    If oPrecision.Value < 0 Then
                        oGrid.Rows(index).Cells(colId).Value = oReader("Value")
                    Else
                        oGrid.Rows(index).Cells(colId).value =
                        Math.Round(Double.Parse(oReader("Value")), CType(Math.Ceiling(oPrecision.Value), Integer))
                    End If
                End If
                Dim cellInfo = New CellInfo
                cellInfo.seqNo = oReader("ExternalSeqNo")
                cellInfo.timestamp = DateTime.Parse(timestamp)
                cellInfo.colIndex = colId

                If Not IsDBNull(oReader("Value")) Then
                    cellInfo.value = oReader("Value")
                End If
                oGrid.Rows(index).Cells(colId).Tag = cellInfo
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End While
        oReader.Close()
        eConnection.Close()
        CheckInfo.Text = ""
    End Sub

    Private Sub oGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellContentClick
        oGrid_CurrentCellChanged(sender, e)
    End Sub

    Private Sub dlgTableView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim width = Me.ClientSize.Width
        Dim height = Me.ClientSize.Height
        ColInfo.Width = (width - 50) / 4
        If ColInfo.Width < 100 Then
            ColInfo.Width = 100
        End If
        CheckInfo.Width = ColInfo.Width
        ColQuery.Width = ColInfo.Width
        RowQuery.Width = ColInfo.Width

        ColInfo.Left = 10
        ColInfo.Top = height - 90
        ColInfo.Height = 80

        CheckInfo.Left = ColInfo.Left + ColInfo.Width + 10
        CheckInfo.Top = height - 90
        CheckInfo.Height = 80

        ColQuery.Left = CheckInfo.Left + CheckInfo.Width + 10
        ColQuery.Top = height - 90
        ColQuery.Height = 80

        RowQuery.Left = ColQuery.Left + ColQuery.Width + 10
        RowQuery.Top = height - 90
        RowQuery.Height = 80

        oGrid.Width = width - 40
        oGrid.Left = 20
        oGrid.Height = height - 90 - 100
        oGrid.Top = 90

        oStartDate.Value = Global.EmsBMSReports.My.MySettings.Default.StartDate
        oStartTime.Value = Global.EmsBMSReports.My.MySettings.Default.StartTime
        oEndDate.Value = Global.EmsBMSReports.My.MySettings.Default.EndDate
        oEndTime.Value = Global.EmsBMSReports.My.MySettings.Default.EndTime

    End Sub

    Private Sub oGrid_CurrentCellChanged(sender As Object, e As EventArgs) Handles oGrid.CurrentCellChanged
        Try
            If oGrid.CurrentCell Is Nothing Then
                ColInfo.Text = ""
                CheckInfo.Text = ""
                ColQuery.Text = ""
                RowQuery.Text = ""
                Exit Sub
            End If
            If oGrid.CurrentCell.Tag Is Nothing Then
                ColInfo.Text = ""
                CheckInfo.Text = ""
                ColQuery.Text = ""
                RowQuery.Text = ""
                Exit Sub
            End If
            If oGrid.CurrentCell IsNot Nothing And oGrid.CurrentCell.Tag IsNot Nothing Then
                Dim cellInfo As CellInfo = oGrid.CurrentCell.Tag
                Dim colIndex = cellInfo.colIndex - 1
                Dim seqNo = cellInfo.seqNo
                Dim timestamp = cellInfo.timestamp
                Dim val = ""
                val += "ExternalLogId: " + g_oColList(colIndex).m_sColumnNameinTable + vbNewLine
                val += "Sequence No: " + seqNo + vbNewLine
                val += "Timestamp in DB: " + timestamp.ToString("yyyy/MM/dd hh:mm:ss") + vbNewLine
                ColInfo.Text = val
                val = "Value: " + cellInfo.value + vbNewLine
                If g_oColList(colIndex).m_bLowCheck Then
                    val += "Low Check : " + g_oColList(colIndex).m_fLow.ToString() + vbNewLine
                End If
                If g_oColList(colIndex).m_bHighCheck Then
                    val += "High Check: " + g_oColList(colIndex).m_fHigh.ToString() + vbNewLine
                End If
                CheckInfo.Text = val
                val = "Select * from nsp.Trend_Data where ExternalSEQNO = " + seqNo + vbNewLine
                ColQuery.Text = val
                Dim row = oGrid.Rows(oGrid.CurrentCell.RowIndex)
                Dim seqClause = ""
                For i = 0 To row.Cells.Count - 1
                    If row.Cells(i).Tag Is Nothing Then
                        Continue For
                    End If
                    If row.Cells(i).Tag IsNot Nothing Then
                        Dim c As CellInfo = row.Cells(i).Tag
                        If seqClause.Length > 0 Then
                            seqClause += ","
                        End If
                        seqClause += c.seqNo
                    End If
                Next
                val = "Select * from nsp.Trend_Data where ExternalSEQNO in (" + seqClause + ")"
                RowQuery.Text = val
            Else
                ColInfo.Text = ""
                CheckInfo.Text = ""
                ColQuery.Text = ""
                RowQuery.Text = ""
            End If
        Catch ex As Exception
            ColInfo.Text = ""
            CheckInfo.Text = ""
            ColQuery.Text = ""
            RowQuery.Text = ""
        End Try

    End Sub

    Private Sub oStartDate_ValueChanged(sender As Object, e As EventArgs) Handles oStartDate.ValueChanged
        If isLoaded Then
            Global.EmsBMSReports.My.MySettings.Default.StartDate = oStartDate.Value
        End If
    End Sub

    Private Sub oEndDate_ValueChanged(sender As Object, e As EventArgs) Handles oEndDate.ValueChanged
        If isLoaded Then
            Global.EmsBMSReports.My.MySettings.Default.EndDate = oEndDate.Value
        End If
    End Sub

    Private Sub oStartTime_ValueChanged(sender As Object, e As EventArgs) Handles oStartTime.ValueChanged
        If isLoaded Then
            Global.EmsBMSReports.My.MySettings.Default.StartTime = oStartTime.Value
        End If
    End Sub

    Private Sub oEndTime_ValueChanged(sender As Object, e As EventArgs) Handles oEndTime.ValueChanged
        If isLoaded Then
            Global.EmsBMSReports.My.MySettings.Default.EndTime = oEndTime.Value
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles oPrecision.ValueChanged
        If isLoaded Then
            Global.EmsBMSReports.My.MySettings.Default.Precision = oPrecision.Value
        End If
    End Sub

    Private Sub oTolerance_ValueChanged(sender As Object, e As EventArgs) Handles oTolerance.ValueChanged
        If isLoaded Then
            Global.EmsBMSReports.My.MySettings.Default.Tolerance = oTolerance.Value
        End If
    End Sub

    Private Sub CheckInfo_TextChanged(sender As Object, e As EventArgs) Handles CheckInfo.TextChanged
        If CheckInfo.Text.Length = 0 Then
            Dim i = 0
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles oIncludeEvents.CheckedChanged
        If isLoaded Then
            If oIncludeEvents.Checked Then
                Global.EmsBMSReports.My.MySettings.Default.IncludeEvents = "1"
            Else
                Global.EmsBMSReports.My.MySettings.Default.IncludeEvents = "0"
            End If
        End If

    End Sub
    Private Sub RowQuery_MouseClick(sender As Object, e As MouseEventArgs) Handles RowQuery.MouseClick
        Try
            ToolTip2.Active = True
            Clipboard.SetText(RowQuery.Text)
            ToolTip2.UseFading = True
            ToolTip2.AutomaticDelay = 1
            ToolTip2.AutoPopDelay = 1000
            ToolTip2.InitialDelay = 1
            ToolTip2.IsBalloon = True
            ToolTip2.Show("Query copied", RowQuery, 1000)
            Timer1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ColQuery_MouseClick(sender As Object, e As MouseEventArgs) Handles ColQuery.MouseClick
        Try
            ToolTip1.Active = True
            Clipboard.SetText(ColQuery.Text)
            ToolTip1.AutomaticDelay = 1
            ToolTip1.AutoPopDelay = 1000
            ToolTip1.InitialDelay = 1
            ToolTip1.IsBalloon = True
            ToolTip1.Show("Query copied", ColQuery, 1000)
            Timer1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tp_Popup(sender As Object, e As PopupEventArgs)

    End Sub

    Private Sub tp_Disposed(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolTip1.Active = False
        ToolTip2.Active = False
    End Sub
End Class
