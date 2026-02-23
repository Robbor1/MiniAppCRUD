<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MiniAppCRUD.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Login</title>
    <link href="Content/Styles.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-body">
    <form id="form1" runat="server">
        <div class="login-card">
            <h2>Login</h2>
            <div class="form-group">
                <label>Usuario</label>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Ingresa usuario"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Ingresa contraseña"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn-login" />
        </div>
    </form>
</body>
</html>