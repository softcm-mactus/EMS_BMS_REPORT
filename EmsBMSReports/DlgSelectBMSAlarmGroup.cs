using System;
using System.Data.Odbc;
using static MactusReportLib.MactusReportLib;

namespace EmsBMSReports
{

    public partial class DlgSelectBMSAlarmGroup
    {

        public string m_sGroupName;

        public DlgSelectBMSAlarmGroup()
        {
            InitializeComponent();
        }
        private void DlgSelectBMSAlarmGroup_Load(object sender, EventArgs e)
        {
            SynchronizeAlarmGroupName();
            string sQuery = "SELECT * FROM tbl_datagroups WHERE grouptype<>0 ORDER BY groupid";
            OdbcDataReader oReader;
            try
            {
                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                        oGroup.Items.Add(oReader["groupname"]);
                    oConnection.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void oGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                m_sGroupName = oGroup.SelectedItem.ToString();
            }
            catch (Exception )
            {
                m_sGroupName = "";
            }
            if (m_sGroupName.Length > 0)
            {

            }

        }
    }
}