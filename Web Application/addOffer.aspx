<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addOffer.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.addOffer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Offer_Amount_label" runat="server" style="z-index: 1; left: 10px; top: 10px; 
            position: absolute" Text="Offer amount: "></asp:Label>
            <asp:TextBox ID="Offer_Amount_txt" runat="server" style="z-index: 1; left: 160px; top: 10px; 
            position: absolute"></asp:TextBox>
            <asp:Label ID="Expiry_date_label" runat="server" style="z-index: 1; left: 10px; top: 55px; 
            position: absolute" Text="Expires on: "></asp:Label>
            <asp:TextBox ID="Expiry_date_txt" runat="server" style="z-index: 1; left: 160px; top: 55px; 
            position: absolute" ></asp:TextBox>
            <asp:Button ID="Add_item_button" runat="server" Text="Add offer" OnClick ="OfferAdding" 
                style="z-index: 1; left: 10px; top: 100px; position: absolute" />
            <asp:Button ID="Home_redirector" runat="server" Text="Home" OnClick ="redirectToVendorHome" 
                style="z-index: 1; left: 200px; top: 100px; position: absolute" />
        </div>
    </form>
</body>
</html>
