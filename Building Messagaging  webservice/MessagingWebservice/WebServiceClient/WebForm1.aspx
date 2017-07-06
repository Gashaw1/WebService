<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebServiceClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Button" />
                <asp:TextBox ID="txtSenderID" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtReciverID" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
