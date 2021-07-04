<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            z-index: 1;
            left: 10px;
            top: 253px;
            width: 137px;
            position: absolute;
        }
        .auto-style3 {
            z-index: 1;
            left: 200px;
            top: 105px;
            position: absolute;
            width: 850px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Product_name_label" runat="server" style="z-index: 1; left: 10px; top: 10px; position: absolute" Text="Product name: "></asp:Label>
        <asp:TextBox ID="Product_name" runat="server" style="z-index: 1; left: 200px; top: 10px; position: absolute"></asp:TextBox>
       
        <asp:Label ID="Category_label" runat="server" style="z-index: 1; left: 10px; top: 55px; position: absolute" Text="Category: "></asp:Label>
        <asp:TextBox ID="Category" runat="server" style="z-index: 1; left: 200px; top: 55px; position: absolute" ></asp:TextBox>
        
        <asp:Label ID="Product_description_label" runat="server" style="z-index: 1; left: 10px; top: 107px; position: absolute" Text="Product description: "></asp:Label>
        <asp:TextBox ID="Product_description" runat="server" CssClass="auto-style3"></asp:TextBox>
        
        <asp:Label ID="Price_label" runat="server" style="z-index: 1; left: 10px; top: 157px; position: absolute" Text="Price: "></asp:Label>
        <asp:TextBox ID="Price" runat="server" style="z-index: 1; left: 200px; top: 152px; position: absolute"></asp:TextBox>
 
        <asp:Label ID="Color_label" runat="server" style="z-index: 1; left: 10px; top: 200px; position: absolute" Text="Color: "></asp:Label>
        <asp:TextBox ID="Color" runat="server" style="z-index: 1; left: 200px; top: 200px; position: absolute"></asp:TextBox>
       
        <asp:Button ID="Change_item_button" runat="server" Text="Apply Changes" OnClick ="ProductEditing" CssClass="auto-style2" />
        <asp:Button ID="Home_redirector" runat="server" Text="Home" OnClick ="redirectToVendorHome" 
                style="z-index: 1; left: 200px; top: 252px; position: absolute" />
        </div>
    </form>
</body>
</html>
