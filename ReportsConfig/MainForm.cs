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

namespace EmsBMSReports
{

    public partial class MainForm
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            string connectionString = $"Driver={{SQL Server}};Server={server.Text};Database={database.Text};UID={username.Text};PWD={password.Text};Connect Timeout=3";
            database.Items.Clear();
            error.ForeColor = Color.Black;
            error.Text = "checking db connection";
            try
            {
                using (var oConnection = new OdbcConnection(connectionString))
                {
                    oConnection.Open();
                    oConnection.Close();
                }
                error.ForeColor = Color.Green;
                error.Text = "Connection successful";
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = ex.Message;
            }
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
            this.Close();
        }

        private void error_Click(object sender, EventArgs e)
        {

        }
    }
}