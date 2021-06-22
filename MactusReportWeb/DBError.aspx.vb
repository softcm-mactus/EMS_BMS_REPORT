Public Class DBError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label1.Text = MactusReportLib.g_sErrorText

    End Sub

End Class