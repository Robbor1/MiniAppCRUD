<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="MiniAppCRUD.EditarProducto" %>

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

            <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Precio: "></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>

            <asp:Label ID="Label4" runat="server" Text="Categoria: "></asp:Label>
            <asp:DropDownList ID="dropdownCategoria" runat="server"></asp:DropDownList>

            <asp:Label ID="Label5" runat="server" Text="Fecha Registro: "></asp:Label>
            <asp:Calendar ID="fchRegistro" runat="server"></asp:Calendar>

            <asp:Label ID="lblActivo" runat="server" Text="Activo: "></asp:Label>
            <asp:CheckBox ID="cbActivo" runat="server" />


            <asp:Button ID="btnAñadir" runat="server" Text="Añadir" OnClick="btnAñadir_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

        </div>
    </form>
</body>
</html>
