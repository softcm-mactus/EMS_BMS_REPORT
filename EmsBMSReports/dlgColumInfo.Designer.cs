using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class dlgColumInfo : Form
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
            ColInfo = new TextBox();
            SuspendLayout();
            // 
            // ColInfo
            // 
            ColInfo.BackColor = SystemColors.ControlLightLight;
            ColInfo.Font = new Font("Courier New", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            ColInfo.Location = new Point(78, 69);
            ColInfo.Multiline = true;
            ColInfo.Name = "ColInfo";
            ColInfo.ReadOnly = true;
            ColInfo.Size = new Size(664, 234);
            ColInfo.TabIndex = 0;
            // 
            // dlgColumInfo
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 469);
            Controls.Add(ColInfo);
            Name = "dlgColumInfo";
            Text = "EBO Column Info";
            Load += new EventHandler(dlgColumInfo_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        internal TextBox ColInfo;
    }
}