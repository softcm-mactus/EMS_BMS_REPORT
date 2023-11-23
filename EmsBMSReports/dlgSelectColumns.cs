using System;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic.CompilerServices;

namespace EmsBMSReports
{
    public partial class dlgSelectColumns
    {
        public dlgSelectColumns()
        {
            InitializeComponent();
        }
        private void dlgSelectColumns_Load(object sender, EventArgs e)
        {
            foreach (var col in g_oColList)
            {
                oColumns.Items.Add(col.m_sColTitle);
                if (col.m_bshowAlarmCol)
                {
                    oColumns.SetItemChecked(oColumns.Items.Count - 1, true);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void oColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var col in g_oColList)
                col.m_bshowAlarmCol = false;
            foreach (var col in oColumns.CheckedIndices)
                g_oColList[Conversions.ToInteger(col)].m_bshowAlarmCol = true;
        }
    }
}