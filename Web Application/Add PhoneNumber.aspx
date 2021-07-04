<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add PhoneNumber.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.Add_PhoneNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="PhoneNumber_Label" runat="server" style="z-index: 1; left: 10px; top: 20px; position: absolute" Text="PhoneNumber"></asp:Label>
        <asp:TextBox ID="PhoneNumber" runat="server" style="z-index: 1; left: 140px; top: 20px; position: absolute" MaxLength="20"></asp:TextBox>

        <asp:Button ID="Add_button" runat="server" Text="Add" style="z-index: 1; left: 10px; top: 65px; width:90px; position: absolute" OnClick="AddPhoneNumber" />
           <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" style="float:right;width:90px;" />
        </div>
    </form>
</body>
</html>
