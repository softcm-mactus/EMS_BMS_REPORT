<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="MactusReportWeb.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mactus EMS Reporting Tool
    </title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />



</head>
<body class=" ">
    <div class="container text-center">
        <h1>
            <asp:Label ID="lblReportName" runat="server"></asp:Label></h1>

    </div>
    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                </ul>
            </div>
        </div>
    </nav>
    <form id="MainForm" class="col-md-12 text-center" runat="server">
        <div class="container">
            <div class="row">

                <div class="col-md-6">
                    <asp:Button ID="bDataReports" runat="server" Style="min-width: 450px"
                        Text="Generate Data Trend Reports" CssClass="btn btn-success" Font-Size="X-Large" />
                    <br />
                    <br />

                    <asp:Button ID="bEventReport" runat="server" Style="min-width: 450px"
                        CssClass="btn btn-info" Text="Generate Event Report" Font-Size="X-Large" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="bAlarmReports" runat="server" Style="min-width: 450px"
                        CssClass="btn  btn-warning" Text="Generate Alarm Reports" Font-Size="X-Large" />
                    <asp:Button ID="btnTrendDataAlarmReport" OnClick="btnTrendDataAlarmReport_Click" runat="server" Style="min-width: 450px; display:none"
                        Text="Generate Alarm Reports" CssClass="btn btn-warning" Font-Size="X-Large" />
                    <br />
                    <br />
                    <asp:Button ID="btnCDUDeviceBateeryStatus" OnClick="btnCDUDeviceBateeryStatus_Click" runat="server" Style="min-width: 450px;display:none"
                        Text="Generate Battery Percentage" CssClass="btn btn-light " Font-Size="X-Large" />
                    <br />
                    <br />

                    <asp:Button ID="btnExcursionReport" OnClick="btnExcursionReport_Click" runat="server" Style="min-width: 450px; color: white; display: none"
                        CssClass="btn  btn-danger" Text="Generate Excursion Report" Font-Size="X-Large" />
                </div>
                <div class="col-md-6">
                    
                </div>
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
            <br />

            <%-- <div class="row">
                <div class="col-md-6">
                   
                </div>
            </div>--%>
        </div>


    </form>


</body>
</html>
