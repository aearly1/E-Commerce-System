<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWishList.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.Add_WishList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="WishList_Label" runat="server" style="z-index: 1; left: 10px; top: 20px; position: absolute" Text="WishList"></asp:Label>
        <asp:TextBox ID="WishList" runat="server" style="z-index: 1; left: 140px; top: 20px; position: absolute" maxlength="20"></asp:TextBox>

        <asp:Button ID="Add_button" runat="server" Text="Add" style="z-index: 1; left: 10px; top: 65px; width:90px; position: absolute" onclick="AddWishList" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" style="float:right;width:90px;" />
        </div>
    </form>
</body>
</html>
