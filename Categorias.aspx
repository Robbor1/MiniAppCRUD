<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="MiniAppCRUD.Categorias" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Encabezado -->
        <div class="d-flex align-items-center mb-4 pb-3 border-bottom">
            <div>
                <h2 class="mb-1"><%: Title %></h2>
                <p class="text-muted mb-0" style="font-size:13px;">Gestiona las categorías del sistema</p>
            </div>
        </div>

        <!-- Toolbar -->
        <div class="card mb-4 border-0 shadow-sm">
            <div class="card-body d-flex align-items-center gap-2 flex-wrap">
                <label class="fw-semibold mb-0 me-1" style="font-size:13px;">Categoría:</label>
                <asp:TextBox ID="txtCategoria" runat="server" placeholder="Ej: maquinaria" CssClass="form-control" style="max-width:220px;"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-warning fw-bold text-white" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-secondary fw-bold" />
                <asp:Button ID="btnGuardar" runat="server" Text="+ Añadir" OnClick="btnGuardar_Click" CssClass="btn btn-dark fw-bold" />
            </div>
        </div>

        <!-- Tabla -->
        <div class="card border-0 shadow-sm">
            <div class="card-body p-0">
                <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="gvCategorias_RowCommand"
                    AllowPaging="true" PageSize="5"
                    OnPageIndexChanging="gvCategorias_PageIndexChanging"
                    CssClass="table table-hover mb-0"
                    GridLines="None">
                    <HeaderStyle CssClass="table-dark" />
                    <Columns>
                        <asp:BoundField DataField="IdCategoria" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:TemplateField HeaderText="Estatus">
                            <ItemTemplate>
                                <span class='<%# Convert.ToBoolean(Eval("Activo")) ? "badge bg-success" : "badge bg-danger" %>'>
                                    <%# Convert.ToBoolean(Eval("Activo")) ? "Activo" : "Inactivo" %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="btnActualizar" runat="server" Text="Editar"
                                    CommandName="Actualizar" CommandArgument='<%# Eval("IdCategoria") %>'
                                    CssClass="btn btn-sm btn-warning text-white fw-bold" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                                    CommandName="Eliminar" CommandArgument='<%# Eval("IdCategoria") %>'
                                    CssClass="btn btn-sm btn-outline-danger fw-bold" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </main>
</asp:Content>