<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="MiniAppCRUD.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Encabezado -->
        <div class="d-flex align-items-center mb-4 pb-3 border-bottom">
            <div>
                <h2 class="mb-1"><%: Title %></h2>
                <p class="text-muted mb-0" style="font-size:13px;">Genera y exporta reportes del sistema</p>
            </div>
        </div>

        <!-- REPORTE 1 -->
        <div class="card border-0 shadow-sm mb-4">
            <div class="card-header bg-dark text-warning fw-bold" style="border-left: 4px solid #f39c12;">
                Productos por Categoría
            </div>
            <div class="card-body">
                <div class="d-flex align-items-center gap-3 mb-3">
                    <asp:Button ID="btnReporte1" runat="server" Text="Generar Reporte" OnClick="btnReporte1_Click" CssClass="btn btn-warning fw-bold text-white" />
                    <asp:Label ID="lblFecha1" runat="server" Visible="false" CssClass="text-muted" style="font-size:12px;"></asp:Label>
                </div>
                <asp:GridView ID="gvReporte1" runat="server" AutoGenerateColumns="false" Visible="false"
                    CssClass="table table-hover mb-3" GridLines="None">
                    <HeaderStyle CssClass="table-dark" />
                    <Columns>
                        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                        <asp:BoundField DataField="Total" HeaderText="Total" />
                        <asp:BoundField DataField="Activos" HeaderText="Activos" />
                        <asp:BoundField DataField="Inactivos" HeaderText="Inactivos" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblTotal1" runat="server" Visible="false" CssClass="fw-bold text-dark d-block mb-3"></asp:Label>
                <div class="d-flex gap-2">
                    <asp:Button ID="btnExcel1" runat="server" Text="Exportar Excel" OnClick="btnExcel1_Click" Visible="false" CssClass="btn btn-success fw-bold" />
                    <asp:Button ID="btnPdf1" runat="server" Text="Exportar PDF" OnClick="btnPdf1_Click" Visible="false" CssClass="btn btn-danger fw-bold" />
                </div>
            </div>
        </div>

        <!-- REPORTE 2 -->
        <div class="card border-0 shadow-sm mb-4">
            <div class="card-header bg-dark text-warning fw-bold" style="border-left: 4px solid #f39c12;">
                Productos con Stock Bajo
            </div>
            <div class="card-body">
                <div class="d-flex align-items-center gap-3 mb-3 flex-wrap">
                    <label class="fw-semibold mb-0" style="font-size:13px;">Stock menor a:</label>
                    <asp:TextBox ID="txtStockLimite" runat="server" placeholder="Ej: 20" CssClass="form-control" style="max-width:100px;"></asp:TextBox>
                    <asp:Button ID="btnReporte2" runat="server" Text="Generar Reporte" OnClick="btnReporte2_Click" CssClass="btn btn-warning fw-bold text-white" />
                    <asp:Label ID="lblFecha2" runat="server" Visible="false" CssClass="text-muted" style="font-size:12px;"></asp:Label>
                </div>
                <asp:GridView ID="gvReporte2" runat="server" AutoGenerateColumns="false" Visible="false"
                    CssClass="table table-hover mb-3" GridLines="None">
                    <HeaderStyle CssClass="table-dark" />
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblTotal2" runat="server" Visible="false" CssClass="fw-bold text-dark d-block mb-3"></asp:Label>
                <div class="d-flex gap-2">
                    <asp:Button ID="btnExcel2" runat="server" Text="Exportar Excel" OnClick="btnExcel2_Click" Visible="false" CssClass="btn btn-success fw-bold" />
                    <asp:Button ID="btnPdf2" runat="server" Text="Exportar PDF" OnClick="btnPdf2_Click" Visible="false" CssClass="btn btn-danger fw-bold" />
                </div>
            </div>
        </div>

        <!-- REPORTE 3 -->
        <div class="card border-0 shadow-sm mb-4">
            <div class="card-header bg-dark text-warning fw-bold" style="border-left: 4px solid #f39c12;">
                Productos Inactivos
            </div>
            <div class="card-body">
                <div class="d-flex align-items-center gap-3 mb-3">
                    <asp:Button ID="btnReporte3" runat="server" Text="Generar Reporte" OnClick="btnReporte3_Click" CssClass="btn btn-warning fw-bold text-white" />
                    <asp:Label ID="lblFecha3" runat="server" Visible="false" CssClass="text-muted" style="font-size:12px;"></asp:Label>
                </div>
                <asp:GridView ID="gvReporte3" runat="server" AutoGenerateColumns="false" Visible="false"
                    CssClass="table table-hover mb-3" GridLines="None">
                    <HeaderStyle CssClass="table-dark" />
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblTotal3" runat="server" Visible="false" CssClass="fw-bold text-dark d-block mb-3"></asp:Label>
                <div class="d-flex gap-2">
                    <asp:Button ID="btnExcel3" runat="server" Text="Exportar Excel" OnClick="btnExcel3_Click" Visible="false" CssClass="btn btn-success fw-bold" />
                    <asp:Button ID="btnPdf3" runat="server" Text="Exportar PDF" OnClick="btnPdf3_Click" Visible="false" CssClass="btn btn-danger fw-bold" />
                </div>
            </div>
        </div>

    </main>
</asp:Content>