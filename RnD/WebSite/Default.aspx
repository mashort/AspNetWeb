﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Home of RnD Website</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblIntro" runat="server" Text="Introductory stuff"></asp:Label>

        <asp:Panel ID="pnlName" runat="server" Visible="false">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
        </asp:Panel>
    </div>
    </form>
</body>
</html>