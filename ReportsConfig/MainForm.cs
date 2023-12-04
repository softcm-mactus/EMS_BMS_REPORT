using System;
using System.ComponentModel;
using System.Data.Odbc;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using System.Runtime.Remoting.Contexts;
using System.Xml.XPath;
using System.Xml;
using Microsoft.Web.Administration;
using System.IO;
using ReportsSetup;
using System.ServiceProcess;
using System.Threading;
using System.Text.Json;

namespace EmsBMSReports
{

    public partial class MainForm
    {
        bool bForce = false;
        string installPath = "D:\\Mactus\\EMS_BMS_Reports\\InstallInfo.json";
        InstallInfo installInfo = new InstallInfo();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var _installPath = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Mactus\\EMSBMSReports", "InstallInfo", null);
            if (_installPath == null) {
                MessageBox.Show("reg val is null");
                try
                {
                    var keySoftware = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software", true);
                    var keyMactus = keySoftware.CreateSubKey("Mactus");
                    var keyReports = keyMactus.CreateSubKey("EMSBMSReports");
                    _installPath = keyReports.GetValue("InstallInfo", null);
                    if(_installPath == null)
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (_installPath != null)
            {
                installPath = (_installPath as String);
                if(File.Exists(installPath))
                {
                    string _installInfo = File.ReadAllText(installPath);
                    ForceInstall dlg = new ForceInstall(apppath.Text,webpath.Text);
                    try
                    {
                        installInfo = JsonSerializer.Deserialize<InstallInfo>(_installInfo);
                        installInfo.decryptPasswords();
                        webpath.Text = installInfo.webInfo.path;
                        website.Text = installInfo.webInfo.name;
                        webport.Value = installInfo.webInfo.port;

                        apppath.Text = installInfo.appInfo.path;
                        servicename.Text = installInfo.appInfo.service;

                        database.Text = installInfo.dbInfo.database;
                        server.Text = installInfo.dbInfo.server;
                        username.Text = installInfo.dbInfo.username;
                        password.Text = installInfo.dbInfo.password;

                        ebodb.Text = installInfo.eboInfo.database;
                        eboserver.Text = installInfo.eboInfo.server;
                        ebouser.Text = installInfo.eboInfo.username;
                        ebopassword.Text = installInfo.eboInfo.password;
                        ebotype.Text = installInfo.eboInfo.type;

                        dlg.apppath = installInfo.appInfo.path;
                        dlg.webpath = installInfo.webInfo.path;
                    }
                    catch (Exception ex)
                    {
                        if (_installPath == null)
                        {
                            MessageBox.Show("error parsing json");
                        }
                        LogError(ex.Message);
                        dlg.isCorrupted= true;
                        dlg.installInfo = installPath;
                    }
                    dlg.ShowDialog();
                    if (dlg.result == "cancel")
                    {
                        this.Close();
                    }
                    else if (dlg.result == "upgrade")
                    {
                        upgrade();
                        Close();
                    }
                    else if (dlg.result == "force")
                    {
                        bForce = true;
                    }
                }
            }
        }
        void upgrade()
        {
            Install install = new Install();   
            install.installInfo = installInfo;
            install.isUpgrade=true;
            install.installInfoPath = installPath;
            install.ShowDialog();
            install.Close();
        }
        void install()
        {
            Install install = new Install();
            testDBConnection(null,null);

            install.installInfo = installInfo;
            install.isUpgrade = false;
            install.isForce = bForce;
            install.installInfoPath = apppath.Text+"\\InstallInfo.json";

            installInfo.dbInfo.database = database.Text;
            installInfo.dbInfo.username = username.Text;   
            installInfo.dbInfo.password = password.Text;
            installInfo.dbInfo.server = server.Text;

            installInfo.eboInfo.database = ebodb.Text;
            installInfo.eboInfo.username = ebouser.Text;
            installInfo.eboInfo.password = ebopassword.Text;
            installInfo.eboInfo.server = eboserver.Text;
            installInfo.eboInfo.type = ebotype.Text;

            installInfo.appInfo.service = servicename.Text;
            installInfo.appInfo.path = apppath.Text;
            installInfo.webInfo.name = website.Text;
            installInfo.webInfo.path = webpath.Text;
            installInfo.webInfo.port = (int)webport.Value;

            install.ShowDialog();
            install.Close();
        }

        private void testDBConnection(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    installInfo.dbInfo.connectionString = $"Driver={{SQL Server}};Server={server.Text};Database={database.Text};UID={username.Text};PWD={password.Text};";
                    error.ForeColor = Color.Black;
                    error.Text = "checking db connection";
                    using (var oConnection = new OdbcConnection(installInfo.dbInfo.connectionString))
                    {
                        oConnection.Open();
                        oConnection.Close();
                    }
                }
                catch(Exception ex)
                {
                    // try native driver
                    installInfo.dbInfo.connectionString = $"Driver={{SQL Server Native Client 11.0}};Server={server.Text};Database={database.Text};UID={username.Text};PWD={password.Text};";
                    error.ForeColor = Color.Black;
                    error.Text = "checking db connection";
                    using (var oConnection = new OdbcConnection(installInfo.dbInfo.connectionString))
                    {
                        oConnection.Open();
                        oConnection.Close();
                    }
                }
                error.ForeColor = Color.Green;
                error.Text = "Connection successful";

                try
                {
                    installInfo.eboInfo.connectionString = getEBODBConnectionString(false);
                    error.ForeColor = Color.Black;
                    error.Text = "checking ebo db connection";
                    using (var oConnection = new OdbcConnection(installInfo.eboInfo.connectionString))
                    {
                        oConnection.Open();
                        oConnection.Close();
                    }
                    error.ForeColor = Color.Green;
                    error.Text = "EBO DB Connection successful";
                }
                catch(Exception)
                {
                    // Try native driver
                    installInfo.eboInfo.connectionString = getEBODBConnectionString(true);
                    error.ForeColor = Color.Black;
                    error.Text = "checking ebo db connection";
                    using (var oConnection = new OdbcConnection(installInfo.eboInfo.connectionString))
                    {
                        oConnection.Open();
                        oConnection.Close();
                    }
                    error.ForeColor = Color.Green;
                    error.Text = "EBO DB Connection successful";

                }
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = ex.Message;
            }
        }

        private string getEBODBConnectionString(bool nativeClient)
        {
            string connectionString;
            if (ebotype.Text == "SQLServer")
            {
                if(nativeClient)
                {
                    connectionString = $"Driver={{SQL Server Native Client 11.0}};Server={eboserver.Text};Database={ebodb.Text};UID={ebouser.Text};PWD={ebopassword.Text}";
                }
                else
                {
                    connectionString = $"Driver={{SQL Server}};Server={eboserver.Text};Database={ebodb.Text};UID={ebouser.Text};PWD={ebopassword.Text}";
                }
            }
            else
            {
                string port = "5432";
                if (server.Text.Split(':').Length > 1)
                {
                    port = server.Text.Split(':')[1];
                }
                string host = server.Text.Split(':')[0];
                connectionString = $"Driver={ebotype.Text};Server={host};Port={port};Database={ebodb.Text};UID={ebouser.Text};PWD={password.Text};Connect Timeout=3";
            }

            return connectionString;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string query = "SELECT name, database_id, create_date FROM sys.databases";
            string connectionString = $"Driver={{SQL Server}};Server={server.Text};UID={username.Text};PWD={password.Text};Connect Timeout=3";
            database.Items.Clear();
            error.ForeColor = Color.Black;
            error.Text = "checking db connection";

            try
            {
                using (var oConnection = new OdbcConnection(connectionString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(query, oConnection);
                    var oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        database.Items.Add(oReader.GetString(0));
                    }
                    oConnection.Close();
                }
                error.Text = "";
            }
            catch (Exception ex) {
                error.ForeColor = Color.Red;
                error.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var files = new string[]{
                "Client/EmsBMSReports.exe.config",
                "ExceptionReport/ExceptionReport.exe.config",
                "Service/EmsBMSReportService.exe.config",
                "Service2/EmsBMSReportService2.exe.config",
                "ServiceTest/EMSBMSReportServiceTest.exe.config",
                "Web/Web.Config",
            };
            string connectionString = $"Driver={{SQL Server}};Server={server.Text};Database={database.Text};UID={username.Text};PWD={password.Text};";

            try
            {
                // Check if website directory or app directory exists
                if (!bForce &&( Directory.Exists(webpath.Text) || Directory.Exists(apppath.Text)))
                {
                    ForceInstall dlg = new ForceInstall(apppath.Text,webpath.Text);
                    dlg.ShowDialog();
                    if (dlg.result == "cancel")
                    {
                        this.Close();
                    }
                    else if (dlg.result == "upgrade")
                    {
                        upgrade();
                        Close();
                    }
                    else if (dlg.result == "force")
                    {
                        bForce = true;
                        install();
                    }
                }
                else
                {
                    install();
                }
            }
            catch (Exception ex)
            {

            }

            this.Close();
        }
        void LogError(string message)
        {
            error.Text = message;
            error.ForeColor = Color.Red;
        }
        private void error_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ebodb_DropDown(object sender, EventArgs e)
        {
            string query = "SELECT name, database_id, create_date FROM sys.databases";
            string connectionString = $"Driver={{SQL Server}};Server={server.Text};UID={username.Text};PWD={password.Text};Connect Timeout=3";
            database.Items.Clear();
            error.ForeColor = Color.Black;
            error.Text = "checking db connection";

            try
            {
                using (var oConnection = new OdbcConnection(connectionString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(query, oConnection);
                    var oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        ebodb.Items.Add(oReader.GetString(0));
                    }
                    oConnection.Close();
                }
                error.Text = "";
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = ex.Message;
            }
        }
    }
}