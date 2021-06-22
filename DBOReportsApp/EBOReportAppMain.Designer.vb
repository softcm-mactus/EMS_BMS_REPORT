<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EBOReportMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cInterval = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bEventReport = New System.Windows.Forms.RadioButton()
        Me.bAlarmReports = New System.Windows.Forms.RadioButton()
        Me.bAreaReports = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Interval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Report = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oReportGrid = New System.Windows.Forms.DataGridView()
        Me.bGenerate = New System.Windows.Forms.Button()
        Me.tr_ToDate = New System.Windows.Forms.DateTimePicker()
        Me.tr_FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.oReportGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cInterval
        '
        Me.cInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cInterval.FormattingEnabled = True
        Me.cInterval.Items.AddRange(New Object() {"1", "5", "15", "30", "60"})
        Me.cInterval.Location = New System.Drawing.Point(710, 132)
        Me.cInterval.Name = "cInterval"
        Me.cInterval.Size = New System.Drawing.Size(121, 21)
        Me.cInterval.TabIndex = 345
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(706, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 20)
        Me.Label5.TabIndex = 336
        Me.Label5.Text = "Report Time Interval "
        '
        'bEventReport
        '
        Me.bEventReport.AutoSize = True
        Me.bEventReport.Location = New System.Drawing.Point(38, 141)
        Me.bEventReport.Name = "bEventReport"
        Me.bEventReport.Size = New System.Drawing.Size(137, 28)
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
        Me.bAlarmReports.Size = New System.Drawing.Size(147, 28)
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
        Me.bAreaReports.Size = New System.Drawing.Size(138, 28)
        Me.bAreaReports.TabIndex = 0
        Me.bAreaReports.TabStop = True
        Me.bAreaReports.Text = "Area Reports"
        Me.bAreaReports.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bEventReport)
        Me.GroupBox1.Controls.Add(Me.bAlarmReports)
        Me.GroupBox1.Controls.Add(Me.bAreaReports)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 195)
        Me.GroupBox1.TabIndex = 344
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report Type"
        '
        'Interval
        '
        Me.Interval.HeaderText = "Interval"
        Me.Interval.Name = "Interval"
        Me.Interval.ReadOnly = True
        Me.Interval.Visible = False
        '
        'Report
        '
        Me.Report.HeaderText = "Report Name"
        Me.Report.Name = "Report"
        Me.Report.ReadOnly = True
        Me.Report.Width = 300
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
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
        Me.oReportGrid.Location = New System.Drawing.Point(326, 108)
        Me.oReportGrid.MultiSelect = False
        Me.oReportGrid.Name = "oReportGrid"
        Me.oReportGrid.RowHeadersVisible = False
        Me.oReportGrid.Size = New System.Drawing.Size(334, 418)
        Me.oReportGrid.TabIndex = 343
        '
        'bGenerate
        '
        Me.bGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGenerate.Location = New System.Drawing.Point(710, 386)
        Me.bGenerate.Name = "bGenerate"
        Me.bGenerate.Size = New System.Drawing.Size(178, 47)
        Me.bGenerate.TabIndex = 342
        Me.bGenerate.Text = "Generate Report"
        Me.bGenerate.UseVisualStyleBackColor = True
        '
        'tr_ToDate
        '
        Me.tr_ToDate.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.tr_ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tr_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tr_ToDate.Location = New System.Drawing.Point(710, 311)
        Me.tr_ToDate.Name = "tr_ToDate"
        Me.tr_ToDate.ShowUpDown = True
        Me.tr_ToDate.Size = New System.Drawing.Size(178, 26)
        Me.tr_ToDate.TabIndex = 340
        '
        'tr_FromDate
        '
        Me.tr_FromDate.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.tr_FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tr_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tr_FromDate.Location = New System.Drawing.Point(710, 226)
        Me.tr_FromDate.Name = "tr_FromDate"
        Me.tr_FromDate.ShowUpDown = True
        Me.tr_FromDate.Size = New System.Drawing.Size(178, 26)
        Me.tr_FromDate.TabIndex = 341
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(706, 283)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 337
        Me.Label4.Text = "To Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(706, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 20)
        Me.Label3.TabIndex = 338
        Me.Label3.Text = "From Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 20)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Configured Reports"
        '
        'oTimer
        '
        Me.oTimer.Interval = 3000
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-3, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1085, 63)
        Me.Label1.TabIndex = 335
        Me.Label1.Text = "EMS Reporting Tool"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EBOReportMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 579)
        Me.Controls.Add(Me.cInterval)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.oReportGrid)
        Me.Controls.Add(Me.bGenerate)
        Me.Controls.Add(Me.tr_ToDate)
        Me.Controls.Add(Me.tr_FromDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EBOReportMainForm"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.oReportGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cInterval As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents bEventReport As RadioButton
    Friend WithEvents bAlarmReports As RadioButton
    Friend WithEvents bAreaReports As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Interval As DataGridViewTextBoxColumn
    Friend WithEvents Report As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents oReportGrid As DataGridView
    Friend WithEvents bGenerate As Button
    Friend WithEvents tr_ToDate As DateTimePicker
    Friend WithEvents tr_FromDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents oTimer As Timer
    Friend WithEvents Label1 As Label
End Class
