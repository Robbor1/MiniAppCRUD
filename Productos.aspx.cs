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
    public partial class Contact : Page
    {
        readonly SqlConnection sqlConectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarTabla();
            }
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

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("SP_CargarProductos", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("NombreCategoria", typeof(string));

            gvProductos.DataSource = dt;
            gvProductos.DataBind();
            sqlConectar.Close();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SP_InsertarProducto", sqlConectar);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConectar.Open();
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = txtNombre.Text;
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPrecio.Text);
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Convert.ToInt32(txtStock.Text);
                cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = Convert.ToInt32(dropdownCategoria.SelectedValue);
                cmd.ExecuteNonQuery();
                sqlConectar.Close();
                CargarTabla();

                txtNombre.Text = " ";
                txtPrecio.Text = " ";
                txtStock.Text = " ";
                dropdownCategoria.TabIndex = 0;

            }
            
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditarProducto.aspx?id=" + id);
            }

            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                SqlCommand cmd = new SqlCommand("SP_EliminarProductos", sqlConectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);

                sqlConectar.Open();
                cmd.ExecuteNonQuery();
                sqlConectar.Close();

                CargarTabla();
            }
        }





    }
}