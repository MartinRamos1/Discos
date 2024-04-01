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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();

            try
            {
                if (txtPass.Text == txtPassConfirm.Text)
                {
                    user.Email = txtEmail.Text;
                    user.Pass = txtPass.Text;

                    if (negocio.SignUp(user))
                    {
                        Session.Add("user", user);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        lblErrorSignUp.Text = "El usuario ya existe";
                    }

                }
                else { lblErrorSignUp.Text = "Las contraseñas no coinciden"; }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}