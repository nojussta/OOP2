<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Lab5.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="InitialData">
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nurodykite poziciją:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nurodykite periodą(data nuo iki, pvz. 2022-01-01):"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Įveskite sąrašo kiekį:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
&nbsp;<br />
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Atrinkti krepšininkus" Width="145px" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Atrinkti naudingiausius" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Išvalyti" />
            <br />
        </div>
    </form>
</body>
</html>
