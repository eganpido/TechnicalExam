<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ClientInformation.aspx.vb" Inherits="TestProject.ClientInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle4 {
            border-style: solid;
        }
    </style>
    <h1>TECHNICAL EXAM</h1>
</head>
<body>
    <form id="form1" runat="server">  
        <asp:Label ID="Label1" runat="server" Text="Name :"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" style="margin-left: 63px" Width="207px" CssClass="newStyle4"></asp:TextBox>
        <br>
        <br>
        <asp:Label ID="Label2" runat="server" Text="Phone Number :"></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server" style="margin-left: 6px" Width="207px" CssClass="newStyle4"></asp:TextBox>
        <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 6px" Width="295px" BorderStyle="Ridge" />
        <asp:Button ID="Button3" runat="server" Text="Import CSV" style="margin-left: 6px" Width="115px" CssClass="newStyle4" Height="22px"/>
        <br>
        <br>
        <asp:Label ID="Label3" runat="server" Text="City :"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server" style="margin-left: 74px; margin-top: 0px;" Width="207px" CssClass="newStyle4"></asp:TextBox>
        <br>
        <br>
        <asp:Label ID="Label4" runat="server" Text="Date :"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server" style="margin-left: 71px" Width="207px" CssClass="newStyle4"></asp:TextBox>
        <br>
        <br>
        <asp:Button ID="Button1" runat="server" Text="View Data" Height="33px" style="text-align: center; margin-left: 3px; margin-top: 20px" Width="257px" />
        <asp:Button ID="Button2" runat="server" Text="Insert Data" Height="33px" style="text-align: center; margin-left: 3px; margin-top: 20px" Width="257px" />
        <asp:GridView ID="grdViewClient" runat="server" Height="229px" style="text-align: center; margin-top: 23px" Width="906px">
        </asp:GridView>
    </form>
</body>
</html>
