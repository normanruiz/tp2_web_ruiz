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
                //MessageBox.Show(excepcion.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}