using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsSetup
{
    public partial class CreateDB : Form
    {
        public string usernameValue, passwordValue, databaseValue, serverValue; 
        public CreateDB()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            output.Text = "";
            runDBUpdateScript();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateDB_Load(object sender, EventArgs e)
        {
            server.Text = serverValue;
            password.Text = passwordValue; 
            database.Text = databaseValue;  
            username.Text = usernameValue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serverValue = server.Text;
            passwordValue = password.Text;  
            databaseValue = database.Text;  
            username.Text = usernameValue;  
            Close();
        }

        void logInfo(string msg, bool invoke = true)
        {
            {
                var bytes = new UTF8Encoding(true).GetBytes($"[Info   ] {msg}\n");
                var updateOutput = () =>
                {
                    if (msg != null)
                    {
                        int start = output.TextLength;
                        output.AppendText(msg + "\r\n");
                        int end = output.TextLength;
                        output.Select(start, end - start);
                        output.SelectionColor = Color.Black;
                        output.SelectionLength = 0;
                        output.Refresh();
                    }
                };
                if (invoke)
                    Invoke(new Action(updateOutput));
                else
                    updateOutput();
            }
        }
        void logError(string msg, bool invoke = true)
        {
            {
                var bytes = new UTF8Encoding(true).GetBytes($"[Error  ] {msg}\n");
                var updateOutput = () =>
                {
                    int start = output.TextLength;
                    output.AppendText(msg + "\r\n");
                    int end = output.TextLength;
                    output.Select(start, end - start);
                    output.SelectionColor = Color.Red;
                    output.SelectionLength = 0;
                    output.Refresh();
                };
                if (invoke)
                    Invoke(new Action(updateOutput));
                else
                    updateOutput();
            }
        }
        void runDBUpdateScript()
        {
            string filename = "create.sql";
#if DEBUG
            filename = "../../../../InstallScripts/create.sql";
#endif
            if (File.Exists(filename))
            {
                var process = new Process();
                var startinfo = new ProcessStartInfo("sqlcmd.exe");
                startinfo.Arguments = $"-S {server.Text} -d master -U {username.Text} -P \"{password.Text}\" -v uname={username.Text} -v password={password.Text} -v database={database.Text} -i {filename} -r0";
                startinfo.RedirectStandardOutput = true;
                startinfo.RedirectStandardError = true;
                startinfo.CreateNoWindow = false;
                startinfo.UseShellExecute = false;
                process.StartInfo = startinfo;
                process.OutputDataReceived += (sender, args) => logInfo(args.Data, true);
                process.ErrorDataReceived += (sender, args) => logError(args.Data, true);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit(90000);
                process.Close();
                Thread.Sleep(1000);
            }
        }
    }
}
