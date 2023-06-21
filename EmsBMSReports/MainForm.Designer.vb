<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tr_FromDate = New System.Windows.Forms.DateTimePicker()
        Me.tr_ToDate = New System.Windows.Forms.DateTimePicker()
        Me.bGenerate = New System.Windows.Forms.Button()
        Me.oReportGrid = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Report = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bEventReport = New System.Windows.Forms.RadioButton()
        Me.bAlarmReports = New System.Windows.Forms.RadioButton()
        Me.bAreaReports = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cInterval = New System.Windows.Forms.ComboBox()
        Me.oProgress = New System.Windows.Forms.ProgressBar()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.StatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportPathName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Open = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cGroup = New System.Windows.Forms.ComboBox()
        Me.bCOnfigureReports = New System.Windows.Forms.Button()
        Me.bConfigureAlarmReports = New System.Windows.Forms.Button()
        Me.bGenerateChart = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bConfigure = New System.Windows.Forms.Button()
        Me.btnExcursionReport = New System.Windows.Forms.Button()
        Me.btnBatteryPercentage = New System.Windows.Forms.Button()
        CType(Me.oReportGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1085, 63)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMS Reporting Tool"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(315, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Configured Reports"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(709, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "From Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(709, 240)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "To Date"
        '
        'tr_FromDate
        '
        Me.tr_FromDate.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.tr_FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tr_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tr_FromDate.Location = New System.Drawing.Point(713, 183)
        Me.tr_FromDate.Name = "tr_FromDate"
        Me.tr_FromDate.ShowUpDown = True
        Me.tr_FromDate.Size = New System.Drawing.Size(178, 30)
        Me.tr_FromDate.TabIndex = 327
        '
        'tr_ToDate
        '
        Me.tr_ToDate.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.tr_ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tr_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tr_ToDate.Location = New System.Drawing.Point(713, 268)
        Me.tr_ToDate.Name = "tr_ToDate"
        Me.tr_ToDate.ShowUpDown = True
        Me.tr_ToDate.Size = New System.Drawing.Size(178, 30)
        Me.tr_ToDate.TabIndex = 327
        '
        'bGenerate
        '
        Me.bGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGenerate.Location = New System.Drawing.Point(713, 340)
        Me.bGenerate.Name = "bGenerate"
        Me.bGenerate.Size = New System.Drawing.Size(178, 47)
        Me.bGenerate.TabIndex = 328
        Me.bGenerate.Text = "Generate Report"
        Me.bGenerate.UseVisualStyleBackColor = True
        '
        'oReportGrid
        '
        Me.oReportGrid.AllowUserToAddRows = False
        Me.oReportGrid.AllowUserToDeleteRows = False
        Me.oReportGrid.AllowUserToResizeColumns = False
        Me.oReportGrid.AllowUserToResizeRows = False
        Me.oReportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oReportGrid.ColumnHeadersVisible = False
        Me.oReportGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Report, Me.Interval})
        Me.oReportGrid.Location = New System.Drawing.Point(319, 190)
        Me.oReportGrid.MultiSelect = False
        Me.oReportGrid.Name = "oReportGrid"
        Me.oReportGrid.RowHeadersVisible = False
        Me.oReportGrid.RowHeadersWidth = 51
        Me.oReportGrid.Size = New System.Drawing.Size(334, 245)
        Me.oReportGrid.TabIndex = 329
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.MinimumWidth = 6
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 125
        '
        'Report
        '
        Me.Report.HeaderText = "Report Name"
        Me.Report.MinimumWidth = 6
        Me.Report.Name = "Report"
        Me.Report.ReadOnly = True
        Me.Report.Width = 300
        '
        'Interval
        '
        Me.Interval.HeaderText = "Interval"
        Me.Interval.MinimumWidth = 6
        Me.Interval.Name = "Interval"
        Me.Interval.ReadOnly = True
        Me.Interval.Visible = False
        Me.Interval.Width = 125
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bEventReport)
        Me.GroupBox1.Controls.Add(Me.bAlarmReports)
        Me.GroupBox1.Controls.Add(Me.bAreaReports)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(22, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 195)
        Me.GroupBox1.TabIndex = 330
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report Type"
        '
        'bEventReport
        '
        Me.bEventReport.AutoSize = True
        Me.bEventReport.Location = New System.Drawing.Point(38, 141)
        Me.bEventReport.Name = "bEventReport"
        Me.bEventReport.Size = New System.Drawing.Size(173, 33)
        Me.bEventReport.TabIndex = 0
        Me.bEventReport.TabStop = True
        Me.bEventReport.Text = "Event Report"
        Me.bEventReport.UseVisualStyleBackColor = True
        '
        'bAlarmReports
        '
        Me.bAlarmReports.AutoSize = True
        Me.bAlarmReports.Location = New System.Drawing.Point(38, 87)
        Me.bAlarmReports.Name = "bAlarmReports"
        Me.bAlarmReports.Size = New System.Drawing.Size(187, 33)
        Me.bAlarmReports.TabIndex = 0
        Me.bAlarmReports.TabStop = True
        Me.bAlarmReports.Text = "Alarm Reports"
        Me.bAlarmReports.UseVisualStyleBackColor = True
        '
        'bAreaReports
        '
        Me.bAreaReports.AutoSize = True
        Me.bAreaReports.Location = New System.Drawing.Point(38, 37)
        Me.bAreaReports.Name = "bAreaReports"
        Me.bAreaReports.Size = New System.Drawing.Size(175, 33)
        Me.bAreaReports.TabIndex = 0
        Me.bAreaReports.TabStop = True
        Me.bAreaReports.Text = "Area Reports"
        Me.bAreaReports.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(709, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 25)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Report Time Interval "
        '
        'oTimer
        '
        Me.oTimer.Interval = 3000
        '
        'cInterval
        '
        Me.cInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cInterval.FormattingEnabled = True
        Me.cInterval.Items.AddRange(New Object() {"1", "5", "15", "30", "60"})
        Me.cInterval.Location = New System.Drawing.Point(713, 109)
        Me.cInterval.Name = "cInterval"
        Me.cInterval.Size = New System.Drawing.Size(121, 28)
        Me.cInterval.TabIndex = 334
        '
        'oProgress
        '
        Me.oProgress.Location = New System.Drawing.Point(32, 559)
        Me.oProgress.Name = "oProgress"
        Me.oProgress.Size = New System.Drawing.Size(960, 23)
        Me.oProgress.TabIndex = 335
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StatusID, Me.ReportFileName, Me.ReportPathName, Me.Open})
        Me.oGrid.Location = New System.Drawing.Point(341, 601)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.RowHeadersVisible = False
        Me.oGrid.RowHeadersWidth = 51
        Me.oGrid.Size = New System.Drawing.Size(651, 150)
        Me.oGrid.TabIndex = 336
        '
        'StatusID
        '
        Me.StatusID.HeaderText = "StatusID"
        Me.StatusID.MinimumWidth = 6
        Me.StatusID.Name = "StatusID"
        Me.StatusID.Visible = False
        Me.StatusID.Width = 125
        '
        'ReportFileName
        '
        Me.ReportFileName.HeaderText = "Report File Name"
        Me.ReportFileName.MinimumWidth = 6
        Me.ReportFileName.Name = "ReportFileName"
        Me.ReportFileName.ReadOnly = True
        Me.ReportFileName.Width = 400
        '
        'ReportPathName
        '
        Me.ReportPathName.HeaderText = "ReportPathName"
        Me.ReportPathName.MinimumWidth = 6
        Me.ReportPathName.Name = "ReportPathName"
        Me.ReportPathName.ReadOnly = True
        Me.ReportPathName.Visible = False
        Me.ReportPathName.Width = 125
        '
        'Open
        '
        Me.Open.HeaderText = "Open"
        Me.Open.MinimumWidth = 6
        Me.Open.Name = "Open"
        Me.Open.Text = "Open"
        Me.Open.Width = 125
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(315, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 25)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Group Name"
        '
        'cGroup
        '
        Me.cGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cGroup.FormattingEnabled = True
        Me.cGroup.Location = New System.Drawing.Point(319, 112)
        Me.cGroup.Name = "cGroup"
        Me.cGroup.Size = New System.Drawing.Size(325, 28)
        Me.cGroup.TabIndex = 337
        '
        'bCOnfigureReports
        '
        Me.bCOnfigureReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCOnfigureReports.Location = New System.Drawing.Point(32, 340)
        Me.bCOnfigureReports.Name = "bCOnfigureReports"
        Me.bCOnfigureReports.Size = New System.Drawing.Size(260, 37)
        Me.bCOnfigureReports.TabIndex = 338
        Me.bCOnfigureReports.Text = "Configure Data Trend Reports"
        Me.bCOnfigureReports.UseVisualStyleBackColor = True
        Me.bCOnfigureReports.Visible = False
        '
        'bConfigureAlarmReports
        '
        Me.bConfigureAlarmReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConfigureAlarmReports.Location = New System.Drawing.Point(32, 473)
        Me.bConfigureAlarmReports.Name = "bConfigureAlarmReports"
        Me.bConfigureAlarmReports.Size = New System.Drawing.Size(260, 37)
        Me.bConfigureAlarmReports.TabIndex = 338
        Me.bConfigureAlarmReports.Text = "Configure Alarm Reports"
        Me.bConfigureAlarmReports.UseVisualStyleBackColor = True
        Me.bConfigureAlarmReports.Visible = False
        '
        'bGenerateChart
        '
        Me.bGenerateChart.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGenerateChart.Location = New System.Drawing.Point(713, 412)
        Me.bGenerateChart.Name = "bGenerateChart"
        Me.bGenerateChart.Size = New System.Drawing.Size(178, 47)
        Me.bGenerateChart.TabIndex = 328
        Me.bGenerateChart.Text = "Generate Chart"
        Me.bGenerateChart.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(32, 516)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 37)
        Me.Button1.TabIndex = 339
        Me.Button1.Text = "Synchronize Point Names"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bConfigure
        '
        Me.bConfigure.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConfigure.Location = New System.Drawing.Point(32, 297)
        Me.bConfigure.Name = "bConfigure"
        Me.bConfigure.Size = New System.Drawing.Size(260, 37)
        Me.bConfigure.TabIndex = 340
        Me.bConfigure.Text = "Configure Main Parameters"
        Me.bConfigure.UseVisualStyleBackColor = True
        '
        'btnExcursionReport
        '
        Me.btnExcursionReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcursionReport.Location = New System.Drawing.Point(32, 383)
        Me.btnExcursionReport.Name = "btnExcursionReport"
        Me.btnExcursionReport.Size = New System.Drawing.Size(260, 37)
        Me.btnExcursionReport.TabIndex = 341
        Me.btnExcursionReport.Text = "Configure Excursion Reports"
        Me.btnExcursionReport.UseVisualStyleBackColor = True
        Me.btnExcursionReport.Visible = False
        '
        'btnBatteryPercentage
        '
        Me.btnBatteryPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatteryPercentage.Location = New System.Drawing.Point(32, 430)
        Me.btnBatteryPercentage.Name = "btnBatteryPercentage"
        Me.btnBatteryPercentage.Size = New System.Drawing.Size(260, 37)
        Me.btnBatteryPercentage.TabIndex = 342
        Me.btnBatteryPercentage.Text = "Configure Battery  Reports"
        Me.btnBatteryPercentage.UseVisualStyleBackColor = True
        Me.btnBatteryPercentage.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1129, 901)
        Me.Controls.Add(Me.btnBatteryPercentage)
        Me.Controls.Add(Me.btnExcursionReport)
        Me.Controls.Add(Me.bConfigure)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bConfigureAlarmReports)
        Me.Controls.Add(Me.bCOnfigureReports)
        Me.Controls.Add(Me.cGroup)
        Me.Controls.Add(Me.oGrid)
        Me.Controls.Add(Me.oProgress)
        Me.Controls.Add(Me.cInterval)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.oReportGrid)
        Me.Controls.Add(Me.bGenerateChart)
        Me.Controls.Add(Me.bGenerate)
        Me.Controls.Add(Me.tr_ToDate)
        Me.Controls.Add(Me.tr_FromDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.oReportGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tr_FromDate As DateTimePicker
    Friend WithEvents tr_ToDate As DateTimePicker
    Friend WithEvents bGenerate As Button
    Friend WithEvents oReportGrid As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents bEventReport As RadioButton
    Friend WithEvents bAlarmReports As RadioButton
    Friend WithEvents bAreaReports As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Report As DataGridViewTextBoxColumn
    Friend WithEvents Interval As DataGridViewTextBoxColumn
    Friend WithEvents oTimer As Timer
    Friend WithEvents cInterval As ComboBox
    Friend WithEvents oProgress As ProgressBar
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents StatusID As DataGridViewTextBoxColumn
    Friend WithEvents ReportFileName As DataGridViewTextBoxColumn
    Friend WithEvents ReportPathName As DataGridViewTextBoxColumn
    Friend WithEvents Open As DataGridViewButtonColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents cGroup As ComboBox
    Friend WithEvents bCOnfigureReports As Button
    Friend WithEvents bConfigureAlarmReports As Button
    Friend WithEvents bGenerateChart As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents bConfigure As Button
    Friend WithEvents btnExcursionReport As Button
    Friend WithEvents btnBatteryPercentage As Button
End Class
