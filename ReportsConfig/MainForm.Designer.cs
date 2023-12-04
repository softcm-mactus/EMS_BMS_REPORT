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
            this.apppath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.webpath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.website = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.eboserver = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ebodb = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ebopassword = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ebouser = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ebotypelabel = new System.Windows.Forms.Label();
            this.ebotype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.webport = new System.Windows.Forms.NumericUpDown();
            this.servicename = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.webport)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Navy;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(2, -3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(861, 39);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Mactus EMS Reports Setup";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // bGenerate
            // 
            this.bGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGenerate.Location = new System.Drawing.Point(655, 44);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(178, 28);
            this.bGenerate.TabIndex = 328;
            this.bGenerate.Text = "Test Connection";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.testDBConnection);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 345;
            this.label2.Text = "Database Configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-19, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 347;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 348;
            this.label6.Text = "Server";
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(118, 87);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(276, 22);
            this.server.TabIndex = 349;
            this.server.Text = "localhost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 350;
            this.label7.Text = "Database";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 352;
            this.label8.Text = "Username";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(118, 180);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(276, 22);
            this.username.TabIndex = 354;
            this.username.Text = "Mactus";
            // 
            // database
            // 
            this.database.FormattingEnabled = true;
            this.database.Location = new System.Drawing.Point(118, 131);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(276, 24);
            this.database.TabIndex = 355;
            this.database.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(118, 228);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(276, 22);
            this.password.TabIndex = 357;
            this.password.Text = "Mactus@123";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 356;
            this.label9.Text = "Password";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(655, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 47);
            this.button1.TabIndex = 358;
            this.button1.Text = "Install";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // error
            // 
            this.error.ForeColor = System.Drawing.Color.IndianRed;
            this.error.Location = new System.Drawing.Point(12, 562);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(839, 70);
            this.error.TabIndex = 360;
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error.Click += new System.EventHandler(this.error_Click);
            // 
            // apppath
            // 
            this.apppath.Location = new System.Drawing.Point(112, 482);
            this.apppath.Name = "apppath";
            this.apppath.Size = new System.Drawing.Size(276, 22);
            this.apppath.TabIndex = 370;
            this.apppath.Text = "D:\\Mactus\\Reports";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 369;
            this.label3.Text = "Path";
            // 
            // webpath
            // 
            this.webpath.Location = new System.Drawing.Point(113, 391);
            this.webpath.Name = "webpath";
            this.webpath.Size = new System.Drawing.Size(276, 22);
            this.webpath.TabIndex = 367;
            this.webpath.Text = "C:\\WebSites\\Mactus_EMS_Reports";
            this.webpath.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 391);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 365;
            this.label10.Text = "Path";
            // 
            // website
            // 
            this.website.Location = new System.Drawing.Point(113, 341);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(276, 22);
            this.website.TabIndex = 364;
            this.website.Text = "Mactus_EMS_Reports";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 363;
            this.label11.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(49, 329);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 362;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 301);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 20);
            this.label13.TabIndex = 361;
            this.label13.Text = "Web Site";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 440);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 20);
            this.label14.TabIndex = 371;
            this.label14.Text = "Application";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // eboserver
            // 
            this.eboserver.Location = new System.Drawing.Point(557, 92);
            this.eboserver.Name = "eboserver";
            this.eboserver.Size = new System.Drawing.Size(276, 22);
            this.eboserver.TabIndex = 374;
            this.eboserver.Text = "localhost";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(438, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 16);
            this.label15.TabIndex = 373;
            this.label15.Text = "EBO Server";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // ebodb
            // 
            this.ebodb.FormattingEnabled = true;
            this.ebodb.Location = new System.Drawing.Point(557, 175);
            this.ebodb.Name = "ebodb";
            this.ebodb.Size = new System.Drawing.Size(276, 24);
            this.ebodb.TabIndex = 376;
            this.ebodb.DropDown += new System.EventHandler(this.ebodb_DropDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(438, 179);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 16);
            this.label16.TabIndex = 375;
            this.label16.Text = "EBO DB";
            // 
            // ebopassword
            // 
            this.ebopassword.Location = new System.Drawing.Point(557, 253);
            this.ebopassword.Name = "ebopassword";
            this.ebopassword.Size = new System.Drawing.Size(276, 22);
            this.ebopassword.TabIndex = 380;
            this.ebopassword.Text = "Mactus@123";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(438, 257);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 16);
            this.label17.TabIndex = 379;
            this.label17.Text = "EBO Password";
            // 
            // ebouser
            // 
            this.ebouser.Location = new System.Drawing.Point(557, 215);
            this.ebouser.Name = "ebouser";
            this.ebouser.Size = new System.Drawing.Size(276, 22);
            this.ebouser.TabIndex = 378;
            this.ebouser.Text = "Mactus";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(438, 219);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 16);
            this.label18.TabIndex = 377;
            this.label18.Text = "EBO Username";
            // 
            // ebotypelabel
            // 
            this.ebotypelabel.AutoSize = true;
            this.ebotypelabel.Location = new System.Drawing.Point(438, 133);
            this.ebotypelabel.Name = "ebotypelabel";
            this.ebotypelabel.Size = new System.Drawing.Size(113, 16);
            this.ebotypelabel.TabIndex = 381;
            this.ebotypelabel.Text = "EBO Server Type";
            // 
            // ebotype
            // 
            this.ebotype.FormattingEnabled = true;
            this.ebotype.Items.AddRange(new object[] {
            "SQLServer",
            "PostgreSQL",
            "PostgreSQL ANSI",
            "PostgreSQL UNICODE"});
            this.ebotype.Location = new System.Drawing.Point(557, 129);
            this.ebotype.Name = "ebotype";
            this.ebotype.Size = new System.Drawing.Size(276, 24);
            this.ebotype.TabIndex = 382;
            this.ebotype.Text = "SQLServer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 383;
            this.label4.Text = "Port";
            // 
            // webport
            // 
            this.webport.Location = new System.Drawing.Point(468, 342);
            this.webport.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.webport.Name = "webport";
            this.webport.Size = new System.Drawing.Size(83, 22);
            this.webport.TabIndex = 384;
            this.webport.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            // 
            // servicename
            // 
            this.servicename.Location = new System.Drawing.Point(112, 524);
            this.servicename.Name = "servicename";
            this.servicename.Size = new System.Drawing.Size(276, 22);
            this.servicename.TabIndex = 386;
            this.servicename.Text = "Mactus EMS Reports";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 530);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 16);
            this.label19.TabIndex = 385;
            this.label19.Text = "Service";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 641);
            this.Controls.Add(this.servicename);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.webport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ebotype);
            this.Controls.Add(this.ebotypelabel);
            this.Controls.Add(this.ebopassword);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ebouser);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ebodb);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.eboserver);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.apppath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.webpath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.website);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
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
            ((System.ComponentModel.ISupportInitialize)(this.webport)).EndInit();
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
        private TextBox apppath;
        private Label label3;
        private TextBox webpath;
        private Label label10;
        private TextBox website;
        private Label label11;
        private Label label12;
        private Label label13;
        private SaveFileDialog saveFileDialog1;
        private Label label14;
        private TextBox eboserver;
        private Label label15;
        private ComboBox ebodb;
        private Label label16;
        private TextBox ebopassword;
        private Label label17;
        private TextBox ebouser;
        private Label label18;
        private Label ebotypelabel;
        private ComboBox ebotype;
        private Label label4;
        private NumericUpDown webport;
        private TextBox servicename;
        private Label label19;
    }
}