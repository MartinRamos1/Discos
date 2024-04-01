using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Discos
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Disco> ListaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["logout"] != null)
            {
                Session.Remove("user");
            }
            DiscoNegocio negocio = new DiscoNegocio();
            ListaDiscos = negocio.Listar();
            Session.Add("lista", ListaDiscos);
            //dgvDiscos.DataSource = ListaDiscos;
            //dgvDiscos.DataBind();
        }

        protected void btnAgregarDisco_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarDisco.aspx");
        }

        //protected void btnSeleccionar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("AgregarDisco.aspx?id=" + );
            
        //}
    }
}