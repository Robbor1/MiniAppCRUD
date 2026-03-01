<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="MiniAppCRUD.Contact" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Encabezado -->
        <div class="d-flex align-items-center mb-4 pb-3 border-bottom">
            <div>
                <h2 class="mb-1"><%: Title %></h2>
                <p class="text-muted mb-0" style="font-size:13px;">Gestiona los productos del sistema</p>
            </div>
        </div>

        <!-- Toolbar -->
        <div class="card mb-4 border-0 shadow-sm">
            <div class="card-body d-flex align-items-center gap-2 flex-wrap">
                <label class="fw-semibold mb-0" style="font-size:13px;">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Ej: producto1" CssClass="form-control" style="max-width:150px;"></asp:TextBox>

                <label class="fw-semibold mb-0" style="font-size:13px;">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server" placeholder="Ej: $100.00" CssClass="form-control" style="max-width:120px;"></asp:TextBox>

                <label class="fw-semibold mb-0" style="font-size:13px;">Stock:</label>
                <asp:TextBox ID="txtStock" runat="server" placeholder="Ej: 100" CssClass="form-control" style="max-width:90px;"></asp:TextBox>

                <label class="fw-semibold mb-0" style="font-size:13px;">Categoría:</label>
                <asp:DropDownList ID="dropdownCategoria" runat="server" CssClass="form-select" style="max-width:180px;"></asp:DropDownList>

                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-warning fw-bold text-white" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-secondary fw-bold" />
                <asp:Button ID="btnGuardar" runat="server" Text="+ Añadir" OnClick="btnGuardar_Click" CssClass="btn btn-dark fw-bold" />
            </div>
        </div>

        <!-- Tabla -->
        <div class="card border-0 shadow-sm">
            <div class="card-body p-0">
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="gvProductos_RowCommand"
                    AllowPaging="true" PageSize="5"
                    OnPageIndexChanging="gvProductos_PageIndexChanging"
                    CssClass="table table-hover mb-0"
                    GridLines="None">
                    <HeaderStyle CssClass="table-dark" />
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
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
                                    CommandName="Actualizar" CommandArgument='<%# Eval("IdProducto") %>'
                                    CssClass="btn btn-sm btn-warning text-white fw-bold" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                                    CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>'
                                    CssClass="btn btn-sm btn-outline-danger fw-bold" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </main>
</asp:Content>