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
    public partial class AgregarDisco : System.Web.UI.Page
    {
        public Disco seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null || !(UserNegocio.isAdmin((User)Session["user"])))
            {
                Response.Redirect("Login.aspx");
            }
            EstiloNegocio esNegocio = new EstiloNegocio();
            EdicionNegocio edNegocio = new EdicionNegocio();

            if (!IsPostBack)
            {
                ddlEstilo.DataValueField = "Id";
                ddlEstilo.DataTextField = "Descripcion";

                ddlEstilo.DataSource = esNegocio.Listar();
                ddlEstilo.DataBind();

                ddlEdicion.DataValueField = "Id";
                ddlEdicion.DataTextField = "Descripcion";

                ddlEdicion.DataSource = edNegocio.Listar();
                ddlEdicion.DataBind();

                txtId.Enabled = false;

                // MODIFICAR
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    seleccionado = ((List<Disco>)Session["lista"]).Find(x => x.Id == id);
                    txtId.Text = seleccionado.Id.ToString();
                    txtTitulo.Text = seleccionado.Titulo;
                    txtCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();
                    txtUrlImagen.Text = seleccionado.UrlImagenTapa;
                    Fecha.Text = Convert.ToDateTime(seleccionado.FechaLanzamiento).ToString("dd/MM/yyyy");
                    
                    ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                    ddlEdicion.SelectedValue = seleccionado.Edicion.Id.ToString();


                    btnAgregar.Text = "Aceptar";
                }
            }  
        }

        public void btnAgregar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
                Disco nuevo = new Disco();
                nuevo.Titulo = txtTitulo.Text;
                nuevo.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                nuevo.UrlImagenTapa = txtUrlImagen.Text;

                nuevo.FechaLanzamiento = new DateTime();
                nuevo.FechaLanzamiento = DateTime.Parse(Fecha.Text);

                nuevo.Estilo = new Estilo();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);
                nuevo.Estilo.Descripcion = ddlEstilo.SelectedItem.Text;

                nuevo.Edicion = new Edicion();
                nuevo.Edicion.Id = int.Parse(ddlEdicion.SelectedValue);
                nuevo.Edicion.Descripcion = ddlEdicion.SelectedItem.Text;

                if (btnAgregar.Text == "Agregar")
                    negocio.Agregar(nuevo);
                else
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo); 
                }
                Response.Redirect("Default.aspx");
            }
            catch (Exception)
            {

            }
            finally { datos.cerrarConexion(); }
        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            negocio.Eliminar(int.Parse(Request.QueryString["id"]));
            Response.Redirect("Default.aspx", false);
        }
    }
}