<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExcursionReport.aspx.vb" Inherits="MactusReportWeb.ExcursionReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Generate Excursion Report" Font-Size="XX-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
        </div>
        <div style="text-align: center; padding-top: 30px; margin-top: 30px; display: none">
            <asp:Label ID="Label4" runat="server" Text="Select Report Group" Font-Size="X-Large"></asp:Label>
            <asp:DropDownList ID="cReportGroup" runat="server" Font-Size="X-Large" Width="45%" ViewStateMode="Enabled" AutoPostBack="True" DataTextField="GroupName" DataValueField="GroupID"></asp:DropDownList>
        </div>
        <div>

            <div class="row col-md-12 text-center p-3">
                <div class="col-md-2">

                </div>
                <div class="col-md-8">
                    <asp:Label ID="Label2" runat="server" Text="Select Report To Be Generated" Font-Size="X-Large"></asp:Label>
                <asp:DropDownList ID="oCombo" CssClass="col-md-8" runat="server" Font-Size="X-Large"
                    AppendDataBoundItems="True" DataTextField="ReportName" DataValueField="ID">
                </asp:DropDownList>
                </div>
                
            </div>
            <div class="row col-md-12 text-center p-3">
                <div class="col-md-1">

                </div>
                <div class=" col-md-4">
                    <asp:Label ID="Label6" runat="server" Text="From Date Time" Font-Size="X-Large"></asp:Label>
                     <asp:TextBox ID="tFromDate" CssClass="col-md-12" runat="server" Font-Size="X-Large"
                         BorderStyle="Solid" TextMode="DateTime" style="float:right" ></asp:TextBox>
                </div>
                <div class=" col-md-1">

                </div>
                <div class=" col-md-4">
                    <asp:Label ID="Label7" runat="server" Text="To Date Time" Font-Size="X-Large"></asp:Label>
                     <asp:TextBox ID="tToDate" runat="server"  CssClass="col-md-12" Font-Size="X-Large" BorderStyle="Solid" TextMode="DateTime" ></asp:TextBox>
                </div>
                <div class="col-md-1">

                </div>
            </div>
            
        </div>

        <div style="text-align: center">
            <asp:Button ID="bGenerateReport" runat="server" Text="Generate Report" BorderColor="Black" BorderStyle="Solid" BackColor="#3399FF" Font-Bold="True" Font-Size="XX-Large" />
        </div>



        <div>
        </div>
    </form>
</body>
</html>
