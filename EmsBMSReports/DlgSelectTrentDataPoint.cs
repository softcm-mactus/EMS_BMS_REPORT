using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using static EmsBMSReports.dlgColumnsConfiguration;

namespace EmsBMSReports
{

    public partial class DlgSelectTrentDataPoint
    {
        public Dictionary<string, string> UsedColumnNames = new Dictionary<string, string>();
        public Dictionary<string, string> SelectedColumnNames = new Dictionary<string, string>();
        public Dictionary<string, PointName> PointNames = new Dictionary<string, PointName>();

        public DlgSelectTrentDataPoint()
        {
            InitializeComponent();
        }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void RefreshGrid()
        {
            OdbcDataReader oReader;

            int nRow;
            if (PointNames.Count == 0)
            {
                string sQuery = "SELECT * FROM tbl_pointidname ORDER BY id";
                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        var p = new PointName();
                        p.id = oReader["id"].ToString();
                        p.name = oReader["pointname"].ToString();
                        p.isSelected = false;
                        PointNames.Add(p.id, p);
                    }
                    oReader.Close();
                    oConnection.Close();
                }
            }
            try
            {
                oGrid.Rows.Clear();
                foreach(var v in PointNames.Values)
                {
                    if(tPointName.Text.Length>1)
                    {
                        if(!v.name.ToUpper().Contains(tPointName.Text.ToUpper()))
                        {
                            continue;
                        }
                    }
                    if (bHide.Checked == true)
                    {
                        if (IsTrendLogAlreadyUsed(v.id) == false)
                        {
                            nRow = oGrid.Rows.Add();
                            oGrid.Rows[nRow].Tag = v;
                            oGrid.Rows[nRow].Cells[0].Value = v.isSelected;
                            oGrid.Rows[nRow].Cells[1].Value = v.id;
                            oGrid.Rows[nRow].Cells[2].Value = "";
                            oGrid.Rows[nRow].Cells[3].Value = v.name;
                        }
                    }
                    else
                    {
                        nRow = oGrid.Rows.Add();
                        oGrid.Rows[nRow].Tag = v;
                        oGrid.Rows[nRow].Cells[0].Value = v.isSelected;
                        oGrid.Rows[nRow].Cells[0].Value = v.id;
                        oGrid.Rows[nRow].Cells[1].Value = "";
                        oGrid.Rows[nRow].Cells[2].Value = v.name;
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void DlgSelectTrentDataPoint_Load(object sender, EventArgs e)
        {

            string sQuery = "SELECT colnameindb FROM tbl_reportcolumns";
            using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
            {

                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                var oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    var colName = oReader["colnameindb"].ToString();
                    try
                    {
                       UsedColumnNames.Add(colName, colName);
                    }
                    catch(Exception)
                    { 
                    }
                }
                oReader.Close();
                oConnection.Close();
            }

            RefreshGrid();


        }
        private bool IsTrendLogAlreadyUsed(int nLogID)
        {
            try
            {
                if (UsedColumnNames.ContainsKey(nLogID.ToString())) return true;
            }
            catch (Exception)
            {

            }

            return false;
        }

        private bool IsTrendLogAlreadyUsed(string sLogID)
        {
            try
            {
                if (UsedColumnNames.ContainsKey(sLogID)) return true;
            }
            catch (Exception)
            {

            }

            return false;
        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell)oGrid.Rows[e.RowIndex].Cells[0];
                    if ((bool)c.Value == true)
                    {
                        c.Value = false;
                        ((PointName)oGrid.Rows[e.RowIndex].Tag).isSelected = false;
                        c.Style.BackColor = System.Drawing.Color.White;
                        c.Style.ForeColor = System.Drawing.Color.Black;
                        oGrid.Rows[e.RowIndex].Cells[1].Style.BackColor = System.Drawing.Color.White;
                        oGrid.Rows[e.RowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.Black;
                        oGrid.Rows[e.RowIndex].Cells[2].Style.BackColor = System.Drawing.Color.White;
                        oGrid.Rows[e.RowIndex].Cells[2].Style.ForeColor = System.Drawing.Color.Black;
                        oGrid.Rows[e.RowIndex].Cells[3].Style.BackColor = System.Drawing.Color.White;
                        oGrid.Rows[e.RowIndex].Cells[3].Style.ForeColor = System.Drawing.Color.Black;
                    }
                    else if ((bool)c.Value == false)
                    {
                        c.Value = true;
                        c.Style.BackColor = System.Drawing.Color.Blue;
                        c.Style.ForeColor = System.Drawing.Color.White;
                        ((PointName)oGrid.Rows[e.RowIndex].Tag).isSelected = true;
                        oGrid.Rows[e.RowIndex].Cells[1].Style.BackColor = System.Drawing.Color.Blue;
                        oGrid.Rows[e.RowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.White;
                        oGrid.Rows[e.RowIndex].Cells[2].Style.BackColor = System.Drawing.Color.Blue;
                        oGrid.Rows[e.RowIndex].Cells[2].Style.ForeColor = System.Drawing.Color.White;
                        oGrid.Rows[e.RowIndex].Cells[3].Style.BackColor = System.Drawing.Color.Blue;
                        oGrid.Rows[e.RowIndex].Cells[3].Style.ForeColor = System.Drawing.Color.White;
                    }

                }
            }
        }

        private void bHide_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void tPointName_TextChanged(object sender, EventArgs e)
        {
            if (tPointName.Text.Length > 0)
            {
                RefreshGrid();
            }
        }

        private void bGetSimilorPoints_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void oGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}