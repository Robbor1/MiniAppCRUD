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
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    int getId = Convert.ToInt32(Request.QueryString["id"]);
                    CargarCategoria(getId);
                }
            }

            txtId.Enabled = false;

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


                SqlCommand cmd = new SqlCommand("SP_ActualizarCategoria", sqlConectar);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConectar.Open();
                cmd.Parameters.Add("@IdCategoria", getId);
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = txtCategoria.Text;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Convert.ToInt32(cbActivo.Checked);
                cmd.ExecuteNonQuery();
                sqlConectar.Close();

                Response.Redirect("Categorias.aspx");
            }
        }
    }
}