using System;
using System.Data.Odbc;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgBatteryReportConfiguration
    {
        public DlgBatteryReportConfiguration()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {

            UpdateGridData();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DlgReportsConfiguration_Load(object sender, EventArgs e)
        {
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

                        if (nReportType == MactusReportLib.MactusReportLib.ReportType.BatteryStatusReport)
                        {
                            nRow = oGrid.Rows.Add();
                            oGrid.Rows[nRow].Cells[0].Value = oReader["reportid"];
                            var tmp = oReader;
                            int argnTemID = Conversions.ToInteger(tmp["templateid"]);
                            oGrid.Rows[nRow].Cells[1].Value = GetTemplateName(ref argnTemID);
                            oGrid.Rows[nRow].Cells[1].ReadOnly = true;
                            oGrid.Rows[nRow].Cells[2].Value = nReportType.ToString();
                            oGrid.Rows[nRow].Cells[3].Value = GetGroupName(Conversions.ToInteger(oReader["almgroupid"]));
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
                            oGrid.Rows[nRow].Cells[12].Value = Conversions.ToBoolean(oReader["PrintMinMaxRows"]);
                            oGrid.Rows[nRow].Cells[13].Value = Conversions.ToBoolean(oReader["PrintAlarmSpRows"]);

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
            int nRow;
            int nReportID;

            UpdateGridDataRet = false;

            try
            {
                var loopTo = oGrid.Rows.Count - 1;
                for (nRow = 0; nRow <= loopTo; nRow++)
                {

                    nReportID = Conversions.ToInteger(oGrid.Rows[nRow].Cells[0].Value);

                    sQuery = "UPDATE tbl_reportsconfiguration SET templateid=?, almgroupid=?,reporttitle=?,reportheader=?,generatedtime=?,generatedby=?,fromtodatesprinted=?,timeintervalinmin=?,dataaggregationtype=?,PrintMinMaxRows=?,PrintAlarmSpRows=? WHERE reportid=" + nReportID.ToString();
                    using (var oUpdateConnection = new OdbcConnection(g_sConString))
                    {
                        oUpdateConnection.Open();
                        var oUpdateCmd = new OdbcCommand(sQuery, oUpdateConnection);
                        string argsTempName = Conversions.ToString(oGrid.Rows[nRow].Cells[1].Value);
                        oUpdateCmd.Parameters.Add("@0", OdbcType.Int).Value = GetTemplateID(ref argsTempName);
                        oGrid.Rows[nRow].Cells[1].Value = argsTempName; // templateid
                        string argsGroupName = Conversions.ToString(oGrid.Rows[nRow].Cells[3].Value);
                        oUpdateCmd.Parameters.Add("@1", OdbcType.Int).Value = GetGroupID(ref argsGroupName);
                        oGrid.Rows[nRow].Cells[3].Value = argsGroupName; // almgroupid
                        oUpdateCmd.Parameters.Add("@2", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[4].Value; // reporttitle
                        oUpdateCmd.Parameters.Add("@3", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[5].Value; // reportheader

                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[6].Value))
                        {
                            oUpdateCmd.Parameters.Add("@4", OdbcType.Int).Value = 1; // generatedtime
                        }
                        else
                        {
                            oUpdateCmd.Parameters.Add("@4", OdbcType.Int).Value = 0;
                        } // generatedtime

                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[7].Value)) // generatedby
                        {
                            oUpdateCmd.Parameters.Add("@5", OdbcType.Int).Value = 1;
                        }
                        else
                        {
                            oUpdateCmd.Parameters.Add("@5", OdbcType.Int).Value = 1;
                        }

                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[8].Value)) // fromtodatesprinted
                        {
                            oUpdateCmd.Parameters.Add("@6", OdbcType.Int).Value = 1;
                        }
                        else
                        {
                            oUpdateCmd.Parameters.Add("@6", OdbcType.Int).Value = 1;
                        }

                        oUpdateCmd.Parameters.Add("@7", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[9].Value; // timeintervalinmin

                        DataAgg nAggtype = (DataAgg)Conversions.ToInteger(Enum.Parse(typeof(DataAgg), oGrid.Rows[nRow].Cells[10].Value.ToString()));
                        oUpdateCmd.Parameters.Add("@8", OdbcType.Int).Value = nAggtype; // dataaggregationtype


                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[12].Value)) // PrintMinMaxRows
                        {
                            oUpdateCmd.Parameters.Add("@9", OdbcType.Int).Value = 1;
                        }
                        else
                        {
                            oUpdateCmd.Parameters.Add("@9", OdbcType.Int).Value = 1;
                        }

                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[13].Value)) // PrintAlarmSpRows
                        {
                            oUpdateCmd.Parameters.Add("@10", OdbcType.Int).Value = 1;
                        }
                        else
                        {
                            oUpdateCmd.Parameters.Add("@10", OdbcType.Int).Value = 1;
                        }

                        oUpdateCmd.ExecuteNonQuery();
                        oUpdateConnection.Close();
                    }
                }
            }

            catch (Exception )
            {
                UpdateGridDataRet = false;
            }

            return UpdateGridDataRet;


        }



        private void oGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void bAddNewReport_Click(object sender, EventArgs e)
        {
            int nRow;
            string sQuery;
            int nReportID;

            var oDlg = new DlgSelectReportGroupTemplate();

            if (oDlg.ShowDialog() == DialogResult.OK)
            {

                sQuery = "INSERT INTO tbl_reportsconfiguration (templateid, reporttype, almgroupid, reporttitle, reportheader, generatedtime, generatedby, fromtodatesprinted, datatablename, timeintervalinmin, dataaggregationtype,PrintAlarmSpRows,PrintMinMaxRows )VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";

                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    string argsTempName = oDlg.cTemplate.Text;
                    oCmd.Parameters.Add("@0", OdbcType.Int).Value = GetTemplateID(ref argsTempName);
                    oDlg.cTemplate.Text = argsTempName; // templateid
                    oCmd.Parameters.Add("@1", OdbcType.Int).Value = MactusReportLib.MactusReportLib.ReportType.BatteryStatusReport;  // reporttype
                    string argsGroupName = oDlg.cGroup.Text;
                    oCmd.Parameters.Add("@2", OdbcType.Int).Value = GetGroupID(ref argsGroupName);
                    oDlg.cGroup.Text = argsGroupName; // almgroupid
                    oCmd.Parameters.Add("@3", OdbcType.VarChar).Value = oDlg.tReportTitle.Text; // reporttitle
                    oCmd.Parameters.Add("@4", OdbcType.VarChar).Value = "New Report Second Title"; // reportheader
                    oCmd.Parameters.Add("@5", OdbcType.Int).Value = 1; // generatedtime
                    oCmd.Parameters.Add("@6", OdbcType.Int).Value = 1; // generatedby
                    oCmd.Parameters.Add("@7", OdbcType.Int).Value = 1; // fromtodatesprinted
                    if (g_bIsBMS == 1) // datatablename
                    {
                        oCmd.Parameters.Add("@8", OdbcType.VarChar).Value = "trend_data";
                    }
                    else
                    {
                        oCmd.Parameters.Add("@8", OdbcType.VarChar).Value = "alldata";
                    }
                    oCmd.Parameters.Add("@9", OdbcType.Int).Value = 1; // timeintervalinmin
                    oCmd.Parameters.Add("@10", OdbcType.Int).Value = DataAgg.Instance; // dataaggregationtype
                    oCmd.Parameters.Add("@11", OdbcType.Int).Value = 0; // PrintAlarmSpRows
                    oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0; // PrintMinMaxRows
                    oCmd.ExecuteNonQuery();
                    sQuery = "SELECT @@Identity ";
                    oCmd.Parameters.Clear();
                    oCmd.CommandText = sQuery;
                    nReportID = Conversions.ToInteger(oCmd.ExecuteScalar());
                    if (nReportID > 0)
                    {
                        AddDateTimeColumnToReport(nReportID);
                    }
                    oConnection.Close();


                    nRow = oGrid.Rows.Add();
                    oGrid.Rows[nRow].Cells[0].Value = nReportID;
                    oGrid.Rows[nRow].Cells[1].Value = oDlg.cTemplate.Text;
                    oGrid.Rows[nRow].Cells[2].Value = "Data Report";
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
                    oGrid.Rows[nRow].Cells[12].Value = false;
                    oGrid.Rows[nRow].Cells[13].Value = false;
                }
            }



        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nReportID;
            if (e.RowIndex != -1)
            {
                nReportID = Conversions.ToInteger(oGrid.Rows[e.RowIndex].Cells[0].Value);
                if (e.ColumnIndex == 11 & nReportID != 0)
                {

                    var oDlg = new dlgColumnsConfiguration();
                    oDlg.m_nReportID = nReportID;
                    oDlg.ShowDialog();
                }
            }
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
    }
}