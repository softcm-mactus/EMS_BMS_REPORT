using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class MainForm : Form
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
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Label1 = new System.Windows.Forms.Label();
            this.bGenerate = new System.Windows.Forms.Button();
            this.oTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.server = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.database = new System.Windows.Forms.ComboBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Navy;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(2, -3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(566, 63);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Report Setup Configuration";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bGenerate
            // 
            this.bGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGenerate.Location = new System.Drawing.Point(69, 355);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(178, 47);
            this.bGenerate.TabIndex = 328;
            this.bGenerate.Text = "Test Connection";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 24);
            this.label2.TabIndex = 345;
            this.label2.Text = "Database Configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 347;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 348;
            this.label6.Text = "Server";
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(207, 127);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(276, 22);
            this.server.TabIndex = 349;
            this.server.Text = "localhost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 350;
            this.label7.Text = "Database";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 352;
            this.label8.Text = "Username";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(207, 220);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(276, 22);
            this.username.TabIndex = 354;
            this.username.Text = "Mactus";
            // 
            // database
            // 
            this.database.FormattingEnabled = true;
            this.database.Location = new System.Drawing.Point(207, 171);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(276, 24);
            this.database.TabIndex = 355;
            this.database.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(207, 268);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(276, 22);
            this.password.TabIndex = 357;
            this.password.Text = "Mactus@123";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 356;
            this.label9.Text = "Password";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(294, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 47);
            this.button1.TabIndex = 358;
            this.button1.Text = "Update Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // error
            // 
            this.error.ForeColor = System.Drawing.Color.IndianRed;
            this.error.Location = new System.Drawing.Point(12, 405);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(542, 55);
            this.error.TabIndex = 360;
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error.Click += new System.EventHandler(this.error_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 458);
            this.Controls.Add(this.error);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.database);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.server);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bGenerate);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Label Label1;
        internal Button bGenerate;
        internal Timer oTimer;
        private Label label2;
        private Label label5;
        private Label label6;
        private TextBox server;
        private Label label7;
        private Label label8;
        private TextBox username;
        private ComboBox database;
        private TextBox password;
        private Label label9;
        internal Button button1;
        private Label error;
    }
}