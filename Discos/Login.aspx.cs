using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Discos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();

            user.Email = txtEmail.Text;
            user.Pass = txtPass.Text;
            
            if (negocio.Login(user))
            {
                Session.Add("user", user);
                Response.Redirect("Default.aspx", false);
            } else
            {
                lblLoginError.Text = "Usuario y contraseña incorrectas";
            }
            

        }
    }
}