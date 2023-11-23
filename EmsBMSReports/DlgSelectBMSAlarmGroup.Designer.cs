using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgSelectBMSAlarmGroup : Form
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
            oGroup = new ListBox();
            oGroup.SelectedIndexChanged += new EventHandler(oGroup_SelectedIndexChanged);
            bSelect = new Button();
            bCancel = new Button();
            SuspendLayout();
            // 
            // oGroup
            // 
            oGroup.FormattingEnabled = true;
            oGroup.ItemHeight = 16;
            oGroup.Location = new Point(13, 13);
            oGroup.Name = "oGroup";
            oGroup.Size = new Size(243, 356);
            oGroup.TabIndex = 0;
            // 
            // bSelect
            // 
            bSelect.DialogResult = DialogResult.OK;
            bSelect.Location = new Point(299, 39);
            bSelect.Name = "bSelect";
            bSelect.Size = new Size(75, 23);
            bSelect.TabIndex = 1;
            bSelect.Text = "Select";
            bSelect.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            bCancel.DialogResult = DialogResult.Cancel;
            bCancel.Location = new Point(299, 91);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(75, 23);
            bCancel.TabIndex = 1;
            bCancel.Text = "Close";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // DlgSelectBMSAlarmGroup
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 388);
            Controls.Add(bCancel);
            Controls.Add(bSelect);
            Controls.Add(oGroup);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgSelectBMSAlarmGroup";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select BMS Alarm Group";
            Load += new EventHandler(DlgSelectBMSAlarmGroup_Load);
            ResumeLayout(false);

        }

        internal ListBox oGroup;
        internal Button bSelect;
        internal Button bCancel;
    }
}