<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyOffer.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.applyOffer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="offer_id_label" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute" Text="Enter offer ID: "></asp:Label>
            <asp:TextBox ID="offer_id_txt" runat="server" style="z-index: 1; left: 160px; top: 14px; position: absolute"></asp:TextBox>

            <asp:Label ID="serial_id_label" runat="server" style="z-index: 1; left: 10px; top: 50px; position: absolute" Text="Enter Product ID: "></asp:Label>
            <asp:TextBox ID="serial_id_txt" runat="server" style="z-index: 1; left: 160px; top: 49px; position: absolute"></asp:TextBox>
            
            <asp:Button ID="offer_applier_id" runat="server" style="z-index: 1; left: 40px; top: 100px; position: absolute" Text="Activate offer" OnClick ="OfferApplying" />
            <asp:Button ID="Home_redirector" runat="server" Text="Home" OnClick ="redirectToVendorHome" 
                style="z-index: 1; left: 230px; top: 100px; position: absolute" />
        </div>
    </form>
</body>
</html>
