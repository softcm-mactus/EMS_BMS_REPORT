<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportProgress.aspx.vb" Inherits="MactusReportWeb.ReportProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="testscript" runat="server"></asp:ScriptManager>

        <table style="width: 80%; text-align: center; justify-self: center; padding-top: 20px; padding-bottom: 10px;">
            <tr style="width: 80%">

                <td style="text-align: center">
                    <asp:Label ID="lReportName" runat="server" Text="ReportName" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"></asp:Label>
                </td>

            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="tProgress" runat="server" Text="Progress" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"></asp:Label>
                </td>
            </tr>

        </table>
        <div>
        </div>
        <div>
        </div>
        <asp:Timer ID="oTimer" runat="server" Interval="1000">
        </asp:Timer>
    </form>

</body>
</html>
