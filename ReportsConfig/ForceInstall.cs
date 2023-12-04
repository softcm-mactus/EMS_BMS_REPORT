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

namespace ReportsSetup
{
    public partial class ForceInstall : Form
    {
        public string webpath = "";
        public string apppath = "";
        public string installInfo = "";

        public string result = "";
        public bool isCorrupted = false;

        public ForceInstall(string _appPath, string _webPath)
        {
            this.apppath = _appPath;
            this.webpath = _webPath;
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
            if(isCorrupted)
            {
                msg += $"Previous installation info at {installInfo} is corrupted\n";
            }
            if (Directory.Exists(webpath))
            {
                msg += $"Web site path '{webpath}' already exist\n";
            }
            if (Directory.Exists(apppath))
            {
                msg += $"Application install path '{apppath}' already exist\n";
            }
            this.msg.Text = msg;
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
