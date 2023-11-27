Imports MactusReportLib.MactusReportLib
Public Class dlgColumInfo
    Public colIndex As Integer
    Public seqNo As String
    Public timestamp As DateTime
    Public value As Single
    Private Sub dlgColumInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim val = ""
        val += "ExternalLogId: " + g_oColList(colIndex).m_sColumnNameinTable + vbNewLine
        val += "Sequence No: " + seqNo + vbNewLine
        val += "Timestamp in DB: " + timestamp.ToString("yyyy/MM/dd hh:mm:ss") + vbNewLine
        If g_oColList(colIndex).m_bLowCheck Then
            val += "Low Check : " + g_oColList(colIndex).m_fLow.ToString()
        End If
        If g_oColList(colIndex).m_bHighCheck Then
            val += "High Check: " + g_oColList(colIndex).m_fHigh.ToString()
        End If
        val += "Query:" + vbNewLine + "   Select * from nsp.Trend_Data where [ExternalSEQNO] = " + seqNo + vbNewLine
        ColInfo.Text = val
    End Sub
End Class