<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkandremoveExpiredoffer.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.checkandremoveExpiredoffer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="offer_id_label" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute" Text="Enter offer ID: "></asp:Label>

            <asp:TextBox ID="offer_id_txt" runat="server" style="z-index: 1; left: 150px; top: 14px; position: absolute"></asp:TextBox>

            <asp:Button ID="offer_checker_id" runat="server" style="z-index: 1; left: 10px; top: 60px; position: absolute" Text="Check and Remove" OnClick ="OfferChecking" />
            <asp:Button ID="Home_redirector" runat="server" Text="Home" OnClick ="redirectToVendorHome" 
                style="z-index: 1; left: 250px; top: 60px; position: absolute" />
        </div>
    </form>
</body>
</html>
