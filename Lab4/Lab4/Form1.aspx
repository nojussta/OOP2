<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Lab4.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Tables">
            <asp:Label ID="Label1" runat="server" Text="Duomenys apie studentus"></asp:Label>
            <br />
            <asp:TextBox ID="ResultBox" runat="server" Height="200px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Užduočių rezultatai"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Height="200px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            <br />
            <br />
        </div>
        <div class="Button">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Atlikti" />
        </div>
    </form>
</body>
</html>
