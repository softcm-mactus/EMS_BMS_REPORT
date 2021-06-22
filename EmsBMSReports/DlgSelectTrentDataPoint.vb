Imports System.Windows.Forms
Imports System.Data.Odbc
Imports MactusReportLib

Public Class DlgSelectTrentDataPoint
    Public m_nLogID As Integer
    Public m_sPointName As String
    Public m_sPointType As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        m_nLogID = oGrid.SelectedRows(0).Cells(0).Value
        m_sPointType = oGrid.SelectedRows(0).Cells(1).Value
        m_sPointName = oGrid.SelectedRows(0).Cells(2).Value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        m_nLogID = 0

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub RefreshGrid()
        Dim oReader As OdbcDataReader
        Dim sQuery As String = ""
        Dim nLogID As Integer
        Dim sPointName As String

        Dim nRow As Integer

        oGrid.Rows.Clear()
        Try
            If bGetSimilorPoints.Checked And tPointName.Text.Length > 2 Then
                sQuery = "SELECT * FROM tbl_pointidname where pointname like '%" + tPointName.Text + "%' ORDER BY id"
            Else
                sQuery = "SELECT * FROM tbl_pointidname ORDER BY id"
            End If
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    nLogID = oReader("id")
                    sPointName = oReader("pointname")

                    If bHide.Checked = True Then
                        If IsTrendLogAlreadyUsed(nLogID) = False Then
                            nRow = oGrid.Rows.Add()
                            oGrid.Rows(nRow).Cells(0).Value = nLogID
                            oGrid.Rows(nRow).Cells(1).Value = ""
                            oGrid.Rows(nRow).Cells(2).Value = sPointName
                        End If
                    Else
                        nRow = oGrid.Rows.Add()
                        oGrid.Rows(nRow).Cells(0).Value = nLogID
                        oGrid.Rows(nRow).Cells(1).Value = ""
                        oGrid.Rows(nRow).Cells(2).Value = sPointName
                    End If
                End While
                oConnection.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message + "  " + sQuery)
        End Try

    End Sub



    Private Sub DlgSelectTrentDataPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RefreshGrid()


    End Sub
    Private Function IsTrendLogAlreadyUsed(ByRef nLogID As Integer) As Boolean
        IsTrendLogAlreadyUsed = False
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Try
            sQuery = "SELECT * FROM tbl_reportcolumns where colnameindb='" + nLogID.ToString() + "'"
            Using oConnection As New OdbcConnection(g_sConString)

                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                If (oReader.Read()) Then
                    IsTrendLogAlreadyUsed = True
                End If

                oConnection.Close()

            End Using
        Catch ex As Exception

        End Try
    End Function

    Private Function IsTrendLogAlreadyUsed(ByRef sLogID As String) As Boolean
        IsTrendLogAlreadyUsed = False
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Try
            sQuery = "SELECT * FROM tbl_reportcolumns where colnameindb='" + sLogID + "'"
            Using oConnection As New OdbcConnection(g_sConString)

                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                If (oReader.Read()) Then
                    IsTrendLogAlreadyUsed = True
                End If

                oConnection.Close()

            End Using
        Catch ex As Exception

        End Try
    End Function

    Private Sub oGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellClick
        If oGrid.SelectedRows.Count <= 0 Then
            OK_Button.Enabled = False
        Else
            OK_Button.Enabled = True
        End If
    End Sub

    Private Sub bHide_CheckedChanged(sender As Object, e As EventArgs) Handles bHide.CheckedChanged
        RefreshGrid()
    End Sub

    Private Sub tPointName_TextChanged(sender As Object, e As EventArgs) Handles tPointName.TextChanged
        If tPointName.Text.Length > 0 Then
            RefreshGrid()
        End If
    End Sub
End Class
