using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}