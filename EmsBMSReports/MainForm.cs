using System;
using System.ComponentModel;
using System.Data.Odbc;
using System.Diagnostics;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;

namespace EmsBMSReports
{
    
    public partial class MainForm
    {

        public class GroupInfo
        {
            public int index = 0;
            public string name = "";
            public override string ToString()
            {
                return name;
            }
        }

        private ReportType m_nSelectedReportType;
        private int m_nIntervalMin = 1;
        private int m_nReportID = 0;
        private long m_nReportStatusID = 0L;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            try
            {
                // If g_sCurrent_login_UserID.Length > 0 Then
                string sError = "";

                var oTime = DateTime.Now;
                if (ReadDatabaseConnection(ref sError) == false)
                {
                    Interaction.MsgBox(sError);
                    Environment.Exit(0);
                }

                bCOnfigureReports.Visible = true;
                bConfigureAlarmReports.Visible = true; // g_bEnableConfiguration

                string sQuery;
                //sQuery = "UPDATE tbl_reportstatus SET status=4 where status=3";
                //ExecuteSQLInDb(sQuery);

                m_oEBOReprots = new MactusReportLib.EBOReport();
                m_oIndusoftReports = new MactusReportLib.NewInduSoftReport();

                bAreaReports.Checked = true;
                bAlarmReports.Checked = false;
                bEventReport.Checked = false;
                if (g_bIsBMS == 2)
                {
                    btnBatteryPercentage.Visible = true;
                    btnExcursionReport.Visible = true;
                }
                var argoReportGrid = oReportGrid;
                LoadReportsIntoListBox(ref argoReportGrid, (int)ReportType.DataReport);
                oReportGrid = argoReportGrid;
                cInterval.SelectedIndex = 0;
                m_nSelectedReportType = ReportType.DataReport;
                oTime = oTime.AddMilliseconds(-oTime.Millisecond);
                oTime = oTime.AddSeconds(-oTime.Second);
                oTime = oTime.AddMinutes(-oTime.Minute);
                oTime = oTime.AddHours(-oTime.Hour);
                oTime = oTime.AddDays(-7);
                tr_FromDate.Value = oTime;
                tr_ToDate.Value = oTime.AddDays(1d);
                bGenerate.Enabled = false;

                // Dim sQuery As String
                OdbcDataReader oReader;
                sQuery = "SELECT * FROM TBL_DataGroups WHERE grouptype=0 ORDER BY groupid";

                try
                {
                    using (var oConnection = new OdbcConnection(g_sConString))
                    {
                        oConnection.Open();
                        var oCmd = new OdbcCommand(sQuery, oConnection);
                        oReader = oCmd.ExecuteReader();
                        while (oReader.Read())
                        {
                            var g = new GroupInfo();
                            g.index = int.Parse(oReader["GroupId"].ToString());
                            g.name = oReader["GroupName"].ToString();
                            cGroup.Items.Add(g);
                        }
                        oConnection.Close();
                    }
                }
                catch (Exception )
                {

                }

                try
                {
                    cGroup.SelectedIndex = 0;
                    cGroup_SelectedIndexChanged(null, null);
                }
                catch (Exception )
                {

                }

                UpdateGrid();
                StartThread();


                oTimer.Enabled = true;
            }

            // Else

            // End If
            catch (Exception )
            {

            }


        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            if (m_nReportID == 0)
            {
                Interaction.MsgBox("No Report Selected");
                return;
            }
            oProgress.Value = 0;
            int nTimeInterval;

            nTimeInterval = Convert.ToInt16(cInterval.Text);

            var argdtFrom = tr_FromDate.Value;
            var argdtTo = tr_ToDate.Value;
            string argsGeneratedUserName = "user Name";
            int argnReportType = (int)m_nSelectedReportType;
            m_nReportStatusID = InsertNewReportStatusRecord(m_nReportID, ref argdtFrom, ref argdtTo, ref nTimeInterval, ref argsGeneratedUserName, ref argnReportType);
            tr_FromDate.Value = argdtFrom;
            tr_ToDate.Value = argdtTo;
            m_nSelectedReportType = (ReportType)argnReportType;
        }

        private void oReportGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                m_nReportID = Conversions.ToInteger(oReportGrid.Rows[e.RowIndex].Cells[0].Value);
                if (m_nSelectedReportType == ReportType.DataReport)
                {
                    cInterval.Text = oReportGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Label5.Visible = true;
                    cInterval.Visible = true;
                    m_nIntervalMin = Convert.ToInt16(oReportGrid.Rows[e.RowIndex].Cells[2].Value);
                    var argoDateTime = tr_FromDate.Value;
                    AdjustTimeMinuetsToInterval(ref argoDateTime);
                    tr_FromDate.Value = argoDateTime;
                    var argoDateTime1 = tr_ToDate.Value;
                    AdjustTimeMinuetsToInterval(ref argoDateTime1);
                    tr_ToDate.Value = argoDateTime1;
                    bGenerateChart.Enabled = true;
                }
                else
                {
                    Label5.Visible = false;
                    m_nIntervalMin = 1;
                    bGenerateChart.Enabled = false;
                }
                bGenerate.Enabled = true;
            }
            catch (Exception )
            {
                m_nReportID = 0;
                Label5.Visible = false;
                m_nIntervalMin = 1;
                bGenerate.Enabled = false;
                cInterval.Visible = false;
                bGenerateChart.Enabled = false;
            }

        }

        private void bAreaReports_CheckedChanged(object sender, EventArgs e)
        {

            cGroup.Enabled = true;
            var argoReportGrid = oReportGrid;
            LoadReportsIntoListBox(ref argoReportGrid, (int)ReportType.DataReport);
            oReportGrid = argoReportGrid;
            Label5.Visible = false;
            m_nSelectedReportType = ReportType.DataReport;
        }

        private void bAlarmReports_CheckedChanged(object sender, EventArgs e)
        {
            cGroup.Enabled = false;
            var argoReportGrid = oReportGrid;
            LoadReportsIntoListBox(ref argoReportGrid, (int)ReportType.AlarmReport);
            oReportGrid = argoReportGrid;
            Label5.Visible = false;
            m_nIntervalMin = 1;
            m_nSelectedReportType = ReportType.AlarmReport;
        }

        private void bEventReport_CheckedChanged(object sender, EventArgs e)
        {
            cGroup.Enabled = false;
            var argoReportGrid = oReportGrid;
            LoadReportsIntoListBox(ref argoReportGrid, (int)ReportType.EventReport);
            oReportGrid = argoReportGrid;
            Label5.Visible = false;
            m_nIntervalMin = 1;
            m_nSelectedReportType = ReportType.EventReport;
        }

        private void AdjustTimeMinuetsToInterval(ref DateTime oDateTime)
        {
            try
            {
                int nTemp;

                if (m_nIntervalMin == 1)
                {
                    return;
                }
                nTemp = (int)Math.Round(oDateTime.Minute / (double)m_nIntervalMin);

                nTemp = oDateTime.Minute - nTemp * m_nIntervalMin;

                oDateTime = oDateTime.AddMinutes(-nTemp);
            }
            catch (Exception )
            {

            }

        }

        private void tr_FromDate_LostFocus(object sender, EventArgs e)
        {
            var argoDateTime = tr_FromDate.Value;
            AdjustTimeMinuetsToInterval(ref argoDateTime);
            tr_FromDate.Value = argoDateTime;
        }

        private void tr_ToDate_LostFocus(object sender, EventArgs e)
        {
            var argoDateTime = tr_ToDate.Value;
            AdjustTimeMinuetsToInterval(ref argoDateTime);
            tr_ToDate.Value = argoDateTime;
        }

        public void LoadReportsIntoListBox(ref DataGridView oReportGrid, int nReportType)
        {
            oReportGrid.Rows.Clear();
            string sQuery;
            OdbcDataReader oReader;
            int nRow;

            try
            {
                if (nReportType == (int)ReportType.DataReport )
                {
                    string index = "0";
                    if (cGroup.SelectedIndex >= 0)
                        index = ((GroupInfo)(cGroup.Items[cGroup.SelectedIndex])).index.ToString();
                    sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE AlmGroupID=" + index + " AND ReportType=" + nReportType.ToString() + " ORDER BY ReportTitle";
                }
                else
                {
                    sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE ReportType=" + nReportType.ToString() + " ORDER BY ReportTitle";
                }
                var oConnection = new OdbcConnection(g_sConString);
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    nRow = oReportGrid.Rows.Add();
                    oReportGrid.Rows[nRow].Cells[0].Value = oReader["ReportID"];
                    oReportGrid.Rows[nRow].Cells[1].Value = oReader["ReportTitle"];
                    try
                    {
                        oReportGrid.Rows[nRow].Cells[2].Value = oReader["TimeIntervalInMin"];
                    }
                    catch (Exception )
                    {
                        oReportGrid.Rows[nRow].Cells[2].Value = "1";
                    }

                }
                oReader.Close();
                oConnection.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
                return;
            }
            oReportGrid.ClearSelection();
            oReportGrid.Refresh();
        }

        private void oTimer_Tick(object sender, EventArgs e)
        {
            oTimer.Enabled = false;

            if (m_nReportStatusID != 0L)
            {
                oProgress.Value = GetReportProgress(ref m_nReportStatusID);
                if (oProgress.Value == 100)
                {
                    UpdateGrid();
                }
            }


            oTimer.Enabled = true;
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            m_bStopThread = true;
        }

        private void UpdateGrid()
        {
            string sQuery = @"SELECT status.id id, 
                             status.reportId reportid,
                             rc.ReportTitle reporttitle,  
                             rc.ReportHeader reportheader, 
                             status.username username,  
                             status.fromdate fromdate,  
                             status.todate todate,  
                             status.status status,  
                             status.progress progress,  
                             status.errormessage errormessage,  
                             status.filename filename,  
                             status.outputfilename outputfilename  
                        FROM tbl_reportstatus as status  
                        Join TBL_ReportsConfiguration rc on rc.ReportID = status.reportid  
                        WHERE Status< 4";
            try
            {
                oGrid.Rows.Clear();
                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    var oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        var nRow = oGrid.Rows.Add();
                        oGrid.Rows[nRow].Tag = oReader["id"];
                        oGrid.Rows[nRow].Cells[0].Value = oReader["reportheader"];
                        oGrid.Rows[nRow].Cells[1].Value = oReader["reporttitle"];
                        oGrid.Rows[nRow].Cells[2].Value = oReader["username"];
                        oGrid.Rows[nRow].Cells[3].Value = oReader["fromdate"].ToString();
                        oGrid.Rows[nRow].Cells[4].Value = oReader["todate"].ToString();
                        oGrid.Rows[nRow].Cells[5].Value = oReader["progress"].ToString()+"%";
                        if (oReader["status"].ToString() == "3")
                        {
                            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)oGrid.Rows[nRow].Cells[6];
                            c.Style.Font =  new Font(oGrid.Font,FontStyle.Underline);
                            c.Style.ForeColor = Color.Blue;
                            c.Tag = oReader["outputfilename"];
                            c.Value = "Open Report";
                            c.ToolTipText = "Open report " + c.Tag.ToString();
                            c.Value = "Open Report";
                        }
                        else
                        {
                            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)oGrid.Rows[nRow].Cells[6];
                            c.Value = "Pending";
                        }
                    }
                    oConnection.Close();
                }
            }
            catch(Exception ex)
            {
            }
            oGrid.ClearSelection();
            oGrid.Refresh();
        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex != 6)
            {
                return;
            }
            try
            {
                string sQuery;
                if (oGrid.Rows[e.RowIndex].Cells[6].Tag != null)
                {
                    sQuery = "UPDATE tbl_reportstatus SET  Status=4 WHERE id=" + oGrid.Rows[e.RowIndex].Tag.ToString();
                    ExecuteSQLInDb(sQuery);
                    Process.Start(oGrid.Rows[e.RowIndex].Cells[6].Tag.ToString());
                }
            }

            catch (Exception)
            {

            }
            UpdateGrid();
        }

        private void cGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var argoReportGrid = oReportGrid;
            LoadReportsIntoListBox(ref argoReportGrid, (int)ReportType.DataReport);
            oReportGrid = argoReportGrid;
        }

        private void bCOnfigureReports_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgReportsConfiguration();
            oDlg.ShowDialog();
        }

        private void bConfigureAlarmReports_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgAlarmReportConfiguration();
            oDlg.ShowDialog();
        }

        private void bGenerateChart_Click(object sender, EventArgs e)
        {

            var argdtFrom = tr_FromDate.Value;
            var argdtTo = tr_ToDate.Value;
            int argnTimeInterval = 1;
            string argsGeneratedUserName = "user Name";
            int argnReportType = 1;
            m_nReportStatusID = InsertNewReportStatusRecord(m_nReportID, ref argdtFrom, ref argdtTo, ref argnTimeInterval, ref argsGeneratedUserName, ref argnReportType);
            tr_FromDate.Value = argdtFrom;
            tr_ToDate.Value = argdtTo;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (g_bIsBMS == 1)
            {
                SynchronizeEBOPointIDNamesTable();
            }
            else if (g_bIsBMS == 2)
            {
                SynchronizeWirelessCDUPointIDNamesTable();
            }
            else
            {
                SynchronizeIndusoftPointIDNamesTable();
            }
            Interaction.MsgBox("Data Synchronization Completed");
        }

        private void bConfigure_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgAppConfiguration();
            oDlg.ShowDialog();
        }

        private void btnExcursionReport_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgExcursionConfiguration();
            oDlg.ShowDialog();
        }

        private void btnBatteryPercentage_Click(object sender, EventArgs e)
        {
            var oDlg = new DlgBatteryReportConfiguration();
            oDlg.ShowDialog();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            var oDlg = new dlgTableView();
            oDlg.ShowDialog();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            var dlg = new DlgConfigureViewGroup();
            dlg.ShowDialog();
        }

        private void oGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cGroup_DropDown(object sender, EventArgs e)
        {
            string sQuery = "SELECT * FROM TBL_DataGroups WHERE grouptype=0 ORDER BY groupid";
            cGroup.Items.Clear();
            try
            {
                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    var oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        var g = new GroupInfo();
                        g.index = int.Parse(oReader["GroupId"].ToString());
                        g.name = oReader["GroupName"].ToString();
                        cGroup.Items.Add(g);
                    }
                    oReader.Close();
                    oConnection.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void oGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            string sQuery = "delete from tbl_reportstatus WHERE id=" + e.Row.Tag.ToString();
            ExecuteSQLInDb(sQuery);
        }
    }
}