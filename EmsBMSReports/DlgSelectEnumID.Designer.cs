using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgSelectEnumID : Form
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
            oGrid = new DataGridView();
            oGrid.CellClick += new DataGridViewCellEventHandler(oGrid_CellClick);
            Added = new DataGridViewCheckBoxColumn();
            EnumID = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            bUpdate = new Button();
            bUpdate.Click += new EventHandler(bUpdate_Click);
            bSelect = new Button();
            bClose = new Button();
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            SuspendLayout();
            // 
            // oGrid
            // 
            oGrid.AllowUserToDeleteRows = false;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { Added, EnumID, Value, Description });
            oGrid.Location = new Point(12, 12);
            oGrid.Name = "oGrid";
            oGrid.Size = new Size(422, 353);
            oGrid.TabIndex = 0;
            // 
            // Added
            // 
            Added.HeaderText = "Added";
            Added.Name = "Added";
            Added.Visible = false;
            // 
            // EnumID
            // 
            EnumID.HeaderText = "ID";
            EnumID.Name = "EnumID";
            EnumID.Width = 50;
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.Width = 50;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.Width = 250;
            // 
            // bUpdate
            // 
            bUpdate.Location = new Point(456, 55);
            bUpdate.Name = "bUpdate";
            bUpdate.Size = new Size(111, 23);
            bUpdate.TabIndex = 1;
            bUpdate.Text = "Update";
            bUpdate.UseVisualStyleBackColor = true;
            bUpdate.Visible = false;
            // 
            // bSelect
            // 
            bSelect.DialogResult = DialogResult.OK;
            bSelect.Enabled = false;
            bSelect.Location = new Point(456, 175);
            bSelect.Name = "bSelect";
            bSelect.Size = new Size(99, 23);
            bSelect.TabIndex = 1;
            bSelect.Text = "Select";
            bSelect.UseVisualStyleBackColor = true;
            // 
            // bClose
            // 
            bClose.DialogResult = DialogResult.Cancel;
            bClose.Location = new Point(456, 312);
            bClose.Name = "bClose";
            bClose.Size = new Size(99, 23);
            bClose.TabIndex = 1;
            bClose.Text = "Close";
            bClose.UseVisualStyleBackColor = true;
            // 
            // DlgSelectEnumID
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 388);
            Controls.Add(bClose);
            Controls.Add(bSelect);
            Controls.Add(bUpdate);
            Controls.Add(oGrid);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgSelectEnumID";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Enumeration ID for Digital points";
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            Load += new EventHandler(DlgSelectEnumID_Load);
            ResumeLayout(false);

        }

        internal DataGridView oGrid;
        internal DataGridViewCheckBoxColumn Added;
        internal DataGridViewTextBoxColumn EnumID;
        internal DataGridViewTextBoxColumn Value;
        internal DataGridViewTextBoxColumn Description;
        internal Button bUpdate;
        internal Button bSelect;
        internal Button bClose;
    }
}