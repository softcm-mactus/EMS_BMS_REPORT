using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Login : Form
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
            btLoginLogin = new Button();
            btLoginLogin.Click += new EventHandler(btLoginLogin_Click);
            UsrPassword = new TextBox();
            UsrPassword.TextChanged += new EventHandler(UsrPassword_TextChanged);
            UserID = new TextBox();
            UserID.TextChanged += new EventHandler(UserID_TextChanged);
            Label2 = new Label();
            Label1 = new Label();
            Label4 = new Label();
            Label4.Click += new EventHandler(Label4_Click);
            btCreateTables = new Button();
            btCancel = new Button();
            Label5 = new Label();
            Label3 = new Label();
            SuspendLayout();
            // 
            // btLoginLogin
            // 
            btLoginLogin.DialogResult = DialogResult.OK;
            btLoginLogin.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btLoginLogin.Location = new Point(411, 343);
            btLoginLogin.Margin = new Padding(5, 6, 5, 6);
            btLoginLogin.Name = "btLoginLogin";
            btLoginLogin.Size = new Size(147, 43);
            btLoginLogin.TabIndex = 21;
            btLoginLogin.Text = "Login";
            btLoginLogin.UseVisualStyleBackColor = true;
            // 
            // UsrPassword
            // 
            UsrPassword.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsrPassword.Location = new Point(380, 256);
            UsrPassword.Margin = new Padding(5, 6, 5, 6);
            UsrPassword.MaxLength = 16;
            UsrPassword.Name = "UsrPassword";
            UsrPassword.PasswordChar = '*';
            UsrPassword.Size = new Size(397, 34);
            UsrPassword.TabIndex = 20;
            // 
            // UserID
            // 
            UserID.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserID.Location = new Point(380, 150);
            UserID.Margin = new Padding(5, 6, 5, 6);
            UserID.Name = "UserID";
            UserID.Size = new Size(397, 34);
            UserID.TabIndex = 19;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label2.ForeColor = SystemColors.ControlText;
            Label2.Location = new Point(261, 265);
            Label2.Margin = new Padding(5, 0, 5, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(106, 25);
            Label2.TabIndex = 18;
            Label2.Text = "Password";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.BackColor = SystemColors.Control;
            Label1.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label1.ForeColor = SystemColors.ControlText;
            Label1.Location = new Point(275, 158);
            Label1.Margin = new Padding(5, 0, 5, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(84, 25);
            Label1.TabIndex = 17;
            Label1.Text = "User ID";
            // 
            // Label4
            // 
            Label4.BackColor = Color.MediumBlue;
            Label4.Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label4.ForeColor = Color.Transparent;
            Label4.Location = new Point(60, 50);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(999, 49);
            Label4.TabIndex = 24;
            Label4.Text = "ADMIN LOGIN";
            Label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btCreateTables
            // 
            btCreateTables.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCreateTables.Location = new Point(7, 922);
            btCreateTables.Margin = new Padding(5, 6, 5, 6);
            btCreateTables.Name = "btCreateTables";
            btCreateTables.Size = new Size(243, 43);
            btCreateTables.TabIndex = 34;
            btCreateTables.Text = "Create Tables";
            btCreateTables.UseVisualStyleBackColor = true;
            btCreateTables.Visible = false;
            // 
            // btCancel
            // 
            btCancel.DialogResult = DialogResult.Cancel;
            btCancel.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCancel.Location = new Point(596, 343);
            btCancel.Margin = new Padding(5, 6, 5, 6);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(148, 43);
            btCancel.TabIndex = 35;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.ForeColor = SystemColors.ControlText;
            Label5.Location = new Point(391, 298);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(225, 17);
            Label5.TabIndex = 36;
            Label5.Text = "* Min 6 Characters, Case Sensitive";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.ForeColor = SystemColors.ControlText;
            Label3.Location = new Point(391, 192);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(351, 17);
            Label3.TabIndex = 36;
            Label3.Text = "* Min 6 Characters, Max 12 Characters, Case Sensitive";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1115, 463);
            ControlBox = false;
            Controls.Add(Label5);
            Controls.Add(Label3);
            Controls.Add(btCancel);
            Controls.Add(btCreateTables);
            Controls.Add(Label4);
            Controls.Add(btLoginLogin);
            Controls.Add(UsrPassword);
            Controls.Add(UserID);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Margin = new Padding(4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterParent;
            Load += new EventHandler(Login_New_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button btLoginLogin;
        internal TextBox UsrPassword;
        internal TextBox UserID;
        internal Label Label2;
        internal Label Label1;
        internal Label Label4;
        internal Button btCreateTables;
        internal Button btCancel;
        internal Label Label5;
        internal Label Label3;
    }
}