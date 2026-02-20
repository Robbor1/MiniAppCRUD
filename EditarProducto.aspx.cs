using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                CargarCategorias();
                txtId.Enabled = false;

                if (Request.QueryString["op"] == "C")
                {
                    btnActualizar.Visible = false;
                    btnAñadir.Visible = true;
                    cbActivo.Enabled = false;
                    fchRegistro.Enabled = false;
                    fchRegistro.SelectedDate = DateTime.Now;
                }
                else if (Request.QueryString["id"] != null)
                {
                    btnActualizar.Visible = true;
                    btnAñadir.Visible = false;
                    cbActivo.Enabled = true;
                    fchRegistro.Enabled = true;

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

                using (SqlCommand cmd = new SqlCommand("SP_ActualizarProducto", sqlConectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = getId;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = txtNombre.Text;
                    cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPrecio.Text);
                    cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Convert.ToInt32(txtStock.Text);
                    cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = Convert.ToInt32(dropdownCategoria.SelectedValue);
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = fchRegistro.SelectedDate;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = cbActivo.Checked;

                    sqlConectar.Open();
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("Productos.aspx");
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                Response.Write("<script>alert('No se pueden guardar datos vacíos.');</script>");
            }
            else if (dropdownCategoria.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Selecciona una categoría.');</script>");
                return;
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

                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
                dropdownCategoria.SelectedIndex = 0;

                Response.Redirect("Productos.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}