﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgReportsConfiguration
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.bAddNewReport = New System.Windows.Forms.Button()
        Me.bDeleteReport = New System.Windows.Forms.Button()
        Me.ReportID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportTemplate = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ReportType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ReportGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportTitlle2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrntTime = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrintBy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrintDates = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DefaultTimeInterval = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataAggType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ConfCol = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PrMinMax = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrSV = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1094, 489)
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
        Me.Cancel_Button.Text = "Close"
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportID, Me.ReportTemplate, Me.ReportType, Me.ReportGroup, Me.ReportTitle, Me.ReportTitlle2, Me.PrntTime, Me.PrintBy, Me.PrintDates, Me.DefaultTimeInterval, Me.DataAggType, Me.ConfCol, Me.PrMinMax, Me.PrSV})
        Me.oGrid.Location = New System.Drawing.Point(13, 12)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.Size = New System.Drawing.Size(1276, 461)
        Me.oGrid.TabIndex = 1
        '
        'bAddNewReport
        '
        Me.bAddNewReport.Location = New System.Drawing.Point(42, 491)
        Me.bAddNewReport.Name = "bAddNewReport"
        Me.bAddNewReport.Size = New System.Drawing.Size(175, 33)
        Me.bAddNewReport.TabIndex = 2
        Me.bAddNewReport.Text = "Add New Report"
        Me.bAddNewReport.UseVisualStyleBackColor = True
        '
        'bDeleteReport
        '
        Me.bDeleteReport.Location = New System.Drawing.Point(261, 492)
        Me.bDeleteReport.Name = "bDeleteReport"
        Me.bDeleteReport.Size = New System.Drawing.Size(175, 33)
        Me.bDeleteReport.TabIndex = 3
        Me.bDeleteReport.Text = "Delete Report"
        Me.bDeleteReport.UseVisualStyleBackColor = True
        '
        'ReportID
        '
        Me.ReportID.HeaderText = "ReportID"
        Me.ReportID.Name = "ReportID"
        Me.ReportID.Visible = False
        Me.ReportID.Width = 80
        '
        'ReportTemplate
        '
        Me.ReportTemplate.HeaderText = "Report Template"
        Me.ReportTemplate.Items.AddRange(New Object() {"ProtraitWiderMargin", "LandScapeWiderMargin", "ProtraitNarrowMargin", "LandScapeNarrowMargin"})
        Me.ReportTemplate.Name = "ReportTemplate"
        '
        'ReportType
        '
        Me.ReportType.HeaderText = "Report Type"
        Me.ReportType.Items.AddRange(New Object() {"DataReport", "AlarmReport"})
        Me.ReportType.Name = "ReportType"
        Me.ReportType.Visible = False
        '
        'ReportGroup
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.ReportGroup.DefaultCellStyle = DataGridViewCellStyle1
        Me.ReportGroup.HeaderText = "Report Group"
        Me.ReportGroup.Name = "ReportGroup"
        Me.ReportGroup.ReadOnly = True
        Me.ReportGroup.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReportGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ReportTitle
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReportTitle.DefaultCellStyle = DataGridViewCellStyle2
        Me.ReportTitle.HeaderText = "Report Title"
        Me.ReportTitle.Name = "ReportTitle"
        Me.ReportTitle.Width = 200
        '
        'ReportTitlle2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReportTitlle2.DefaultCellStyle = DataGridViewCellStyle3
        Me.ReportTitlle2.HeaderText = "Report Title 2"
        Me.ReportTitlle2.Name = "ReportTitlle2"
        Me.ReportTitlle2.Width = 200
        '
        'PrntTime
        '
        Me.PrntTime.HeaderText = "Print Gen Time"
        Me.PrntTime.Name = "PrntTime"
        Me.PrntTime.Width = 70
        '
        'PrintBy
        '
        Me.PrintBy.HeaderText = "Print Gen By"
        Me.PrintBy.Name = "PrintBy"
        Me.PrintBy.Width = 60
        '
        'PrintDates
        '
        Me.PrintDates.HeaderText = "PrintFrom ToDate"
        Me.PrintDates.Name = "PrintDates"
        Me.PrintDates.Width = 70
        '
        'DefaultTimeInterval
        '
        Me.DefaultTimeInterval.AutoComplete = False
        Me.DefaultTimeInterval.HeaderText = "Default TimeInterval"
        Me.DefaultTimeInterval.Items.AddRange(New Object() {"1", "5", "15", "30"})
        Me.DefaultTimeInterval.Name = "DefaultTimeInterval"
        '
        'DataAggType
        '
        Me.DataAggType.AutoComplete = False
        Me.DataAggType.HeaderText = "Data Agg Type"
        Me.DataAggType.Items.AddRange(New Object() {"Instance", "Minimum", "Average", "Maximum"})
        Me.DataAggType.Name = "DataAggType"
        '
        'ConfCol
        '
        Me.ConfCol.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ConfCol.HeaderText = "Configure Columns"
        Me.ConfCol.Name = "ConfCol"
        Me.ConfCol.UseColumnTextForButtonValue = True
        Me.ConfCol.Width = 80
        '
        'PrMinMax
        '
        Me.PrMinMax.HeaderText = "Pr Min Max"
        Me.PrMinMax.Name = "PrMinMax"
        Me.PrMinMax.Width = 70
        '
        'PrSV
        '
        Me.PrSV.HeaderText = "Pr SV"
        Me.PrSV.Name = "PrSV"
        Me.PrSV.Width = 50
        '
        'DlgReportsConfiguration
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1305, 540)
        Me.Controls.Add(Me.bDeleteReport)
        Me.Controls.Add(Me.bAddNewReport)
        Me.Controls.Add(Me.oGrid)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgReportsConfiguration"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgReportsConfiguration"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents bAddNewReport As Button
    Friend WithEvents bDeleteReport As Button
    Friend WithEvents ReportID As DataGridViewTextBoxColumn
    Friend WithEvents ReportTemplate As DataGridViewComboBoxColumn
    Friend WithEvents ReportType As DataGridViewComboBoxColumn
    Friend WithEvents ReportGroup As DataGridViewTextBoxColumn
    Friend WithEvents ReportTitle As DataGridViewTextBoxColumn
    Friend WithEvents ReportTitlle2 As DataGridViewTextBoxColumn
    Friend WithEvents PrntTime As DataGridViewCheckBoxColumn
    Friend WithEvents PrintBy As DataGridViewCheckBoxColumn
    Friend WithEvents PrintDates As DataGridViewCheckBoxColumn
    Friend WithEvents DefaultTimeInterval As DataGridViewComboBoxColumn
    Friend WithEvents DataAggType As DataGridViewComboBoxColumn
    Friend WithEvents ConfCol As DataGridViewButtonColumn
    Friend WithEvents PrMinMax As DataGridViewCheckBoxColumn
    Friend WithEvents PrSV As DataGridViewCheckBoxColumn
End Class
