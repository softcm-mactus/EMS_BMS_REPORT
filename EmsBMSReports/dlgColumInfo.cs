using System;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;

namespace EmsBMSReports
{
    public partial class dlgColumInfo
    {
        public int colIndex;
        public string seqNo;
        public DateTime timestamp;
        public float value;

        public dlgColumInfo()
        {
            InitializeComponent();
        }
        private void dlgColumInfo_Load(object sender, EventArgs e)
        {
            string val = "";
            val += "ExternalLogId: " + g_oColList[colIndex].m_sColumnNameinTable + Constants.vbNewLine;
            val += "Sequence No: " + seqNo + Constants.vbNewLine;
            val += "Timestamp in DB: " + timestamp.ToString("yyyy/MM/dd hh:mm:ss") + Constants.vbNewLine;
            if (g_oColList[colIndex].m_bLowCheck)
            {
                val += "Low Check : " + g_oColList[colIndex].m_fLow.ToString();
            }
            if (g_oColList[colIndex].m_bHighCheck)
            {
                val += "High Check: " + g_oColList[colIndex].m_fHigh.ToString();
            }
            val += "Query:" + Constants.vbNewLine + "   Select * from nsp.Trend_Data where [ExternalSEQNO] = " + seqNo + Constants.vbNewLine;
            ColInfo.Text = val;
        }
    }
}