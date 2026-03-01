<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniAppCRUD._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Encabezado -->
        <div class="d-flex align-items-center mb-4 pb-3 border-bottom">
            <div>
                <h2 class="mb-1">Dashboard</h2>
                <p class="text-muted mb-0" style="font-size:13px;">Resumen general del sistema</p>
            </div>
        </div>

        <!-- Tarjetas -->
        <div class="row g-4">

            <!-- Total Productos -->
            <div class="col-md-3">
                <div class="card border-0 shadow-sm h-100" style="border-top: 4px solid #f39c12 !important;">
                    <div class="card-body">
                        <p class="text-muted mb-1" style="font-size:12px; text-transform:uppercase; letter-spacing:0.8px; font-weight:600;">Total Productos</p>
                        <h2 class="fw-bold mb-0" style="font-size:36px; color:#1a1a1a;">
                            <asp:Label ID="lblTotalProductos" runat="server" Text="0"></asp:Label>
                        </h2>
                        <p class="text-muted mt-2 mb-0" style="font-size:12px;">Productos registrados</p>
                    </div>
                </div>
            </div>

            <!-- Productos Activos -->
            <div class="col-md-3">
                <div class="card border-0 shadow-sm h-100" style="border-top: 4px solid #2e7d32 !important;">
                    <div class="card-body">
                        <p class="text-muted mb-1" style="font-size:12px; text-transform:uppercase; letter-spacing:0.8px; font-weight:600;">Productos Activos</p>
                        <h2 class="fw-bold mb-0" style="font-size:36px; color:#2e7d32;">
                            <asp:Label ID="lblActivos" runat="server" Text="0"></asp:Label>
                        </h2>
                        <p class="text-muted mt-2 mb-0" style="font-size:12px;">En operación actualmente</p>
                    </div>
                </div>
            </div>

            <!-- Productos Inactivos -->
            <div class="col-md-3">
                <div class="card border-0 shadow-sm h-100" style="border-top: 4px solid #c0392b !important;">
                    <div class="card-body">
                        <p class="text-muted mb-1" style="font-size:12px; text-transform:uppercase; letter-spacing:0.8px; font-weight:600;">Productos Inactivos</p>
                        <h2 class="fw-bold mb-0" style="font-size:36px; color:#c0392b;">
                            <asp:Label ID="lblInactivos" runat="server" Text="0"></asp:Label>
                        </h2>
                        <p class="text-muted mt-2 mb-0" style="font-size:12px;">Fuera de operación</p>
                    </div>
                </div>
            </div>

            <!-- Stock Bajo -->
            <div class="col-md-3">
                <div class="card border-0 shadow-sm h-100" style="border-top: 4px solid #e67e22 !important;">
                    <div class="card-body">
                        <p class="text-muted mb-1" style="font-size:12px; text-transform:uppercase; letter-spacing:0.8px; font-weight:600;">Stock Bajo</p>
                        <h2 class="fw-bold mb-0" style="font-size:36px; color:#e67e22;">
                            <asp:Label ID="lblStockBajo" runat="server" Text="0"></asp:Label>
                        </h2>
                        <p class="text-muted mt-2 mb-0" style="font-size:12px;">Menos de 20 unidades</p>
                    </div>
                </div>
            </div>

        </div>
    </main>
</asp:Content>