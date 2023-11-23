using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DataTrendChart : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components = null;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var ChartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            var Legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            var Series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            oTrendChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)oTrendChart).BeginInit();
            SuspendLayout();
            // 
            // oTrendChart
            // 
            ChartArea1.AxisX.IsStartedFromZero = false;
            ChartArea1.AxisX.Title = "Time";
            ChartArea1.Name = "ChartArea1";
            oTrendChart.ChartAreas.Add(ChartArea1);
            Legend1.Name = "Legend1";
            oTrendChart.Legends.Add(Legend1);
            oTrendChart.Location = new Point(12, 85);
            oTrendChart.Name = "oTrendChart";
            Series1.BorderColor = Color.Red;
            Series1.BorderWidth = 3;
            Series1.ChartArea = "ChartArea1";
            Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Series1.Legend = "Legend1";
            Series1.Name = "Series1";
            oTrendChart.Series.Add(Series1);
            oTrendChart.Size = new Size(754, 389);
            oTrendChart.TabIndex = 392;
            oTrendChart.Text = "Chart1";
            // 
            // DataTrendChart
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 505);
            Controls.Add(oTrendChart);
            Name = "DataTrendChart";
            Text = "DataTrendChart";
            ((System.ComponentModel.ISupportInitialize)oTrendChart).EndInit();
            ResumeLayout(false);

        }

        internal System.Windows.Forms.DataVisualization.Charting.Chart oTrendChart;
    }
}