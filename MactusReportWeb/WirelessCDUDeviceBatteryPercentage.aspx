<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WirelessCDUDeviceBatteryPercentage.aspx.vb" Inherits="MactusReportWeb.WirelessCDUDeviceBatteryPercentage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Generate Battery Percentage Report" Font-Size="XX-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
        </div>
        <div style="text-align: center;padding-top: 30px; margin-top: 30px;">
            <asp:Label ID="Label4" runat="server" Text="Select Report Group" Font-Size="X-Large"></asp:Label>
            <asp:DropDownList ID="cReportGroup" runat="server" Font-Size="X-Large" Width="45%" ViewStateMode="Enabled" AutoPostBack="True" DataTextField="GroupName" DataValueField="GroupID"></asp:DropDownList>
        </div>
        <div>
            <table style="width: 100%; text-align: center; padding: 10px; margin: 10px;">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Select Report To Be Generated" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Time Interval (in Min)" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="oCombo" runat="server" Font-Size="X-Large" AppendDataBoundItems="True" DataTextField="ReportName" DataValueField="ID" Width="80%"></asp:DropDownList>

                    </td>
                    <td>
                        <asp:DropDownList ID="cTimeInterval" runat="server" Font-Size="X-Large" Width="70%">
                          
                            <asp:ListItem>60</asp:ListItem>
                            <asp:ListItem>120</asp:ListItem>
                            <asp:ListItem>180</asp:ListItem>
                            <asp:ListItem>240</asp:ListItem>                           
                        </asp:DropDownList>
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
    </form>
</body>
</html>
