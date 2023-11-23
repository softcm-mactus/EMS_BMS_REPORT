using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class dlgTableView
    {
        private Dictionary<string, int> colMap = new Dictionary<string, int>();
        public class ReportInfo
        {
            public string id;
            public string name;
            public string type;
            public override string ToString()
            {
                string ToStringRet = default;
                ToStringRet = name;
                return ToStringRet;
            }
        }
        public class CellInfo
        {
            public string seqNo;
            public int colIndex;
            public DateTime timestamp;
            public string value;
        }
        public int m_nReportID = 0;
        public object isLoaded = false;

        public dlgTableView()
        {
            InitializeComponent();
        }

        private void dlgTableView_load(object sender, EventArgs e)
        {
            try
            {
                string sQuery = "SELECT * FROM TBL_DataGroups WHERE grouptype=0 ORDER BY groupid";
                var oConnection = new OdbcConnection(g_sConString);
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                var oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    var o = new ReportInfo();
                    o.id = Conversions.ToString(oReader["GroupId"]);
                    o.name = Conversions.ToString(oReader["GroupName"]);
                    o.type = Conversions.ToString(oReader["GroupType"]);
                    cGroup.Items.Add(o);
                }
                oReader.Close();
                oConnection.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            try
            {
                string sQuery = "SELECT distinct(CategoryName) CatName FROM TBL_ReportGroups";
                var oConnection = new OdbcConnection(g_sConString);
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                var oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    var o = new ReportInfo();
                    o.name = Conversions.ToString(oReader["CatName"]);
                    cGroup.Items.Add(o);
                }
                oReader.Close();
                oConnection.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            if (cGroup.Items.Count > 0)
            {
                cGroup.SelectedIndex = 0;
                cGroup_SelectedIndexChanged(null, null);
            }
            oStartDate.Checked = true;
            oStartTime.Checked = true;
            oEndDate.Checked = true;
            oEndTime.Checked = true;

            oStartDate.Value = My.MySettings.Default.StartDate;
            oStartTime.Value = My.MySettings.Default.StartTime;
            oEndDate.Value = My.MySettings.Default.EndDate;
            oEndTime.Value = My.MySettings.Default.EndTime;

            oTolerance.Value = My.MySettings.Default.Tolerance;
            oPrecision.Value = My.MySettings.Default.Precision;
            if (My.MySettings.Default.IncludeEvents > 0)
            {
                oIncludeEvents.Checked = true;
            }
            else
            {
                oIncludeEvents.Checked = false;
            }
            isLoaded = true;
            dlgTableView_Resize(null, null);
        }
        private void cGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            oReports.Items.Clear();
            OdbcDataReader oReader;
            ReportInfo group = (ReportInfo)cGroup.SelectedItem;
            try
            {
                if (group.id != null && group.id.Length > 0)
                {
                    string sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE AlmGroupID=" + group.id + " AND ReportType = 0 " + " ORDER BY ReportTitle";
                    var oConnection = new OdbcConnection(g_sConString);
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        var o = new ReportInfo();
                        o.id = Conversions.ToString(oReader["ReportID"]);
                        o.name = Conversions.ToString(oReader["ReportTitle"]);
                        oReports.Items.Add(o);
                    }
                    oReader.Close();
                    oConnection.Close();
                }
                else
                {
                    string sQuery = "SELECT distinct(GroupName) GroupName FROM TBL_ReportGroups where CategoryName = '" + group.name+"'";
                    var oConnection = new OdbcConnection(g_sConString);
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        var o = new ReportInfo();
                        o.name = Conversions.ToString(oReader["GroupName"]);
                        oReports.Items.Add(o);
                    }
                    oReader.Close();
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            if (oReports.Items.Count > 0)
            {
                oReports.SelectedIndex = 0;
            }
        }

        private void Reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_oColList.Clear();
            try
            {
                string sQuery;
                OdbcDataReader oReader;
                ReportInfo report = (ReportInfo)oReports.SelectedItem;
                ReportInfo group = (ReportInfo)cGroup.SelectedItem;
                if (report.id!=null && report.id.Length > 0)
                {
                    sQuery = "SELECT * FROM TBL_ReportColumns WHERE ReportID=" + report.id + " ORDER BY ColSeq";
                    var oConnection = new OdbcConnection(g_sConString);
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();

                    while (oReader.Read())
                    {
                        var oCol = new ReportColumn();
                        if (string.Compare(Conversions.ToString(oReader["ColNameInDB"]), "timestamp", true) != 0)
                        {
                            getColDetails(oReader, oCol);
                            oCol.m_bshowAlarmCol = true;
                            g_oColList.Add(oCol);
                        }
                    }
                    oReader.Close();
                    oConnection.Close();
                }
                else
                {
                    sQuery = "SELECT * FROM TBL_ReportGroups WHERE GroupName= '" + report.name + "' AND CategoryName = '" + group.name +"' ORDER BY ExternalLogId";
                    var oConnection = new OdbcConnection(g_sConString);
                    var eConnection = new OdbcConnection(g_sEMSDbConString);
                    oConnection.Open();
                    eConnection.Open();
                    var oGroupCmd = new OdbcCommand(sQuery, oConnection);
                    var oGroupReader = oGroupCmd.ExecuteReader();

                    while (oGroupReader.Read())
                    {
                        var ExternalLogId = oGroupReader["ExternalLogId"];
                        //sQuery = Conversions.ToString(Operators.AddObject("SELECT * FROM TBL_ReportColumns WHERE ColNameInDB = ", ExternalLogId));
                        //var oCmd = new OdbcCommand(sQuery, oConnection);
                        //oReader = oCmd.ExecuteReader();
                        var oCol = new ReportColumn();
                        //if (oReader.Read())
                        //{
                        //    getColDetails(oReader, oCol);
                        //}
                        //else
                        {
                            oCol.m_sColumnNameinTable = Conversions.ToString(ExternalLogId);
                            oCol.m_sColTitle = Conversions.ToString(oGroupReader["ColumnName"]);
                            // sQuery = "SELECT * from nsp.Trend_Meta where ExternalLogId = " + ExternalLogId
                            // Dim cmd As New OdbcCommand(sQuery, oConnection)
                            // oReader = cmd.ExecuteReader
                            // If oReader.Read() Then
                            // oCol.m_sColTitle = oReader("Source")
                            // oCol.m_sColTitle.Split("/").Last
                            // End If
                        }
                        oCol.m_bshowAlarmCol = true;
                        g_oColList.Add(oCol);
                        //oReader.Close();
                    }
                    oGroupReader.Close();
                    oConnection.Close();
                    eConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }

        }

        private static void getColDetails(OdbcDataReader oReader, ReportColumn oCol)
        {
            oCol.m_nID = Conversions.ToInteger(oReader["ColumnID"]);
            try
            {
                oCol.m_sColType = Conversions.ToString(oReader["ColType"]);
            }
            catch (Exception )
            {
                oCol.m_sColType = "";
            }

            try
            {
                oCol.m_sColTitle = Conversions.ToString(oReader["ColTitle"]);
            }
            catch (Exception )
            {
                oCol.m_sColTitle = "";
            }

            try
            {
                oCol.m_sColWidth = Conversions.ToSingle(oReader["ColWidth"]);
            }
            catch (Exception )
            {
                oCol.m_sColWidth = 1.0f;
            }

            try
            {
                oCol.m_nColJust = (ColJust)Conversions.ToInteger(oReader["ColJust"]);
            }
            catch (Exception )
            {
                oCol.m_nColJust = 0;
            }

            try
            {
                oCol.m_sColumnNameinTable = Conversions.ToString(oReader["ColNameInDB"]);
            }
            catch (Exception )
            {
                oCol.m_sColumnNameinTable = "";
            }

            try
            {
                oCol.m_bLowCheck = Conversions.ToBoolean(oReader["LowCheck"]);
            }
            catch (Exception )
            {
                oCol.m_bLowCheck = false;
            }
            try
            {
                oCol.m_nLowCheckType = Conversions.ToInteger(oReader["LowCheckType"]);
            }
            catch (Exception )
            {
                oCol.m_bLowCheck = false;
                oCol.m_nLowCheckType = 0;
            }

            try
            {
                oCol.m_fLow = Conversions.ToSingle(oReader["LowCheckValue"]);
            }
            catch (Exception )
            {
                oCol.m_bLowCheck = false;
                oCol.m_fLow = 0f;
            }

            try
            {
                oCol.m_bHighCheck = Conversions.ToBoolean(oReader["HighCheck"]);
            }
            catch (Exception )
            {
                oCol.m_bHighCheck = false;
            }

            try
            {
                oCol.m_nHighCheckType = Conversions.ToInteger(oReader["HighCheckType"]);
            }
            catch (Exception )
            {
                oCol.m_bHighCheck = false;
                oCol.m_nHighCheckType = 0;
            }

            try
            {
                oCol.m_fHigh = Conversions.ToSingle(oReader["HighCheckValue"]);
            }
            catch (Exception )
            {
                oCol.m_bHighCheck = false;
                oCol.m_fHigh = 0f;
            }

            try
            {
                oCol.m_bSPCheck = Conversions.ToBoolean(oReader["SetPointCheck"]);
            }
            catch (Exception )
            {
                oCol.m_bSPCheck = false;
            }

            try
            {
                oCol.m_nSPCheckType = Conversions.ToInteger(oReader["SetPointType"]);
            }
            catch (Exception )
            {
                oCol.m_bHighCheck = false;
                oCol.m_nSPCheckType = 0;
            }

            try
            {
                oCol.m_fSP = Conversions.ToSingle(oReader["SetPointValue"]);
            }
            catch (Exception )
            {
                oCol.m_bSPCheck = false;
                oCol.m_fSP = 0f;
            }

            if (oCol.m_nColType == ColType.DateTime | oCol.m_nColType == ColType.Other)
            {
                oCol.m_bLowCheck = false;
                oCol.m_bHighCheck = false;
            }

            try
            {
                oCol.m_nEnumID = Conversions.ToInteger(oReader["enumid"]);
            }
            catch (Exception )
            {
                oCol.m_nEnumID = 0;
            }


            oCol.m_fReportMax = (float)-9999.0d;
            oCol.m_fReportMin = 9999.0f;
            oCol.m_bReportMinAdded = false;
            oCol.m_bReportMaxAdded = false;
            oCol.m_dKMT = 0.0d;
            oCol.m_nKMTCount = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var columnSelector = new dlgSelectColumns();
            columnSelector.ShowDialog();
        }

        private void ViewData_Click(object sender, EventArgs e)
        {
            oGrid.Columns.Clear();
            oGrid.Rows.Clear();

            populateData();
        }

        private void populateData()
        {
            colMap = new Dictionary<string, int>();
            var oCol = new DataGridViewTextBoxColumn();
            string columnIds = "";
            oCol.Name = "Timestamp";
            oCol.Width = 140;
            oCol.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            oCol.DefaultCellStyle = new DataGridViewCellStyle();
            oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            oGrid.Columns.Add(oCol);

            foreach (var col in g_oColList)
            {
                if (col.m_bshowAlarmCol)
                {
                    oCol = new DataGridViewTextBoxColumn();
                    oCol.Name = col.m_sColTitle;
                    if (col.m_sColWidth > 60f)
                    {
                        oCol.Width = (int)Math.Round(col.m_sColWidth);
                    }
                    else
                    {
                        oCol.Width = 100;
                    }
                    oCol.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
                    oCol.DefaultCellStyle = new DataGridViewCellStyle();
                    oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    oGrid.Columns.Add(oCol);
                    if (columnIds.Length > 0)
                    {
                        columnIds += ",";
                    }
                    columnIds += col.m_sColumnNameinTable;
                    colMap.Add(col.m_sColumnNameinTable,(oGrid.Columns.Count - 1));
                }
            }
            oGrid.AutoResizeColumnHeadersHeight();

            var StartTime = oStartDate.Value.Date + oStartTime.Value.TimeOfDay;
            var EndTime = oEndDate.Value.Date + oEndTime.Value.TimeOfDay;
            string includeEventsClause = "";
            if (!oIncludeEvents.Checked)
            {
                includeEventsClause = " and Event is null ";
            }

            string sQuery = "select ExternalSeqNo, ExternalLogId, Timestamp, Value from nsp.Trend_Data where ExternalLogId in (" + columnIds + ") and Timestamp >= '" + StartTime.ToUniversalTime().ToString("s") + "' and Timestamp <='" + EndTime.ToUniversalTime().ToString("s") + "'" + includeEventsClause + " order by Timestamp";

            var eConnection = new OdbcConnection(g_sEMSDbConString);
            eConnection.Open();
            var oCmd = new OdbcCommand(sQuery, eConnection);
            var oReader = oCmd.ExecuteReader();
            var oLastTime = new DateTime();
            int index = 0;
            var currentTime = new DateTime();
            oLastTime = oLastTime.ToUniversalTime();
            while (oReader.Read())
            {
                try
                {
                    var timestamp = DateTime.Parse(Conversions.ToString(oReader["Timestamp"]));
                    if (oLastTime > timestamp | (timestamp - oLastTime).TotalMilliseconds > (double)oTolerance.Value)
                    {
                        index = oGrid.Rows.Add();
                        oLastTime = timestamp;
                        oGrid.Rows[index].Cells[0].Value = DateTime.Parse(Conversions.ToString(timestamp)).ToLocalTime().ToString("yyyy/MM/dd hh:mm:ss");
                        if ((DateTime.Now - currentTime).TotalSeconds > 2d)
                        {
                            double totalDiff = (EndTime - StartTime).TotalSeconds;
                            double curDiff = (DateTime.Parse(Conversions.ToString(timestamp)) - StartTime).TotalSeconds;
                            string val = Math.Ceiling(curDiff * 1.0d / totalDiff * 100d).ToString() + "% complete";
                            CheckInfo.Text = val;
                            CheckInfo.Update();
                            currentTime = new DateTime();
                        }
                    }
                    var id = oReader["ExternalLogId"];
                    var colId = this.colMap[id.ToString()];
                    if (!(oReader["Value"] is DBNull))
                    {
                        if (oPrecision.Value < 0m)
                        {
                            oGrid.Rows[index].Cells[colId].Value = oReader["Value"];
                        }
                        else
                        {
                            oGrid.Rows[index].Cells[colId].Value = (object)Math.Round(double.Parse(Conversions.ToString(oReader["Value"])), (int)Math.Round(Math.Ceiling(oPrecision.Value)));
                        }
                    }
                    var cellInfo = new CellInfo();
                    cellInfo.seqNo = Conversions.ToString(oReader["ExternalSeqNo"]);
                    cellInfo.timestamp = DateTime.Parse(Conversions.ToString(timestamp));
                    cellInfo.colIndex = Conversions.ToInteger(colId);

                    if (!(oReader["Value"] is DBNull))
                    {
                        cellInfo.value = Conversions.ToString(oReader["Value"]);
                    }
                    oGrid.Rows[index].Cells[colId].Tag = cellInfo;
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.Message);
                }

            }
            oReader.Close();
            eConnection.Close();
            CheckInfo.Text = "";
        }

        private void oGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oGrid_CurrentCellChanged(sender, e);
        }

        private void dlgTableView_Resize(object sender, EventArgs e)
        {
            int width = ClientSize.Width;
            int height = ClientSize.Height;
            ColInfo.Width = (int)Math.Round((width - 50) / 4d);
            if (ColInfo.Width < 100)
            {
                ColInfo.Width = 100;
            }
            CheckInfo.Width = ColInfo.Width;
            ColQuery.Width = ColInfo.Width;
            RowQuery.Width = ColInfo.Width;

            ColInfo.Left = 10;
            ColInfo.Top = height - 90;
            ColInfo.Height = 80;

            CheckInfo.Left = ColInfo.Left + ColInfo.Width + 10;
            CheckInfo.Top = height - 90;
            CheckInfo.Height = 80;

            ColQuery.Left = CheckInfo.Left + CheckInfo.Width + 10;
            ColQuery.Top = height - 90;
            ColQuery.Height = 80;

            RowQuery.Left = ColQuery.Left + ColQuery.Width + 10;
            RowQuery.Top = height - 90;
            RowQuery.Height = 80;

            oGrid.Width = width - 40;
            oGrid.Left = 20;
            oGrid.Height = height - 90 - 100;
            oGrid.Top = 90;

            oStartDate.Value = My.MySettings.Default.StartDate;
            oStartTime.Value = My.MySettings.Default.StartTime;
            oEndDate.Value = My.MySettings.Default.EndDate;
            oEndTime.Value = My.MySettings.Default.EndTime;

        }

        private void oGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (oGrid.CurrentCell == null)
                {
                    ColInfo.Text = "";
                    CheckInfo.Text = "";
                    ColQuery.Text = "";
                    RowQuery.Text = "";
                    return;
                }
                if (oGrid.CurrentCell.Tag == null)
                {
                    ColInfo.Text = "";
                    CheckInfo.Text = "";
                    ColQuery.Text = "";
                    RowQuery.Text = "";
                    return;
                }
                if (oGrid.CurrentCell != null & oGrid.CurrentCell.Tag is not null)
                {
                    CellInfo cellInfo = (CellInfo)oGrid.CurrentCell.Tag;
                    int colIndex = cellInfo.colIndex - 1;
                    string seqNo = cellInfo.seqNo;
                    var timestamp = cellInfo.timestamp;
                    string val = "";
                    val += "ExternalLogId: " + g_oColList[colIndex].m_sColumnNameinTable + Constants.vbNewLine;
                    val += "Sequence No: " + seqNo + Constants.vbNewLine;
                    val += "Timestamp in DB: " + timestamp.ToString("yyyy/MM/dd hh:mm:ss") + Constants.vbNewLine;
                    ColInfo.Text = val;
                    val = "Value: " + cellInfo.value + Constants.vbNewLine;
                    if (g_oColList[colIndex].m_bLowCheck)
                    {
                        val += "Low Check : " + g_oColList[colIndex].m_fLow.ToString() + Constants.vbNewLine;
                    }
                    if (g_oColList[colIndex].m_bHighCheck)
                    {
                        val += "High Check: " + g_oColList[colIndex].m_fHigh.ToString() + Constants.vbNewLine;
                    }
                    CheckInfo.Text = val;
                    val = "Select * from nsp.Trend_Data where ExternalSEQNO = " + seqNo + Constants.vbNewLine;
                    ColQuery.Text = val;
                    var row = oGrid.Rows[oGrid.CurrentCell.RowIndex];
                    string seqClause = "";
                    for (int i = 0, loopTo = row.Cells.Count - 1; i <= loopTo; i++)
                    {
                        if (row.Cells[i].Tag == null)
                        {
                            continue;
                        }
                        if (row.Cells[i].Tag != null)
                        {
                            CellInfo c = (CellInfo)row.Cells[i].Tag;
                            if (seqClause.Length > 0)
                            {
                                seqClause += ",";
                            }
                            seqClause += c.seqNo;
                        }
                    }
                    val = "Select * from nsp.Trend_Data where ExternalSEQNO in (" + seqClause + ")";
                    RowQuery.Text = val;
                }
                else
                {
                    ColInfo.Text = "";
                    CheckInfo.Text = "";
                    ColQuery.Text = "";
                    RowQuery.Text = "";
                }
            }
            catch (Exception )
            {
                ColInfo.Text = "";
                CheckInfo.Text = "";
                ColQuery.Text = "";
                RowQuery.Text = "";
            }

        }

        private void oStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                My.MySettings.Default.StartDate = oStartDate.Value;
            }
        }

        private void oEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                My.MySettings.Default.EndDate = oEndDate.Value;
            }
        }

        private void oStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                My.MySettings.Default.StartTime = oStartTime.Value;
            }
        }

        private void oEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                My.MySettings.Default.EndTime = oEndTime.Value;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                My.MySettings.Default.Precision = (int)Math.Round(oPrecision.Value);
            }
        }

        private void oTolerance_ValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                My.MySettings.Default.Tolerance = (int)Math.Round(oTolerance.Value);
            }
        }

        private void CheckInfo_TextChanged(object sender, EventArgs e)
        {
            if (CheckInfo.Text.Length == 0)
            {
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isLoaded))
            {
                if (oIncludeEvents.Checked)
                {
                    My.MySettings.Default.IncludeEvents = Conversions.ToInteger("1");
                }
                else
                {
                    My.MySettings.Default.IncludeEvents = Conversions.ToInteger("0");
                }
            }

        }
        private void RowQuery_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ToolTip2.Active = true;
                Clipboard.SetText(RowQuery.Text);
                ToolTip2.UseFading = true;
                ToolTip2.AutomaticDelay = 1;
                ToolTip2.AutoPopDelay = 1000;
                ToolTip2.InitialDelay = 1;
                ToolTip2.IsBalloon = true;
                ToolTip2.Show("Query copied", RowQuery, 1000);
                Timer1.Enabled = true;
            }
            catch (Exception )
            {
            }
        }
        private void ColQuery_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ToolTip1.Active = true;
                Clipboard.SetText(ColQuery.Text);
                ToolTip1.AutomaticDelay = 1;
                ToolTip1.AutoPopDelay = 1000;
                ToolTip1.InitialDelay = 1;
                ToolTip1.IsBalloon = true;
                ToolTip1.Show("Query copied", ColQuery, 1000);
                Timer1.Enabled = true;
            }
            catch (Exception )
            {
            }
        }

        private void tp_Popup(object sender, PopupEventArgs e)
        {

        }

        private void tp_Disposed(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ToolTip1.Active = false;
            ToolTip2.Active = false;
        }
    }
}