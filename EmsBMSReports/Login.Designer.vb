<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btLoginLogin = New System.Windows.Forms.Button()
        Me.UsrPassword = New System.Windows.Forms.TextBox()
        Me.UserID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btCreateTables = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btLoginLogin
        '
        Me.btLoginLogin.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btLoginLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLoginLogin.Location = New System.Drawing.Point(411, 343)
        Me.btLoginLogin.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btLoginLogin.Name = "btLoginLogin"
        Me.btLoginLogin.Size = New System.Drawing.Size(147, 43)
        Me.btLoginLogin.TabIndex = 21
        Me.btLoginLogin.Text = "Login"
        Me.btLoginLogin.UseVisualStyleBackColor = True
        '
        'UsrPassword
        '
        Me.UsrPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsrPassword.Location = New System.Drawing.Point(380, 256)
        Me.UsrPassword.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UsrPassword.MaxLength = 16
        Me.UsrPassword.Name = "UsrPassword"
        Me.UsrPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UsrPassword.Size = New System.Drawing.Size(397, 34)
        Me.UsrPassword.TabIndex = 20
        '
        'UserID
        '
        Me.UserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserID.Location = New System.Drawing.Point(380, 150)
        Me.UserID.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UserID.Name = "UserID"
        Me.UserID.Size = New System.Drawing.Size(397, 34)
        Me.UserID.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(261, 265)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(275, 158)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 25)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "User ID"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.MediumBlue
        Me.Label4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(60, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(999, 49)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "ADMIN LOGIN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btCreateTables
        '
        Me.btCreateTables.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCreateTables.Location = New System.Drawing.Point(7, 922)
        Me.btCreateTables.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btCreateTables.Name = "btCreateTables"
        Me.btCreateTables.Size = New System.Drawing.Size(243, 43)
        Me.btCreateTables.TabIndex = 34
        Me.btCreateTables.Text = "Create Tables"
        Me.btCreateTables.UseVisualStyleBackColor = True
        Me.btCreateTables.Visible = False
        '
        'btCancel
        '
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancel.Location = New System.Drawing.Point(596, 343)
        Me.btCancel.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(148, 43)
        Me.btCancel.TabIndex = 35
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(391, 298)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(225, 17)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "* Min 6 Characters, Case Sensitive"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(391, 192)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(351, 17)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "* Min 6 Characters, Max 12 Characters, Case Sensitive"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1115, 463)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btCreateTables)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btLoginLogin)
        Me.Controls.Add(Me.UsrPassword)
        Me.Controls.Add(Me.UserID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btLoginLogin As System.Windows.Forms.Button
    Friend WithEvents UsrPassword As System.Windows.Forms.TextBox
    Friend WithEvents UserID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btCreateTables As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
End Class
