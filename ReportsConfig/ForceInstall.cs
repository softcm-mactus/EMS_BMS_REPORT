using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsConfig
{
    public partial class ForceInstall : Form
    {
        public string webpath = "";
        public string apppath = "";

        public string result = "";

        public ForceInstall()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ForceInstall_Load(object sender, EventArgs e)
        {
            string msg ="";
            if (Directory.Exists(webpath))
            {
                msg += $"Web site path '{webpath}' already exist\n";
            }
            if (Directory.Exists(apppath))
            {
                msg += $"Application install path '{webpath}' already exist\n";
            }
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {
            result = "upgrade";
            this.Close();
        }

        private void Force_Click(object sender, EventArgs e)
        {
            result = "force";
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            result = "cancel";
            this.Close();
        }
    }
}
