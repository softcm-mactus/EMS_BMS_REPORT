<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgConfigureAlarmReportColumns
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.bMoveUp = New System.Windows.Forms.Button()
        Me.bMoveDown = New System.Windows.Forms.Button()
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNameInDB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFormat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJust = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.COlHeader2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnumID = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.ColNameInDB, Me.ColType, Me.ColWidth, Me.ColFormat, Me.ColJust, Me.COlHeader2, Me.EnumID})
        Me.oGrid.Location = New System.Drawing.Point(12, 12)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.Size = New System.Drawing.Size(858, 455)
        Me.oGrid.TabIndex = 2
        '
        'bMoveUp
        '
        Me.bMoveUp.Location = New System.Drawing.Point(145, 473)
        Me.bMoveUp.Name = "bMoveUp"
        Me.bMoveUp.Size = New System.Drawing.Size(175, 33)
        Me.bMoveUp.TabIndex = 7
        Me.bMoveUp.Text = "Move Row Up"
        Me.bMoveUp.UseVisualStyleBackColor = True
        '
        'bMoveDown
        '
        Me.bMoveDown.Location = New System.Drawing.Point(437, 473)
        Me.bMoveDown.Name = "bMoveDown"
        Me.bMoveDown.Size = New System.Drawing.Size(175, 33)
        Me.bMoveDown.TabIndex = 8
        Me.bMoveDown.Text = "Move Row Down"
        Me.bMoveDown.UseVisualStyleBackColor = True
        '
        'bUpdate
        '
        Me.bUpdate.Location = New System.Drawing.Point(892, 33)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(148, 33)
        Me.bUpdate.TabIndex = 8
        Me.bUpdate.Text = "Update"
        Me.bUpdate.UseVisualStyleBackColor = True
        '
        'bCancel
        '
        Me.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancel.Location = New System.Drawing.Point(892, 115)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(148, 33)
        Me.bCancel.TabIndex = 8
        Me.bCancel.Text = "Cancel"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'colID
        '
        Me.colID.HeaderText = "colid"
        Me.colID.Name = "colID"
        Me.colID.Visible = False
        '
        'ColNameInDB
        '
        Me.ColNameInDB.HeaderText = "DB Col Name"
        Me.ColNameInDB.Name = "ColNameInDB"
        Me.ColNameInDB.ReadOnly = True
        Me.ColNameInDB.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ColType
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ColType.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColType.HeaderText = "Type"
        Me.ColType.Name = "ColType"
        Me.ColType.ReadOnly = True
        Me.ColType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColWidth
        '
        Me.ColWidth.HeaderText = "Col Width"
        Me.ColWidth.Name = "ColWidth"
        Me.ColWidth.Width = 50
        '
        'ColFormat
        '
        Me.ColFormat.HeaderText = "Column Format"
        Me.ColFormat.Name = "ColFormat"
        Me.ColFormat.Width = 150
        '
        'ColJust
        '
        Me.ColJust.HeaderText = "Justification"
        Me.ColJust.Items.AddRange(New Object() {"Center", "Left", "Right"})
        Me.ColJust.Name = "ColJust"
        '
        'COlHeader2
        '
        Me.COlHeader2.HeaderText = "Column Title"
        Me.COlHeader2.Name = "COlHeader2"
        Me.COlHeader2.Width = 230
        '
        'EnumID
        '
        Me.EnumID.HeaderText = "Visible"
        Me.EnumID.Name = "EnumID"
        Me.EnumID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EnumID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.EnumID.Width = 70
        '
        'DlgConfigureAlarmReportColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 518)
        Me.Controls.Add(Me.bCancel)
        Me.Controls.Add(Me.bUpdate)
        Me.Controls.Add(Me.bMoveDown)
        Me.Controls.Add(Me.bMoveUp)
        Me.Controls.Add(Me.oGrid)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgConfigureAlarmReportColumns"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgConfigureAlarmReportColumns"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oGrid As DataGridView
    Friend WithEvents bMoveUp As Button
    Friend WithEvents bMoveDown As Button
    Friend WithEvents bUpdate As Button
    Friend WithEvents bCancel As Button
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents ColNameInDB As DataGridViewTextBoxColumn
    Friend WithEvents ColType As DataGridViewTextBoxColumn
    Friend WithEvents ColWidth As DataGridViewTextBoxColumn
    Friend WithEvents ColFormat As DataGridViewTextBoxColumn
    Friend WithEvents ColJust As DataGridViewComboBoxColumn
    Friend WithEvents COlHeader2 As DataGridViewTextBoxColumn
    Friend WithEvents EnumID As DataGridViewCheckBoxColumn
End Class
