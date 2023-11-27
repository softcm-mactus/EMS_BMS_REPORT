<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgAppConfiguration
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.bClose = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Decription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaxValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.AllowUserToResizeRows = False
        Me.oGrid.BackgroundColor = System.Drawing.SystemColors.Control
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Decription, Me.Type, Me.Value, Me.MinValue, Me.MaxValue, Me.OldValue})
        Me.oGrid.Location = New System.Drawing.Point(12, 18)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.RowHeadersVisible = False
        Me.oGrid.Size = New System.Drawing.Size(679, 490)
        Me.oGrid.TabIndex = 391
        '
        'bClose
        '
        Me.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.bClose.Location = New System.Drawing.Point(721, 223)
        Me.bClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.bClose.Name = "bClose"
        Me.bClose.Size = New System.Drawing.Size(151, 43)
        Me.bClose.TabIndex = 389
        Me.bClose.Text = "Return"
        Me.bClose.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btSave.Location = New System.Drawing.Point(721, 72)
        Me.btSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(151, 43)
        Me.btSave.TabIndex = 390
        Me.btSave.Text = "Update"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ID.Visible = False
        '
        'Decription
        '
        Me.Decription.DataPropertyName = "Description"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Decription.DefaultCellStyle = DataGridViewCellStyle13
        Me.Decription.HeaderText = "Parameter Description"
        Me.Decription.Name = "Decription"
        Me.Decription.ReadOnly = True
        Me.Decription.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Decription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Decription.Width = 350
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Type.Visible = False
        '
        'Value
        '
        Me.Value.DataPropertyName = "Value"
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.Value.DefaultCellStyle = DataGridViewCellStyle14
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Value.Width = 300
        '
        'MinValue
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MinValue.DefaultCellStyle = DataGridViewCellStyle15
        Me.MinValue.HeaderText = "MinValue"
        Me.MinValue.Name = "MinValue"
        Me.MinValue.ReadOnly = True
        Me.MinValue.Visible = False
        Me.MinValue.Width = 75
        '
        'MaxValue
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MaxValue.DefaultCellStyle = DataGridViewCellStyle16
        Me.MaxValue.HeaderText = "MaxValue"
        Me.MaxValue.Name = "MaxValue"
        Me.MaxValue.ReadOnly = True
        Me.MaxValue.Visible = False
        Me.MaxValue.Width = 75
        '
        'OldValue
        '
        Me.OldValue.HeaderText = "OldValue"
        Me.OldValue.Name = "OldValue"
        Me.OldValue.Visible = False
        '
        'DlgAppConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 528)
        Me.Controls.Add(Me.oGrid)
        Me.Controls.Add(Me.bClose)
        Me.Controls.Add(Me.btSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgAppConfiguration"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Site Configuration"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oGrid As DataGridView
    Friend WithEvents bClose As Button
    Friend WithEvents btSave As Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Decription As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
    Friend WithEvents MinValue As DataGridViewTextBoxColumn
    Friend WithEvents MaxValue As DataGridViewTextBoxColumn
    Friend WithEvents OldValue As DataGridViewTextBoxColumn
End Class
