<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add a Phone number" style=" margin-left: 23px;" Width="262px" />

       
        <p>
             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add a Credit Card" style=" margin-left: 23px;" Width="262px" />
             </p>
        <p>
             <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="View Products" style="margin-left: 23px" Height="33px" Width="262px" />
             </p>
        <p>
             <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Add a wishlist" style=" margin-left: 23px;" Width="261px" />
             </p>
        <p>
             <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Remove an item from the cart" style=" margin-left: 23px;" Width="262px" />
             </p>
        <p>
             <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Remove an item from a wishlist" style=" margin-left: 23px;" Width="262px" />

        </p>
        <p>
           <asp:Button ID="Button7" runat="server" Text="My Orders" OnClick="Orders" style="margin-left: 25px" Width="260px" />
        </p>
     </div>
            
            </form>
</body>
</html>
