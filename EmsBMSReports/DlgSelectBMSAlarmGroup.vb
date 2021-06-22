Imports System.Windows.Forms
Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib

Public Class DlgSelectBMSAlarmGroup

    Public m_sGroupName As String
    Private Sub DlgSelectBMSAlarmGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SynchronizeAlarmGroupName()
        Dim sQuery As String = "SELECT * FROM tbl_datagroups WHERE grouptype<>0 ORDER BY groupid"
        Dim oReader As OdbcDataReader
        Try
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    oGroup.Items.Add(oReader("groupname"))
                End While
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub oGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles oGroup.SelectedIndexChanged
        Try
            m_sGroupName = oGroup.SelectedItem.ToString
        Catch ex As Exception
            m_sGroupName = ""
        End Try
        If m_sGroupName.Length > 0 Then

        End If

    End Sub
End Class
