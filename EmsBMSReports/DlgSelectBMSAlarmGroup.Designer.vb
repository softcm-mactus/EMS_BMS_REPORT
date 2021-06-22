<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSelectBMSAlarmGroup
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
        Me.oGroup = New System.Windows.Forms.ListBox()
        Me.bSelect = New System.Windows.Forms.Button()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'oGroup
        '
        Me.oGroup.FormattingEnabled = True
        Me.oGroup.ItemHeight = 16
        Me.oGroup.Location = New System.Drawing.Point(13, 13)
        Me.oGroup.Name = "oGroup"
        Me.oGroup.Size = New System.Drawing.Size(243, 356)
        Me.oGroup.TabIndex = 0
        '
        'bSelect
        '
        Me.bSelect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bSelect.Location = New System.Drawing.Point(299, 39)
        Me.bSelect.Name = "bSelect"
        Me.bSelect.Size = New System.Drawing.Size(75, 23)
        Me.bSelect.TabIndex = 1
        Me.bSelect.Text = "Select"
        Me.bSelect.UseVisualStyleBackColor = True
        '
        'bCancel
        '
        Me.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancel.Location = New System.Drawing.Point(299, 91)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(75, 23)
        Me.bCancel.TabIndex = 1
        Me.bCancel.Text = "Close"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'DlgSelectBMSAlarmGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 388)
        Me.Controls.Add(Me.bCancel)
        Me.Controls.Add(Me.bSelect)
        Me.Controls.Add(Me.oGroup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgSelectBMSAlarmGroup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select BMS Alarm Group"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oGroup As ListBox
    Friend WithEvents bSelect As Button
    Friend WithEvents bCancel As Button
End Class
