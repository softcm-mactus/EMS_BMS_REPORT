Imports System.Data.Odbc
Imports System.Windows.Forms
Imports MactusReportLib.MactusReportLib

Public Class dlgColumnsConfiguration
    Public m_nReportID As Integer = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If MessageBox.Show("Do You Really Want To Save Changes?", "Reports Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim nColID As Integer
            Dim nTemp As Integer
            For nRow = 0 To oGrid.Rows.Count - 1
                nTemp = nRow + 1
                nColID = oGrid.Rows(nRow).Cells(0).Value
                If nColID <= 0 Then
                    nColID = InsertNewColumn(nRow)
                    oGrid.Rows(nRow).Cells(0).Value = nColID
                Else
                    UpdateColumnData(nRow)
                End If
            Next

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If


    End Sub
    Private Sub UpdateColumnData(ByVal nRow As Integer)

        Dim sQuery As String
        sQuery = "Update tbl_reportcolumns SET "
        sQuery += "ColNameInDB ='" + oGrid.Rows(nRow).Cells(1).Value.ToString() + "',"
        sQuery += "colseq =" + (nRow + 2).ToString() + ","

        Dim nColType As ColType = [Enum].Parse(GetType(ColType), oGrid.Rows(nRow).Cells(2).Value.ToString())
        sQuery += "coltype=" + Str(nColType) + ","

        sQuery += "colwidth =" + oGrid.Rows(nRow).Cells(3).Value.ToString() + ","
        sQuery += "colformat ='" + oGrid.Rows(nRow).Cells(4).Value.ToString() + "',"

        Dim nColJust As ColJust = [Enum].Parse(GetType(ColJust), oGrid.Rows(nRow).Cells(5).Value.ToString())
        sQuery += "coljust=" + Str(nColJust) + ","

        sQuery += "colheader ='" + oGrid.Rows(nRow).Cells(6).Value.ToString() + "',"
        sQuery += "coltitle ='" + oGrid.Rows(nRow).Cells(7).Value.ToString() + "',"


        If oGrid.Rows(nRow).Cells(8).Value Then
            If oGrid.Rows(nRow).Cells(9).Value Then
                sQuery += "lowcheck=1,lowchecktype=1,lowcheckvalue=" + oGrid.Rows(nRow).Cells(10).Value.ToString() + ","
            Else
                sQuery += "lowcheck=1,lowchecktype=0,lowcheckvalue=" + oGrid.Rows(nRow).Cells(10).Value.ToString() + ","
            End If
        Else
            sQuery += "lowcheck=0,lowcheckvalue=0,lowchecktype=0,"
        End If

        If oGrid.Rows(nRow).Cells(11).Value Then
            If oGrid.Rows(nRow).Cells(12).Value Then
                sQuery += "highcheck=1,highchecktype=1,highcheckvalue=" + oGrid.Rows(nRow).Cells(13).Value.ToString() + ","
            Else
                sQuery += "highcheck=1,highchecktype=0,highcheckvalue=" + oGrid.Rows(nRow).Cells(13).Value.ToString() + ","
            End If
        Else
            sQuery += "highcheck=0,highcheckvalue=0,highchecktype=0,"
        End If

        If oGrid.Rows(nRow).Cells(16).Value Then
            If oGrid.Rows(nRow).Cells(17).Value Then
                sQuery += "setpointcheck=1,setpointtype=1,setpointvalue=" + oGrid.Rows(nRow).Cells(18).Value.ToString() + ","
            Else
                sQuery += "setpointcheck=1,setpointtype=0,setpointvalue=" + oGrid.Rows(nRow).Cells(18).Value.ToString() + ","
            End If
        Else
            sQuery += "setpointcheck=0,setpointtype=0,setpointvalue=0,"
        End If

        sQuery += "colmerge =" + oGrid.Rows(nRow).Cells(15).Value.ToString() + ","
        sQuery += "enumid =" + oGrid.Rows(nRow).Cells(14).Value.ToString() + " WHERE columnid =" + oGrid.Rows(nRow).Cells(0).Value.ToString()

        ExecuteSQLInDb(sQuery)

    End Sub

    Private Function InsertNewColumn(ByRef nRow As Integer) As Integer
        InsertNewColumn = 0
        Dim sQuery As String
        Dim nColID As Integer

        nColID = GetNewColumnID()

        sQuery = "INSERT INTO tbl_reportcolumns(columnid,reportid, colnameindb, colseq, coltype, colwidth, colformat, coljust, colheader, coltitle, lowcheck,lowchecktype, lowcheckvalue, highcheck,highchecktype, highcheckvalue,setpointcheck,setpointtype,setpointvalue, enumid, colmerge) "
        sQuery += "	VALUES ( " + nColID.ToString() + "," + m_nReportID.ToString()
        sQuery += ",'" + oGrid.Rows(nRow).Cells(1).Value.ToString() + "'"
        sQuery += "," + (nRow + 2).ToString()

        Dim nColType As ColType = [Enum].Parse(GetType(ColType), oGrid.Rows(nRow).Cells(2).Value.ToString())
        sQuery += "," + Str(nColType)
        sQuery += "," + oGrid.Rows(nRow).Cells(3).Value.ToString() 'colwidth
        sQuery += ",'" + oGrid.Rows(nRow).Cells(4).Value.ToString() + "'" 'colformat


        Dim nColJust As ColJust = [Enum].Parse(GetType(ColJust), oGrid.Rows(nRow).Cells(5).Value.ToString())
        sQuery += "," + Str(nColJust)

        sQuery += ",'" + oGrid.Rows(nRow).Cells(6).Value.ToString() + "'" 'colheader
        sQuery += ",'" + oGrid.Rows(nRow).Cells(7).Value.ToString() + "'" 'coltitle

        If oGrid.Rows(nRow).Cells(8).Value Then
            If oGrid.Rows(nRow).Cells(9).Value Then
                sQuery += ",1,1," + oGrid.Rows(nRow).Cells(10).Value.ToString()
            Else
                sQuery += ",1,0," + oGrid.Rows(nRow).Cells(10).Value.ToString()
            End If
        Else
            sQuery += ",0,0,0"
        End If

        If oGrid.Rows(nRow).Cells(11).Value Then
            If oGrid.Rows(nRow).Cells(12).Value Then
                sQuery += ",1,1," + oGrid.Rows(nRow).Cells(13).Value.ToString()
            Else
                sQuery += ",1,0," + oGrid.Rows(nRow).Cells(13).Value.ToString()
            End If
        Else
            sQuery += ",0,0,0"
        End If

        If oGrid.Rows(nRow).Cells(16).Value Then
            If oGrid.Rows(nRow).Cells(17).Value Then
                sQuery += ",1,1," + oGrid.Rows(nRow).Cells(18).Value.ToString()
            Else
                sQuery += ",1,0," + oGrid.Rows(nRow).Cells(18).Value.ToString()
            End If
        Else
            sQuery += ",0,0,0"
        End If

        sQuery += "," + oGrid.Rows(nRow).Cells(14).Value.ToString() + "," + oGrid.Rows(nRow).Cells(15).Value.ToString() + ")"
        Try
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oCmd.ExecuteNonQuery()

                oConnection.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function



    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgColumnsConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        oGrid.Rows.Clear()
        Try
            sQuery = "SELECT * FROM tbl_reportcolumns WHERE reportid=" + m_nReportID.ToString() + " ORDER BY colseq"

            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    Dim nColType As ColType
                    Dim nColJust As ColJust
                    nColType = oReader("coltype")
                    nColJust = oReader("coljust")
                    If nColType <> MactusReportLib.ColType.DateTime Then
                        nRow = oGrid.Rows.Add()
                        oGrid.Rows(nRow).Cells(0).Value = oReader("columnid")
                        oGrid.Rows(nRow).Cells(1).Value = oReader("colnameindb")
                        oGrid.Rows(nRow).Cells(2).Value = nColType.ToString()
                        oGrid.Rows(nRow).Cells(3).Value = oReader("colwidth")
                        oGrid.Rows(nRow).Cells(4).Value = oReader("colformat")
                        oGrid.Rows(nRow).Cells(5).Value = nColJust.ToString()
                        oGrid.Rows(nRow).Cells(6).Value = oReader("colheader")
                        oGrid.Rows(nRow).Cells(7).Value = oReader("coltitle")
                        oGrid.Rows(nRow).Cells(8).Value = CBool(oReader("lowcheck"))
                        oGrid.Rows(nRow).Cells(9).Value = CBool(oReader("lowcheckType"))
                        oGrid.Rows(nRow).Cells(10).Value = oReader("lowcheckvalue")

                        oGrid.Rows(nRow).Cells(11).Value = CBool(oReader("highcheck"))
                        oGrid.Rows(nRow).Cells(12).Value = CBool(oReader("highchecktype"))
                        oGrid.Rows(nRow).Cells(13).Value = oReader("highcheckvalue")

                        oGrid.Rows(nRow).Cells(14).Value = oReader("enumid")
                        oGrid.Rows(nRow).Cells(15).Value = oReader("colmerge")

                        oGrid.Rows(nRow).Cells(16).Value = CBool(oReader("SetPointCheck"))
                        oGrid.Rows(nRow).Cells(17).Value = CBool(oReader("SetPointType"))
                        oGrid.Rows(nRow).Cells(18).Value = oReader("SetPointValue")



                    End If
                End While
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub oGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles oGrid.DataError

    End Sub

    Private Sub bDeleteColumn_Click(sender As Object, e As EventArgs) Handles bDeleteColumn.Click
        Dim nColID As Integer
        Dim sColTitle As String
        Dim sQuery As String

        If oGrid.SelectedRows.Count <= 0 Then
            MsgBox("No Row Selected")
            Exit Sub
        End If
        For nRow = 0 To oGrid.SelectedRows.Count - 1
            nColID = oGrid.SelectedRows(nRow).Cells(0).Value
            sColTitle = oGrid.SelectedRows(nRow).Cells(6).Value
            If nColID > 0 Then
                If MessageBox.Show(sColTitle + " : Do you Really Want To Delete The  Column?", "Columns Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    sQuery = "DELETE FROM tbl_reportcolumns WHERE columnid=" + nColID.ToString()
                    ExecuteSQLInDb(sQuery)

                    RefreshGrid()

                End If
            Else
                MessageBox.Show(sColTitle + " :New Column Not Yet Saved In The Database?", "Columns Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Next
    End Sub

    Private Sub bAddNewColumn_Click(sender As Object, e As EventArgs) Handles bAddNewColumn.Click

        Dim oDlg As New DlgSelectTrentDataPoint



        Dim nRow As Integer
        If oDlg.ShowDialog() = DialogResult.OK And oDlg.m_nLogID > 0 Then

            Dim bFound As Boolean = False
            If g_bIsBMS Then
                For nRow = 0 To oGrid.Rows.Count - 1
                    If oDlg.m_nLogID = oGrid.Rows(nRow).Cells(1).Value Then
                        bFound = True
                    End If
                Next
            Else
                For nRow = 0 To oGrid.Rows.Count - 1
                    If oDlg.m_sPointName = oGrid.Rows(nRow).Cells(1).Value Then
                        bFound = True
                    End If
                Next
            End If


            If bFound = False Then
                nRow = oGrid.Rows.Add
                oGrid.Rows(nRow).Cells(0).Value = 0
                If g_bIsBMS Then
                    oGrid.Rows(nRow).Cells(1).Value = oDlg.m_nLogID
                Else
                    oGrid.Rows(nRow).Cells(1).Value = oDlg.m_sPointName
                End If
                oGrid.Rows(nRow).Cells(2).Value = MactusReportLib.ColType.Other.ToString()
                oGrid.Rows(nRow).Cells(3).Value = 1.0
                oGrid.Rows(nRow).Cells(4).Value = ""
                oGrid.Rows(nRow).Cells(5).Value = MactusReportLib.ColJust.Center.ToString()
                oGrid.Rows(nRow).Cells(6).Value = oDlg.m_sPointName
                oGrid.Rows(nRow).Cells(7).Value = oDlg.m_sPointType

                oGrid.Rows(nRow).Cells(8).Value = False
                oGrid.Rows(nRow).Cells(9).Value = False
                oGrid.Rows(nRow).Cells(10).Value = 0

                oGrid.Rows(nRow).Cells(11).Value = False
                oGrid.Rows(nRow).Cells(12).Value = False
                oGrid.Rows(nRow).Cells(13).Value = 0

                oGrid.Rows(nRow).Cells(14).Value = 0
                oGrid.Rows(nRow).Cells(15).Value = 0

                oGrid.Rows(nRow).Cells(16).Value = False
                oGrid.Rows(nRow).Cells(17).Value = False
                oGrid.Rows(nRow).Cells(18).Value = 0



            Else
                MessageBox.Show("Trend Log Point is Already Added To The Report")
            End If
        End If

    End Sub

    Private Sub oGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.ColumnIndex = 14 Then
            If oGrid.Rows(e.RowIndex).Cells(2).Value = "Enumtype" Then
                Dim oDlg As New DlgSelectEnumID()
                If oDlg.ShowDialog() = DialogResult.OK Then
                    oGrid.Rows(e.RowIndex).Cells(14).Value = oDlg.m_nEnumID
                End If
            Else
                oGrid.Rows(e.RowIndex).Cells(14).Value = 0
            End If
        ElseIf e.ColumnIndex = 13 Then
            If oGrid.Rows(e.RowIndex).Cells(12).Value Then
                Dim oDlg As New DlgSelectTrentDataPoint
                If oDlg.ShowDialog() = DialogResult.OK Then
                    oGrid.Rows(e.RowIndex).Cells(13).Value = oDlg.m_nLogID
                End If
            End If
        ElseIf e.ColumnIndex = 10 Then
            If oGrid.Rows(e.RowIndex).Cells(9).Value Then
                Dim oDlg As New DlgSelectTrentDataPoint
                If oDlg.ShowDialog() = DialogResult.OK Then
                    oGrid.Rows(e.RowIndex).Cells(10).Value = oDlg.m_nLogID
                End If
            End If
        ElseIf e.ColumnIndex = 18 Then
            If oGrid.Rows(e.RowIndex).Cells(17).Value Then
                Dim oDlg As New DlgSelectTrentDataPoint
                If oDlg.ShowDialog() = DialogResult.OK Then
                    oGrid.Rows(e.RowIndex).Cells(18).Value = oDlg.m_nLogID
                End If
            End If
        ElseIf e.ColumnIndex = 1 Then
            Dim oDlg As New DlgSelectTrentDataPoint
            If oDlg.ShowDialog() = DialogResult.OK Then
                If g_bIsBMS Then
                    oGrid.Rows(e.RowIndex).Cells(1).Value = oDlg.m_nLogID
                Else
                    oGrid.Rows(e.RowIndex).Cells(1).Value = oDlg.m_sPointName
                End If
            End If

            End If

    End Sub

    Private Sub bMoveUp_Click(sender As Object, e As EventArgs) Handles bMoveUp.Click
        Dim nRowIndex As Integer

        Try
            nRowIndex = oGrid.SelectedRows(0).Index
            Dim oTemp As Object
            For nCol = 0 To oGrid.Columns.Count - 1
                Try
                    oTemp = oGrid.Rows(nRowIndex).Cells(nCol).Value
                    oGrid.Rows(nRowIndex).Cells(nCol).Value = oGrid.Rows(nRowIndex - 1).Cells(nCol).Value
                    oGrid.Rows(nRowIndex - 1).Cells(nCol).Value = oTemp

                Catch ex As Exception

                End Try
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub oGrid_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.RowEnter
        If e.RowIndex = 0 Then
            bMoveUp.Enabled = False
        Else
            bMoveUp.Enabled = True
        End If
        If e.RowIndex = oGrid.Rows.Count - 1 Then
            bMoveDown.Enabled = False
        Else
            bMoveDown.Enabled = True
        End If
    End Sub

    Private Sub bMoveDown_Click(sender As Object, e As EventArgs) Handles bMoveDown.Click
        Dim nRowIndex As Integer

        Try
            nRowIndex = oGrid.SelectedRows(0).Index
            Dim oTemp As Object
            For nCol = 0 To oGrid.Columns.Count - 1
                Try
                    oTemp = oGrid.Rows(nRowIndex).Cells(nCol).Value
                    oGrid.Rows(nRowIndex).Cells(nCol).Value = oGrid.Rows(nRowIndex + 1).Cells(nCol).Value
                    oGrid.Rows(nRowIndex + 1).Cells(nCol).Value = oTemp

                Catch ex As Exception

                End Try
            Next

        Catch ex As Exception

        End Try
    End Sub


End Class
