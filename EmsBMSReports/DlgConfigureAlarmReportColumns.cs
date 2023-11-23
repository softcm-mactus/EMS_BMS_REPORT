using System;
using System.Data.Odbc;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgConfigureAlarmReportColumns
    {
        public DlgConfigureAlarmReportColumns()
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

        private void DlgConfigureAlarmReportColumns_Load(object sender, EventArgs e)
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
                sQuery = "SELECT * FROM tbl_reportcolumns WHERE reportid=-2 ORDER BY colseq";

                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        ColType nColType;
                        ColJust nColJust;
                        nColType = (ColType)Conversions.ToInteger(oReader["coltype"]);
                        nColJust = (ColJust)Conversions.ToInteger(oReader["coljust"]);

                        nRow = oGrid.Rows.Add();
                        oGrid.Rows[nRow].Cells[0].Value = oReader["columnid"];
                        oGrid.Rows[nRow].Cells[1].Value = oReader["colnameindb"];
                        oGrid.Rows[nRow].Cells[2].Value = nColType.ToString();
                        oGrid.Rows[nRow].Cells[3].Value = oReader["colwidth"];
                        oGrid.Rows[nRow].Cells[4].Value = oReader["colformat"];
                        oGrid.Rows[nRow].Cells[5].Value = nColJust.ToString();
                        oGrid.Rows[nRow].Cells[6].Value = oReader["coltitle"];

                        oGrid.Rows[nRow].Cells[7].Value = Conversions.ToBoolean(oReader["enumid"]);


                    }
                    oConnection.Close();
                }
            }
            catch (Exception )
            {

            }
        }

        private void oGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void bMoveUp_Click(object sender, EventArgs e)
        {
            int nRowIndex;

            try
            {
                nRowIndex = oGrid.SelectedRows[0].Index;
                object oTemp;
                for (int nCol = 0, loopTo = oGrid.Columns.Count - 1; nCol <= loopTo; nCol++)
                {
                    try
                    {
                        oTemp = oGrid.Rows[nRowIndex].Cells[nCol].Value;
                        oGrid.Rows[nRowIndex].Cells[nCol].Value = oGrid.Rows[nRowIndex - 1].Cells[nCol].Value;
                        oGrid.Rows[nRowIndex - 1].Cells[nCol].Value = oTemp;
                    }

                    catch (Exception )
                    {

                    }
                }
            }

            catch (Exception )
            {

            }
        }

        private void bMoveDown_Click(object sender, EventArgs e)
        {
            int nRowIndex;

            try
            {
                nRowIndex = oGrid.SelectedRows[0].Index;
                object oTemp;
                for (int nCol = 0, loopTo = oGrid.Columns.Count - 1; nCol <= loopTo; nCol++)
                {
                    try
                    {
                        oTemp = oGrid.Rows[nRowIndex].Cells[nCol].Value;
                        oGrid.Rows[nRowIndex].Cells[nCol].Value = oGrid.Rows[nRowIndex + 1].Cells[nCol].Value;
                        oGrid.Rows[nRowIndex + 1].Cells[nCol].Value = oTemp;
                    }

                    catch (Exception )
                    {

                    }
                }
            }

            catch (Exception )
            {

            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want To Save Changes?", "Reports Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sQuery;
                int nRow;
                ColJust nColJust;
                try
                {
                    var loopTo = oGrid.Rows.Count - 1;
                    for (nRow = 0; nRow <= loopTo; nRow++)
                    {
                        sQuery = "UPDATE  tbl_reportcolumns SET colnameindb=?,colwidth=?,colformat=?,coljust=?,coltitle=?,enumid=?,colseq=? WHERE reportid=-2 AND columnid=?";

                        using (var oConnection = new OdbcConnection(g_sConString))
                        {
                            oConnection.Open();
                            var oCmd = new OdbcCommand(sQuery, oConnection);
                            oCmd.Parameters.Add("@0", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[1].Value; // ColNameInDB
                            oCmd.Parameters.Add("@1", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[3].Value; // colwidth
                            oCmd.Parameters.Add("@2", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[4].Value; // colformat
                            nColJust = (ColJust)Conversions.ToInteger(Enum.Parse(typeof(ColJust), oGrid.Rows[nRow].Cells[5].Value.ToString()));
                            oCmd.Parameters.Add("@3", OdbcType.Int).Value = nColJust; // coljust
                            oCmd.Parameters.Add("@4", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[6].Value; // coltitle
                            if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[7].Value))
                            {
                                oCmd.Parameters.Add("@5", OdbcType.Int).Value = 1; // enumid
                            }
                            else
                            {
                                oCmd.Parameters.Add("@5", OdbcType.Int).Value = 0;
                            } // enumid
                            oCmd.Parameters.Add("@6", OdbcType.Int).Value = nRow + 1; // colseq
                            oCmd.Parameters.Add("@7", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[0].Value; // columnid

                            oCmd.ExecuteNonQuery();
                            oConnection.Close();
                        }
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception )
                {

                }

            }
        }
    }
}