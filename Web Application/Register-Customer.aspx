<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register-Customer.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="FirstName_Label" runat="server" style="z-index: 1; left: 10px; top: 10px; position: absolute" Text="FirstName"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" style="z-index: 1; left: 104px; top: 10px; position: absolute"></asp:TextBox>
       
        <asp:Label ID="LastName_Label" runat="server" style="z-index: 1; left: 10px; top: 55px; position: absolute" Text="LastName"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" style="z-index: 1; left: 104px; top: 55px; position: absolute" ></asp:TextBox>
        
        <asp:Label ID="Username_Label" runat="server" style="z-index: 1; left: 10px; top: 107px; position: absolute" Text="Username"></asp:Label>
        <asp:TextBox ID="Username" runat="server" style="z-index: 1; left: 104px; top: 104px; position: absolute; right: 1164px;"></asp:TextBox>
        
        <asp:Label ID="Password_Label" runat="server" style="z-index: 1; left: 10px; top: 157px; position: absolute" Text="Password"></asp:Label>
        <asp:TextBox ID="Password" TextMode="Password" runat="server" style="z-index: 1; left: 104px; top: 152px; position: absolute"></asp:TextBox>
 
        <asp:TextBox ID="Email" runat="server" style="z-index: 1; left: 104px; top: 211px; position: absolute"></asp:TextBox>
        <asp:Label ID="Email_Label" runat="server" style="z-index: 1; left: 10px; top: 213px; position: absolute" Text="Email"></asp:Label>
       
        <asp:Button ID="Register_Button" runat="server" Text="Register" style="z-index: 1; left: 10px; top: 253px; width:90px; position: absolute" OnClick ="Registration" />



            </div>

    </form>
</body>
</html>
