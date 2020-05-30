using Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class CatalogoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControladorArticulo controladorArticulo;
            try
            {
                controladorArticulo = new ControladorArticulo();
                gvCatalogo.DataSource = controladorArticulo.Listar();
                gvCatalogo.DataBind();
                gvCatalogo.Columns[1].Visible = false;
            }
            catch (Exception excepcion)
            {
                Session.Add("Session_id_" + Session.SessionID + "_error", excepcion.Message);
                Response.Redirect("error.aspx");
            }
        }
    }
}