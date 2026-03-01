<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MiniAppCRUD.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Login — Exploraciones Mineras del Desierto</title>
    <link href="/Content/Styles.css" rel="stylesheet" type="text/css" />
    <style>
        html, body, form { margin: 0; padding: 0; height: 100%; }

        .login-body {
            min-height: 100vh;
            display: flex !important;
            align-items: center !important;
            justify-content: center !important;
            background: #ffffff;
            position: relative;
            overflow: hidden;
        }

        /* Círculos animados de fondo */
        .login-body::before,
        .login-body::after {
            content: '';
            position: fixed;
            border-radius: 50%;
            opacity: 0.12;
            animation: flotar 8s ease-in-out infinite;
        }

        .login-body::before {
            width: 600px;
            height: 600px;
            background: radial-gradient(circle, #f39c12, #e67e22);
            top: -200px;
            right: -150px;
            animation-delay: 0s;
        }

        .login-body::after {
            width: 400px;
            height: 400px;
            background: radial-gradient(circle, #c0392b, #7d5a3c);
            bottom: -100px;
            left: -100px;
            animation-delay: 4s;
        }

        @keyframes flotar {
            0%, 100% { transform: translateY(0px) scale(1); }
            50% { transform: translateY(-30px) scale(1.05); }
        }

        /* Burbujas extra */
        .burbuja {
            position: fixed;
            border-radius: 50%;
            opacity: 0.07;
            animation: flotar 10s ease-in-out infinite;
        }

        .b1 { width: 300px; height: 300px; background: #f39c12; top: 40%; left: -80px; animation-delay: 2s; }
        .b2 { width: 200px; height: 200px; background: #c0392b; top: 10%; right: 20%; animation-delay: 6s; }
        .b3 { width: 150px; height: 150px; background: #7d5a3c; bottom: 20%; right: -40px; animation-delay: 1s; }

        /* Tarjeta */
        .login-wrapper {
            position: relative;
            z-index: 10;
            width: 100%;
            max-width: 420px;
            padding: 20px;
        }

        .login-card {
            background: #ffffff;
            border-radius: 24px;
            padding: 45px 40px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.12), 0 0 0 1px rgba(243,156,18,0.15);
            border: none;
        }

        .login-logo {
            display: block;
            margin: 0 auto 20px auto;
            width: 110px;
            height: auto;
        }

        .login-empresa {
            text-align: center;
            font-size: 13px;
            font-weight: 600;
            color: #7d5a3c;
            letter-spacing: 1px;
            text-transform: uppercase;
            margin-bottom: 6px;
        }

        .login-titulo {
            text-align: center;
            font-size: 24px;
            font-weight: 800;
            color: #1a1a1a;
            margin-bottom: 30px;
            border: none;
            padding: 0;
        }

        .login-divider {
            width: 40px;
            height: 3px;
            background: linear-gradient(to right, #f39c12, #e67e22);
            border-radius: 2px;
            margin: 0 auto 28px auto;
        }

        .form-group {
            margin-bottom: 18px;
        }

        .form-group label {
            display: block;
            font-size: 12px;
            font-weight: 700;
            color: #555;
            margin-bottom: 7px;
            text-transform: uppercase;
            letter-spacing: 0.8px;
        }

        .form-group input[type="text"],
        .form-group input[type="password"] {
            width: 100%;
            display: block;
            padding: 13px 16px;
            border: 1.5px solid #e8e8e8;
            border-radius: 12px;
            font-size: 15px;
            color: #1a1a1a;
            outline: none;
            transition: border-color 0.2s, box-shadow 0.2s;
            box-sizing: border-box;
            background: #fafafa;
        }

        .form-group input[type="text"]:focus,
        .form-group input[type="password"]:focus {
            border-color: #f39c12;
            box-shadow: 0 0 0 3px rgba(243,156,18,0.12);
            background: #fff;
        }

        .btn-login {
            width: 100%;
            padding: 14px;
            background: linear-gradient(135deg, #f39c12, #e67e22);
            color: #fff;
            border: none;
            border-radius: 12px;
            font-size: 15px;
            font-weight: 700;
            cursor: pointer;
            margin-top: 10px;
            transition: opacity 0.2s, transform 0.1s;
            letter-spacing: 0.5px;
            box-shadow: 0 4px 15px rgba(243,156,18,0.35);
        }

        .btn-login:hover {
            opacity: 0.92;
            transform: translateY(-1px);
        }

        .btn-login:active {
            transform: translateY(0);
        }

        .login-footer {
            text-align: center;
            margin-top: 20px;
            font-size: 12px;
            color: #aaa;
        }
    </style>
</head>
<body>
    <!-- Burbujas de fondo -->
    <div class="burbuja b1"></div>
    <div class="burbuja b2"></div>
    <div class="burbuja b3"></div>

    <form id="form1" runat="server" style="height:100%;">
        <div class="login-body">
            <div class="login-wrapper">
                <div class="login-card">
                    <img src="/Images/logoEMD.png" alt="Logo EMD" class="login-logo" />
                    <p class="login-empresa">Exploraciones Mineras del Desierto</p>
                    <h2 class="login-titulo">Iniciar Sesión</h2>
                    <div class="login-divider"></div>
                    <div class="form-group">
                        <label>Usuario</label>
                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Ingresa tu usuario"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn-login" />
                    <p class="login-footer">&copy; 2026 Exploraciones Mineras del Desierto</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>