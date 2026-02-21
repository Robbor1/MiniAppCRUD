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

        void CargarTabla(string filtro = "", string campo = "")
        {
            SqlCommand cmd = new SqlCommand("SP_CargarProductos", sqlConectar);
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (!string.IsNullOrWhiteSpace(filtro) && !string.IsNullOrWhiteSpace(campo))
            {
                string expresion = "";

                switch (campo)
                {
                    case "Nombre":
                        string termino = filtro.ToLower();
                        if (termino == "activo" || termino == "true")
                            expresion = "Activo = true";
                        else if (termino == "inactivo" || termino == "false")
                            expresion = "Activo = false";
                        else
                            expresion = $"Nombre LIKE '%{filtro}%'";
                        break;
                    case "Precio":
                        if (decimal.TryParse(filtro, out decimal precio))
                            expresion = $"Precio = {precio.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                        break;
                    case "Stock":
                        if (int.TryParse(filtro, out int stock))
                            expresion = $"Stock = {stock}";
                        break;
                    case "Activo":
                        string t = filtro.ToLower();
                        bool esActivo = t == "true" || t == "activo";
                        expresion = $"Activo = {esActivo.ToString().ToLower()}";
                        break;
                    case "NombreCategoria":
                        expresion = $"NombreCategoria = '{filtro}'";
                        break;
                }

                if (!string.IsNullOrEmpty(expresion))
                {
                    DataRow[] filas = dt.Select(expresion);
                    DataTable dtFiltrado = dt.Clone();
                    foreach (DataRow fila in filas)
                        dtFiltrado.ImportRow(fila);
                    dt = dtFiltrado;
                }
            }

            gvProductos.DataSource = dt;
            gvProductos.DataBind();
            sqlConectar.Close();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        { 
            Response.Redirect("EditarProducto.aspx?op=C");  

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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                CargarTabla(txtNombre.Text, "Nombre");
            } 
            else if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                CargarTabla(txtPrecio.Text, "Precio");
            }
            else if (!string.IsNullOrWhiteSpace(txtStock.Text))
            {
                CargarTabla(txtStock.Text, "Stock");
            }
            else if (!string.IsNullOrWhiteSpace(dropdownCategoria.SelectedValue))
            {
                CargarTabla(dropdownCategoria.SelectedItem.Text, "NombreCategoria");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            dropdownCategoria.SelectedIndex = 0;
            CargarTabla();
        }
    }
}