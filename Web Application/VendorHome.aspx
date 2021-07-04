<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VendorHome.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.VendorHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Welcome_Message" runat="server" style="z-index: 1; left: 10px; top: 10px; position: absolute" Text="Welcome!"></asp:Label>
            <asp:Button ID="Add_item_redirector" runat="server" Text="Post a new product" OnClick ="redirectToPostProduct" 
            style="z-index: 1; left: 10px; top: 50px; position: absolute" />
            <asp:Button ID="View_products_redirector" runat="server" Text="View my products" OnClick ="redirectToVendorViewProducts" 
            style="z-index: 1; left: 300px; top: 50px; position: absolute" />
            <asp:Button ID="View_questions_redirector" runat="server" Text="View questions" OnClick ="redirectToViewQuestions" 
            style="z-index: 1; left: 600px; top: 50px; position: absolute" />
            <asp:Button ID="Add_offer_redirector" runat="server" Text="Create an offer" OnClick ="redirectToAddOffer" 
            style="z-index: 1; left: 10px; top: 100px; position: absolute" />
            <asp:Button ID="Check_and_remove_redirector" runat="server" Text="Check and remove expired offer" OnClick ="redirectToCheckAndRemove" 
            style="z-index: 1; left: 210px; top: 100px; position: absolute" />
            <asp:Button ID="Apply_offer_id" runat="server" Text="Activate Offer" OnClick ="redirectToofferApplying" 
            style="z-index: 1; left: 615px; top: 100px; position: absolute" />
        </div>
    </form>
</body>
</html>
