Imports System.Windows.Forms
Imports MactusReportLib

Public Class DlgNewGroup

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If GetGroupID(tGroupName.Text) > 0 Then
            MessageBox.Show("Group Name Already Exist.", "Add NEw Data Trend Group", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            AddNewDataTrendGroup(tGroupName.Text)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub tGroupName_TextChanged(sender As Object, e As EventArgs) Handles tGroupName.TextChanged
        If tGroupName.Text.Length <= 2 Then
            OK_Button.Enabled = False
        Else
            OK_Button.Enabled = True
        End If
    End Sub
End Class
