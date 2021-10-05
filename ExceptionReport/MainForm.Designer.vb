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
        Me.bGenerate = New System.Windows.Forms.Button()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.oGrid = New System.Windows.Forms.DataGridView()
        Me.PointID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PointName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataMissingTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateMissingEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oAllPoints = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bGenerate
        '
        Me.bGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGenerate.Location = New System.Drawing.Point(543, 4)
        Me.bGenerate.Name = "bGenerate"
        Me.bGenerate.Size = New System.Drawing.Size(161, 39)
        Me.bGenerate.TabIndex = 0
        Me.bGenerate.Text = "Generate"
        Me.bGenerate.UseVisualStyleBackColor = True
        '
        'dtFrom
        '
        Me.dtFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFrom.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(120, 12)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(156, 20)
        Me.dtFrom.TabIndex = 1
        '
        'dtto
        '
        Me.dtto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(365, 11)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(156, 20)
        Me.dtto.TabIndex = 2
        '
        'oGrid
        '
        Me.oGrid.AllowUserToAddRows = False
        Me.oGrid.AllowUserToDeleteRows = False
        Me.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PointID, Me.PointName, Me.DataMissingTime, Me.DateMissingEnd, Me.Duration})
        Me.oGrid.Location = New System.Drawing.Point(12, 77)
        Me.oGrid.Name = "oGrid"
        Me.oGrid.ReadOnly = True
        Me.oGrid.Size = New System.Drawing.Size(1069, 542)
        Me.oGrid.TabIndex = 3
        '
        'PointID
        '
        Me.PointID.HeaderText = "PointID"
        Me.PointID.Name = "PointID"
        Me.PointID.ReadOnly = True
        Me.PointID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PointName
        '
        Me.PointName.HeaderText = "Point Name"
        Me.PointName.Name = "PointName"
        Me.PointName.ReadOnly = True
        Me.PointName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PointName.Width = 370
        '
        'DataMissingTime
        '
        Me.DataMissingTime.HeaderText = "Data Missing Start Time"
        Me.DataMissingTime.Name = "DataMissingTime"
        Me.DataMissingTime.ReadOnly = True
        Me.DataMissingTime.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataMissingTime.Width = 200
        '
        'DateMissingEnd
        '
        Me.DateMissingEnd.HeaderText = "Data Missing End Time"
        Me.DateMissingEnd.Name = "DateMissingEnd"
        Me.DateMissingEnd.ReadOnly = True
        Me.DateMissingEnd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DateMissingEnd.Width = 200
        '
        'Duration
        '
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        Me.Duration.ReadOnly = True
        Me.Duration.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'oAllPoints
        '
        Me.oAllPoints.Location = New System.Drawing.Point(22, 44)
        Me.oAllPoints.Name = "oAllPoints"
        Me.oAllPoints.Size = New System.Drawing.Size(1059, 23)
        Me.oAllPoints.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(776, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 5
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 631)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.oAllPoints)
        Me.Controls.Add(Me.oGrid)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.bGenerate)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.oGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bGenerate As Button
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents oGrid As DataGridView
    Friend WithEvents oAllPoints As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents PointID As DataGridViewTextBoxColumn
    Friend WithEvents PointName As DataGridViewTextBoxColumn
    Friend WithEvents DataMissingTime As DataGridViewTextBoxColumn
    Friend WithEvents DateMissingEnd As DataGridViewTextBoxColumn
    Friend WithEvents Duration As DataGridViewTextBoxColumn
End Class
