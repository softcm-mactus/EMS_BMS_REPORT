using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.XPath;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.Web.Administration;
using System.ComponentModel.Composition.Primitives;
using System.ServiceProcess;
using System.Threading;
using System.Text.Json;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using System.IO;
using System.Data.Odbc;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration.Install;
using System.Security.Policy;

namespace ReportsSetup
{
    public partial class Install : Form
    {
        public bool isUpgrade = false;
        public bool isForce = false;
        public InstallInfo installInfo;
        public FileStream installLog;
        public string installInfoPath;
        bool hasError=false;
        public Install()
        {
            InitializeComponent();
        }

        private void Install_Load(object sender, EventArgs e)
        {
            close.Enabled = false;
            errorMsg.Text = "";
            Directory.CreateDirectory(installInfo.appInfo.path);
            installLog = new FileStream(installInfo.appInfo.path + "/install.log", FileMode.Create);
            Thread thread = new Thread(install);
            thread.Start();
        }

        void logError(string msg, bool invoke = true)
        {
            {
                var bytes = new UTF8Encoding(true).GetBytes($"[Error  ] {msg}\n");
                installLog.Write(bytes, 0, bytes.Length);
                installLog.Flush();
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
        void logInfo(string msg, bool invoke=true)
        {
            {
                var bytes = new UTF8Encoding(true).GetBytes($"[Info   ] {msg}\n");
                installLog.Write(bytes, 0, bytes.Length);
                installLog.Flush();
                var updateOutput = () =>
                {
                    if (msg != null)
                    {
                        int start = output.TextLength;
                        output.AppendText(msg+"\r\n");
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
            hasError = true;
        }
        void logWarn(string msg, bool invoke = true)
        {
            {
                var bytes = new UTF8Encoding(true).GetBytes($"[Warning] {msg}\n");
                installLog.Write(bytes, 0, bytes.Length);
                installLog.Flush();
                var updateOutput = () =>
                {
                    int start = output.TextLength;
                    output.AppendText(msg);
                    int end = output.TextLength;
                    output.Select(start, end - start);
                    output.SelectionColor = Color.Brown;
                    output.SelectionLength = 0;
                    output.Refresh();
                };
                if (invoke)
                    Invoke(new Action(updateOutput));
                else
                    updateOutput();
            }
        }

        private void updateAppConfig()
        {
            var files = new string[]{
                "../Client/EmsBMSReports.exe.config",
                "../ExceptionReport/ExceptionReport.exe.config",
                "../Service/EmsBMSReportService.exe.config",
                "../Service2/EmsBMSReportService2.exe.config",
                "../ServiceTest/EMSBMSReportServiceTest.exe.config",
                "../Web/Web.Config",
            };
            string connectionString = installInfo.dbInfo.connectionString;

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
                catch (Exception ex)
                {
                    logError(ex.ToString());
                }
            }
        }

        void install()
        {
            if (isForce || isUpgrade)
            {
                logInfo("Stopping website");
                stopWebsite(installInfo.webInfo.name);
                logInfo("Stopping reporting service");
                stopService(installInfo.appInfo.service);
                Invoke(new Action(() => { progressBar.Value = 10; }));
            }
            logInfo("Updating App Config");
            updateAppConfig();
            if (isUpgrade)
            {
                logInfo("Updating files");
                runBatch("updatefiles.bat");
            }
            else
            {
                logInfo("Installing files");
                runBatch("installfiles.bat");
            }
            Invoke(new Action(() => { progressBar.Value = 40; }));
            logInfo("Updating database");
            runDBUpdateScript();
            Invoke(new Action(() => { progressBar.Value = 50; }));
            if (!isUpgrade)
            {
                logInfo($"Updating EBO DB info in configuration database: \"{installInfo.eboInfo.connectionString}\"");
                try
                {
                    string query = $"Update TBL_ReportAppConfig set Value = '{installInfo.eboInfo.connectionString}' where Code = 'EMSDBODBCLocation'";
                    using (var oConnection = new OdbcConnection(installInfo.dbInfo.connectionString))
                    {
                        oConnection.Open();
                        var cmd = oConnection.CreateCommand();
                        var oCmd = new OdbcCommand(query, oConnection);
                        var oReader = oCmd.ExecuteNonQuery();
                        oConnection.Close();
                    }
                }
                catch(Exception e)
                {
                    logError(e.ToString());
                }

                logInfo($"Updating Directory info in configuration database: \"{installInfo.eboInfo.connectionString}\"");
                try
                {
                    string query = $"Update TBL_ReportAppConfig set Value = '{installInfo.appInfo.path}' where Code = 'InFileDir'";
                    using (var oConnection = new OdbcConnection(installInfo.dbInfo.connectionString))
                    {
                        oConnection.Open();
                        var cmd = oConnection.CreateCommand();
                        var oCmd = new OdbcCommand(query, oConnection);
                        var oReader = oCmd.ExecuteNonQuery();
                        oConnection.Close();
                    }
                }
                catch (Exception e)
                {
                    logError(e.ToString());
                }
                try
                {
                    string query = $"Update TBL_ReportAppConfig set Value = '{installInfo.appInfo.path}\\output' where Code = 'OutFileDir'";
                    using (var oConnection = new OdbcConnection(installInfo.dbInfo.connectionString))
                    {
                        oConnection.Open();
                        var cmd = oConnection.CreateCommand();
                        var oCmd = new OdbcCommand(query, oConnection);
                        var oReader = oCmd.ExecuteNonQuery();
                        oConnection.Close();
                    }
                }
                catch (Exception e)
                {
                    logError(e.ToString());
                }
            }
            Invoke(new Action(() => { progressBar.Value = 60; }));
            try
            {
                if (!isUpgrade)
                {
                    logInfo("Creating application pool");
                    CreateAppPool("MactusReports", true, ManagedPipelineMode.Integrated);
                }
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
            Invoke(new Action(() => { progressBar.Value = 70; }));
            try
            {
                if (!isUpgrade)
                {
                    logInfo("Creating Website");
                    CreateIISWebsite(installInfo.webInfo.name, (int)installInfo.webInfo.port, installInfo.webInfo.path, "MactusReports");
                }
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
            try
            {
                var keySoftware = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software",true);
                var keyMactus = keySoftware.CreateSubKey("Mactus");
                if (keyMactus != null)
                {
                    var keyReports = keyMactus.CreateSubKey("EMSBMSReports");
                    if (keyReports != null)
                    {
                        keyReports.SetValue("InstallInfo", installInfoPath);
                    }
                }
            }
            catch(Exception ex)
            {
                logError(ex.ToString());
            }

            Invoke(new Action(() => { progressBar.Value = 80; }));
            try
            {
                logInfo("Starting Website");
                startWebsite(installInfo.webInfo.name);
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
            Invoke(new Action(() => { progressBar.Value = 90; }));
            try
            {
                if (!isUpgrade)
                {
                    logInfo("Installing Service");
                    installService();
                }
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
            try
            {
                logInfo("Starting Service");
                startService(installInfo.appInfo.service);
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
            Invoke(new Action(() => { progressBar.Value = 100; }));

            logInfo("Updating install info");
            try
            {
                installInfo.updateDate = DateTime.Now;
                installInfo.encryptPasswords();
                var f = File.CreateText(installInfoPath);
                string _installInfo = JsonConvert.SerializeObject(installInfo, Newtonsoft.Json.Formatting.Indented);
                f.Write(_installInfo);
                f.Close();
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
            installLog.Close();
            Invoke(new Action(() =>
            {
                if (hasError)
                {
                    errorMsg.Text = "Installation completed with errors. Check install.log";
                }
                close.Enabled = true;
            }));
        }

        private void runBatch(string filename)
        {
            if (File.Exists(filename))
            {
                var process = new Process();
                var startinfo = new ProcessStartInfo(filename);
                startinfo.Arguments = $"\"{installInfo.appInfo.path}\",\"{installInfo.webInfo.path}\"";
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
                Thread.Sleep(2000);
            }
            else
            {
                logError($"Batch file {filename} not found");
            }
        }
        void runDBUpdateScript()
        {
            string filename = "update.sql";
#if DEBUG
            filename = "../../../../InstallScripts/update.sql";
#endif
            if (File.Exists(filename))
            {
                var process = new Process();
                var startinfo = new ProcessStartInfo("sqlcmd.exe");
                startinfo.Arguments = $"-S {installInfo.dbInfo.server} -d {installInfo.dbInfo.database} -U {installInfo.dbInfo.username} -P {installInfo.dbInfo.password} -i {filename} -r0";
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
        void setAppConfig()
        {
            logInfo("Setting app config");
            var files = new string[]{
                "../Client/EmsBMSReports.exe.config",
                "../ExceptionReport/ExceptionReport.exe.config",
                "../Service/EmsBMSReportService.exe.config",
                "../Service2/EmsBMSReportService2.exe.config",
                "../ServiceTest/EMSBMSReportServiceTest.exe.config",
                "../Web/Web.Config",
            };
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
                                    nav.SetValue(installInfo.dbInfo.connectionString);
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    nav.CreateAttribute("", "connectionString", "", installInfo.dbInfo.connectionString);
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
                catch (Exception ex)
                {
                    logError(ex.ToString());
                }
            }
        }
        void CreateAppPool(string poolname, bool enable32bitOn64, ManagedPipelineMode mode, string runtimeVersion = "v4.0")
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    ApplicationPool newPool = serverManager.ApplicationPools.Add(poolname);
                    newPool.ManagedRuntimeVersion = runtimeVersion;
                    newPool.ManagedPipelineMode = mode;
                    serverManager.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }
        void installService()
        {
            try
            { 
                if(ServiceInstaller.isInstalled(installInfo.appInfo.service))
                {
                    ServiceInstaller.Uninstall(installInfo.appInfo.service);
                }
                ServiceInstaller.Install(installInfo.appInfo.service, installInfo.appInfo.service, installInfo.appInfo.path + "/service/EmsBMSReportService.exe");
                if(!ServiceInstaller.isInstalled(installInfo.appInfo.service))
                {
                    logError($"Service {installInfo.appInfo.service} is not installed");
                }
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }
        void CreateIISWebsite(string websiteName, int port, string phyPath, string appPool)
        {
            try
            {
                ServerManager iisManager = new ServerManager();
                iisManager.Sites.Add(websiteName, "http", $"*:{port}:", phyPath);
                iisManager.Sites[websiteName].ApplicationDefaults.ApplicationPoolName = appPool;
                foreach (var item in iisManager.Sites[websiteName].Applications)
                {
                    item.ApplicationPoolName = appPool;
                }
                iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }
        void stopWebsite(string websiteName)
        {
            try
            {
                ServerManager iisManager = new ServerManager();
                var site = iisManager.Sites.FirstOrDefault(s => s.Name == installInfo.webInfo.name);
                if (site != null)
                {
                    site.Stop();
                }
                iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }
        void startWebsite(string websiteName)
        {
            try
            {
                ServerManager iisManager = new ServerManager();
                var site = iisManager.Sites.FirstOrDefault(s => s.Name == installInfo.webInfo.name);
                if (site != null)
                {
                    site.Start();
                }
                else
                {
                    logError($"Website {installInfo.webInfo.name} not found in IIS");
                }
                iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
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
                        logInfo("Starting Service " + serviceName);
                        sc.Start();
                    }
                    catch (Exception ex)
                    {
                        logError(ex.ToString());
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
                logError(ex.ToString());
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
                        logInfo("Stopping  Service " + serviceName);
                        sc.Stop();
                    }
                    catch (Exception ex)
                    {
                        logError(ex.ToString());
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
                logError(ex.ToString());
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void errorMsg_Click(object sender, EventArgs e)
        {

        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }
    }
}