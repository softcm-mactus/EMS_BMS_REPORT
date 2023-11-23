using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class dlgSelectColumns : Form
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
            oColumns = new CheckedListBox();
            oColumns.SelectedIndexChanged += new EventHandler(oColumns_SelectedIndexChanged);
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            SuspendLayout();
            // 
            // oColumns
            // 
            oColumns.CheckOnClick = true;
            oColumns.FormattingEnabled = true;
            oColumns.Location = new Point(31, 12);
            oColumns.Name = "oColumns";
            oColumns.Size = new Size(473, 454);
            oColumns.TabIndex = 0;
            // 
            // Button1
            // 
            Button1.Location = new Point(635, 82);
            Button1.Name = "Button1";
            Button1.Size = new Size(75, 23);
            Button1.TabIndex = 1;
            Button1.Text = "Close";
            Button1.UseVisualStyleBackColor = true;
            // 
            // dlgSelectColumns
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 501);
            Controls.Add(Button1);
            Controls.Add(oColumns);
            Name = "dlgSelectColumns";
            Text = "dlgSelectColumns";
            Load += new EventHandler(dlgSelectColumns_Load);
            ResumeLayout(false);

        }

        internal CheckedListBox oColumns;
        internal Button Button1;
    }
}