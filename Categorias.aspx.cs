using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniAppCRUD
{
    public partial class Categorias : Page
    {
        readonly SqlConnection sqlConectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("SP_CargarCategorias", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvCategorias.DataSource = dt;
            gvCategorias.DataBind();
            sqlConectar.Close();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditarCategoria.aspx?op=C");

        }

        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditarCategoria.aspx?id=" + id);
            }

            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                SqlCommand cmd = new SqlCommand("SP_EliminarCategorias", sqlConectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", id);

                sqlConectar.Open();
                cmd.ExecuteNonQuery();
                sqlConectar.Close();

                CargarTabla();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                Response.Write("<script>alert('Escribe qu');</script>");
            }
            else
            {
                
            }
        }
    }
}