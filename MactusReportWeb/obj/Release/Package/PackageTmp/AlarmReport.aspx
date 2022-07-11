<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AlarmReport.aspx.vb" Inherits="MactusReportWeb.AlarmReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Generate Alarm Report" Font-Size="XX-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
        </div>
        <div>
            <table style="width: 100%; text-align: center; padding: 10px; margin: 10px;">
                <tr>
                    <td style="text-align:right;width:50%">
                        <asp:Label ID="Label2" runat="server" Text="Select Report To Be Generated" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td style="text-align:left">
                        <asp:DropDownList ID="oCombo" runat="server" Font-Size="X-Large" AppendDataBoundItems="True" DataTextField="ReportName" DataValueField="ID" Width="80%"></asp:DropDownList>                     
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="From Date Time" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="To Date Time" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="text-align: center">
                        <asp:TextBox ID="tFromDate" runat="server" Font-Size="X-Large" BorderStyle="Solid" TextMode="DateTime" Width="70%"></asp:TextBox></td>
                    <td style="text-align: center">

                        <asp:TextBox ID="tToDate" runat="server" Font-Size="X-Large" BorderStyle="Solid" TextMode="DateTime" Width="70%"></asp:TextBox></td>
                    <td style="text-align: center"></td>
                </tr>
            </table>
        </div>

        <div style="text-align: center">
            <asp:Button ID="bGenerateReport" runat="server" Text="Generate Report" BorderColor="Black" BorderStyle="Solid" BackColor="#3399FF" Font-Bold="True" Font-Size="XX-Large" />
        </div>
        <div>
        </div>
    </form>
</body>
</html>
