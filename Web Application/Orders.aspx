<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="MyOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" OnClick ="BackToHome" Text="Home" />
            <asp:Button ID="Button1" runat="server" Text="Make Order" OnClick ="MakeOrder" style="margin-left: 27px" />

            <asp:Button ID="AddCreditCard" runat="server" OnClick="Button_Click" Text="Add Credit card to existing order" style="margin-left: 25px" />

            <br />

            <br />
            
                        <asp:Label ID="Label1" runat="server" Text="Pay partially or fully using cash"></asp:Label>
           
            /credit<br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Please enter the amount you want to pay and then press the pay button next to the corresponding order"></asp:Label>
            <br />
            <br />
            
            <asp:Label ID="Label2" runat="server" Text="Amount: "></asp:Label><asp:TextBox ID="Amount" runat="server" maxlength="13" style="margin-left: 37px"></asp:TextBox>

            <br />

            <br />
            <asp:Label ID="Label3" runat="server" Text="Payment method: "></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-left: 53px">
                <asp:ListItem>Cash</asp:ListItem>
                <asp:ListItem>Credit </asp:ListItem>
            </asp:DropDownList>
          
            <br />
            <br />
        </div>
    </form>
</body>
</html>
