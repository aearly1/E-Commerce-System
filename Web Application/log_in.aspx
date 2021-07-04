<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log_in.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.log_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Username_Label" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Password_Label" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
    
        <br />

        <asp:Button ID="Login_Button" runat="server" Text="Login" onclick="Login" Width="90px"/>
    
    </div>
    </form>
</body>
</html>
