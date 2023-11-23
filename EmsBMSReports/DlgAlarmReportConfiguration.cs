using System;
using System.Data.Odbc;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgAlarmReportConfiguration
    {
        public DlgAlarmReportConfiguration()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DlgAlarmReportConfiguration_Load(object sender, EventArgs e)
        {
            if (g_bIsBMS == 1)
            {
                SynchronizeAlarmGroupName();
            }
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            string sQuery;
            OdbcDataReader oReader;
            int nRow;

            oGrid.Rows.Clear();
            try
            {
                sQuery = "SELECT * FROM tbl_reportsconfiguration ORDER BY reportid";

                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        ReportType nReportType;
                        nReportType = (ReportType)Conversions.ToInteger(oReader["reporttype"]);

                        if (nReportType == MactusReportLib.MactusReportLib.ReportType.AlarmReport)
                        {
                            nRow = oGrid.Rows.Add();
                            oGrid.Rows[nRow].Cells[0].Value = oReader["reportid"];
                            var tmp = oReader;
                            int argnTemID = Conversions.ToInteger(tmp["templateid"]);
                            oGrid.Rows[nRow].Cells[1].Value = GetTemplateName(ref argnTemID);
                            oGrid.Rows[nRow].Cells[1].ReadOnly = true;
                            oGrid.Rows[nRow].Cells[2].Value = nReportType.ToString();
                            oGrid.Rows[nRow].Cells[3].Value = GetGroupName(Conversions.ToInteger(oReader["almgroupid"]), MactusReportLib.MactusReportLib.ReportType.AlarmReport);
                            oGrid.Rows[nRow].Cells[4].Value = oReader["reporttitle"];
                            oGrid.Rows[nRow].Cells[5].Value = oReader["reportheader"];
                            oGrid.Rows[nRow].Cells[6].Value = Conversions.ToBoolean(oReader["generatedtime"]);
                            oGrid.Rows[nRow].Cells[7].Value = Conversions.ToBoolean(oReader["generatedby"]);
                            oGrid.Rows[nRow].Cells[8].Value = Conversions.ToBoolean(oReader["fromtodatesprinted"]);
                            oGrid.Rows[nRow].Cells[9].Value = oReader["timeintervalinmin"].ToString();
                            try
                            {
                                DataAgg nAggType = (DataAgg)Conversions.ToInteger(oReader["dataaggregationtype"]);
                                oGrid.Rows[nRow].Cells[10].Value = nAggType.ToString();
                            }
                            catch (Exception )
                            {

                            }
                        }
                    }
                    oConnection.Close();
                }
            }
            catch (Exception )
            {

            }
        }

        private bool UpdateGridData()
        {
            bool UpdateGridDataRet = default;
            string sQuery;
            OdbcDataReader oReader;
            int nRow;
            ReportType nReportType;
            int nReportID;

            UpdateGridDataRet = false;

            try
            {
                sQuery = "SELECT * FROM tbl_reportsconfiguration  ORDER BY reportid";

                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        nReportType = (ReportType)Conversions.ToInteger(oReader["reporttype"]);
                        nReportID = Conversions.ToInteger(oReader["reportid"]);
                        if (nReportType == MactusReportLib.MactusReportLib.ReportType.AlarmReport)
                        {
                            bool bFound = false;
                            var loopTo = oGrid.Rows.Count - 1;
                            for (nRow = 0; nRow <= loopTo; nRow++)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(oGrid.Rows[nRow].Cells[0].Value, oReader["reportid"], false)))
                                {
                                    sQuery = "UPDATE tbl_reportsconfiguration ";
                                    int localGetTemplateID() { string argsTempName = Conversions.ToString(oGrid.Rows[nRow].Cells[1].Value); var ret = GetTemplateID(ref argsTempName); oGrid.Rows[nRow].Cells[1].Value = argsTempName; return ret; }

                                    sQuery += " SET templateid=" + localGetTemplateID().ToString();
                                    // sQuery += " SET reporttype=" + GetTemplateID(oGrid.Rows(nRow).Cells(2).Value).ToString
                                    int localGetGroupID() { string argsGroupName = Conversions.ToString(oGrid.Rows[nRow].Cells[3].Value); var ret = GetGroupID(ref argsGroupName, MactusReportLib.MactusReportLib.ReportType.AlarmReport); oGrid.Rows[nRow].Cells[3].Value = argsGroupName; return ret; }

                                    sQuery += ", almgroupid=" + localGetGroupID().ToString();
                                    sQuery += ", reporttitle='" + oGrid.Rows[nRow].Cells[4].Value.ToString() + "'";
                                    sQuery += ", reportheader='" + oGrid.Rows[nRow].Cells[5].Value.ToString() + "'";
                                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[6].Value))
                                    {
                                        sQuery += ", generatedtime=1";
                                    }
                                    else
                                    {
                                        sQuery += ", generatedtime=0";
                                    }
                                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[7].Value))
                                    {
                                        sQuery += ", generatedby=1";
                                    }
                                    else
                                    {
                                        sQuery += ", generatedby=0";
                                    }
                                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[8].Value))
                                    {
                                        sQuery += ", fromtodatesprinted=1";
                                    }
                                    else
                                    {
                                        sQuery += ", fromtodatesprinted=0";
                                    }

                                    sQuery += ",  timeintervalinmin=" + oGrid.Rows[nRow].Cells[9].Value.ToString();

                                    DataAgg nAggtype = (DataAgg)Conversions.ToInteger(Enum.Parse(typeof(DataAgg), oGrid.Rows[nRow].Cells[10].Value.ToString()));
                                    sQuery += ",  dataaggregationtype=" + Conversion.Str(nAggtype);

                                    sQuery += " where reportid=" + nReportID.ToString();
                                    ExecuteSQLInDb(sQuery);
                                    bFound = true;
                                }
                            }

                            if (bFound == false)
                            {
                                sQuery = "DELETE FROM tbl_reportcolumns WHERE reportid=" + nReportID.ToString();
                                ExecuteSQLInDb(sQuery);
                                sQuery = "DELETE FROM tbl_reportsconfiguration WHERE reportid=" + nReportID.ToString();
                                ExecuteSQLInDb(sQuery);
                            }
                        }
                    }
                    oConnection.Close();
                }
            }
            catch (Exception )
            {
                UpdateGridDataRet = false;
            }

            int nTemp;
            string sTemp;

            var loopTo1 = oGrid.Rows.Count - 1;
            for (nRow = 0; nRow <= loopTo1; nRow++)
            {
                try
                {
                    nReportID = Conversions.ToInteger(oGrid.Rows[nRow].Cells[0].Value);
                    if (nReportID == 0)
                    {
                        sQuery = "INSERT INTO tbl_reportsconfiguration (templateid, reporttype, almgroupid, reporttitle, reportheader, generatedtime, generatedby, fromtodatesprinted, datatablename, timeintervalinmin, dataaggregationtype )VALUES (";
                        try
                        {
                            sTemp = Conversions.ToString(oGrid.Rows[nRow].Cells[1].Value);
                        }
                        catch (Exception )
                        {
                            sTemp = "";
                        }
                        nTemp = GetTemplateID(ref sTemp);
                        sQuery += nTemp.ToString() + ",2,";

                        try
                        {
                            sTemp = Conversions.ToString(oGrid.Rows[nRow].Cells[3].Value);
                        }
                        catch (Exception )
                        {
                            sTemp = 0.ToString();
                        }
                        sQuery += GetGroupID(ref sTemp, MactusReportLib.MactusReportLib.ReportType.AlarmReport).ToString() + ",";

                        try
                        {
                            sTemp = oGrid.Rows[nRow].Cells[4].Value.ToString();
                            if (sTemp == null)
                            {
                                sTemp = "";
                            }
                        }
                        catch (Exception )
                        {
                            sTemp = "";
                        }
                        if (sTemp.Length <= 5)
                        {
                            Interaction.MsgBox("Title Should Be Minimum 5 characters");
                            break;
                        }


                        sQuery += "'" + sTemp + "',";

                        try
                        {
                            sTemp = Conversions.ToString(oGrid.Rows[nRow].Cells[5].Value);
                        }
                        catch (Exception )
                        {
                            sTemp = "";
                        }
                        if (sTemp == null)
                        {
                            sTemp = "";
                        }
                        sQuery += "'" + sTemp + "',";

                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[6].Value))
                        {
                            sQuery += "1,";
                        }
                        else
                        {
                            sQuery += "0,";
                        }

                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[7].Value))
                        {
                            sQuery += "1,";
                        }
                        else
                        {
                            sQuery += "0,";
                        }
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[8].Value))
                        {
                            sQuery += "1,";
                        }
                        else
                        {
                            sQuery += "0,";
                        }
                        if (g_bIsBMS == 1)
                        {
                            sQuery += "'event_data',";
                        }
                        else
                        {
                            sQuery += "'ALARMHISTORY',";
                        }

                        DataAgg nAggtype = (DataAgg)Conversions.ToInteger(Enum.Parse(typeof(DataAgg), oGrid.Rows[nRow].Cells[10].Value.ToString()));
                        sQuery += oGrid.Rows[nRow].Cells[9].Value.ToString() + "," + Conversion.Str(nAggtype) + ")";
                        try
                        {


                            using (var oConnection = new OdbcConnection(g_sConString))
                            {
                                oConnection.Open();
                                var oCmd = new OdbcCommand(sQuery, oConnection);
                                oCmd.ExecuteNonQuery();
                                sQuery = "SELECT @@Identity ";
                                oCmd.Parameters.Clear();
                                oCmd.CommandText = sQuery;
                                nReportID = Conversions.ToInteger(oCmd.ExecuteScalar());

                                oConnection.Close();
                            }
                        }

                        catch (Exception )
                        {
                            nReportID = 0;
                        }
                        if (nReportID > 0)
                        {
                            // AddDateTimeColumnToReport(nReportID)
                        }

                        UpdateGridDataRet = true;
                    }
                }
                catch (Exception )
                {
                    nReportID = 0;
                    UpdateGridDataRet = false;
                }
            }

            return UpdateGridDataRet;
        }

        private void oGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void OK_Button_Click_1(object sender, EventArgs e)
        {
            UpdateGridData();
        }

        private void bDeleteReport_Click(object sender, EventArgs e)
        {
            int nReportID;
            string sReportTitle;
            string sQuery;

            if (oGrid.SelectedRows.Count <= 0)
            {
                Interaction.MsgBox("No Row Selected");
                return;
            }
            for (int nRow = 0, loopTo = oGrid.SelectedRows.Count - 1; nRow <= loopTo; nRow++)
            {
                nReportID = Conversions.ToInteger(oGrid.SelectedRows[nRow].Cells[0].Value);
                sReportTitle = Conversions.ToString(oGrid.SelectedRows[nRow].Cells[4].Value);
                if (nReportID > 0)
                {
                    if (MessageBox.Show(sReportTitle + " : Do you Really Want To Delete The Report and Columns?", "Reports Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        sQuery = "DELETE FROM tbl_reportcolumns WHERE reportid=" + nReportID.ToString();
                        ExecuteSQLInDb(sQuery);
                        sQuery = "DELETE FROM tbl_reportsconfiguration WHERE reportid=" + nReportID.ToString();
                        ExecuteSQLInDb(sQuery);
                        RefreshGrid();

                    }
                }
                else
                {
                    MessageBox.Show(sReportTitle + " :New Report Not Yet Saved In The Database?", "Reports Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void bAddNewReport_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgSelectReportGroupTemplate();
            oDlg.m_bAlarmGroup = true;
            int nRow;
            if (oDlg.ShowDialog() == DialogResult.OK)
            {
                nRow = oGrid.Rows.Add();
                oGrid.Rows[nRow].Cells[0].Value = 0;
                oGrid.Rows[nRow].Cells[1].Value = oDlg.cTemplate.Text;
                oGrid.Rows[nRow].Cells[2].Value = "Alarm Report";
                oGrid.Rows[nRow].Cells[3].Value = oDlg.cGroup.Text;
                oGrid.Rows[nRow].Cells[4].Value = oDlg.tReportTitle.Text;
                oGrid.Rows[nRow].Cells[5].Value = "New Report Second Title";
                oGrid.Rows[nRow].Cells[6].Value = true;
                oGrid.Rows[nRow].Cells[7].Value = true;
                oGrid.Rows[nRow].Cells[8].Value = true;
                oGrid.Rows[nRow].Cells[9].Value = 1;
                try
                {
                    oGrid.Rows[nRow].Cells[10].Value = DataAgg.Instance.ToString();
                }
                catch (Exception )
                {

                }
            }
        }

        private void bConfigureColumns_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgConfigureAlarmReportColumns();
            oDlg.ShowDialog();
        }
    }
}