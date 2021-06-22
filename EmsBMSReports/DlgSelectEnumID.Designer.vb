<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSelectEnumID
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
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.Added = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EnumID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.bSelect = New System.Windows.Forms.Button()
        Me.bClose = New System.Windows.Forms.Button()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oGrid
        '
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Added, Me.EnumID, Me.Value, Me.Description})
        Me.oGrid.Location = New System.Drawing.Point(12, 12)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.Size = New System.Drawing.Size(422, 353)
        Me.oGrid.TabIndex = 0
        '
        'Added
        '
        Me.Added.HeaderText = "Added"
        Me.Added.Name = "Added"
        Me.Added.Visible = False
        '
        'EnumID
        '
        Me.EnumID.HeaderText = "ID"
        Me.EnumID.Name = "EnumID"
        Me.EnumID.Width = 50
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.Width = 50
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 250
        '
        'bUpdate
        '
        Me.bUpdate.Location = New System.Drawing.Point(456, 55)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(111, 23)
        Me.bUpdate.TabIndex = 1
        Me.bUpdate.Text = "Update"
        Me.bUpdate.UseVisualStyleBackColor = True
        '
        'bSelect
        '
        Me.bSelect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bSelect.Enabled = False
        Me.bSelect.Location = New System.Drawing.Point(456, 175)
        Me.bSelect.Name = "bSelect"
        Me.bSelect.Size = New System.Drawing.Size(99, 23)
        Me.bSelect.TabIndex = 1
        Me.bSelect.Text = "Select"
        Me.bSelect.UseVisualStyleBackColor = True
        '
        'bClose
        '
        Me.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bClose.Location = New System.Drawing.Point(456, 312)
        Me.bClose.Name = "bClose"
        Me.bClose.Size = New System.Drawing.Size(99, 23)
        Me.bClose.TabIndex = 1
        Me.bClose.Text = "Close"
        Me.bClose.UseVisualStyleBackColor = True
        '
        'DlgSelectEnumID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 388)
        Me.Controls.Add(Me.bClose)
        Me.Controls.Add(Me.bSelect)
        Me.Controls.Add(Me.bUpdate)
        Me.Controls.Add(Me.oGrid)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgSelectEnumID"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Enumeration ID for Digital points"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oGrid As DataGridView
    Friend WithEvents Added As DataGridViewCheckBoxColumn
    Friend WithEvents EnumID As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents bUpdate As Button
    Friend WithEvents bSelect As Button
    Friend WithEvents bClose As Button
End Class
