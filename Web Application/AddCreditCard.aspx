<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCreditCard.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.AddCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="CardCard_Label" runat="server" style="z-index: 1; left: 10px; top: 20px; position: absolute" Text="Credit Card Number"></asp:Label>
        <asp:TextBox ID="CreditCard" MaxLength="20" runat="server" style="z-index: 1; left: 160px; top: 20px; position: absolute"></asp:TextBox>

        <asp:Label ID="CVV_Label" runat="server" style="z-index: 1; left: 10px; top: 60px; position: absolute" Text="CVV"></asp:Label>
        <asp:TextBox ID="CVV" MaxLength="4" runat="server" style="z-index: 1; left: 160px; top: 60px; position: absolute"></asp:TextBox>

        <asp:Label ID="Date_Label" runat="server" style="z-index: 1; left: 10px; top: 100px; position: absolute" Text="Expiry Date"></asp:Label>
        <input type ="text" ID="date"  runat="server" style="z-index: 1; left: 160px; top: 100px; position: absolute" />
      
            <asp:Button ID="Add_button" runat="server" Text="Add" style="z-index: 1; left: 10px; top: 140px; width:90px; position: absolute" OnClick="AddCard" />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" style="float:right;width:90px;" />
    </form> 
</body>
</html>
