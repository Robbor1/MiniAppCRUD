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
    public partial class EditarCategoria : System.Web.UI.Page
    {
        readonly SqlConnection sqlConectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // MODO CREAR
                if (Request.QueryString["op"] == "C")
                {
                    txtId.Enabled = false;
                    cbActivo.Enabled = false;
                    btnActualizar.Visible = false;
                    btnAñadir.Visible = true;
                }

                // MODO EDITAR
                else if (Request.QueryString["id"] != null)
                {
                    txtId.Enabled = false;
                    cbActivo.Enabled = true;
                    btnActualizar.Visible = true;
                    btnAñadir.Visible = false;

                    int getId = Convert.ToInt32(Request.QueryString["id"]);
                    CargarCategoria(getId);
                }
            }

        }

        void CargarCategoria(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_SeleccionarCategoria", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCategoria", id);

            sqlConectar.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtId.Text = dr["IdCategoria"].ToString();
                txtCategoria.Text = dr["Nombre"].ToString();
                cbActivo.Checked = Convert.ToBoolean(dr["Activo"]);
            }

            sqlConectar.Close();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                Response.Write("<script>alert('No se pueden guardar datos vacíos.');</script>");
            }
            else
            {
                int getId = Convert.ToInt32(Request.QueryString["id"]);

                using (SqlCommand cmd = new SqlCommand("SP_ActualizarCategoria", sqlConectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = getId;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = txtCategoria.Text;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = cbActivo.Checked;

                    sqlConectar.Open();
                    cmd.ExecuteNonQuery();
                    sqlConectar.Close();
                }

                Response.Redirect("Categorias.aspx");
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                Response.Write("<script>alert('No se pueden guardar datos vacíos.');</script>");
                return;
            }

            using (SqlCommand cmd = new SqlCommand("SP_InsertarCategoria", sqlConectar))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = txtCategoria.Text;

                sqlConectar.Open();
                cmd.ExecuteNonQuery();
                sqlConectar.Close();
            }

            Response.Redirect("Categorias.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }
    }
}