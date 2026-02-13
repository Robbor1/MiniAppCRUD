using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MiniAppCRUD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlConectar);
            {
                 cmd.CommandType = CommandType.StoredProcedure;
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar,150).Value = txtUsername.Text;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 150).Value = txtPassword.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
            cmd.Connection.Close();
        }
    }
}