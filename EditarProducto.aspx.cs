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
    public partial class EditarProducto : System.Web.UI.Page
    {
        readonly SqlConnection sqlConectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtId.Enabled = false;
                CargarCategorias();

                if (Request.QueryString["id"] != null)
                {
                    int getId = Convert.ToInt32(Request.QueryString["id"]);
                    CargarProductos(getId);
                }
            }
        }

        void CargarProductos(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_SeleccionarProducto", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", id);

            sqlConectar.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtId.Text = dr["IdProducto"].ToString();
                txtNombre.Text = dr["Nombre"].ToString();
                txtPrecio.Text = dr["Precio"].ToString();
                txtStock.Text = dr["Stock"].ToString();
                dropdownCategoria.SelectedValue = dr["IdCategoria"].ToString();

                if (dr["FechaRegistro"] != DBNull.Value)
                {
                    DateTime fecha = Convert.ToDateTime(dr["FechaRegistro"]).Date;
                    fchRegistro.SelectedDate = fecha;
                    fchRegistro.VisibleDate = fecha;
                }

                cbActivo.Checked = Convert.ToBoolean(dr["Activo"]);

            }

            sqlConectar.Close();
        }

        void CargarCategorias()
        {
            SqlCommand cmd = new SqlCommand("SELECT IdCategoria, Nombre FROM Categorias", sqlConectar);
            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConectar.Close();

            dropdownCategoria.DataSource = dt;
            dropdownCategoria.DataTextField = "Nombre";
            dropdownCategoria.DataValueField = "IdCategoria";
            dropdownCategoria.DataBind();
            dropdownCategoria.Items.Insert(0, new ListItem("-- Selecciona una categoría --", ""));
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrEmpty(dropdownCategoria.Text))
            {
                Response.Write("<script>alert('No se pueden guardar datos vacíos.');</script>");
            }
            else if (dropdownCategoria.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Selecciona una categoría.');</script>");
            }
            else
            {
                int getId = Convert.ToInt32(Request.QueryString["id"]);


                SqlCommand cmd = new SqlCommand("SP_ActualizarProducto", sqlConectar);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConectar.Open();
                cmd.Parameters.Add("@IdProducto", getId);
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = txtNombre.Text;
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPrecio.Text);
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Convert.ToInt32(txtStock.Text);
                cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = Convert.ToInt32(dropdownCategoria.Text);
                cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = fchRegistro.SelectedDate;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = cbActivo.Checked;
                cmd.ExecuteNonQuery();
                sqlConectar.Close();

                Response.Redirect("Productos.aspx");
            }
        }
    }
}