<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MiniAppCRUD.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Usuario:"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Ingresa usuario"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Ingresa contraseña"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click"/>
        </div>
    </form>
</body>
</html>
