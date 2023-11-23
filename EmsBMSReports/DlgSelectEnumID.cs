using System;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgSelectEnumID
    {

        public int m_nEnumID;

        public DlgSelectEnumID()
        {
            InitializeComponent();
        }

        private void DlgSelectEnumID_Load(object sender, EventArgs e)
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
                sQuery = "SELECT * FROM tbl_enumvalue  ORDER BY enumid";

                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {

                        nRow = oGrid.Rows.Add();
                        oGrid.Rows[nRow].Cells[0].Value = true;
                        oGrid.Rows[nRow].Cells[1].Value = oReader["enumid"];
                        oGrid.Rows[nRow].Cells[2].Value = oReader["enumvalue"];
                        oGrid.Rows[nRow].Cells[3].Value = oReader["enumdesc"];
                        oGrid.Rows[nRow].Cells[1].ReadOnly = true;
                        oGrid.Rows[nRow].Cells[1].Style.BackColor = Color.LightGray;
                        oGrid.Rows[nRow].Cells[2].ReadOnly = true;
                        oGrid.Rows[nRow].Cells[2].Style.BackColor = Color.LightGray;

                    }
                    oConnection.Close();
                }
            }
            catch (Exception )
            {

            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            string sQuery;
            for (int nRow = 0, loopTo = oGrid.Rows.Count - 1; nRow <= loopTo; nRow++)
            {
                if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[0].Value))
                {
                    if (oGrid.Rows[nRow].Cells[3].Value.ToString().Length > 2)
                    {
                        sQuery = "UPDATE tbl_enumvalue SET enumdesc='" + oGrid.Rows[nRow].Cells[3].Value.ToString() + "' WHERE enumid=" + oGrid.Rows[nRow].Cells[1].Value.ToString() + " AND enumvalue=" + oGrid.Rows[nRow].Cells[2].Value.ToString();
                        MactusReportLib.MactusReportLib.ExecuteSQLInDb(sQuery);
                    }
                }
                else
                {
                    try
                    {

                        if (oGrid.Rows[nRow].Cells[1].Value.ToString().Length >= 1 & oGrid.Rows[nRow].Cells[2].Value.ToString().Length >= 1 & oGrid.Rows[nRow].Cells[3].Value.ToString().Length >= 2)
                        {

                            sQuery = " INSERT INTO tbl_enumvalue (enumid,enumvalue,enumdesc) VALUES(" + oGrid.Rows[nRow].Cells[1].Value.ToString() + "," + oGrid.Rows[nRow].Cells[2].Value.ToString() + ",'" + oGrid.Rows[nRow].Cells[3].Value.ToString() + " ')";
                            if (MactusReportLib.MactusReportLib.ExecuteSQLInDb(sQuery))
                            {
                                oGrid.Rows[nRow].Cells[1].Value = true;
                            }
                        }
                    }

                    catch (Exception )
                    {

                    }
                }

            }

            RefreshGrid();
        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 1)
            {
                return;
            }
            if (Conversions.ToBoolean(oGrid.Rows[e.RowIndex].Cells[0].Value))
            {
                bSelect.Enabled = true;
                m_nEnumID = Conversions.ToInteger(oGrid.Rows[e.RowIndex].Cells[1].Value);
            }
            else
            {
                bSelect.Enabled = false;
                m_nEnumID = -1;
            }
        }
    }
}