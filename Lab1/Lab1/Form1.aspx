<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Lab1.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 350px">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Pradiniai duomenys:"></asp:Label>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
        </asp:Table>
        <asp:Label ID="Label2" runat="server" Text="Rezultatai:"></asp:Label>
        <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <asp:Button ID="Button1" runat="server" Text="Atlikti" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </form>
</body>
</html>
