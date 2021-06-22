<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSelectTrentDataPoint
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.TrendLogID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrendLogType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrendLogName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bHide = New System.Windows.Forms.CheckBox()
        Me.tPointName = New System.Windows.Forms.TextBox()
        Me.bGetSimilorPoints = New System.Windows.Forms.CheckBox()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(575, 69)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Select"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(575, 112)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrendLogID, Me.TrendLogType, Me.TrendLogName})
        Me.oGrid.Location = New System.Drawing.Point(12, 69)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.ReadOnly = True
        Me.oGrid.Size = New System.Drawing.Size(517, 451)
        Me.oGrid.TabIndex = 1
        '
        'TrendLogID
        '
        Me.TrendLogID.HeaderText = "TrendLogID"
        Me.TrendLogID.Name = "TrendLogID"
        Me.TrendLogID.ReadOnly = True
        '
        'TrendLogType
        '
        Me.TrendLogType.HeaderText = "TrendLogType"
        Me.TrendLogType.Name = "TrendLogType"
        Me.TrendLogType.ReadOnly = True
        Me.TrendLogType.Visible = False
        '
        'TrendLogName
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TrendLogName.DefaultCellStyle = DataGridViewCellStyle4
        Me.TrendLogName.HeaderText = "TrendLogName"
        Me.TrendLogName.Name = "TrendLogName"
        Me.TrendLogName.ReadOnly = True
        Me.TrendLogName.Width = 350
        '
        'bHide
        '
        Me.bHide.AutoSize = True
        Me.bHide.Checked = True
        Me.bHide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.bHide.Location = New System.Drawing.Point(468, 33)
        Me.bHide.Name = "bHide"
        Me.bHide.Size = New System.Drawing.Size(140, 17)
        Me.bHide.TabIndex = 2
        Me.bHide.Text = "Hide Already Used Logs"
        Me.bHide.UseVisualStyleBackColor = True
        '
        'tPointName
        '
        Me.tPointName.Location = New System.Drawing.Point(13, 31)
        Me.tPointName.Name = "tPointName"
        Me.tPointName.Size = New System.Drawing.Size(410, 20)
        Me.tPointName.TabIndex = 3
        '
        'bGetSimilorPoints
        '
        Me.bGetSimilorPoints.AutoSize = True
        Me.bGetSimilorPoints.Location = New System.Drawing.Point(13, 8)
        Me.bGetSimilorPoints.Name = "bGetSimilorPoints"
        Me.bGetSimilorPoints.Size = New System.Drawing.Size(156, 17)
        Me.bGetSimilorPoints.TabIndex = 4
        Me.bGetSimilorPoints.Text = "Search Similar Point Names"
        Me.bGetSimilorPoints.UseVisualStyleBackColor = True
        '
        'DlgSelectTrentDataPoint
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(681, 535)
        Me.Controls.Add(Me.bGetSimilorPoints)
        Me.Controls.Add(Me.tPointName)
        Me.Controls.Add(Me.bHide)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.oGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgSelectTrentDataPoint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgSelectTrentDataPoint"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents bHide As CheckBox
    Friend WithEvents TrendLogID As DataGridViewTextBoxColumn
    Friend WithEvents TrendLogType As DataGridViewTextBoxColumn
    Friend WithEvents TrendLogName As DataGridViewTextBoxColumn
    Friend WithEvents tPointName As TextBox
    Friend WithEvents bGetSimilorPoints As CheckBox
End Class
