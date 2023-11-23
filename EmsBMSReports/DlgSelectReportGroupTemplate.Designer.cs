using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgSelectReportGroupTemplate : Form
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
            cTemplate = new ComboBox();
            cTemplate.SelectedIndexChanged += new EventHandler(cTemplate_SelectedIndexChanged);
            Label1 = new Label();
            Label2 = new Label();
            cGroup = new ComboBox();
            cGroup.SelectedIndexChanged += new EventHandler(cGroup_SelectedIndexChanged);
            Label3 = new Label();
            tReportTitle = new TextBox();
            tReportTitle.TextChanged += new EventHandler(tReportTitle_TextChanged);
            bAdd = new Button();
            bAdd.Click += new EventHandler(bAdd_Click);
            bCancel = new Button();
            bCancel.Click += new EventHandler(bCancel_Click);
            bAddNewGroup = new Button();
            bAddNewGroup.Click += new EventHandler(bAddNewGroup_Click);
            SuspendLayout();
            // 
            // cTemplate
            // 
            cTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cTemplate.FormattingEnabled = true;
            cTemplate.Location = new Point(41, 34);
            cTemplate.Name = "cTemplate";
            cTemplate.Size = new Size(323, 24);
            cTemplate.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(41, 13);
            Label1.Name = "Label1";
            Label1.Size = new Size(110, 16);
            Label1.TabIndex = 2;
            Label1.Text = "Report Template";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(41, 78);
            Label2.Name = "Label2";
            Label2.Size = new Size(89, 16);
            Label2.TabIndex = 3;
            Label2.Text = "Report Group";
            // 
            // cGroup
            // 
            cGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cGroup.FormattingEnabled = true;
            cGroup.Location = new Point(41, 97);
            cGroup.Name = "cGroup";
            cGroup.Size = new Size(323, 24);
            cGroup.TabIndex = 4;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(41, 147);
            Label3.Name = "Label3";
            Label3.Size = new Size(78, 16);
            Label3.TabIndex = 5;
            Label3.Text = "Report Title";
            // 
            // tReportTitle
            // 
            tReportTitle.Location = new Point(41, 167);
            tReportTitle.Name = "tReportTitle";
            tReportTitle.Size = new Size(628, 22);
            tReportTitle.TabIndex = 6;
            // 
            // bAdd
            // 
            bAdd.DialogResult = DialogResult.OK;
            bAdd.Enabled = false;
            bAdd.Location = new Point(537, 34);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(132, 23);
            bAdd.TabIndex = 7;
            bAdd.Text = "Add";
            bAdd.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            bCancel.DialogResult = DialogResult.Cancel;
            bCancel.Location = new Point(537, 97);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(132, 23);
            bCancel.TabIndex = 8;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // bAddNewGroup
            // 
            bAddNewGroup.Location = new Point(370, 78);
            bAddNewGroup.Name = "bAddNewGroup";
            bAddNewGroup.Size = new Size(72, 43);
            bAddNewGroup.TabIndex = 7;
            bAddNewGroup.Text = "Add New Group";
            bAddNewGroup.UseVisualStyleBackColor = true;
            // 
            // DlgSelectReportGroupTemplate
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 211);
            Controls.Add(bCancel);
            Controls.Add(bAddNewGroup);
            Controls.Add(bAdd);
            Controls.Add(tReportTitle);
            Controls.Add(Label3);
            Controls.Add(cGroup);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(cTemplate);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgSelectReportGroupTemplate";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "DlgSelectReportGroupTemplate";
            Load += new EventHandler(DlgSelectReportGroupTemplate_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal ComboBox cTemplate;
        internal Label Label1;
        internal Label Label2;
        internal ComboBox cGroup;
        internal Label Label3;
        internal TextBox tReportTitle;
        internal Button bAdd;
        internal Button bCancel;
        internal Button bAddNewGroup;
    }
}