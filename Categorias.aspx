<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="MiniAppCRUD.Categorias" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <div>
            
            <asp:Label ID="lblCategoria" runat="server" Text="Label">Categoria: </asp:Label>
            <asp:TextBox ID="txtCategoria" runat="server" placeholder="Ej: maquinaria"></asp:TextBox>

            <asp:Button ID="btnGuardar" runat="server" Text="Añadir" OnClick="btnGuardar_Click" />

            <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCategorias_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdCategoria" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnActualizar" runat="server" Text="Editar" CommandName="Actualizar" CommandArgument='<%# Eval("IdCategoria") %>' />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdCategoria") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </main>
</asp:Content>
