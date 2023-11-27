﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EventReport.aspx.vb" Inherits="MactusReportWeb.EventReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Generate Event Report" Font-Size="XX-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
        </div>
        <div>
            <table style="width: 100%; text-align: center; padding: 10px; margin: 10px;">
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
                        <asp:TextBox ID="tFromDate" runat="server" Font-Size="X-Large" BorderStyle="Solid" TextMode="DateTime" Width="70%" ViewStateMode="Enabled"></asp:TextBox></td>
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
            <div style="margin:20px">
             <div style="margin:20px;font-size:30px;font-weight:600">Pending Reports</div>
                <asp:Table runat="server"
                    CellPadding="10"
                    GridLines="Both" ID="StatusTable">
         <asp:TableHeaderRow id="StatusHeaderRow" 
            BackColor="LightBlue"
            runat="server">
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Report Header" />
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Report Title" />
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="From Date" />
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="To Date" />
            <asp:TableHeaderCell  
                Scope="Column" 
                Text="User" />
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Progress" />
            <asp:TableHeaderCell 
                Scope="Column" 
                Text="Status" />
        </asp:TableHeaderRow>  
    </asp:Table>
         </div>

    </form>
</body>
</html>
