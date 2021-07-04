<%@ Page Language="C#" AutoEventWireup="true" CodeFile="answerQuestions.aspx.cs" Inherits="Mashroo3Qa3edetTa5zeenMa3loomat.answerQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            left: 100px;
            top: 10px;
            position: absolute;
            width: 604px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Answer_label" runat="server" style="z-index: 1; left: 10px; top: 10px; 
            position: absolute" Text="Answer: "></asp:Label>
            <asp:TextBox ID="Answer_txt" runat="server" CssClass="auto-style1"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 10px; top: 50px; 
            position: absolute" Text="Upload answer" Width="117px" OnClick ="QuestionAnswering" />
        </div>
    </form>
</body>
</html>
