Imports System.Data.Odbc
Imports System.Windows.Forms
Imports MactusReportLib.MactusReportLib

Public Class DlgConfigureAlarmReportColumns

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgConfigureAlarmReportColumns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        oGrid.Rows.Clear()
        Try
            sQuery = "SELECT * FROM tbl_reportcolumns WHERE reportid=-2 ORDER BY colseq"

            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    Dim nColType As ColType
                    Dim nColJust As ColJust
                    nColType = oReader("coltype")
                    nColJust = oReader("coljust")

                    nRow = oGrid.Rows.Add()
                    oGrid.Rows(nRow).Cells(0).Value = oReader("columnid")
                    oGrid.Rows(nRow).Cells(1).Value = oReader("colnameindb")
                    oGrid.Rows(nRow).Cells(2).Value = nColType.ToString()
                    oGrid.Rows(nRow).Cells(3).Value = oReader("colwidth")
                    oGrid.Rows(nRow).Cells(4).Value = oReader("colformat")
                    oGrid.Rows(nRow).Cells(5).Value = nColJust.ToString()
                    oGrid.Rows(nRow).Cells(6).Value = oReader("coltitle")

                    oGrid.Rows(nRow).Cells(7).Value = CBool(oReader("enumid"))


                End While
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub oGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles oGrid.DataError

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

    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click
        If MessageBox.Show("Do You Really Want To Save Changes?", "Reports Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim sQuery As String
            Dim nRow As Integer
            Dim nColJust As ColJust
            Try
                For nRow = 0 To oGrid.Rows.Count - 1
                    sQuery = "UPDATE  tbl_reportcolumns SET colnameindb=?,colwidth=?,colformat=?,coljust=?,coltitle=?,enumid=?,colseq=? WHERE reportid=-2 AND columnid=?"

                    Using oConnection As New OdbcConnection(g_sConString)
                        oConnection.Open()
                        Dim oCmd As New OdbcCommand(sQuery, oConnection)
                        oCmd.Parameters.Add("@0", OdbcType.VarChar).Value = oGrid.Rows(nRow).Cells(1).Value 'ColNameInDB
                        oCmd.Parameters.Add("@1", OdbcType.Int).Value = oGrid.Rows(nRow).Cells(3).Value 'colwidth
                        oCmd.Parameters.Add("@2", OdbcType.VarChar).Value = oGrid.Rows(nRow).Cells(4).Value 'colformat
                        nColJust = [Enum].Parse(GetType(ColJust), oGrid.Rows(nRow).Cells(5).Value.ToString())
                        oCmd.Parameters.Add("@3", OdbcType.Int).Value = nColJust 'coljust
                        oCmd.Parameters.Add("@4", OdbcType.VarChar).Value = oGrid.Rows(nRow).Cells(6).Value 'coltitle
                        If oGrid.Rows(nRow).Cells(7).Value Then
                            oCmd.Parameters.Add("@5", OdbcType.Int).Value = 1 'enumid
                        Else
                            oCmd.Parameters.Add("@5", OdbcType.Int).Value = 0 'enumid
                        End If
                        oCmd.Parameters.Add("@6", OdbcType.Int).Value = nRow + 1 'colseq
                        oCmd.Parameters.Add("@7", OdbcType.Int).Value = oGrid.Rows(nRow).Cells(0).Value 'columnid

                        oCmd.ExecuteNonQuery()
                        oConnection.Close()
                    End Using
                Next

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class
