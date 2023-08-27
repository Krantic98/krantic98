<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataOfMovies._Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>MovieFlowTracker</title>
    
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<style>
    body{
        background:url(https://d1nhio0ox7pgb.cloudfront.net/_img/g_collection_png/standard/256x256/film.png);
        background-size: 1500px;
    }

    .white-bg {
        background-color: white;
    }
    .container-fluid{
        background-color:#1a8cff;
    }
    .LiteralNumResults{
        margin-left:30%;
        color:white;
    }
</style>
<body id="body">
    <div class="container-fluid">
        <img src="">
        <h1 style="color:white">MovieFlowTracker</h1>
    </div>  <br /><br />
    <form id="form1" runat="server">
        <div class="row justify-content-center">
            <div class="col-md-3">
                <h2 style="color:white">Reporting of Movies</h2>
                <div class="form-group">
                    <label for="StartYearTextBox" style="color:white">Enter Start Year:</label>
                    <asp:TextBox ID="StartYearTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="EndYearTextBox" style="color:white">Enter End Year:</label>
                    <asp:TextBox ID="EndYearTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="BroadcastTextBox" style="color:white">Enter Broadcast Value:</label>
                    <asp:TextBox ID="BroadcastTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnPrikazi" runat="server" Text="Show" class="btn btn-primary" OnClick="btnPrikazi_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-primary" OnClick="btnClear_Click" />
                    <asp:Button ID="ExportToExcel" runat="server" Text="Export " OnClick="ExportToExcel_Click" class="btn btn-primary" />
                </div>
                <br />
                <br />
                <asp:Label ID="LiteralNumResults" runat="server" CssClass="LiteralNumResults"></asp:Label>
                <br /><br />
            </div>
        </div>
    </form>
    
     <asp:Repeater ID="rptFilmovi" runat="server">
    <HeaderTemplate>
        <div class="table-responsive">
            <table class="table table-striped table-bordered">
                <tr style="background-color:	 #00001a;color:white">
                    <th>ID</th>
                    <th>Name</th>
                    <th>Year</th>
                    <th>Genre</th>
                    <th>Director</th>
                       <th>Broadcast</th>
                </tr>
    </HeaderTemplate>
 <ItemTemplate>
    <tr>
        <td class="white-bg"><asp:Label runat="server" Text='<%# Eval("ID") %>' /></td>
        <td class="white-bg"><asp:Label runat="server" Text='<%# Eval("Name") %>' /></td>
        <td class="white-bg"><asp:Label runat="server" Text='<%# Eval("Year") %>' /></td>
        <td class="white-bg"><asp:Label runat="server" Text='<%# Eval("Genre") %>' /></td>
        <td class="white-bg"><asp:Label runat="server" Text='<%# Eval("Director") %>' /></td>
        <td class="white-bg"><asp:Label runat="server" Text='<%# Eval("Broadcast") %>' /></td>
    </tr>
</ItemTemplate>


    <FooterTemplate>
        </table>
        </div>
    </FooterTemplate>
</asp:Repeater>

</body>
</html>
