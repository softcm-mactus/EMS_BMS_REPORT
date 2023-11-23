using System;
using System.Data.Odbc;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgSelectTrentDataPoint
    {
        public int m_nLogID;
        public string m_sPointName;
        public string m_sPointType;

        public DlgSelectTrentDataPoint()
        {
            InitializeComponent();
        }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            m_nLogID = Conversions.ToInteger(oGrid.SelectedRows[0].Cells[0].Value);
            m_sPointType = Conversions.ToString(oGrid.SelectedRows[0].Cells[1].Value);
            m_sPointName = Conversions.ToString(oGrid.SelectedRows[0].Cells[2].Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            m_nLogID = 0;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void RefreshGrid()
        {
            OdbcDataReader oReader;
            string sQuery = "";
            int nLogID;
            string sPointName;

            int nRow;

            oGrid.Rows.Clear();
            try
            {
                if (bGetSimilorPoints.Checked & tPointName.Text.Length > 2)
                {
                    sQuery = "SELECT * FROM tbl_pointidname where pointname like '%" + tPointName.Text + "%' ORDER BY id";
                }
                else
                {
                    sQuery = "SELECT * FROM tbl_pointidname ORDER BY id";
                }
                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        nLogID = Conversions.ToInteger(oReader["id"]);
                        sPointName = Conversions.ToString(oReader["pointname"]);

                        if (bHide.Checked == true)
                        {
                            if (IsTrendLogAlreadyUsed(ref nLogID) == false)
                            {
                                nRow = oGrid.Rows.Add();
                                oGrid.Rows[nRow].Cells[0].Value = nLogID;
                                oGrid.Rows[nRow].Cells[1].Value = "";
                                oGrid.Rows[nRow].Cells[2].Value = sPointName;
                            }
                        }
                        else
                        {
                            nRow = oGrid.Rows.Add();
                            oGrid.Rows[nRow].Cells[0].Value = nLogID;
                            oGrid.Rows[nRow].Cells[1].Value = "";
                            oGrid.Rows[nRow].Cells[2].Value = sPointName;
                        }
                    }
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message + "  " + sQuery);
            }

        }



        private void DlgSelectTrentDataPoint_Load(object sender, EventArgs e)
        {

            RefreshGrid();


        }
        private bool IsTrendLogAlreadyUsed(ref int nLogID)
        {
            bool IsTrendLogAlreadyUsedRet = default;
            IsTrendLogAlreadyUsedRet = false;
            string sQuery;
            OdbcDataReader oReader;
            try
            {
                sQuery = "SELECT * FROM tbl_reportcolumns where colnameindb='" + nLogID.ToString() + "'";
                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {

                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    if (oReader.Read())
                    {
                        IsTrendLogAlreadyUsedRet = true;
                    }

                    oConnection.Close();

                }
            }
            catch (Exception )
            {

            }

            return IsTrendLogAlreadyUsedRet;
        }

        private bool IsTrendLogAlreadyUsed(ref string sLogID)
        {
            bool IsTrendLogAlreadyUsedRet = default;
            IsTrendLogAlreadyUsedRet = false;
            string sQuery;
            OdbcDataReader oReader;
            try
            {
                sQuery = "SELECT * FROM tbl_reportcolumns where colnameindb='" + sLogID + "'";
                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {

                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    if (oReader.Read())
                    {
                        IsTrendLogAlreadyUsedRet = true;
                    }

                    oConnection.Close();

                }
            }
            catch (Exception )
            {

            }

            return IsTrendLogAlreadyUsedRet;
        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oGrid.SelectedRows.Count <= 0)
            {
                OK_Button.Enabled = false;
            }
            else
            {
                OK_Button.Enabled = true;
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
    }
}