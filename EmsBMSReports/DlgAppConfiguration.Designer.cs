using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgAppConfiguration : Form
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
            var DataGridViewCellStyle13 = new DataGridViewCellStyle();
            var DataGridViewCellStyle14 = new DataGridViewCellStyle();
            var DataGridViewCellStyle15 = new DataGridViewCellStyle();
            var DataGridViewCellStyle16 = new DataGridViewCellStyle();
            oGrid = new DataGridView();
            oGrid.CellClick += new DataGridViewCellEventHandler(oGrid_CellClick);
            oGrid.CellValueChanged += new DataGridViewCellEventHandler(oGrid_CellValueChanged);
            bClose = new Button();
            btSave = new Button();
            btSave.Click += new EventHandler(btSave_Click);
            ID = new DataGridViewTextBoxColumn();
            Decription = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            MinValue = new DataGridViewTextBoxColumn();
            MaxValue = new DataGridViewTextBoxColumn();
            OldValue = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            SuspendLayout();
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.AllowUserToDeleteRows = false;
            oGrid.AllowUserToResizeRows = false;
            oGrid.BackgroundColor = SystemColors.Control;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { ID, Decription, Type, Value, MinValue, MaxValue, OldValue });
            oGrid.Location = new Point(12, 18);
            oGrid.Name = "oGrid";
            oGrid.RowHeadersVisible = false;
            oGrid.Size = new Size(679, 490);
            oGrid.TabIndex = 391;
            // 
            // bClose
            // 
            bClose.DialogResult = DialogResult.Cancel;
            bClose.Font = new Font("Microsoft Sans Serif", 10.0f);
            bClose.Location = new Point(721, 223);
            bClose.Margin = new Padding(3, 2, 3, 2);
            bClose.Name = "bClose";
            bClose.Size = new Size(151, 43);
            bClose.TabIndex = 389;
            bClose.Text = "Return";
            bClose.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            btSave.Font = new Font("Microsoft Sans Serif", 10.0f);
            btSave.Location = new Point(721, 72);
            btSave.Margin = new Padding(3, 2, 3, 2);
            btSave.Name = "btSave";
            btSave.Size = new Size(151, 43);
            btSave.TabIndex = 390;
            btSave.Text = "Update";
            btSave.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Resizable = DataGridViewTriState.False;
            ID.SortMode = DataGridViewColumnSortMode.NotSortable;
            ID.Visible = false;
            // 
            // Decription
            // 
            Decription.DataPropertyName = "Description";
            DataGridViewCellStyle13.BackColor = Color.FromArgb(224, 224, 224);
            Decription.DefaultCellStyle = DataGridViewCellStyle13;
            Decription.HeaderText = "Parameter Description";
            Decription.Name = "Decription";
            Decription.ReadOnly = true;
            Decription.Resizable = DataGridViewTriState.False;
            Decription.SortMode = DataGridViewColumnSortMode.NotSortable;
            Decription.Width = 350;
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Resizable = DataGridViewTriState.False;
            Type.SortMode = DataGridViewColumnSortMode.NotSortable;
            Type.Visible = false;
            // 
            // Value
            // 
            Value.DataPropertyName = "Value";
            DataGridViewCellStyle14.Format = "N0";
            DataGridViewCellStyle14.NullValue = null;
            Value.DefaultCellStyle = DataGridViewCellStyle14;
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.Resizable = DataGridViewTriState.False;
            Value.SortMode = DataGridViewColumnSortMode.NotSortable;
            Value.Width = 300;
            // 
            // MinValue
            // 
            DataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCellStyle15.BackColor = Color.FromArgb(224, 224, 224);
            MinValue.DefaultCellStyle = DataGridViewCellStyle15;
            MinValue.HeaderText = "MinValue";
            MinValue.Name = "MinValue";
            MinValue.ReadOnly = true;
            MinValue.Visible = false;
            MinValue.Width = 75;
            // 
            // MaxValue
            // 
            DataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCellStyle16.BackColor = Color.FromArgb(224, 224, 224);
            MaxValue.DefaultCellStyle = DataGridViewCellStyle16;
            MaxValue.HeaderText = "MaxValue";
            MaxValue.Name = "MaxValue";
            MaxValue.ReadOnly = true;
            MaxValue.Visible = false;
            MaxValue.Width = 75;
            // 
            // OldValue
            // 
            OldValue.HeaderText = "OldValue";
            OldValue.Name = "OldValue";
            OldValue.Visible = false;
            // 
            // DlgAppConfiguration
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 528);
            Controls.Add(oGrid);
            Controls.Add(bClose);
            Controls.Add(btSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgAppConfiguration";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Site Configuration";
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            Load += new EventHandler(DlgAppConfiguration_Load);
            ResumeLayout(false);

        }

        internal DataGridView oGrid;
        internal Button bClose;
        internal Button btSave;
        internal DataGridViewTextBoxColumn ID;
        internal DataGridViewTextBoxColumn Decription;
        internal DataGridViewTextBoxColumn Type;
        internal DataGridViewTextBoxColumn Value;
        internal DataGridViewTextBoxColumn MinValue;
        internal DataGridViewTextBoxColumn MaxValue;
        internal DataGridViewTextBoxColumn OldValue;
    }
}