<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Credit_Card.aspx.cs" Inherits="Add_Credit_Card" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" OnClick="ordersPage" Text="Back to orders page" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Add Creditcard to Order"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Credit Card"></asp:Label>
            <asp:TextBox ID="Creditcard_Text" runat="server" style="margin-left: 20px" maxlength="20"></asp:TextBox>
             <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Order no."></asp:Label>
            <asp:TextBox ID="Order_Text" runat="server" style="margin-left: 32px" Width="122px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Submitt" Text="Submitt" />
            <br />
            <br />
        </div>
        
    </form>
</body>
</html>
