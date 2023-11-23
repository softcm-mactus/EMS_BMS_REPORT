using System;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{

    public partial class DlgAppConfiguration
    {
        public DlgAppConfiguration()
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

        private void DlgAppConfiguration_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            DataGridViewButtonCell oButton;
            DataGridViewCheckBoxCell oCheckBox;
            string sQuery;
            OdbcDataReader oReader;
            int nType;
            string sValue;
            int nRow;

            // Delete all old rows if any
            oGrid.Rows.Clear();

            sQuery = "SELECT * FROM TBL_ReportAppConfig";

            using (var oConnection = new OdbcConnection(MactusReportLib.MactusReportLib.g_sConString))
            {
                var cmd = new OdbcCommand(sQuery, oConnection);
                oConnection.Open();
                oReader = cmd.ExecuteReader();
                while (oReader.Read())
                {
                    nRow = oGrid.Rows.Add();
                    nType = Conversions.ToInteger(oReader["Type"]);
                    sValue = Conversions.ToString(oReader["Value"]);
                    oGrid.Rows[nRow].Cells[0].Value = oReader["ID"];
                    oGrid.Rows[nRow].Cells[1].Value = oReader["Description"];
                    oGrid.Rows[nRow].Cells[2].Value = nType;

                    // Try
                    // oGrid.Rows(nRow).Cells(4).Value = oReader("MinValue")
                    // Catch ex As Exception
                    // If nType = 1 Or nType = 3 Then 'String or Dir
                    // oGrid.Rows(nRow).Cells(4).Value = 10
                    // Else
                    // oGrid.Rows(nRow).Cells(4).Value = 0
                    // End If
                    // End Try
                    // Try
                    // oGrid.Rows(nRow).Cells(5).Value = oReader("MaxValue")
                    // Catch ex As Exception
                    // If nType = 1 Or nType = 3 Then 'String or Dir
                    // oGrid.Rows(nRow).Cells(5).Value = 95
                    // Else
                    // oGrid.Rows(nRow).Cells(5).Value = 60
                    // End If
                    // End Try

                    if (nType == 2) // Checkbox
                    {
                        oCheckBox = new DataGridViewCheckBoxCell();
                        oCheckBox.Value = Conversions.ToBoolean(sValue);
                        oCheckBox.ValueType = typeof(bool);

                        oGrid.Rows[nRow].Cells[3] = oCheckBox;
                        oCheckBox = new DataGridViewCheckBoxCell();
                        oCheckBox.Value = Conversions.ToBoolean(sValue);
                        oCheckBox.ValueType = typeof(bool);
                        oGrid.Rows[nRow].Cells[6] = oCheckBox;
                    }
                    else if (nType == 3) // Folder
                    {
                        oButton = new DataGridViewButtonCell();
                        oButton.ValueType = typeof(string);
                        oButton.Value = Convert.ToString(sValue);
                        oGrid.Rows[nRow].Cells[3] = oButton;
                        oButton = new DataGridViewButtonCell();
                        oButton.ValueType = typeof(string);
                        oButton.Value = Convert.ToString(sValue);
                        oGrid.Rows[nRow].Cells[6] = oButton;
                    }
                    else
                    {
                        oGrid.Rows[nRow].Cells[3].Value = sValue;
                        oGrid.Rows[nRow].Cells[6].Value = sValue;
                    }
                }
                oConnection.Close();
            }
            oGrid.ClearSelection();
            oGrid.Refresh();
        }

        private void oGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nType;
            if (e.ColumnIndex == 3 & e.RowIndex > 0)
            {
                nType = Conversions.ToInteger(oGrid.Rows[e.RowIndex].Cells[2].Value);
                if (nType == 3)
                {
                    var folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = false;
                    folderDlg.SelectedPath = Conversions.ToString(oGrid.Rows[e.RowIndex].Cells[3].Value);
                    if (folderDlg.ShowDialog() == DialogResult.OK)
                    {
                        oGrid.Rows[e.RowIndex].Cells[3].Value = folderDlg.SelectedPath;
                    }
                }
            }
        }

        private void oGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Don't Handle for header row
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex != 3)
            {
                return;
            }

            int nID;
            int nType;
            string sValue = "";
            int nTemp;
            try
            {

                nID = Conversions.ToInteger(oGrid.Rows[e.RowIndex].Cells[0].Value);
                nType = Conversions.ToInteger(oGrid.Rows[e.RowIndex].Cells[2].Value);
                if (nType == 0)
                {
                    return;
                }
                sValue = Conversions.ToString(oGrid.Rows[e.RowIndex].Cells[3].Value);
                // If nType = 1 Or nType = 3 Then 'String or Dir
                // If sValue.Length() < oGrid.Rows(e.RowIndex).Cells(4).Value Then
                // ShowMessageBox("Text Length Is Smaller Than MinValue", MessageBoxIcon.Error)
                // oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                // ElseIf sValue.Length() > oGrid.Rows(e.RowIndex).Cells(5).Value Then
                // ShowMessageBox("Text Length Is Larger Than MaxValue", MessageBoxIcon.Error)
                // oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                // Else
                // oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
                // End If
                // End If

                if (nType == 4)
                {
                    try
                    {
                        nTemp = Conversions.ToInteger(sValue);
                        // If nTemp < oGrid.Rows(e.RowIndex).Cells(4).Value Then
                        // ShowMessageBox("Entered Value Is Smaller Than MinValue", MessageBoxIcon.Error)
                        // oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                        // ElseIf nTemp > oGrid.Rows(e.RowIndex).Cells(5).Value Then
                        // ShowMessageBox("Entered Value Is Larger Than MaxValue", MessageBoxIcon.Error)
                        // oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                        // Else
                        // oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
                        // End If
                        oGrid.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.White;
                    }
                    catch (Exception )
                    {
                        oGrid.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.OrangeRed;
                        MessageBox.Show("Please Enter Valid Numeric Value", "Report Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oGrid.Rows[e.RowIndex].Cells[3].Value = oGrid.Rows[e.RowIndex].Cells[6].Value;
                    }

                }
            }
            catch (Exception )
            {

            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int nRowIndex = 0;
            int nID = 0;
            string sDesc;
            string sNewValue;
            string sQuery;
            bool bChanged = false;
            int nType;
            bool bError = false;
            string sValue;
            int nTemp;
            int nCount = 0;

            var loopTo = oGrid.Rows.Count - 1;
            for (nRowIndex = 0; nRowIndex <= loopTo; nRowIndex++)
            {
                sValue = Conversions.ToString(oGrid.Rows[nRowIndex].Cells[3].Value);
                nType = Conversions.ToInteger(oGrid.Rows[nRowIndex].Cells[2].Value);
                if (nType == 4)
                {
                    try
                    {
                        nTemp = Conversions.ToInteger(sValue);

                        oGrid.Rows[nRowIndex].Cells[3].Style.BackColor = Color.White;
                    }

                    catch (Exception )
                    {
                        oGrid.Rows[nRowIndex].Cells[3].Style.BackColor = Color.OrangeRed;
                        bError = true;
                        oGrid.Rows[nRowIndex].Cells[3].Value = oGrid.Rows[nRowIndex].Cells[6].Value;
                    }
                }
            }

            if (bError)
            {
                MessageBox.Show("Please Correct Data Validation Errors. No Records Updated", "Report Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Do You Really Want To Update the Site Configuration?", "Report Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }


            // Validate The Data
            var loopTo1 = oGrid.Rows.Count - 1;
            for (nRowIndex = 0; nRowIndex <= loopTo1; nRowIndex++)
            {
                nID = Conversions.ToInteger(oGrid.Rows[nRowIndex].Cells[0].Value);
                nType = Conversions.ToInteger(oGrid.Rows[nRowIndex].Cells[2].Value);
                sDesc = Conversions.ToString(oGrid.Rows[nRowIndex].Cells[1].Value);
                if (nType == 2)
                {
                    if (Conversions.ToBoolean(oGrid.Rows[nRowIndex].Cells[3].Value))
                    {
                        sNewValue = "1";
                    }
                    else
                    {
                        sNewValue = "0";
                    }
                }
                else
                {
                    sNewValue = oGrid.Rows[nRowIndex].Cells[3].Value.ToString();
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(oGrid.Rows[nRowIndex].Cells[3].Value, oGrid.Rows[nRowIndex].Cells[6].Value, false)))
                {
                    sQuery = "Update TBL_ReportAppConfig SET Value = '" + sNewValue + "' WHERE ID=" + nID.ToString();
                    MactusReportLib.MactusReportLib.ExecuteSQLInDb(sQuery);
                    bChanged = true;
                    nCount = nCount + 1;
                }
            }

            if (bChanged)
            {
                MessageBox.Show(nCount.ToString() + " Records Updated. You Need to Restart Server Computer and Client Application For Changes To Take Effect ", "Report Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}