using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class dlgColumnsConfiguration : Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNameInDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJust = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COlHeader2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LCT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LCV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HCT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HighCheckValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnumID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColMerge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SVCT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SVV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDeleteColumn = new System.Windows.Forms.Button();
            this.bAddNewColumn = new System.Windows.Forms.Button();
            this.bMoveUp = new System.Windows.Forms.Button();
            this.bMoveDown = new System.Windows.Forms.Button();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(1112, 447);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(195, 36);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(4, 4);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(89, 28);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Update";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(101, 4);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(89, 28);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // oGrid
            // 
            this.oGrid.AllowUserToAddRows = false;
            this.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.ColNameInDB,
            this.ColType,
            this.ColWidth,
            this.ColFormat,
            this.ColJust,
            this.ColHeader,
            this.COlHeader2,
            this.LC,
            this.LCT,
            this.LCV,
            this.HighCheck,
            this.HCT,
            this.HighCheckValue,
            this.EnumID,
            this.ColMerge,
            this.SVC,
            this.SVCT,
            this.SVV});
            this.oGrid.Location = new System.Drawing.Point(13, 13);
            this.oGrid.Name = "oGrid";
            this.oGrid.Size = new System.Drawing.Size(1294, 402);
            this.oGrid.TabIndex = 1;
            this.oGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellClick);
            this.oGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.oGrid_DataError);
            this.oGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_RowEnter);
            // 
            // colID
            // 
            this.colID.HeaderText = "colid";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // ColNameInDB
            // 
            this.ColNameInDB.HeaderText = "DB Col Name";
            this.ColNameInDB.Name = "ColNameInDB";
            this.ColNameInDB.ReadOnly = true;
            this.ColNameInDB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColType
            // 
            this.ColType.HeaderText = "Type";
            this.ColType.Items.AddRange(new object[] {
            "Temperature",
            "Humidity",
            "DP",
            "Other",
            "Frequency",
            "Enumtype"});
            this.ColType.Name = "ColType";
            // 
            // ColWidth
            // 
            this.ColWidth.HeaderText = "Col Width";
            this.ColWidth.Name = "ColWidth";
            this.ColWidth.Width = 50;
            // 
            // ColFormat
            // 
            this.ColFormat.HeaderText = "Column Format";
            this.ColFormat.Name = "ColFormat";
            this.ColFormat.Width = 70;
            // 
            // ColJust
            // 
            this.ColJust.HeaderText = "Justification";
            this.ColJust.Items.AddRange(new object[] {
            "Center",
            "Left",
            "Right"});
            this.ColJust.Name = "ColJust";
            // 
            // ColHeader
            // 
            this.ColHeader.HeaderText = "Column Sub Title";
            this.ColHeader.Name = "ColHeader";
            this.ColHeader.Width = 180;
            // 
            // COlHeader2
            // 
            this.COlHeader2.HeaderText = "Column Main Title";
            this.COlHeader2.Name = "COlHeader2";
            this.COlHeader2.Width = 180;
            // 
            // LC
            // 
            this.LC.HeaderText = "LC";
            this.LC.Name = "LC";
            this.LC.Width = 30;
            // 
            // LCT
            // 
            this.LCT.HeaderText = "LCT";
            this.LCT.Name = "LCT";
            this.LCT.Width = 40;
            // 
            // LCV
            // 
            this.LCV.HeaderText = "LCV";
            this.LCV.Name = "LCV";
            this.LCV.Width = 40;
            // 
            // HighCheck
            // 
            this.HighCheck.HeaderText = "HC";
            this.HighCheck.Name = "HighCheck";
            this.HighCheck.Width = 30;
            // 
            // HCT
            // 
            this.HCT.HeaderText = "HCT";
            this.HCT.Name = "HCT";
            this.HCT.Width = 40;
            // 
            // HighCheckValue
            // 
            this.HighCheckValue.HeaderText = "HCV";
            this.HighCheckValue.Name = "HighCheckValue";
            this.HighCheckValue.Width = 40;
            // 
            // EnumID
            // 
            this.EnumID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EnumID.HeaderText = "Enum ID";
            this.EnumID.Name = "EnumID";
            this.EnumID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EnumID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EnumID.Width = 45;
            // 
            // ColMerge
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColMerge.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColMerge.HeaderText = "Col Merge";
            this.ColMerge.Name = "ColMerge";
            this.ColMerge.Width = 50;
            // 
            // SVC
            // 
            this.SVC.HeaderText = "SVC";
            this.SVC.Name = "SVC";
            this.SVC.Width = 40;
            // 
            // SVCT
            // 
            this.SVCT.HeaderText = "SVCT";
            this.SVCT.Name = "SVCT";
            this.SVCT.Width = 45;
            // 
            // SVV
            // 
            this.SVV.HeaderText = "SVV";
            this.SVV.Name = "SVV";
            this.SVV.Width = 50;
            // 
            // bDeleteColumn
            // 
            this.bDeleteColumn.Location = new System.Drawing.Point(256, 435);
            this.bDeleteColumn.Name = "bDeleteColumn";
            this.bDeleteColumn.Size = new System.Drawing.Size(175, 33);
            this.bDeleteColumn.TabIndex = 5;
            this.bDeleteColumn.Text = "Delete Column";
            this.bDeleteColumn.UseVisualStyleBackColor = true;
            this.bDeleteColumn.Click += new System.EventHandler(this.bDeleteColumn_Click);
            // 
            // bAddNewColumn
            // 
            this.bAddNewColumn.Location = new System.Drawing.Point(37, 434);
            this.bAddNewColumn.Name = "bAddNewColumn";
            this.bAddNewColumn.Size = new System.Drawing.Size(175, 33);
            this.bAddNewColumn.TabIndex = 4;
            this.bAddNewColumn.Text = "Add New Column";
            this.bAddNewColumn.UseVisualStyleBackColor = true;
            this.bAddNewColumn.Click += new System.EventHandler(this.bAddNewColumn_Click);
            // 
            // bMoveUp
            // 
            this.bMoveUp.Location = new System.Drawing.Point(555, 435);
            this.bMoveUp.Name = "bMoveUp";
            this.bMoveUp.Size = new System.Drawing.Size(175, 33);
            this.bMoveUp.TabIndex = 6;
            this.bMoveUp.Text = "Move Row Up";
            this.bMoveUp.UseVisualStyleBackColor = true;
            this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
            // 
            // bMoveDown
            // 
            this.bMoveDown.Location = new System.Drawing.Point(753, 435);
            this.bMoveDown.Name = "bMoveDown";
            this.bMoveDown.Size = new System.Drawing.Size(175, 33);
            this.bMoveDown.TabIndex = 7;
            this.bMoveDown.Text = "Move Row Down";
            this.bMoveDown.UseVisualStyleBackColor = true;
            this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
            // 
            // dlgColumnsConfiguration
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(1323, 498);
            this.Controls.Add(this.bMoveDown);
            this.Controls.Add(this.bMoveUp);
            this.Controls.Add(this.bDeleteColumn);
            this.Controls.Add(this.bAddNewColumn);
            this.Controls.Add(this.oGrid);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dlgColumnsConfiguration";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgColumnsConfiguration";
            this.Load += new System.EventHandler(this.dlgColumnsConfiguration_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            this.ResumeLayout(false);

        }
        internal TableLayoutPanel TableLayoutPanel1;
        internal Button OK_Button;
        internal Button Cancel_Button;
        internal DataGridView oGrid;
        internal Button bDeleteColumn;
        internal Button bAddNewColumn;
        internal Button bMoveUp;
        internal Button bMoveDown;
        internal DataGridViewTextBoxColumn colID;
        internal DataGridViewTextBoxColumn ColNameInDB;
        internal DataGridViewComboBoxColumn ColType;
        internal DataGridViewTextBoxColumn ColWidth;
        internal DataGridViewTextBoxColumn ColFormat;
        internal DataGridViewComboBoxColumn ColJust;
        internal DataGridViewTextBoxColumn ColHeader;
        internal DataGridViewTextBoxColumn COlHeader2;
        internal DataGridViewCheckBoxColumn LC;
        internal DataGridViewCheckBoxColumn LCT;
        internal DataGridViewTextBoxColumn LCV;
        internal DataGridViewCheckBoxColumn HighCheck;
        internal DataGridViewCheckBoxColumn HCT;
        internal DataGridViewTextBoxColumn HighCheckValue;
        internal DataGridViewButtonColumn EnumID;
        internal DataGridViewTextBoxColumn ColMerge;
        internal DataGridViewCheckBoxColumn SVC;
        internal DataGridViewCheckBoxColumn SVCT;
        internal DataGridViewTextBoxColumn SVV;
    }
}