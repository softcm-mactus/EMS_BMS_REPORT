using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgNewGroup : Form
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
            OK_Button = new Button();
            OK_Button.Click += new EventHandler(OK_Button_Click);
            Cancel_Button = new Button();
            Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            Label1 = new Label();
            tGroupName = new TextBox();
            tGroupName.TextChanged += new EventHandler(tGroupName_TextChanged);
            SuspendLayout();
            // 
            // OK_Button
            // 
            OK_Button.Anchor = AnchorStyles.None;
            OK_Button.Enabled = false;
            OK_Button.Location = new Point(283, 39);
            OK_Button.Name = "OK_Button";
            OK_Button.Size = new Size(67, 23);
            OK_Button.TabIndex = 0;
            OK_Button.Text = "Add";
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = AnchorStyles.None;
            Cancel_Button.DialogResult = DialogResult.Cancel;
            Cancel_Button.Location = new Point(356, 38);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(67, 23);
            Cancel_Button.TabIndex = 1;
            Cancel_Button.Text = "Close";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label1.Location = new Point(13, 23);
            Label1.Name = "Label1";
            Label1.Size = new Size(186, 16);
            Label1.TabIndex = 2;
            Label1.Text = "New Data Trend Group Name";
            // 
            // tGroupName
            // 
            tGroupName.Location = new Point(16, 41);
            tGroupName.Name = "tGroupName";
            tGroupName.Size = new Size(256, 20);
            tGroupName.TabIndex = 3;
            // 
            // DlgNewGroup
            // 
            AcceptButton = OK_Button;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel_Button;
            ClientSize = new Size(435, 88);
            Controls.Add(tGroupName);
            Controls.Add(Label1);
            Controls.Add(Cancel_Button);
            Controls.Add(OK_Button);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgNewGroup";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Data Group";
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button OK_Button;
        internal Button Cancel_Button;
        internal Label Label1;
        internal TextBox tGroupName;
    }
}