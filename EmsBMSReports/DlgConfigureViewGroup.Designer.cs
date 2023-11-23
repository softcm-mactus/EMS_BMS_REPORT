using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgConfigureViewGroup : Form
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
            this.colGrid = new System.Windows.Forms.DataGridView();
            this.groupView = new System.Windows.Forms.TreeView();
            this.Label1 = new System.Windows.Forms.Label();
            this.addCategory = new System.Windows.Forms.Button();
            this.addGroup = new System.Windows.Forms.Button();
            this.ExternalLogId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.GroupName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.colGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // colGrid
            // 
            this.colGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExternalLogId,
            this.DataGridViewTextBoxColumn8});
            this.colGrid.Location = new System.Drawing.Point(363, 48);
            this.colGrid.MultiSelect = false;
            this.colGrid.Name = "colGrid";
            this.colGrid.Size = new System.Drawing.Size(729, 413);
            this.colGrid.TabIndex = 2;
            this.colGrid.TextChanged += new System.EventHandler(this.colGrid_TextChanged);
            this.colGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView3_CellContentClick);
            this.colGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView3_CellValueChanged);
            this.colGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.colGrid_RowsAdded);
            this.colGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.colGrid_RowsRemoved);
            this.colGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.colGrid_UserDeletedRow);
            this.colGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colGrid_MouseDoubleClick);
            // 
            // groupView
            // 
            this.groupView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupView.FullRowSelect = true;
            this.groupView.LabelEdit = true;
            this.groupView.Location = new System.Drawing.Point(35, 48);
            this.groupView.Name = "groupView";
            this.groupView.PathSeparator = "/";
            this.groupView.Size = new System.Drawing.Size(250, 413);
            this.groupView.TabIndex = 3;
            this.groupView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.groupView_AfterLabelEdit);
            this.groupView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupView_AfterSelect);
            this.groupView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.groupView_MouseDoubleClick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(45, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(114, 18);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Category/Group";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // addCategory
            // 
            this.addCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory.Location = new System.Drawing.Point(37, 469);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(117, 34);
            this.addCategory.TabIndex = 5;
            this.addCategory.Text = "Add Category";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.Button1_Click);
            // 
            // addGroup
            // 
            this.addGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGroup.Location = new System.Drawing.Point(170, 469);
            this.addGroup.Name = "addGroup";
            this.addGroup.Size = new System.Drawing.Size(117, 34);
            this.addGroup.TabIndex = 6;
            this.addGroup.Text = "Add Group";
            this.addGroup.UseVisualStyleBackColor = true;
            this.addGroup.TextChanged += new System.EventHandler(this.addGroup_TextChanged);
            this.addGroup.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ExternalLogId
            // 
            this.ExternalLogId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ExternalLogId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExternalLogId.HeaderText = "ExternalLogId";
            this.ExternalLogId.Name = "ExternalLogId";
            this.ExternalLogId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExternalLogId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DataGridViewTextBoxColumn8
            // 
            this.DataGridViewTextBoxColumn8.HeaderText = "Column Name";
            this.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
            this.DataGridViewTextBoxColumn8.Width = 400;
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(834, 469);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(117, 34);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(977, 469);
            this.Save.Name = "Save";
            this.Save.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Save.Size = new System.Drawing.Size(117, 34);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // GroupName
            // 
            this.GroupName.AutoSize = true;
            this.GroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupName.Location = new System.Drawing.Point(377, 27);
            this.GroupName.Name = "GroupName";
            this.GroupName.Size = new System.Drawing.Size(0, 18);
            this.GroupName.TabIndex = 9;
            // 
            // DlgConfigureViewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 548);
            this.Controls.Add(this.GroupName);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.addGroup);
            this.Controls.Add(this.addCategory);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.groupView);
            this.Controls.Add(this.colGrid);
            this.Name = "DlgConfigureViewGroup";
            this.Text = "DlgConfigureViewGroup";
            this.Load += new System.EventHandler(this.DlgConfigureViewGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal DataGridView colGrid;
        internal TreeView groupView;
        internal Label Label1;
        internal Button addCategory;
        internal Button addGroup;
        private DataGridViewComboBoxColumn ExternalLogId;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumn8;
        internal Button Cancel;
        internal Button Save;
        internal Label GroupName;
    }
}