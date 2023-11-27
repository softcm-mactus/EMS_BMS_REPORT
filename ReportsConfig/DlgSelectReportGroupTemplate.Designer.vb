<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSelectReportGroupTemplate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cTemplate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cGroup = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tReportTitle = New System.Windows.Forms.TextBox()
        Me.bAdd = New System.Windows.Forms.Button()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.bAddNewGroup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cTemplate
        '
        Me.cTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTemplate.FormattingEnabled = True
        Me.cTemplate.Location = New System.Drawing.Point(41, 34)
        Me.cTemplate.Name = "cTemplate"
        Me.cTemplate.Size = New System.Drawing.Size(323, 24)
        Me.cTemplate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Report Template"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Report Group"
        '
        'cGroup
        '
        Me.cGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cGroup.FormattingEnabled = True
        Me.cGroup.Location = New System.Drawing.Point(41, 97)
        Me.cGroup.Name = "cGroup"
        Me.cGroup.Size = New System.Drawing.Size(323, 24)
        Me.cGroup.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Report Title"
        '
        'tReportTitle
        '
        Me.tReportTitle.Location = New System.Drawing.Point(41, 167)
        Me.tReportTitle.Name = "tReportTitle"
        Me.tReportTitle.Size = New System.Drawing.Size(628, 22)
        Me.tReportTitle.TabIndex = 6
        '
        'bAdd
        '
        Me.bAdd.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bAdd.Enabled = False
        Me.bAdd.Location = New System.Drawing.Point(537, 34)
        Me.bAdd.Name = "bAdd"
        Me.bAdd.Size = New System.Drawing.Size(132, 23)
        Me.bAdd.TabIndex = 7
        Me.bAdd.Text = "Add"
        Me.bAdd.UseVisualStyleBackColor = True
        '
        'bCancel
        '
        Me.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancel.Location = New System.Drawing.Point(537, 97)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(132, 23)
        Me.bCancel.TabIndex = 8
        Me.bCancel.Text = "Cancel"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'bAddNewGroup
        '
        Me.bAddNewGroup.Location = New System.Drawing.Point(370, 78)
        Me.bAddNewGroup.Name = "bAddNewGroup"
        Me.bAddNewGroup.Size = New System.Drawing.Size(72, 43)
        Me.bAddNewGroup.TabIndex = 7
        Me.bAddNewGroup.Text = "Add New Group"
        Me.bAddNewGroup.UseVisualStyleBackColor = True
        '
        'DlgSelectReportGroupTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 211)
        Me.Controls.Add(Me.bCancel)
        Me.Controls.Add(Me.bAddNewGroup)
        Me.Controls.Add(Me.bAdd)
        Me.Controls.Add(Me.tReportTitle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cTemplate)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgSelectReportGroupTemplate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgSelectReportGroupTemplate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cTemplate As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cGroup As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tReportTitle As TextBox
    Friend WithEvents bAdd As Button
    Friend WithEvents bCancel As Button
    Friend WithEvents bAddNewGroup As Button
End Class
