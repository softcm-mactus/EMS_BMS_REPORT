namespace ReportsConfig
{
    partial class ForceInstall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Upgrade = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Force = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg.Location = new System.Drawing.Point(25, 9);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(302, 286);
            this.msg.TabIndex = 0;
            this.msg.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Upgrade the current installation";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Upgrade
            // 
            this.Upgrade.BackColor = System.Drawing.Color.LimeGreen;
            this.Upgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Upgrade.Location = new System.Drawing.Point(608, 129);
            this.Upgrade.Name = "Upgrade";
            this.Upgrade.Size = new System.Drawing.Size(145, 37);
            this.Upgrade.TabIndex = 1;
            this.Upgrade.Text = "Upgrade";
            this.Upgrade.UseVisualStyleBackColor = false;
            this.Upgrade.Click += new System.EventHandler(this.Upgrade_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(608, 267);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(145, 37);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Force
            // 
            this.Force.BackColor = System.Drawing.Color.Tomato;
            this.Force.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Force.Location = new System.Drawing.Point(608, 196);
            this.Force.Name = "Force";
            this.Force.Size = new System.Drawing.Size(145, 37);
            this.Force.TabIndex = 2;
            this.Force.Text = "Force Install";
            this.Force.UseVisualStyleBackColor = false;
            this.Force.Click += new System.EventHandler(this.Force_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Overwrite current installation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cancel the new installation";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(604, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Choose Action";
            // 
            // ForceInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 332);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Force);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Upgrade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.msg);
            this.Name = "ForceInstall";
            this.Text = "BMS Reports is already installed";
            this.Load += new System.EventHandler(this.ForceInstall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Upgrade;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Force;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}