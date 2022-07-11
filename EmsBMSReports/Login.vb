Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports MactusReportLib

Public Class Login


    Private Sub btLoginLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoginLogin.Click
        Try
            If ((UserID.Text = "ADMIN123" Or UserID.Text = "SUPERADMIN" Or UserID.Text = "MACTUS") And (UsrPassword.Text = "Password@123" Or UsrPassword.Text = "Admin@123" Or UsrPassword.Text = "Mactus@123")) Then


            End If

        Catch ex As Exception

        End Try
        'CheckUserLogin(UserID.Text, UsrPassword.Text)
    End Sub


    Private Sub btLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        g_sCurrent_login_UserID = ""
        UserID.Text = ""
        UsrPassword.Text = ""
    End Sub

    Private Sub Login_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = ""
        btLoginLogin.Enabled = False



    End Sub

    Private Sub UserID_TextChanged(sender As Object, e As EventArgs) Handles UserID.TextChanged
        If UserID.Text.Length >= 6 And UserID.Text.Length <= 12 And UsrPassword.Text.Length > 6 Then
            btLoginLogin.Enabled = True
        Else
            btLoginLogin.Enabled = False
        End If
    End Sub

    Private Sub UsrPassword_TextChanged(sender As Object, e As EventArgs) Handles UsrPassword.TextChanged
        If UserID.Text.Length >= 6 And UserID.Text.Length <= 12 And UsrPassword.Text.Length > 6 Then
            btLoginLogin.Enabled = True
        Else
            btLoginLogin.Enabled = False
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class

