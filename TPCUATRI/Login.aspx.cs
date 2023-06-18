using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCUATRI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Usuario user;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                user = new Usuario(txtMailLogin.Text, txtPassLogin.Text, false);
                if (negocio.Loguearse(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Perfil.aspx");
                }
                else
                {
                    Session.Add("error", "Email o password incorrecto");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }
    }
}