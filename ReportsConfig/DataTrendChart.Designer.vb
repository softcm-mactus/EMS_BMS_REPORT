<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTrendChart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.oTrendChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.oTrendChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oTrendChart
        '
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisX.Title = "Time"
        ChartArea1.Name = "ChartArea1"
        Me.oTrendChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.oTrendChart.Legends.Add(Legend1)
        Me.oTrendChart.Location = New System.Drawing.Point(12, 85)
        Me.oTrendChart.Name = "oTrendChart"
        Series1.BorderColor = System.Drawing.Color.Red
        Series1.BorderWidth = 3
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.oTrendChart.Series.Add(Series1)
        Me.oTrendChart.Size = New System.Drawing.Size(754, 389)
        Me.oTrendChart.TabIndex = 392
        Me.oTrendChart.Text = "Chart1"
        '
        'DataTrendChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 505)
        Me.Controls.Add(Me.oTrendChart)
        Me.Name = "DataTrendChart"
        Me.Text = "DataTrendChart"
        CType(Me.oTrendChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oTrendChart As DataVisualization.Charting.Chart
End Class
