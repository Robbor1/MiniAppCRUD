<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarCategoria.aspx.cs" Inherits="MiniAppCRUD.EditarCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblId" runat="server" Text="Id: "></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>

            <asp:Label ID="lblCategoria" runat="server" Text="Categoria: "></asp:Label>
            <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>

            <asp:Label ID="lblActivo" runat="server" Text="Activo: "></asp:Label>
            <asp:CheckBox ID="cbActivo" runat="server" />

            <asp:Button ID="btnAñadir" runat="server" Text="Añadir" OnClick="btnAñadir_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

        </div>
    </form>
</body>
</html>
