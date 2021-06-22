Imports System.Windows.Forms
Imports System.Data.Odbc
Imports MactusReportLib

Public Class DlgSelectReportGroupTemplate
    Public m_bAlarmGroup As Boolean = False
    Private Sub DlgSelectReportGroupTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bAddNewGroup.Visible = Not m_bAlarmGroup

        LoadTemplateCombobox()
        LoadGroupCombobox()

    End Sub


    Public Sub LoadTemplateCombobox()
        Dim sQuery As String
        Dim oReader As OdbcDataReader

        sQuery = "SELECT * FROM tbl_reporttemplates order by templateid"

        Using oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            While (oReader.Read())
                cTemplate.Items.Add(oReader("templatename"))
            End While
            oConnection.Close()
        End Using


    End Sub


    Public Sub LoadGroupCombobox()
        If m_bAlarmGroup And g_bIsBMS = False Then
            LoadAlarmGroupComboboxIndusoft()
            Exit Sub
        End If


        Dim sQuery As String
        Dim oReader As OdbcDataReader
        cGroup.Items.Clear()
        If m_bAlarmGroup Then
            sQuery = "SELECT * FROM tbl_datagroups WHERE grouptype<>0 order by groupid"
        Else
            sQuery = "SELECT * FROM tbl_datagroups WHERE grouptype=0 order by groupid"
        End If


        Using oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            While (oReader.Read())
                If m_bAlarmGroup And oReader("groupid") = 0 Then
                    cGroup.Items.Add(oReader("All Alarms"))
                Else
                    cGroup.Items.Add(oReader("groupname"))
                End If
            End While
            oConnection.Close()
        End Using


    End Sub


    Public Sub LoadAlarmGroupComboboxIndusoft()
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        cGroup.Items.Clear()
        Dim nGroupID As Integer

        sQuery = "SELECT DISTINCT Al_Group from ALARMHISTORY where Al_Group IS NOT NULL"
        Using oConnection As New OdbcConnection(g_sEMSDbConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            While (oReader.Read())
                nGroupID = oReader("Al_Group")
                If AlarmGroupReportNotCreated(nGroupID) Then
                    cGroup.Items.Add(nGroupID.ToString)
                End If

            End While
            oConnection.Close()
        End Using


    End Sub
    Private Function AlarmGroupReportNotCreated(ByRef nGroupID As Integer) As Boolean
        AlarmGroupReportNotCreated = False
        Dim sQuery As String
        Dim nCount As Integer = 0
        Try
            sQuery = "SELECT COUNT(*) FROM TBL_ReportsConfiguration where ReportType=2 and AlmGroupID=" + nGroupID.ToString()
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                nCount = oCmd.ExecuteScalar()

                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
        AlarmGroupReportNotCreated = Not CBool(nCount)
    End Function
    Private Sub cTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTemplate.SelectedIndexChanged
        If cTemplate.SelectedIndex = -1 Or cGroup.SelectedIndex = -1 Or tReportTitle.Text.Length < 5 Then
            bAdd.Enabled = False
        Else
            bAdd.Enabled = True
        End If
    End Sub

    Private Sub cGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cGroup.SelectedIndexChanged
        If cTemplate.SelectedIndex = -1 Or cGroup.SelectedIndex = -1 Or tReportTitle.Text.Length < 5 Then
            bAdd.Enabled = False
        Else
            bAdd.Enabled = True
        End If
    End Sub

    Private Sub tReportTitle_TextChanged(sender As Object, e As EventArgs) Handles tReportTitle.TextChanged
        If cTemplate.SelectedIndex = -1 Or cGroup.SelectedIndex = -1 Or tReportTitle.Text.Length < 5 Then
            bAdd.Enabled = False
        Else
            bAdd.Enabled = True
        End If
    End Sub

    Private Sub bAddNewGroup_Click(sender As Object, e As EventArgs) Handles bAddNewGroup.Click
        Dim oDlg As New DlgNewGroup
        If oDlg.ShowDialog() = DialogResult.OK Then
            LoadGroupCombobox()
        End If
    End Sub

    Private Sub bAdd_Click(sender As Object, e As EventArgs) Handles bAdd.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
