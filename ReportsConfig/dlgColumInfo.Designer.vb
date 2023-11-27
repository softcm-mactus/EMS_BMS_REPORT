<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgColumInfo
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
        Me.ColInfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ColInfo
        '
        Me.ColInfo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ColInfo.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColInfo.Location = New System.Drawing.Point(78, 69)
        Me.ColInfo.Multiline = True
        Me.ColInfo.Name = "ColInfo"
        Me.ColInfo.ReadOnly = True
        Me.ColInfo.Size = New System.Drawing.Size(664, 234)
        Me.ColInfo.TabIndex = 0
        '
        'dlgColumInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 469)
        Me.Controls.Add(Me.ColInfo)
        Me.Name = "dlgColumInfo"
        Me.Text = "EBO Column Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColInfo As TextBox
End Class
