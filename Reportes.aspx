<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="MiniAppCRUD.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <!-- REPORTE 1 -->
        <h3>Productos por Categoría</h3>
        <asp:Button ID="btnReporte1" runat="server" Text="Generar" OnClick="btnReporte1_Click" />
        <asp:Label ID="lblFecha1" runat="server" Visible="false" Style="display:block; color:gray; font-size:12px;"></asp:Label>
        <asp:GridView ID="gvReporte1" runat="server" AutoGenerateColumns="false" Visible="false">
            <Columns>
                <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:BoundField DataField="Activos" HeaderText="Activos" />
                <asp:BoundField DataField="Inactivos" HeaderText="Inactivos" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblTotal1" runat="server" Visible="false" Style="display:block; font-weight:bold;"></asp:Label>

        <asp:Button ID="btnExcel1" runat="server" Text="Exportar Excel" OnClick="btnExcel1_Click" Visible="false" />
        <asp:Button ID="btnPdf1" runat="server" Text="Exportar PDF" OnClick="btnPdf1_Click" Visible="false" />
        

        <!-- REPORTE 2 -->
        <h3>Productos con Stock Bajo</h3>
        <asp:Label runat="server" Text="Stock menor a: "></asp:Label>
        <asp:TextBox ID="txtStockLimite" runat="server" placeholder="Ej: 20"></asp:TextBox>
        <asp:Button ID="btnReporte2" runat="server" Text="Generar" OnClick="btnReporte2_Click" />
        <asp:Label ID="lblFecha2" runat="server" Visible="false" Style="display:block; color:gray; font-size:12px;"></asp:Label>
        <asp:GridView ID="gvReporte2" runat="server" AutoGenerateColumns="false" Visible="false">
            <Columns>
                <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblTotal2" runat="server" Visible="false" Style="display:block; font-weight:bold;"></asp:Label>
        
        <asp:Button ID="btnExcel2" runat="server" Text="Exportar Excel" OnClick="btnExcel2_Click" Visible="false" />
        <asp:Button ID="btnPdf2" runat="server" Text="Exportar PDF" OnClick="btnPdf2_Click" Visible="false" />


        <!-- REPORTE 3 -->
        <h3>Productos Inactivos</h3>
        <asp:Button ID="btnReporte3" runat="server" Text="Generar" OnClick="btnReporte3_Click" />
        <asp:Label ID="lblFecha3" runat="server" Visible="false" Style="display:block; color:gray; font-size:12px;"></asp:Label>
        <asp:GridView ID="gvReporte3" runat="server" AutoGenerateColumns="false" Visible="false">
            <Columns>
                <asp:BoundField DataField="IdProducto" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblTotal3" runat="server" Visible="false" Style="display:block; font-weight:bold;"></asp:Label>

        <asp:Button ID="btnExcel3" runat="server" Text="Exportar Excel" OnClick="btnExcel3_Click" Visible="false" />
        <asp:Button ID="btnPdf3" runat="server" Text="Exportar PDF" OnClick="btnPdf3_Click" Visible="false" />

    </main>
</asp:Content>
