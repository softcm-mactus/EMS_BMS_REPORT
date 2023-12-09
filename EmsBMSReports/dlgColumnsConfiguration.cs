using System;
using System.Data.Odbc;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using static EmsBMSReports.DlgSelectTrentDataPoint;
using System.Collections.Generic;

namespace EmsBMSReports
{

    public partial class dlgColumnsConfiguration
    {
        public int m_nReportID = 0;

        public dlgColumnsConfiguration()
        {
            InitializeComponent();
        }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want To Save Changes?", "Reports Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int nColID;
                int nTemp;
                for (int nRow = 0, loopTo = oGrid.Rows.Count - 1; nRow <= loopTo; nRow++)
                {
                    nTemp = nRow + 1;
                    nColID = Conversions.ToInteger(oGrid.Rows[nRow].Cells[0].Value);
                    if (nColID <= 0)
                    {
                        nColID = InsertNewColumn(ref nRow, ref m_nReportID);
                        oGrid.Rows[nRow].Cells[0].Value = nColID;
                    }
                    else
                    {
                        UpdateColumnData(nRow);
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }


        }
        private void UpdateColumnData(int nRow)
        {

            string sQuery;
            ColType nColType;
            ColJust nColJust;
            try
            {


                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    sQuery = "Update tbl_reportcolumns SET ColNameInDB=?, colseq =?, coltype=?,colwidth =?,colformat =?,coljust=?,colheader=?,coltitle=?,lowcheck=?,lowchecktype=?,lowcheckvalue=?,highcheck=?,highchecktype=?,highcheckvalue=?,setpointcheck=?,setpointtype=?,setpointvalue=?,colmerge=?,enumid=? WHERE columnid =" + oGrid.Rows[nRow].Cells[0].Value.ToString();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oCmd.Parameters.Add("@0", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[1].Value; // ColNameInDB
                    oCmd.Parameters.Add("@1", OdbcType.Int).Value = nRow + 2; // colseq
                    nColType = (ColType)Conversions.ToInteger(Enum.Parse(typeof(ColType), oGrid.Rows[nRow].Cells[2].Value.ToString()));
                    oCmd.Parameters.Add("@2", OdbcType.Int).Value = nColType; // coltype
                    oCmd.Parameters.Add("@3", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[3].Value; // colwidth
                    oCmd.Parameters.Add("@4", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[4].Value; // colformat
                    nColJust = (ColJust)Conversions.ToInteger(Enum.Parse(typeof(ColJust), oGrid.Rows[nRow].Cells[5].Value.ToString()));
                    oCmd.Parameters.Add("@5", OdbcType.Int).Value = nColJust; // coljust

                    oCmd.Parameters.Add("@6", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[6].Value; // colheader
                    oCmd.Parameters.Add("@7", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[7].Value; // coltitle





                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[8].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[9].Value))
                        {
                            oCmd.Parameters.Add("@8", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@9", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@10", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[10].Value; // 
                        }
                        else
                        {

                            oCmd.Parameters.Add("@8", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@9", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@10", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[10].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@8", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@9", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@10", OdbcType.Int).Value = 0;
                    } // 

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[11].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[12].Value))
                        {
                            oCmd.Parameters.Add("@11", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@12", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@13", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[13].Value; // 
                        }
                        else
                        {
                            oCmd.Parameters.Add("@11", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@13", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[13].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@11", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@13", OdbcType.Int).Value = 0;

                    } // 

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[16].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[17].Value))
                        {
                            oCmd.Parameters.Add("@14", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@15", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@16", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[18].Value; // 
                        }
                        else
                        {
                            oCmd.Parameters.Add("@14", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@15", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@16", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[18].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@14", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@15", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@16", OdbcType.Int).Value = 0;

                    } // 

                    oCmd.Parameters.Add("@17", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[15].Value; // 
                    oCmd.Parameters.Add("@18", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[14].Value; // 


                    oCmd.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdaeteColumnData");
            }
        }

        private int InsertNewColumn(ref int nRow)
        {
            int InsertNewColumnRet = default;
            InsertNewColumnRet = 0;
            string sQuery;
            int nColID;
            ColType nColType;
            ColJust nColJust;
            nColID = GetNewColumnID();



            sQuery = "INSERT INTO tbl_reportcolumns(columnid, ReportID, colnameindb, colseq, coltype, colwidth, colformat, coljust, colheader, coltitle, lowcheck,lowchecktype, lowcheckvalue, highcheck,highchecktype, highcheckvalue,setpointcheck,setpointtype,setpointvalue, enumid, colmerge,columnid) ";
            sQuery += "	VALUES ( ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

            try
            {
                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oCmd.Parameters.Add("@19", OdbcType.Int).Value = nColID;
                    oCmd.Parameters.Add("@0", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[1].Value; // ColNameInDB
                    oCmd.Parameters.Add("@1", OdbcType.Int).Value = nRow + 2; // colseq
                    nColType = (ColType)Conversions.ToInteger(Enum.Parse(typeof(ColType), oGrid.Rows[nRow].Cells[2].Value.ToString()));
                    oCmd.Parameters.Add("@2", OdbcType.Int).Value = nColType; // coltype
                    oCmd.Parameters.Add("@3", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[3].Value; // colwidth
                    oCmd.Parameters.Add("@4", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[4].Value; // colformat
                    nColJust = (ColJust)Conversions.ToInteger(Enum.Parse(typeof(ColJust), oGrid.Rows[nRow].Cells[5].Value.ToString()));
                    oCmd.Parameters.Add("@5", OdbcType.Int).Value = nColJust; // coljust

                    oCmd.Parameters.Add("@6", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[6].Value; // colheader
                    oCmd.Parameters.Add("@7", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[7].Value; // coltitle

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[8].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[9].Value))
                        {
                            oCmd.Parameters.Add("@8", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@9", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@10", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[10].Value; // 
                        }
                        else
                        {

                            oCmd.Parameters.Add("@8", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@9", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@10", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[10].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@8", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@9", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@10", OdbcType.Int).Value = 0;
                    } // 

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[11].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[12].Value))
                        {
                            oCmd.Parameters.Add("@11", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@12", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@13", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[13].Value; // 
                        }
                        else
                        {
                            oCmd.Parameters.Add("@11", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@13", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[13].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@11", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@13", OdbcType.Int).Value = 0;

                    } // 

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[16].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[17].Value))
                        {
                            oCmd.Parameters.Add("@14", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@15", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@16", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[18].Value; // 
                        }
                        else
                        {
                            oCmd.Parameters.Add("@14", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@15", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@16", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[18].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@14", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@15", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@16", OdbcType.Int).Value = 0;

                    } // 

                    oCmd.Parameters.Add("@17", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[15].Value; // 
                    oCmd.Parameters.Add("@18", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[14].Value; // 


                    oCmd.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception )
            {

            }

            return InsertNewColumnRet;
        }


        private int InsertNewColumn(ref int nRow, ref int nReportId)
        {
            int InsertNewColumnRet = default;
            InsertNewColumnRet = 0;
            string sQuery;
            int nColID;
            ColType nColType;
            ColJust nColJust;
            nColID = GetNewColumnID();



            sQuery = "INSERT INTO tbl_reportcolumns(columnid, ReportID, colnameindb, colseq, coltype, colwidth, colformat, coljust, colheader, coltitle, lowcheck,lowchecktype, lowcheckvalue, highcheck,highchecktype, highcheckvalue,setpointcheck,setpointtype,setpointvalue, enumid, colmerge) ";
            sQuery += "	VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

            try
            {
                using (var oConnection = new OdbcConnection(g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    oCmd.Parameters.Add("@0", OdbcType.Int).Value = nColID;
                    oCmd.Parameters.Add("@1", OdbcType.Int).Value = nReportId;

                    oCmd.Parameters.Add("@2", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[1].Value; // ColNameInDB
                    oCmd.Parameters.Add("@3", OdbcType.Int).Value = nRow + 2; // colseq
                    nColType = (ColType)Conversions.ToInteger(Enum.Parse(typeof(ColType), oGrid.Rows[nRow].Cells[2].Value.ToString()));
                    oCmd.Parameters.Add("@4", OdbcType.Int).Value = nColType; // coltype
                    oCmd.Parameters.Add("@5", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[3].Value; // colwidth
                    oCmd.Parameters.Add("@6", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[4].Value; // colformat
                    nColJust = (ColJust)Conversions.ToInteger(Enum.Parse(typeof(ColJust), oGrid.Rows[nRow].Cells[5].Value.ToString()));
                    oCmd.Parameters.Add("@7", OdbcType.Int).Value = nColJust; // coljust

                    oCmd.Parameters.Add("@8", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[6].Value; // colheader
                    oCmd.Parameters.Add("@9", OdbcType.VarChar).Value = oGrid.Rows[nRow].Cells[7].Value; // coltitle

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[8].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[9].Value))
                        {
                            oCmd.Parameters.Add("@10", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@11", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@12", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[10].Value; // 
                        }
                        else
                        {

                            oCmd.Parameters.Add("@10", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@11", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@12", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[10].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@10", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@11", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@12", OdbcType.Int).Value = 0;
                    } // 

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[11].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[12].Value))
                        {
                            oCmd.Parameters.Add("@13", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@14", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@15", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[13].Value; // 
                        }
                        else
                        {
                            oCmd.Parameters.Add("@13", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@14", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@15", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[13].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@13", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@14", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@15", OdbcType.Int).Value = 0;

                    } // 

                    if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[16].Value))
                    {
                        if (Conversions.ToBoolean(oGrid.Rows[nRow].Cells[17].Value))
                        {
                            oCmd.Parameters.Add("@16", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@17", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@18", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[18].Value; // 
                        }
                        else
                        {
                            oCmd.Parameters.Add("@16", OdbcType.Int).Value = 1; // 
                            oCmd.Parameters.Add("@17", OdbcType.Int).Value = 0; // 
                            oCmd.Parameters.Add("@18", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[18].Value;
                        } // 
                    }
                    else
                    {
                        oCmd.Parameters.Add("@16", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@17", OdbcType.Int).Value = 0; // 
                        oCmd.Parameters.Add("@18", OdbcType.Int).Value = 0;

                    } // 

                    oCmd.Parameters.Add("@19", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[15].Value; // 
                    oCmd.Parameters.Add("@20", OdbcType.Int).Value = oGrid.Rows[nRow].Cells[14].Value; // 


                    oCmd.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception )
            {

            }

            return InsertNewColumnRet;
        }


        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dlgColumnsConfiguration_Load(object sender, EventArgs e)
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
                sQuery = "SELECT * FROM tbl_reportcolumns WHERE reportid=" + m_nReportID.ToString() + " ORDER BY colseq";

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
                        if (nColType != MactusReportLib.MactusReportLib.ColType.DateTime)
                        {
                            nRow = oGrid.Rows.Add();
                            oGrid.Rows[nRow].Cells[0].Value = oReader["columnid"];
                            oGrid.Rows[nRow].Cells[1].Value = oReader["colnameindb"];
                            oGrid.Rows[nRow].Cells[2].Value = nColType.ToString();
                            oGrid.Rows[nRow].Cells[3].Value = oReader["colwidth"];
                            oGrid.Rows[nRow].Cells[4].Value = oReader["colformat"];
                            oGrid.Rows[nRow].Cells[5].Value = nColJust.ToString();
                            oGrid.Rows[nRow].Cells[6].Value = oReader["colheader"];
                            oGrid.Rows[nRow].Cells[7].Value = oReader["coltitle"];
                            oGrid.Rows[nRow].Cells[8].Value = Conversions.ToBoolean(oReader["lowcheck"]);
                            oGrid.Rows[nRow].Cells[9].Value = Conversions.ToBoolean(oReader["lowcheckType"]);
                            oGrid.Rows[nRow].Cells[10].Value = oReader["lowcheckvalue"];

                            oGrid.Rows[nRow].Cells[11].Value = Conversions.ToBoolean(oReader["highcheck"]);
                            oGrid.Rows[nRow].Cells[12].Value = Conversions.ToBoolean(oReader["highchecktype"]);
                            oGrid.Rows[nRow].Cells[13].Value = oReader["highcheckvalue"];

                            oGrid.Rows[nRow].Cells[14].Value = oReader["enumid"];
                            oGrid.Rows[nRow].Cells[15].Value = oReader["colmerge"];

                            oGrid.Rows[nRow].Cells[16].Value = Conversions.ToBoolean(oReader["SetPointCheck"]);
                            oGrid.Rows[nRow].Cells[17].Value = Conversions.ToBoolean(oReader["SetPointType"]);
                            oGrid.Rows[nRow].Cells[18].Value = oReader["SetPointValue"];



                        }
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

        private void bDeleteColumn_Click(object sender, EventArgs e)
        {
            int nColID;
            string sColTitle;
            string sQuery;

            if (oGrid.SelectedRows.Count <= 0)
            {
                Interaction.MsgBox("No Row Selected");
                return;
            }
            for (int nRow = 0, loopTo = oGrid.SelectedRows.Count - 1; nRow <= loopTo; nRow++)
            {
                nColID = Conversions.ToInteger(oGrid.SelectedRows[nRow].Cells[0].Value);
                sColTitle = Conversions.ToString(oGrid.SelectedRows[nRow].Cells[6].Value);
                if (nColID > 0)
                {
                    if (MessageBox.Show(sColTitle + " : Do you Really Want To Delete The  Column?", "Columns Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if(PointNames.ContainsKey(nColID.ToString()))
                        {
                            PointNames[nColID.ToString()].isUsed = false;
                        }
                        sQuery = "DELETE FROM tbl_reportcolumns WHERE columnid=" + nColID.ToString();
                        ExecuteSQLInDb(sQuery);

                        RefreshGrid();

                    }
                }
                else
                {
                    MessageBox.Show(sColTitle + " :New Column Not Yet Saved In The Database?", "Columns Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
        public Dictionary<string, PointName> PointNames = new Dictionary<string, PointName>();
        void loadPointNames()
        {
            if (PointNames.Count == 0)
            {
                string sQuery = "SELECT * FROM tbl_pointidname ORDER BY id";
                using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
                {
                    oConnection.Open();
                    var oCmd = new OdbcCommand(sQuery, oConnection);
                    var oReader = oCmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        var p = new PointName();
                        p.id = oReader["id"].ToString();
                        p.name = oReader["pointname"].ToString();
                        PointNames.Add(p.id, p);
                    }
                    oReader.Close();
                    oConnection.Close();
                }
            }
       }
        public class PointName
        {
            public string id;
            public string name;
            public bool isSelected=false;
            public bool isUsed=false;
        }

        private void bAddNewColumn_Click(object sender, EventArgs e)
        {
            loadPointNames();
            foreach(var v in PointNames.Values)
            {
                v.isSelected = false;
            }
            var oDlg = new DlgSelectTrentDataPoint();
            oDlg.PointNames= PointNames;

            int nRow;
            if (oDlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var v in PointNames.Values)
                {
                    if (v.isSelected && !v.isUsed)
                    {
                        v.isUsed = true;
                        //bool bFound = false;
                        //if (g_bIsBMS == 1)
                        //{
                        //    var loopTo = oGrid.Rows.Count - 1;
                        //    for (nRow = 0; nRow <= loopTo; nRow++)
                        //    {
                        //        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(v.id, oGrid.Rows[nRow].Cells[1].Value, false)))
                        //        {
                        //            bFound = true;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    var loopTo1 = oGrid.Rows.Count - 1;
                        //    for (nRow = 0; nRow <= loopTo1; nRow++)
                        //    {
                        //        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(v.name, oGrid.Rows[nRow].Cells[1].Value, false)))
                        //        {
                        //            bFound = true;
                        //        }
                        //    }
                        //}
                        //if (bFound == false)
                        {
                            nRow = oGrid.Rows.Add();
                            oGrid.Rows[nRow].Cells[0].Value = 0;
                            if (g_bIsBMS == 1)
                            {
                                oGrid.Rows[nRow].Cells[1].Value = v.id;
                            }
                            else
                            {
                                oGrid.Rows[nRow].Cells[1].Value = v.name;
                            }
                            oGrid.Rows[nRow].Cells[2].Value = MactusReportLib.MactusReportLib.ColType.Other.ToString();
                            oGrid.Rows[nRow].Cells[3].Value = 1.0d;
                            oGrid.Rows[nRow].Cells[4].Value = "";
                            oGrid.Rows[nRow].Cells[5].Value = MactusReportLib.MactusReportLib.ColJust.Center.ToString();
                            oGrid.Rows[nRow].Cells[6].Value = v.name;
                            oGrid.Rows[nRow].Cells[7].Value = "";

                            oGrid.Rows[nRow].Cells[8].Value = false;
                            oGrid.Rows[nRow].Cells[9].Value = false;
                            oGrid.Rows[nRow].Cells[10].Value = 0;

                            oGrid.Rows[nRow].Cells[11].Value = false;
                            oGrid.Rows[nRow].Cells[12].Value = false;
                            oGrid.Rows[nRow].Cells[13].Value = 0;

                            oGrid.Rows[nRow].Cells[14].Value = 0;
                            oGrid.Rows[nRow].Cells[15].Value = 0;

                            oGrid.Rows[nRow].Cells[16].Value = false;
                            oGrid.Rows[nRow].Cells[17].Value = false;
                            oGrid.Rows[nRow].Cells[18].Value = 0;
                        }

                    }
                }

            }

        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == 14)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(oGrid.Rows[e.RowIndex].Cells[2].Value, "Enumtype", false)))
                {
                    var oDlg = new DlgSelectEnumID();
                    if (oDlg.ShowDialog() == DialogResult.OK)
                    {
                        oGrid.Rows[e.RowIndex].Cells[14].Value = oDlg.m_nEnumID;
                    }
                }
                else
                {
                    oGrid.Rows[e.RowIndex].Cells[14].Value = 0;
                }
            }
            else if (e.ColumnIndex == 13)
            {
                //if (Conversions.ToBoolean(oGrid.Rows[e.RowIndex].Cells[12].Value))
                //{
                //    var oDlg = new DlgSelectTrentDataPoint();
                //    if (oDlg.ShowDialog() == DialogResult.OK)
                //    {
                //        //oGrid.Rows[e.RowIndex].Cells[13].Value = oDlg.m_nLogID;
                //    }
                //}
            }
            else if (e.ColumnIndex == 10)
            {
                //if (Conversions.ToBoolean(oGrid.Rows[e.RowIndex].Cells[9].Value))
                //{
                //    var oDlg = new DlgSelectTrentDataPoint();
                //    if (oDlg.ShowDialog() == DialogResult.OK)
                //    {
                //        //oGrid.Rows[e.RowIndex].Cells[10].Value = oDlg.m_nLogID;
                //    }
                //}
            }
            else if (e.ColumnIndex == 18)
            {
                //if (Conversions.ToBoolean(oGrid.Rows[e.RowIndex].Cells[17].Value))
                //{
                //    var oDlg = new DlgSelectTrentDataPoint();
                //    if (oDlg.ShowDialog() == DialogResult.OK)
                //    {
                //        //oGrid.Rows[e.RowIndex].Cells[18].Value = oDlg.m_nLogID;
                //    }
                //}
            }
            else if (e.ColumnIndex == 1)
            {
                //var oDlg = new DlgSelectTrentDataPoint();
                //if (oDlg.ShowDialog() == DialogResult.OK)
                //{
                //    if (g_bIsBMS == 1)
                //    {
                //        //oGrid.Rows[e.RowIndex].Cells[1].Value = oDlg.m_nLogID;
                //    }
                //    else
                //    {
                //        //oGrid.Rows[e.RowIndex].Cells[1].Value = oDlg.m_sPointName;
                //    }
                //}

            }

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

        private void oGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                bMoveUp.Enabled = false;
            }
            else
            {
                bMoveUp.Enabled = true;
            }
            if (e.RowIndex == oGrid.Rows.Count - 1)
            {
                bMoveDown.Enabled = false;
            }
            else
            {
                bMoveDown.Enabled = true;
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


    }
}