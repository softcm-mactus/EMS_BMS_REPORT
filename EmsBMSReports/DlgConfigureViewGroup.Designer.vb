<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgConfigureViewGroup
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
        Me.colGrid = New System.Windows.Forms.DataGridView()
        Me.groupView = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.addCategory = New System.Windows.Forms.Button()
        Me.addGroup = New System.Windows.Forms.Button()
        Me.ExternalLogId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeleteRow = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.colGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colGrid
        '
        Me.colGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.colGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ExternalLogId, Me.DataGridViewTextBoxColumn8, Me.DeleteRow})
        Me.colGrid.Location = New System.Drawing.Point(363, 48)
        Me.colGrid.Name = "colGrid"
        Me.colGrid.Size = New System.Drawing.Size(556, 413)
        Me.colGrid.TabIndex = 2
        '
        'groupView
        '
        Me.groupView.FullRowSelect = True
        Me.groupView.LabelEdit = True
        Me.groupView.Location = New System.Drawing.Point(35, 48)
        Me.groupView.Name = "groupView"
        Me.groupView.PathSeparator = "/"
        Me.groupView.Size = New System.Drawing.Size(250, 413)
        Me.groupView.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Category/Group"
        '
        'addCategory
        '
        Me.addCategory.Location = New System.Drawing.Point(35, 471)
        Me.addCategory.Name = "addCategory"
        Me.addCategory.Size = New System.Drawing.Size(117, 23)
        Me.addCategory.TabIndex = 5
        Me.addCategory.Text = "Add Category"
        Me.addCategory.UseVisualStyleBackColor = True
        '
        'addGroup
        '
        Me.addGroup.Location = New System.Drawing.Point(168, 471)
        Me.addGroup.Name = "addGroup"
        Me.addGroup.Size = New System.Drawing.Size(117, 23)
        Me.addGroup.TabIndex = 6
        Me.addGroup.Text = "Add Group"
        Me.addGroup.UseVisualStyleBackColor = True
        '
        'ExternalLogId
        '
        Me.ExternalLogId.HeaderText = "ExternalLogId"
        Me.ExternalLogId.Name = "ExternalLogId"
        Me.ExternalLogId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExternalLogId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Column Name"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 300
        '
        'DeleteRow
        '
        Me.DeleteRow.HeaderText = "Delete"
        Me.DeleteRow.Name = "DeleteRow"
        Me.DeleteRow.Width = 30
        '
        'DlgConfigureViewGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 548)
        Me.Controls.Add(Me.addGroup)
        Me.Controls.Add(Me.addCategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.groupView)
        Me.Controls.Add(Me.colGrid)
        Me.Name = "DlgConfigureViewGroup"
        Me.Text = "DlgConfigureViewGroup"
        CType(Me.colGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents colGrid As DataGridView
    Friend WithEvents groupView As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents addCategory As Button
    Friend WithEvents addGroup As Button
    Friend WithEvents ExternalLogId As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DeleteRow As DataGridViewButtonColumn
End Class
