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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                try
                {
                    User usuario = (User)Session["user"];
                    UserNegocio negocio = new UserNegocio();
                    //User usuario = negocio.buscarUser(sesion.Email, sesion.Pass);
                    if (usuario.TipoUsuario == 1)
                        admin.Text = "Admin";
                    if (!IsPostBack)
                    {
                        txtEmail.Enabled = false;
                        txtEmail.Text = usuario.Email == null ? " " : usuario.Email.ToString();
                        txtNombre.Text = usuario.Nombre == null ? " " : usuario.Nombre.ToString();
                        txtApellido.Text = usuario.Apellido == null ? " " : usuario.Apellido.ToString();
                        fechaNacimiento.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                        //txtUrlImagen.Text = usuario.ImagenPerfil == null ? " " : usuario.ImagenPerfil.ToString();
                        //imgPerfil.ImageUrl = usuario.ImagenPerfil;
                    }
                }
                catch (Exception)
                {

                }
            }

        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                User sesion = (User)Session["user"];
                UserNegocio negocio = new UserNegocio();
                sesion = negocio.buscarUser(sesion.Email, sesion.Pass);

                sesion.Email = txtEmail.Text;
                sesion.Nombre = txtNombre.Text;
                sesion.Apellido = txtApellido.Text;
                sesion.FechaNacimiento = DateTime.Parse(fechaNacimiento.Text);

                negocio.actualizarPerfil(sesion);
                Session.Add("user", sesion);

            }
            catch (Exception)
            {

            }

        }
    }
}