<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Lab2.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Files">
            <br />
            <asp:Label ID="Label17" runat="server" Text="Pirmas failas:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Label ID="Label18" runat="server" Text="Antras failas:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" Width="217px" />
            <br />
            <asp:Label ID="Label19" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <br />
        <div class="Input">
            <asp:Label ID="Label15" runat="server" Text="Įrašykite leidinio pavadinimą"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Įrašykite mėnesio numerį [1-12]"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Atlikti" />
            <br />
            <br />
        </div>
        <div class="Tables">
            <asp:Label ID="Label3" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Rezultatų failas" />
    </form>
</body>
</html>
