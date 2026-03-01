<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarCategoria.aspx.cs" Inherits="MiniAppCRUD.EditarCategoria" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Editar Categoría</title>
    <link href="Content/Styles.css" rel="stylesheet" type="text/css" />
    <style>
        html, body, form { height: 100%; margin: 0; padding: 0; }
        .editar-body {
            background: linear-gradient(135deg, #1a1a1a 0%, #2c2c2c 50%, #3d2b1f 100%) !important;
            min-height: 100vh !important;
            display: flex !important;
            align-items: center !important;
            justify-content: center !important;
            padding: 30px 20px;
        }
        .editar-card {
            background: #ffffff;
            border-radius: 20px;
            padding: 40px 45px;
            width: 100%;
            max-width: 480px;
            box-shadow: 0 25px 60px rgba(0,0,0,0.4);
            border-top: 4px solid #f39c12;
        }
        .editar-header { display: flex; align-items: center; gap: 16px; margin-bottom: 30px; padding-bottom: 20px; border-bottom: 2px solid #f4f4f4; }
        .editar-header-icon { width: 48px; height: 48px; background: linear-gradient(135deg, #f39c12, #e67e22); border-radius: 12px; display: flex; align-items: center; justify-content: center; color: white; font-size: 22px; flex-shrink: 0; }
        .editar-header h2 { font-size: 22px; font-weight: 700; color: #1a1a1a; margin: 0 0 4px 0; border: none; padding: 0; }
        .editar-header p { font-size: 13px; color: #555; margin: 0; }
        .editar-field { display: flex; flex-direction: column; margin-bottom: 18px; }
        .editar-field label { font-size: 13px; font-weight: 600; color: #2c2c2c; margin-bottom: 7px; text-transform: uppercase; letter-spacing: 0.5px; }
        .editar-field input { padding: 11px 14px; border: 1.5px solid #e0e0e0; border-radius: 10px; font-size: 14px; width: 100%; box-sizing: border-box; }
        .editar-check { flex-direction: row; align-items: center; gap: 10px; margin-bottom: 25px; }
        .editar-actions { display: flex; gap: 10px; margin-top: 10px; }
        .btn-editar-guardar { flex: 1; padding: 12px; background: linear-gradient(135deg, #f39c12, #e67e22); color: white; border: none; border-radius: 10px; font-size: 14px; font-weight: 700; cursor: pointer; }
        .btn-editar-actualizar { flex: 1; padding: 12px; background: #1a1a1a; color: white; border: none; border-radius: 10px; font-size: 14px; font-weight: 700; cursor: pointer; }
        .btn-editar-cancelar { padding: 12px 20px; background: transparent; color: #555; border: 1.5px solid #ddd; border-radius: 10px; font-size: 14px; cursor: pointer; }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="height:100%;">
        <div class="editar-body">
            <div class="editar-card">
                <div class="editar-header">
                    <div class="editar-header-icon">&#9632;</div>
                    <div>
                        <h2>Categoría</h2>
                        <p>Completa los campos para guardar o actualizar</p>
                    </div>
                </div>
                <div class="editar-field">
                    <label>ID</label>
                    <asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="input-readonly"></asp:TextBox>
                </div>
                <div class="editar-field">
                    <label>Nombre de la Categoría</label>
                    <asp:TextBox ID="txtCategoria" runat="server" placeholder="Ej: Maquinaria Pesada"></asp:TextBox>
                </div>
                <div class="editar-field editar-check">
                    <asp:CheckBox ID="cbActivo" runat="server" />
                    <label>Activo</label>
                </div>
                <div class="editar-actions">
                    <asp:Button ID="btnAñadir" runat="server" Text="Guardar" OnClick="btnAñadir_Click" CssClass="btn-editar-guardar" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn-editar-actualizar" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn-editar-cancelar" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>