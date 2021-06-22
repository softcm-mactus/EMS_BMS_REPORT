Public Class ViewPDF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' width=""500px"" height=""300px""



        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=100% height=100% >"
        embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        ltEmbed.Text = String.Format(embed, ResolveUrl(String.Format("~/Files/{0}", Request.QueryString("File"))))


    End Sub

End Class