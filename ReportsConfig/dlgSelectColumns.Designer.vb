<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectColumns
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
        Me.oColumns = New System.Windows.Forms.CheckedListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'oColumns
        '
        Me.oColumns.CheckOnClick = True
        Me.oColumns.FormattingEnabled = True
        Me.oColumns.Location = New System.Drawing.Point(31, 12)
        Me.oColumns.Name = "oColumns"
        Me.oColumns.Size = New System.Drawing.Size(473, 454)
        Me.oColumns.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(635, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dlgSelectColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 501)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.oColumns)
        Me.Name = "dlgSelectColumns"
        Me.Text = "dlgSelectColumns"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oColumns As CheckedListBox
    Friend WithEvents Button1 As Button
End Class
