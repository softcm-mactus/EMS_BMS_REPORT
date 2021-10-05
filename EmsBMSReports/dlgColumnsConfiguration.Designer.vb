<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgColumnsConfiguration
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.bDeleteColumn = New System.Windows.Forms.Button()
        Me.bAddNewColumn = New System.Windows.Forms.Button()
        Me.bMoveUp = New System.Windows.Forms.Button()
        Me.bMoveDown = New System.Windows.Forms.Button()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNameInDB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFormat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJust = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColHeader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COlHeader2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LCT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LCV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HighCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.HCT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.HighCheckValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnumID = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColMerge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SVC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SVCT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1112, 447)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Update"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.ColNameInDB, Me.ColType, Me.ColWidth, Me.ColFormat, Me.ColJust, Me.ColHeader, Me.COlHeader2, Me.LC, Me.LCT, Me.LCV, Me.HighCheck, Me.HCT, Me.HighCheckValue, Me.EnumID, Me.ColMerge, Me.SVC, Me.SVCT, Me.SVV})
        Me.oGrid.Location = New System.Drawing.Point(13, 13)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.Size = New System.Drawing.Size(1294, 402)
        Me.oGrid.TabIndex = 1
        '
        'bDeleteColumn
        '
        Me.bDeleteColumn.Location = New System.Drawing.Point(256, 435)
        Me.bDeleteColumn.Name = "bDeleteColumn"
        Me.bDeleteColumn.Size = New System.Drawing.Size(175, 33)
        Me.bDeleteColumn.TabIndex = 5
        Me.bDeleteColumn.Text = "Delete Column"
        Me.bDeleteColumn.UseVisualStyleBackColor = True
        '
        'bAddNewColumn
        '
        Me.bAddNewColumn.Location = New System.Drawing.Point(37, 434)
        Me.bAddNewColumn.Name = "bAddNewColumn"
        Me.bAddNewColumn.Size = New System.Drawing.Size(175, 33)
        Me.bAddNewColumn.TabIndex = 4
        Me.bAddNewColumn.Text = "Add New Column"
        Me.bAddNewColumn.UseVisualStyleBackColor = True
        '
        'bMoveUp
        '
        Me.bMoveUp.Location = New System.Drawing.Point(555, 435)
        Me.bMoveUp.Name = "bMoveUp"
        Me.bMoveUp.Size = New System.Drawing.Size(175, 33)
        Me.bMoveUp.TabIndex = 6
        Me.bMoveUp.Text = "Move Row Up"
        Me.bMoveUp.UseVisualStyleBackColor = True
        '
        'bMoveDown
        '
        Me.bMoveDown.Location = New System.Drawing.Point(753, 435)
        Me.bMoveDown.Name = "bMoveDown"
        Me.bMoveDown.Size = New System.Drawing.Size(175, 33)
        Me.bMoveDown.TabIndex = 7
        Me.bMoveDown.Text = "Move Row Down"
        Me.bMoveDown.UseVisualStyleBackColor = True
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
        Me.ColType.HeaderText = "Type"
        Me.ColType.Items.AddRange(New Object() {"Temperature", "Humidity", "DP", "Other", "Enumtype"})
        Me.ColType.Name = "ColType"
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
        Me.ColFormat.Width = 70
        '
        'ColJust
        '
        Me.ColJust.HeaderText = "Justification"
        Me.ColJust.Items.AddRange(New Object() {"Center", "Left", "Right"})
        Me.ColJust.Name = "ColJust"
        '
        'ColHeader
        '
        Me.ColHeader.HeaderText = "Column Sub Title"
        Me.ColHeader.Name = "ColHeader"
        Me.ColHeader.Width = 180
        '
        'COlHeader2
        '
        Me.COlHeader2.HeaderText = "Column Main Title"
        Me.COlHeader2.Name = "COlHeader2"
        Me.COlHeader2.Width = 180
        '
        'LC
        '
        Me.LC.HeaderText = "LC"
        Me.LC.Name = "LC"
        Me.LC.Width = 30
        '
        'LCT
        '
        Me.LCT.HeaderText = "LCT"
        Me.LCT.Name = "LCT"
        Me.LCT.Width = 40
        '
        'LCV
        '
        Me.LCV.HeaderText = "LCV"
        Me.LCV.Name = "LCV"
        Me.LCV.Width = 40
        '
        'HighCheck
        '
        Me.HighCheck.HeaderText = "HC"
        Me.HighCheck.Name = "HighCheck"
        Me.HighCheck.Width = 30
        '
        'HCT
        '
        Me.HCT.HeaderText = "HCT"
        Me.HCT.Name = "HCT"
        Me.HCT.Width = 40
        '
        'HighCheckValue
        '
        Me.HighCheckValue.HeaderText = "HCV"
        Me.HighCheckValue.Name = "HighCheckValue"
        Me.HighCheckValue.Width = 40
        '
        'EnumID
        '
        Me.EnumID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnumID.HeaderText = "Enum ID"
        Me.EnumID.Name = "EnumID"
        Me.EnumID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EnumID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.EnumID.Width = 45
        '
        'ColMerge
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ColMerge.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColMerge.HeaderText = "Col Merge"
        Me.ColMerge.Name = "ColMerge"
        Me.ColMerge.Width = 50
        '
        'SVC
        '
        Me.SVC.HeaderText = "SVC"
        Me.SVC.Name = "SVC"
        Me.SVC.Width = 40
        '
        'SVCT
        '
        Me.SVCT.HeaderText = "SVCT"
        Me.SVCT.Name = "SVCT"
        Me.SVCT.Width = 45
        '
        'SVV
        '
        Me.SVV.HeaderText = "SVV"
        Me.SVV.Name = "SVV"
        Me.SVV.Width = 50
        '
        'dlgColumnsConfiguration
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1323, 498)
        Me.Controls.Add(Me.bMoveDown)
        Me.Controls.Add(Me.bMoveUp)
        Me.Controls.Add(Me.bDeleteColumn)
        Me.Controls.Add(Me.bAddNewColumn)
        Me.Controls.Add(Me.oGrid)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgColumnsConfiguration"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgColumnsConfiguration"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents bDeleteColumn As Button
    Friend WithEvents bAddNewColumn As Button
    Friend WithEvents bMoveUp As Button
    Friend WithEvents bMoveDown As Button
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents ColNameInDB As DataGridViewTextBoxColumn
    Friend WithEvents ColType As DataGridViewComboBoxColumn
    Friend WithEvents ColWidth As DataGridViewTextBoxColumn
    Friend WithEvents ColFormat As DataGridViewTextBoxColumn
    Friend WithEvents ColJust As DataGridViewComboBoxColumn
    Friend WithEvents ColHeader As DataGridViewTextBoxColumn
    Friend WithEvents COlHeader2 As DataGridViewTextBoxColumn
    Friend WithEvents LC As DataGridViewCheckBoxColumn
    Friend WithEvents LCT As DataGridViewCheckBoxColumn
    Friend WithEvents LCV As DataGridViewTextBoxColumn
    Friend WithEvents HighCheck As DataGridViewCheckBoxColumn
    Friend WithEvents HCT As DataGridViewCheckBoxColumn
    Friend WithEvents HighCheckValue As DataGridViewTextBoxColumn
    Friend WithEvents EnumID As DataGridViewButtonColumn
    Friend WithEvents ColMerge As DataGridViewTextBoxColumn
    Friend WithEvents SVC As DataGridViewCheckBoxColumn
    Friend WithEvents SVCT As DataGridViewCheckBoxColumn
    Friend WithEvents SVV As DataGridViewTextBoxColumn
End Class
