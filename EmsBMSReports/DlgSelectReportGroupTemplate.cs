using System;
using System.Data.Odbc;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgSelectReportGroupTemplate
    {
        public bool m_bAlarmGroup = false;

        public DlgSelectReportGroupTemplate()
        {
            InitializeComponent();
        }
        private void DlgSelectReportGroupTemplate_Load(object sender, EventArgs e)
        {

            bAddNewGroup.Visible = !m_bAlarmGroup;

            LoadTemplateCombobox();
            LoadGroupCombobox();

        }


        public void LoadTemplateCombobox()
        {
            string sQuery;
            OdbcDataReader oReader;

            sQuery = "SELECT * FROM tbl_reporttemplates order by templateid";

            using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
            {
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                    cTemplate.Items.Add(oReader["templatename"]);
                oConnection.Close();
            }


        }


        public void LoadGroupCombobox()
        {
            if (m_bAlarmGroup & MactusReportLib.MactusReportLib.g_bIsBMS == 0)
            {
                LoadAlarmGroupComboboxIndusoft();
                return;
            }


            string sQuery;
            OdbcDataReader oReader;
            cGroup.Items.Clear();
            if (m_bAlarmGroup)
            {
                sQuery = "SELECT * FROM tbl_datagroups WHERE grouptype<>0 order by groupid";
            }
            else
            {
                sQuery = "SELECT * FROM tbl_datagroups WHERE grouptype=0 order by groupid";
            }


            using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
            {
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    if (Conversions.ToBoolean(Operators.AndObject(m_bAlarmGroup, Operators.ConditionalCompareObjectEqual(oReader["groupid"], 0, false))))
                    {
                        cGroup.Items.Add(oReader["All Alarms"]);
                    }
                    else
                    {
                        cGroup.Items.Add(oReader["groupname"]);
                    }
                }
                oConnection.Close();
            }


        }


        public void LoadAlarmGroupComboboxIndusoft()
        {
            string sQuery;
            OdbcDataReader oReader;
            cGroup.Items.Clear();
            int nGroupID;

            sQuery = "SELECT DISTINCT Al_Group from ALARMHISTORY where Al_Group IS NOT NULL";
            using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sEMSDbConString))
            {
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    nGroupID = Conversions.ToInteger(oReader["Al_Group"]);
                    if (AlarmGroupReportNotCreated(ref nGroupID))
                    {
                        cGroup.Items.Add(nGroupID.ToString());
                    }

                }
                oConnection.Close();
            }


        }
        private bool AlarmGroupReportNotCreated(ref int nGroupID)
        {
            bool AlarmGroupReportNotCreatedRet = default;
            AlarmGroupReportNotCreatedRet = false;
            string sQuery;
            int nCount = 0;
            try
            {
                sQuery = "SELECT COUNT(*) FROM TBL_ReportsConfiguration where ReportType=2 and AlmGroupID=" + nGroupID.ToString();
                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    nCount = Conversions.ToInteger(oCmd.ExecuteScalar());

                    oConnection.Close();
                }
            }
            catch (Exception )
            {

            }
            AlarmGroupReportNotCreatedRet = !Conversions.ToBoolean(nCount);
            return AlarmGroupReportNotCreatedRet;
        }
        private void cTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cTemplate.SelectedIndex == -1 | cGroup.SelectedIndex == -1 | tReportTitle.Text.Length < 5)
            {
                bAdd.Enabled = false;
            }
            else
            {
                bAdd.Enabled = true;
            }
        }

        private void cGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cTemplate.SelectedIndex == -1 | cGroup.SelectedIndex == -1 | tReportTitle.Text.Length < 5)
            {
                bAdd.Enabled = false;
            }
            else
            {
                bAdd.Enabled = true;
            }
        }

        private void tReportTitle_TextChanged(object sender, EventArgs e)
        {
            if (cTemplate.SelectedIndex == -1 | cGroup.SelectedIndex == -1 | tReportTitle.Text.Length < 5)
            {
                bAdd.Enabled = false;
            }
            else
            {
                bAdd.Enabled = true;
            }
        }

        private void bAddNewGroup_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgNewGroup();
            if (oDlg.ShowDialog() == DialogResult.OK)
            {
                LoadGroupCombobox();
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}