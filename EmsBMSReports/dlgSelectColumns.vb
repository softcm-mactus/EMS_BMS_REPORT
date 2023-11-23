Imports MactusReportLib.MactusReportLib
Public Class dlgSelectColumns
    Private Sub dlgSelectColumns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each col In g_oColList
            oColumns.Items.Add(col.m_sColTitle)
            If col.m_bshowAlarmCol Then
                oColumns.SetItemChecked(oColumns.Items.Count - 1, True)
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub oColumns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles oColumns.SelectedIndexChanged
        For Each col In g_oColList
            col.m_bshowAlarmCol = False
        Next
        For Each col In oColumns.CheckedIndices
            g_oColList(col).m_bshowAlarmCol = True
        Next
    End Sub
End Class