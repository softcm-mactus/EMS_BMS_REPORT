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
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            TableLayoutPanel1 = new TableLayoutPanel();
            OK_Button = new Button();
            OK_Button.Click += new EventHandler(OK_Button_Click);
            Cancel_Button = new Button();
            Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            oGrid = new DataGridView();
            oGrid.DataError += new DataGridViewDataErrorEventHandler(oGrid_DataError);
            oGrid.CellClick += new DataGridViewCellEventHandler(oGrid_CellClick);
            oGrid.RowEnter += new DataGridViewCellEventHandler(oGrid_RowEnter);
            bDeleteColumn = new Button();
            bDeleteColumn.Click += new EventHandler(bDeleteColumn_Click);
            bAddNewColumn = new Button();
            bAddNewColumn.Click += new EventHandler(bAddNewColumn_Click);
            bMoveUp = new Button();
            bMoveUp.Click += new EventHandler(bMoveUp_Click);
            bMoveDown = new Button();
            bMoveDown.Click += new EventHandler(bMoveDown_Click);
            colID = new DataGridViewTextBoxColumn();
            ColNameInDB = new DataGridViewTextBoxColumn();
            ColType = new DataGridViewComboBoxColumn();
            ColWidth = new DataGridViewTextBoxColumn();
            ColFormat = new DataGridViewTextBoxColumn();
            ColJust = new DataGridViewComboBoxColumn();
            ColHeader = new DataGridViewTextBoxColumn();
            COlHeader2 = new DataGridViewTextBoxColumn();
            LC = new DataGridViewCheckBoxColumn();
            LCT = new DataGridViewCheckBoxColumn();
            LCV = new DataGridViewTextBoxColumn();
            HighCheck = new DataGridViewCheckBoxColumn();
            HCT = new DataGridViewCheckBoxColumn();
            HighCheckValue = new DataGridViewTextBoxColumn();
            EnumID = new DataGridViewButtonColumn();
            ColMerge = new DataGridViewTextBoxColumn();
            SVC = new DataGridViewCheckBoxColumn();
            SVCT = new DataGridViewCheckBoxColumn();
            SVV = new DataGridViewTextBoxColumn();
            TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Controls.Add(OK_Button, 0, 0);
            TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0);
            TableLayoutPanel1.Location = new Point(1112, 447);
            TableLayoutPanel1.Margin = new Padding(4);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Size = new Size(195, 36);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            OK_Button.Anchor = AnchorStyles.None;
            OK_Button.Location = new Point(4, 4);
            OK_Button.Margin = new Padding(4);
            OK_Button.Name = "OK_Button";
            OK_Button.Size = new Size(89, 28);
            OK_Button.TabIndex = 0;
            OK_Button.Text = "Update";
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = AnchorStyles.None;
            Cancel_Button.DialogResult = DialogResult.Cancel;
            Cancel_Button.Location = new Point(101, 4);
            Cancel_Button.Margin = new Padding(4);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(89, 28);
            Cancel_Button.TabIndex = 1;
            Cancel_Button.Text = "Cancel";
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { colID, ColNameInDB, ColType, ColWidth, ColFormat, ColJust, ColHeader, COlHeader2, LC, LCT, LCV, HighCheck, HCT, HighCheckValue, EnumID, ColMerge, SVC, SVCT, SVV });
            oGrid.Location = new Point(13, 13);
            oGrid.Name = "oGrid";
            oGrid.Size = new Size(1294, 402);
            oGrid.TabIndex = 1;
            // 
            // bDeleteColumn
            // 
            bDeleteColumn.Location = new Point(256, 435);
            bDeleteColumn.Name = "bDeleteColumn";
            bDeleteColumn.Size = new Size(175, 33);
            bDeleteColumn.TabIndex = 5;
            bDeleteColumn.Text = "Delete Column";
            bDeleteColumn.UseVisualStyleBackColor = true;
            // 
            // bAddNewColumn
            // 
            bAddNewColumn.Location = new Point(37, 434);
            bAddNewColumn.Name = "bAddNewColumn";
            bAddNewColumn.Size = new Size(175, 33);
            bAddNewColumn.TabIndex = 4;
            bAddNewColumn.Text = "Add New Column";
            bAddNewColumn.UseVisualStyleBackColor = true;
            // 
            // bMoveUp
            // 
            bMoveUp.Location = new Point(555, 435);
            bMoveUp.Name = "bMoveUp";
            bMoveUp.Size = new Size(175, 33);
            bMoveUp.TabIndex = 6;
            bMoveUp.Text = "Move Row Up";
            bMoveUp.UseVisualStyleBackColor = true;
            // 
            // bMoveDown
            // 
            bMoveDown.Location = new Point(753, 435);
            bMoveDown.Name = "bMoveDown";
            bMoveDown.Size = new Size(175, 33);
            bMoveDown.TabIndex = 7;
            bMoveDown.Text = "Move Row Down";
            bMoveDown.UseVisualStyleBackColor = true;
            // 
            // colID
            // 
            colID.HeaderText = "colid";
            colID.Name = "colID";
            colID.Visible = false;
            // 
            // ColNameInDB
            // 
            ColNameInDB.HeaderText = "DB Col Name";
            ColNameInDB.Name = "ColNameInDB";
            ColNameInDB.ReadOnly = true;
            ColNameInDB.Resizable = DataGridViewTriState.False;
            // 
            // ColType
            // 
            ColType.HeaderText = "Type";
            ColType.Items.AddRange(new object[] { "Temperature", "Humidity", "DP", "Other", "Enumtype" });
            ColType.Name = "ColType";
            // 
            // ColWidth
            // 
            ColWidth.HeaderText = "Col Width";
            ColWidth.Name = "ColWidth";
            ColWidth.Width = 50;
            // 
            // ColFormat
            // 
            ColFormat.HeaderText = "Column Format";
            ColFormat.Name = "ColFormat";
            ColFormat.Width = 70;
            // 
            // ColJust
            // 
            ColJust.HeaderText = "Justification";
            ColJust.Items.AddRange(new object[] { "Center", "Left", "Right" });
            ColJust.Name = "ColJust";
            // 
            // ColHeader
            // 
            ColHeader.HeaderText = "Column Sub Title";
            ColHeader.Name = "ColHeader";
            ColHeader.Width = 180;
            // 
            // COlHeader2
            // 
            COlHeader2.HeaderText = "Column Main Title";
            COlHeader2.Name = "COlHeader2";
            COlHeader2.Width = 180;
            // 
            // LC
            // 
            LC.HeaderText = "LC";
            LC.Name = "LC";
            LC.Width = 30;
            // 
            // LCT
            // 
            LCT.HeaderText = "LCT";
            LCT.Name = "LCT";
            LCT.Width = 40;
            // 
            // LCV
            // 
            LCV.HeaderText = "LCV";
            LCV.Name = "LCV";
            LCV.Width = 40;
            // 
            // HighCheck
            // 
            HighCheck.HeaderText = "HC";
            HighCheck.Name = "HighCheck";
            HighCheck.Width = 30;
            // 
            // HCT
            // 
            HCT.HeaderText = "HCT";
            HCT.Name = "HCT";
            HCT.Width = 40;
            // 
            // HighCheckValue
            // 
            HighCheckValue.HeaderText = "HCV";
            HighCheckValue.Name = "HighCheckValue";
            HighCheckValue.Width = 40;
            // 
            // EnumID
            // 
            EnumID.FlatStyle = FlatStyle.Popup;
            EnumID.HeaderText = "Enum ID";
            EnumID.Name = "EnumID";
            EnumID.Resizable = DataGridViewTriState.True;
            EnumID.SortMode = DataGridViewColumnSortMode.Automatic;
            EnumID.Width = 45;
            // 
            // ColMerge
            // 
            DataGridViewCellStyle1.Format = "N0";
            DataGridViewCellStyle1.NullValue = null;
            ColMerge.DefaultCellStyle = DataGridViewCellStyle1;
            ColMerge.HeaderText = "Col Merge";
            ColMerge.Name = "ColMerge";
            ColMerge.Width = 50;
            // 
            // SVC
            // 
            SVC.HeaderText = "SVC";
            SVC.Name = "SVC";
            SVC.Width = 40;
            // 
            // SVCT
            // 
            SVCT.HeaderText = "SVCT";
            SVCT.Name = "SVCT";
            SVCT.Width = 45;
            // 
            // SVV
            // 
            SVV.HeaderText = "SVV";
            SVV.Name = "SVV";
            SVV.Width = 50;
            // 
            // dlgColumnsConfiguration
            // 
            AcceptButton = OK_Button;
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel_Button;
            ClientSize = new Size(1323, 498);
            Controls.Add(bMoveDown);
            Controls.Add(bMoveUp);
            Controls.Add(bDeleteColumn);
            Controls.Add(bAddNewColumn);
            Controls.Add(oGrid);
            Controls.Add(TableLayoutPanel1);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "dlgColumnsConfiguration";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "dlgColumnsConfiguration";
            TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            Load += new EventHandler(dlgColumnsConfiguration_Load);
            ResumeLayout(false);

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