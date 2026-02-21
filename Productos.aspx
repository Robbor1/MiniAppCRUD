<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="MiniAppCRUD.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Ej: producto1"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Precio: "></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" placeholder="Ej: $100.00"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="txtStock" runat="server" placeholder="Ej: 100"></asp:TextBox>

            <asp:Label ID="Label4" runat="server" Text="Categoria: "></asp:Label>
            <asp:DropDownList ID="dropdownCategoria" runat="server"></asp:DropDownList>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Añadir" OnClick="btnGuardar_Click" />


            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" OnRowCommand="gvProductos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:BoundField DataField="NombreCategoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="FechaRegistro" HeaderText="FechaRegistro" />
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("Activo")) ? "Activo" : "Inactivo" %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnActualizar" runat="server" Text="Editar" CommandName="Actualizar" CommandArgument='<%# Eval("IdProducto") %>' />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </main>
</asp:Content>
