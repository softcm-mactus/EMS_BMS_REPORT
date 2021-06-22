<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="MactusReportWeb.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mactus EMS Reporting Tool
    </title>
</head>
<body>
    <form id="MainForm" runat="server">

        <table style="width: 80%; text-align: center; justify-self: center;padding-top:20px;padding-bottom:10px;">
            <tr style="width: 80%">

                <td style="text-align: center">
                    <asp:Button ID="bDataReports" runat="server" Text="Generate Data Trend Reports" Font-Size="X-Large" />
                </td>

            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="bEventReport" runat="server" Text="Generate Event Report" Font-Size="X-Large" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="bAlarmReports" runat="server" Text="Generate Alarm Reports" Font-Size="X-Large" />
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
