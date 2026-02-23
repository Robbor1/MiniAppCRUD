using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace MiniAppCRUD
{
    public partial class Reportes : System.Web.UI.Page
    {
        readonly SqlConnection sqlConectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // REPORTE 1 — Productos por categoría
        protected void btnReporte1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"
            SELECT 
                c.Nombre AS Categoria,
                COUNT(p.IdProducto) AS Total,
                SUM(CASE WHEN p.Activo = 1 THEN 1 ELSE 0 END) AS Activos,
                SUM(CASE WHEN p.Activo = 0 THEN 1 ELSE 0 END) AS Inactivos
            FROM Categorias c
            LEFT JOIN Productos p ON c.IdCategoria = p.IdCategoria
            GROUP BY c.Nombre", sqlConectar);

            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConectar.Close();

            gvReporte1.DataSource = dt;
            gvReporte1.DataBind();
            gvReporte1.Visible = true;

            lblFecha1.Text = "Generado el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblFecha1.Visible = true;
            lblTotal1.Text = "Total de categorías: " + dt.Rows.Count;
            lblTotal1.Visible = true;

            btnExcel1.Visible = true;
            btnPdf1.Visible = true;
        }

        // REPORTE 2 — Stock bajo
        protected void btnReporte2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStockLimite.Text, out int limite) || limite < 0)
            {
                Response.Write("<script>alert('Ingresa un número válido para el límite de stock.');</script>");
                return;
            }

            SqlCommand cmd = new SqlCommand(@"
            SELECT 
                p.IdProducto,
                p.Nombre,
                p.Stock,
                c.Nombre AS NombreCategoria
            FROM Productos p
            INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
            WHERE p.Stock < @Limite
            ORDER BY p.Stock ASC", sqlConectar);

            cmd.Parameters.AddWithValue("@Limite", limite);
            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConectar.Close();

            gvReporte2.DataSource = dt;
            gvReporte2.DataBind();
            gvReporte2.Visible = true;

            lblFecha2.Text = $"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm} — Productos con stock menor a: {limite}";
            lblFecha2.Visible = true;
            lblTotal2.Text = "Total de productos encontrados: " + dt.Rows.Count;
            lblTotal2.Visible = true;
            btnExcel2.Visible = true;
            btnPdf2.Visible = true;
        }

        // REPORTE 3 — Productos inactivos
        protected void btnReporte3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"
            SELECT 
                p.IdProducto,
                p.Nombre,
                p.Precio,
                c.Nombre AS NombreCategoria
            FROM Productos p
            INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
            WHERE p.Activo = 0", sqlConectar);

            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConectar.Close();

            gvReporte3.DataSource = dt;
            gvReporte3.DataBind();
            gvReporte3.Visible = true;

            lblFecha3.Text = "Generado el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblFecha3.Visible = true;
            lblTotal3.Text = "Total de productos inactivos: " + dt.Rows.Count;
            lblTotal3.Visible = true;
            btnExcel3.Visible = true;
            btnPdf3.Visible = true;
        }

        // --------------------EXPORTAR EXCEL Y PDF-----------------------

        // ===== MÉTODOS PARA OBTENER DATOS =====
        DataTable ObtenerReporte1()
        {
            SqlCommand cmd = new SqlCommand(@"
        SELECT 
            c.Nombre AS Categoria,
            COUNT(p.IdProducto) AS Total,
            SUM(CASE WHEN p.Activo = 1 THEN 1 ELSE 0 END) AS Activos,
            SUM(CASE WHEN p.Activo = 0 THEN 1 ELSE 0 END) AS Inactivos
        FROM Categorias c
        LEFT JOIN Productos p ON c.IdCategoria = p.IdCategoria
        GROUP BY c.Nombre", sqlConectar);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConectar.Open();
            da.Fill(dt);
            sqlConectar.Close();
            return dt;
        }

        DataTable ObtenerReporte2(int limite)
        {
            SqlCommand cmd = new SqlCommand(@"
        SELECT p.IdProducto, p.Nombre, p.Stock, c.Nombre AS NombreCategoria
        FROM Productos p
        INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
        WHERE p.Stock < @Limite
        ORDER BY p.Stock ASC", sqlConectar);
            cmd.Parameters.AddWithValue("@Limite", limite);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConectar.Open();
            da.Fill(dt);
            sqlConectar.Close();
            return dt;
        }

        DataTable ObtenerReporte3()
        {
            SqlCommand cmd = new SqlCommand(@"
        SELECT p.IdProducto, p.Nombre, p.Precio, c.Nombre AS NombreCategoria
        FROM Productos p
        INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
        WHERE p.Activo = 0", sqlConectar);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConectar.Open();
            da.Fill(dt);
            sqlConectar.Close();
            return dt;
        }

        // ===== EXPORTAR EXCEL =====
        void ExportarExcel(DataTable dt, string nombreArchivo, string titulo)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Reporte");

                ws.Cell(1, 1).Value = titulo;
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 14;
                ws.Range(1, 1, 1, dt.Columns.Count).Merge();

                ws.Cell(2, 1).Value = "Generado el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Range(2, 1, 2, dt.Columns.Count).Merge();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    var cell = ws.Cell(4, i + 1);
                    cell.Value = dt.Columns[i].ColumnName;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                    cell.Style.Font.FontColor = XLColor.White;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                    for (int j = 0; j < dt.Columns.Count; j++)
                        ws.Cell(i + 5, j + 1).Value = dt.Rows[i][j].ToString();

                ws.Cell(dt.Rows.Count + 6, 1).Value = "Total de registros: " + dt.Rows.Count;
                ws.Cell(dt.Rows.Count + 6, 1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", $"attachment;filename={nombreArchivo}.xlsx");
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    Response.BinaryWrite(ms.ToArray());
                }
                Response.End();
            }
        }

        // ===== EXPORTAR PDF =====
        void ExportarPDF(DataTable dt, string nombreArchivo, string titulo)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", $"attachment;filename={nombreArchivo}.pdf");

            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var fuenteFecha = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.GRAY);
            var fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            var fuenteDato = FontFactory.GetFont(FontFactory.HELVETICA, 9);
            var fuenteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

            doc.Add(new Paragraph(titulo, fuenteTitulo));
            doc.Add(new Paragraph("Generado el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteFecha));
            doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(dt.Columns.Count);
            tabla.WidthPercentage = 100;

            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName, fuenteEncabezado));
                cell.BackgroundColor = new BaseColor(0, 0, 139);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 5;
                tabla.AddCell(cell);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dt.Rows[i][j].ToString(), fuenteDato));
                    cell.BackgroundColor = i % 2 == 0 ? BaseColor.WHITE : new BaseColor(240, 240, 240);
                    cell.Padding = 4;
                    tabla.AddCell(cell);
                }

            doc.Add(tabla);
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Total de registros: " + dt.Rows.Count, fuenteTotal));
            doc.Close();
            Response.End();
        }

        // ===== BOTONES EXCEL =====
        protected void btnExcel1_Click(object sender, EventArgs e)
        {
            ExportarExcel(ObtenerReporte1(), "ProductosPorCategoria", "Productos por Categoría");
        }
        protected void btnExcel2_Click(object sender, EventArgs e)
        {
            int.TryParse(txtStockLimite.Text, out int limite);
            ExportarExcel(ObtenerReporte2(limite), "StockBajo", $"Productos con Stock menor a {limite}");
        }
        protected void btnExcel3_Click(object sender, EventArgs e)
        {
            ExportarExcel(ObtenerReporte3(), "ProductosInactivos", "Productos Inactivos");
        }

        // ===== BOTONES PDF =====
        protected void btnPdf1_Click(object sender, EventArgs e)
        {
            ExportarPDF(ObtenerReporte1(), "ProductosPorCategoria", "Productos por Categoría");
        }
        protected void btnPdf2_Click(object sender, EventArgs e)
        {
            int.TryParse(txtStockLimite.Text, out int limite);
            ExportarPDF(ObtenerReporte2(limite), "StockBajo", $"Productos con Stock menor a {limite}");
        }
        protected void btnPdf3_Click(object sender, EventArgs e)
        {
            ExportarPDF(ObtenerReporte3(), "ProductosInactivos", "Productos Inactivos");
        }


    }
}