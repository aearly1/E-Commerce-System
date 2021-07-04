<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register-Vendor.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.Register_Vendor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendor Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="FirstName_Label" runat="server" style="z-index: 1; left: 10px; top: 10px; position: absolute" Text="FirstName"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" style="z-index: 1; left: 140px; top: 10px; position: absolute"></asp:TextBox>
       
        <asp:Label ID="LastName_Label" runat="server" style="z-index: 1; left: 10px; top: 55px; position: absolute" Text="LastName"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" style="z-index: 1; left: 140px; top: 55px; position: absolute"></asp:TextBox>
        
        <asp:Label ID="Username_Label" runat="server" style="z-index: 1; left: 10px; top: 107px; position: absolute" Text="Username"></asp:Label>
        <asp:TextBox ID="Username" runat="server" style="z-index: 1; left: 140px; top: 104px; position: absolute; right: 1164px;"></asp:TextBox>
        
        <asp:Label ID="Password_Label" runat="server" style="z-index: 1; left: 10px; top: 157px; position: absolute" Text="Password"></asp:Label>
        <asp:TextBox ID="Password" type="password" runat="server" style="z-index: 1; left: 140px; top: 152px; position: absolute" TextMode="Password" ></asp:TextBox>
 
        <asp:TextBox ID="Email" runat="server" style="z-index: 1; left: 140px; top: 195px; position: absolute"></asp:TextBox>
        <asp:Label ID="Email_Label" runat="server" style="z-index: 1; left: 10px; top:195px; position: absolute" Text="Email"></asp:Label>

        <asp:TextBox ID="Company" runat="server" style="z-index: 1; left: 140px; top: 245px; position: absolute"></asp:TextBox>
        <asp:Label ID="Company_Label" runat="server" style="z-index: 1; left: 10px; top: 245px; position: absolute" Text="Company"></asp:Label>

        <asp:TextBox ID="Bank" runat="server" style="z-index: 1; left: 140px; top: 295px; position: absolute"></asp:TextBox>
        <asp:Label ID="Bank_Label" runat="server" style="z-index: 1; left: 10px; top: 295px; position: absolute" Text="Bank Account"></asp:Label>
       
        <asp:Button ID="Register_Button" runat="server" Text="Register" style="z-index: 1; left: 10px; top: 340px; width:90px; position: absolute" onclick="Registration"/>


        </div>    

    </form>
</body>
</html>
