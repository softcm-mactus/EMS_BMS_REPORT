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
        Me.tIP = New System.Windows.Forms.TextBox()
        Me.bAdd = New System.Windows.Forms.Button()
        Me.bStartStop = New System.Windows.Forms.Button()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataMissingTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateMissingEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.oIPList = New System.Windows.Forms.DataGridView()
        Me.IPAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.oIPList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tIP
        '
        Me.tIP.Location = New System.Drawing.Point(33, 13)
        Me.tIP.Name = "tIP"
        Me.tIP.Size = New System.Drawing.Size(233, 20)
        Me.tIP.TabIndex = 0
        '
        'bAdd
        '
        Me.bAdd.Location = New System.Drawing.Point(289, 13)
        Me.bAdd.Name = "bAdd"
        Me.bAdd.Size = New System.Drawing.Size(75, 23)
        Me.bAdd.TabIndex = 1
        Me.bAdd.Text = "Add"
        Me.bAdd.UseVisualStyleBackColor = True
        '
        'bStartStop
        '
        Me.bStartStop.Location = New System.Drawing.Point(379, 13)
        Me.bStartStop.Name = "bStartStop"
        Me.bStartStop.Size = New System.Drawing.Size(75, 23)
        Me.bStartStop.TabIndex = 2
        Me.bStartStop.Text = "Start"
        Me.bStartStop.UseVisualStyleBackColor = True
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IP, Me.DataMissingTime, Me.DateMissingEnd, Me.Duration})
        Me.oGrid.Location = New System.Drawing.Point(289, 51)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.ReadOnly = True
        Me.oGrid.Size = New System.Drawing.Size(518, 427)
        Me.oGrid.TabIndex = 4
        '
        'IP
        '
        Me.IP.HeaderText = "Point Name"
        Me.IP.Name = "IP"
        Me.IP.ReadOnly = True
        Me.IP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataMissingTime
        '
        Me.DataMissingTime.HeaderText = "Data Missing Start Time"
        Me.DataMissingTime.Name = "DataMissingTime"
        Me.DataMissingTime.ReadOnly = True
        Me.DataMissingTime.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataMissingTime.Width = 150
        '
        'DateMissingEnd
        '
        Me.DateMissingEnd.HeaderText = "Data Missing End Time"
        Me.DateMissingEnd.Name = "DateMissingEnd"
        Me.DateMissingEnd.ReadOnly = True
        Me.DateMissingEnd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DateMissingEnd.Width = 150
        '
        'Duration
        '
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        Me.Duration.ReadOnly = True
        Me.Duration.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Duration.Width = 50
        '
        'oTimer
        '
        Me.oTimer.Interval = 10000
        '
        'oIPList
        '
        Me.oIPList.AllowUserToAddRows = False
        Me.oIPList.AllowUserToDeleteRows = False
        Me.oIPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oIPList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IPAddress, Me.Status})
        Me.oIPList.Location = New System.Drawing.Point(33, 51)
        Me.oIPList.Name = "oIPList"
        Me.oIPList.ReadOnly = True
        Me.oIPList.RowHeadersVisible = False
        Me.oIPList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.oIPList.Size = New System.Drawing.Size(233, 427)
        Me.oIPList.TabIndex = 5
        '
        'IPAddress
        '
        Me.IPAddress.HeaderText = "IP Address"
        Me.IPAddress.Name = "IPAddress"
        Me.IPAddress.ReadOnly = True
        Me.IPAddress.Width = 150
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'nInterval
        '
        Me.nInterval.Location = New System.Drawing.Point(475, 15)
        Me.nInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nInterval.Name = "nInterval"
        Me.nInterval.Size = New System.Drawing.Size(120, 20)
        Me.nInterval.TabIndex = 6
        Me.nInterval.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(640, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Label1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 490)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nInterval)
        Me.Controls.Add(Me.oIPList)
        Me.Controls.Add(Me.oGrid)
        Me.Controls.Add(Me.bStartStop)
        Me.Controls.Add(Me.bAdd)
        Me.Controls.Add(Me.tIP)
        Me.Name = "MainForm"
        Me.Text = "IP Error"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.oIPList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tIP As TextBox
    Friend WithEvents bAdd As Button
    Friend WithEvents bStartStop As Button
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents IP As DataGridViewTextBoxColumn
    Friend WithEvents DataMissingTime As DataGridViewTextBoxColumn
    Friend WithEvents DateMissingEnd As DataGridViewTextBoxColumn
    Friend WithEvents Duration As DataGridViewTextBoxColumn
    Friend WithEvents oTimer As Timer
    Friend WithEvents oIPList As DataGridView
    Friend WithEvents IPAddress As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents nInterval As NumericUpDown
    Friend WithEvents Label1 As Label
End Class
