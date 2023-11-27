Imports System.Windows.Forms
Imports System.Data.Odbc
Imports MactusReportLib

Public Class DlgSelectEnumID

    Public m_nEnumID As Integer

    Private Sub DlgSelectEnumID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGrid()
    End Sub
    Private Sub RefreshGrid()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nRow As Integer

        oGrid.Rows.Clear()
        Try
            sQuery = "SELECT * FROM tbl_enumvalue  ORDER BY enumid"

            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()

                    nRow = oGrid.Rows.Add()
                    oGrid.Rows(nRow).Cells(0).Value = True
                    oGrid.Rows(nRow).Cells(1).Value = oReader("enumid")
                    oGrid.Rows(nRow).Cells(2).Value = oReader("enumvalue")
                    oGrid.Rows(nRow).Cells(3).Value = oReader("enumdesc")
                    oGrid.Rows(nRow).Cells(1).ReadOnly = True
                    oGrid.Rows(nRow).Cells(1).Style.BackColor = Color.LightGray
                    oGrid.Rows(nRow).Cells(2).ReadOnly = True
                    oGrid.Rows(nRow).Cells(2).Style.BackColor = Color.LightGray

                End While
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click
        Dim sQuery As String
        For nRow = 0 To oGrid.Rows.Count - 1
            If oGrid.Rows(nRow).Cells(0).Value Then
                If oGrid.Rows(nRow).Cells(3).Value.ToString().Length > 2 Then
                    sQuery = "UPDATE tbl_enumvalue SET enumdesc='" + oGrid.Rows(nRow).Cells(3).Value.ToString() + "' WHERE enumid=" + oGrid.Rows(nRow).Cells(1).Value.ToString() + " AND enumvalue=" + oGrid.Rows(nRow).Cells(2).Value.ToString()
                    ExecuteSQLInDb(sQuery)
                End If
            Else
                Try

                    If oGrid.Rows(nRow).Cells(1).Value.ToString().Length >= 1 And oGrid.Rows(nRow).Cells(2).Value.ToString().Length >= 1 And oGrid.Rows(nRow).Cells(3).Value.ToString().Length >= 2 Then

                        sQuery = " INSERT INTO tbl_enumvalue (enumid,enumvalue,enumdesc) VALUES(" + oGrid.Rows(nRow).Cells(1).Value.ToString() + "," + oGrid.Rows(nRow).Cells(2).Value.ToString() + ",'" + oGrid.Rows(nRow).Cells(3).Value.ToString() + " ')"
                        If ExecuteSQLInDb(sQuery) Then
                            oGrid.Rows(nRow).Cells(1).Value = True
                        End If
                    End If

                Catch ex As Exception

                End Try
            End If

        Next

        RefreshGrid()
    End Sub

    Private Sub oGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellClick
        If e.RowIndex = 1 Then
            Exit Sub
        End If
        If oGrid.Rows(e.RowIndex).Cells(0).Value Then
            bSelect.Enabled = True
            m_nEnumID = oGrid.Rows(e.RowIndex).Cells(1).Value
        Else
            bSelect.Enabled = False
            m_nEnumID = -1
        End If
    End Sub
End Class
