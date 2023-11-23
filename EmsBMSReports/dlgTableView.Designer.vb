<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgTableView
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
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.viewData = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cGroup = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.oReports = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SelectColumn = New System.Windows.Forms.Button()
        Me.ColInfo = New System.Windows.Forms.TextBox()
        Me.CheckInfo = New System.Windows.Forms.TextBox()
        Me.ColQuery = New System.Windows.Forms.TextBox()
        Me.oEndTime = New System.Windows.Forms.DateTimePicker()
        Me.oStartTime = New System.Windows.Forms.DateTimePicker()
        Me.oEndDate = New System.Windows.Forms.DateTimePicker()
        Me.oStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.oTolerance = New System.Windows.Forms.NumericUpDown()
        Me.oPrecision = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.oIncludeEvents = New System.Windows.Forms.CheckBox()
        Me.RowQuery = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.oTolerance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.oPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.AllowUserToResizeRows = False
        Me.oGrid.Location = New System.Drawing.Point(13, 117)
        Me.oGrid.MultiSelect = False
        Me.oGrid.Name = "oGrid"
        Me.oGrid.Size = New System.Drawing.Size(1361, 516)
        Me.oGrid.TabIndex = 1
        '
        'viewData
        '
        Me.viewData.Location = New System.Drawing.Point(1312, 18)
        Me.viewData.Name = "viewData"
        Me.viewData.Size = New System.Drawing.Size(62, 56)
        Me.viewData.TabIndex = 4
        Me.viewData.Text = "View"
        Me.viewData.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 328
        Me.Label4.Text = "To Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 20)
        Me.Label3.TabIndex = 329
        Me.Label3.Text = "From Date"
        '
        'cGroup
        '
        Me.cGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cGroup.FormattingEnabled = True
        Me.cGroup.Location = New System.Drawing.Point(465, 13)
        Me.cGroup.Name = "cGroup"
        Me.cGroup.Size = New System.Drawing.Size(312, 24)
        Me.cGroup.TabIndex = 339
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(349, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 20)
        Me.Label6.TabIndex = 338
        Me.Label6.Text = "Group Name"
        '
        'oReports
        '
        Me.oReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.oReports.FormattingEnabled = True
        Me.oReports.Location = New System.Drawing.Point(465, 47)
        Me.oReports.Name = "oReports"
        Me.oReports.Size = New System.Drawing.Size(312, 24)
        Me.oReports.TabIndex = 341
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(349, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "Report Name"
        '
        'SelectColumn
        '
        Me.SelectColumn.Location = New System.Drawing.Point(1182, 18)
        Me.SelectColumn.Name = "SelectColumn"
        Me.SelectColumn.Size = New System.Drawing.Size(124, 56)
        Me.SelectColumn.TabIndex = 344
        Me.SelectColumn.Text = "Select Columns"
        Me.SelectColumn.UseVisualStyleBackColor = True
        '
        'ColInfo
        '
        Me.ColInfo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ColInfo.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColInfo.Location = New System.Drawing.Point(13, 630)
        Me.ColInfo.Multiline = True
        Me.ColInfo.Name = "ColInfo"
        Me.ColInfo.ReadOnly = True
        Me.ColInfo.Size = New System.Drawing.Size(446, 58)
        Me.ColInfo.TabIndex = 347
        '
        'CheckInfo
        '
        Me.CheckInfo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckInfo.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold)
        Me.CheckInfo.Location = New System.Drawing.Point(465, 630)
        Me.CheckInfo.Multiline = True
        Me.CheckInfo.Name = "CheckInfo"
        Me.CheckInfo.ReadOnly = True
        Me.CheckInfo.Size = New System.Drawing.Size(253, 58)
        Me.CheckInfo.TabIndex = 348
        '
        'ColQuery
        '
        Me.ColQuery.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ColQuery.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ColQuery.Location = New System.Drawing.Point(724, 630)
        Me.ColQuery.Multiline = True
        Me.ColQuery.Name = "ColQuery"
        Me.ColQuery.ReadOnly = True
        Me.ColQuery.Size = New System.Drawing.Size(250, 58)
        Me.ColQuery.TabIndex = 349
        '
        'oEndTime
        '
        Me.oEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.oEndTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.oEndTime.Location = New System.Drawing.Point(222, 51)
        Me.oEndTime.Name = "oEndTime"
        Me.oEndTime.ShowUpDown = True
        Me.oEndTime.Size = New System.Drawing.Size(102, 22)
        Me.oEndTime.TabIndex = 346
        Me.oEndTime.Value = New Date(2023, 11, 22, 21, 0, 13, 0)
        '
        'oStartTime
        '
        Me.oStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.oStartTime.Location = New System.Drawing.Point(222, 17)
        Me.oStartTime.Name = "oStartTime"
        Me.oStartTime.ShowUpDown = True
        Me.oStartTime.Size = New System.Drawing.Size(102, 22)
        Me.oStartTime.TabIndex = 345
        Me.oStartTime.Value = New Date(2023, 11, 22, 21, 0, 13, 0)
        '
        'oEndDate
        '
        Me.oEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.oEndDate.Location = New System.Drawing.Point(114, 50)
        Me.oEndDate.Name = "oEndDate"
        Me.oEndDate.Size = New System.Drawing.Size(102, 22)
        Me.oEndDate.TabIndex = 343
        Me.oEndDate.Value = New Date(2023, 11, 22, 20, 59, 38, 0)
        '
        'oStartDate
        '
        Me.oStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.oStartDate.Location = New System.Drawing.Point(114, 16)
        Me.oStartDate.Name = "oStartDate"
        Me.oStartDate.Size = New System.Drawing.Size(102, 22)
        Me.oStartDate.TabIndex = 342
        Me.oStartDate.Value = New Date(2023, 11, 20, 21, 37, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(790, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 350
        Me.Label2.Text = "Tolerance"
        '
        'oTolerance
        '
        Me.oTolerance.Location = New System.Drawing.Point(885, 17)
        Me.oTolerance.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.oTolerance.Name = "oTolerance"
        Me.oTolerance.Size = New System.Drawing.Size(96, 22)
        Me.oTolerance.TabIndex = 352
        Me.oTolerance.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'oPrecision
        '
        Me.oPrecision.Location = New System.Drawing.Point(885, 52)
        Me.oPrecision.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.oPrecision.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.oPrecision.Name = "oPrecision"
        Me.oPrecision.Size = New System.Drawing.Size(96, 22)
        Me.oPrecision.TabIndex = 354
        Me.oPrecision.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(796, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 20)
        Me.Label5.TabIndex = 353
        Me.Label5.Text = "Precision"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(987, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 20)
        Me.Label7.TabIndex = 355
        Me.Label7.Text = "ms"
        '
        'oIncludeEvents
        '
        Me.oIncludeEvents.AutoSize = True
        Me.oIncludeEvents.Location = New System.Drawing.Point(1049, 19)
        Me.oIncludeEvents.Name = "oIncludeEvents"
        Me.oIncludeEvents.Size = New System.Drawing.Size(113, 20)
        Me.oIncludeEvents.TabIndex = 356
        Me.oIncludeEvents.Text = "Include Events"
        Me.oIncludeEvents.UseVisualStyleBackColor = True
        '
        'RowQuery
        '
        Me.RowQuery.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.RowQuery.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold)
        Me.RowQuery.Location = New System.Drawing.Point(1010, 630)
        Me.RowQuery.Multiline = True
        Me.RowQuery.Name = "RowQuery"
        Me.RowQuery.ReadOnly = True
        Me.RowQuery.Size = New System.Drawing.Size(250, 58)
        Me.RowQuery.TabIndex = 357
        '
        'Timer1
        '
        Me.Timer1.Interval = 1500
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 0
        Me.ToolTip1.ReshowDelay = 0
        '
        'dlgTableView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1386, 689)
        Me.Controls.Add(Me.RowQuery)
        Me.Controls.Add(Me.oIncludeEvents)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.oPrecision)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.oTolerance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ColQuery)
        Me.Controls.Add(Me.CheckInfo)
        Me.Controls.Add(Me.ColInfo)
        Me.Controls.Add(Me.oEndTime)
        Me.Controls.Add(Me.oStartTime)
        Me.Controls.Add(Me.SelectColumn)
        Me.Controls.Add(Me.oEndDate)
        Me.Controls.Add(Me.oStartDate)
        Me.Controls.Add(Me.oReports)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cGroup)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.viewData)
        Me.Controls.Add(Me.oGrid)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "dlgTableView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgColumnsConfiguration"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.oTolerance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.oPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents viewData As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cGroup As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents oReports As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents oStartDate As DateTimePicker
    Friend WithEvents oEndDate As DateTimePicker
    Friend WithEvents SelectColumn As Button
    Friend WithEvents oEndTime As DateTimePicker
    Friend WithEvents oStartTime As DateTimePicker
    Friend WithEvents ColInfo As TextBox
    Friend WithEvents CheckInfo As TextBox
    Friend WithEvents ColQuery As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents oTolerance As NumericUpDown
    Friend WithEvents oPrecision As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents oIncludeEvents As CheckBox
    Friend WithEvents RowQuery As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolTip2 As ToolTip
End Class
