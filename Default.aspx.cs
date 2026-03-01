using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniAppCRUD
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDashboard();
            }
        }

        private void CargarDashboard()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Total productos
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Productos", conn);
                lblTotalProductos.Text = cmd.ExecuteScalar().ToString();

                // Productos activos
                cmd = new SqlCommand("SELECT COUNT(*) FROM Productos WHERE Activo = 1", conn);
                lblActivos.Text = cmd.ExecuteScalar().ToString();

                // Productos inactivos
                cmd = new SqlCommand("SELECT COUNT(*) FROM Productos WHERE Activo = 0", conn);
                lblInactivos.Text = cmd.ExecuteScalar().ToString();

                // Stock bajo (menos de 20)
                cmd = new SqlCommand("SELECT COUNT(*) FROM Productos WHERE Stock < 20", conn);
                lblStockBajo.Text = cmd.ExecuteScalar().ToString();
            }
        }
    }
}