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
using System.ComponentModel.Design.Serialization;
using System.Xml.Linq;
using Microsoft.Web.Administration;
using System.Security.Cryptography;
using System.IO;
using ReportsConfig;
using System.ServiceProcess;
using System.Threading;

namespace EmsBMSReports
{

    public partial class MainForm
    {
        bool bForce = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Driver={{SQL Server}};Server={server.Text};Database={database.Text};UID={username.Text};PWD={password.Text};Connect Timeout=3";
                error.ForeColor = Color.Black;
                error.Text = "checking db connection";
                using (var oConnection = new OdbcConnection(connectionString))
                {
                    oConnection.Open();
                    oConnection.Close();
                }
                error.ForeColor = Color.Green;
                error.Text = "Connection successful";

                connectionString = getEBODBConnectionString();
                error.ForeColor = Color.Black;
                error.Text = "checking ebo db connection";
                using (var oConnection = new OdbcConnection(connectionString))
                {
                    oConnection.Open();
                    oConnection.Close();
                }
                error.ForeColor = Color.Green;
                error.Text = "EBO DB Connection successful";
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = ex.Message;
            }
        }

        private string getEBODBConnectionString()
        {
            string connectionString;
            if (ebotype.Text == "SQLServer")
            {
                connectionString = $"Driver={{SQL Server Native Client 11.0}};Server={eboserver.Text};Database={ebodb.Text};UID={ebouser.Text};PWD={ebopassword.Text}";
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

            foreach (string file in files)
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(file);
                    var root = document.DocumentElement;
                    XPathNavigator navigator = document.CreateNavigator();
                    XmlNamespaceManager ns = new XmlNamespaceManager(navigator.NameTable);

                    foreach (XPathNavigator nav in navigator.Select(@"/configuration/connectionStrings/add"))
                    {
                        try
                        {
                            if (nav.HasAttributes && nav.GetAttribute("name", "") == "DBConStr")
                            {
                                try
                                {
                                    nav.MoveToAttribute("connectionString", "");
                                    nav.SetValue(connectionString);
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    nav.CreateAttribute("", "connectionString", "", connectionString);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    document.Save(file);
                }
                catch(Exception ex)
                {
                    error.Text = ex.Message;
                }
            }

            try
            {
                // Check if website directory or app directory exists
                if(Directory.Exists(webpath.Text) || Directory.Exists(apppath.Text))
                {
                    ForceInstall dlg = new ForceInstall();
                    dlg.webpath = webpath.Text;
                    dlg.apppath = apppath.Text;
                    dlg.ShowDialog();
                    if (dlg.result == "cancel")
                    {
                        this.Close();
                    }
                    else if(dlg.result == "upgrade")
                    {
                        upgrade();
                        Close();
                    }
                    else if(dlg.result=="force")
                    {
                        bForce = true;
                    }
                }
                try
                {
                    CreateAppPool("MactusReports", true, ManagedPipelineMode.Classic);
                }
                catch(Exception ex)
                {
                    error.ForeColor = Color.Red;
                    error.Text=ex.Message;
                }
                try
                {
                    CreateIISWebsite(website.Text, (int)webport.Value, webpath.Text, "MactusReports");
                }
                catch (Exception ex)
                {
                    error.ForeColor = Color.Red;
                    error.Text = ex.Message;
                }
                if(bForce)
                {
                    stopWebsite(website.Text);
                    stopService(servicename.Text);
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
        void CreateAppPool(string poolname, bool enable32bitOn64, ManagedPipelineMode mode, string runtimeVersion = "v4.0")
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    ApplicationPool newPool = serverManager.ApplicationPools.Add(poolname);
                    newPool.ManagedRuntimeVersion = runtimeVersion;
                    newPool.Enable32BitAppOnWin64 = true;
                    newPool.ManagedPipelineMode = mode;
                    serverManager.CommitChanges();
                }
            }
            catch(Exception ex )
            {
                LogError(ex.Message);
            }
        }
        void CreateIISWebsite(string websiteName, int port, string phyPath, string appPool)
        {
            try
            {
                ServerManager iisManager = new ServerManager();
                iisManager.Sites.Add(websiteName, "http", $"*:{port}", phyPath);
                iisManager.Sites[websiteName].ApplicationDefaults.ApplicationPoolName = appPool;
                foreach (var item in iisManager.Sites[websiteName].Applications)
                {
                    item.ApplicationPoolName = appPool;
                }
                iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        void stopWebsite(string websiteName)
        {
            try
            {
                ServerManager iisManager = new ServerManager();
            iisManager.Sites[websiteName].Stop();
            iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        void startWebsite(string websiteName)
        {
                try
                {
                    ServerManager iisManager = new ServerManager();
            iisManager.Sites[websiteName].Stop();
            iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        private void startService(string serviceName)
        {
            // Starting  service

            try
            {
                ServiceController sc = new ServiceController(serviceName);
                // we try to start the  service only if it is not running
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    // Need to wait till the service is stopping
                    // The maximum wait time is 30 seconds
                    for (int i = 0; i <= 60; i++)
                    {
                        sc.Refresh();
                        if ((sc.Status == ServiceControllerStatus.StopPending | sc.Status == ServiceControllerStatus.PausePending))
                            Thread.Sleep(500);
                        else
                            break;
                    }
                    // Start the service
                    try
                    {
                        LogError("Starting Service " + serviceName);
                        sc.Start();
                    }
                    catch (Exception ex)
                    {
                        LogError("Service Exception :: startService() : " + ex.Message);
                    }
                    // Need to wait till the service is running
                    try
                    {
                        sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("IIS Watchdog Service Exception :: startService() : " + ex.Message);
            }
        }
        private void stopService(string serviceName)
        {
            // Stoping  service
            try
            {
                ServiceController sc = new ServiceController(serviceName);
                if (sc.Status != ServiceControllerStatus.Stopped)
                {
                    // stop the service
                    try
                    {
                        LogError("Stopping  Service " + serviceName);
                        sc.Stop();
                    }
                    catch (Exception ex)
                    {
                        LogError("IIS Watchdog Service Exception :: stopService() : " + ex.Message);
                    }
                    // Need to wait till the service is running
                    try
                    {
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("IIS Watchdog Service Exception :: stopService() : " + ex.Message);
            }
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
    }
}