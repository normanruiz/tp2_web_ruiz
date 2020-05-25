using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class CatalogoDeCompras : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
 

        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar(tbxFiltro.Text);
        }

        protected void ibtCarrito_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("carritodecompras.aspx");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        public void Cargar(string busqueda)
        {
            List<Articulo> listaAuxiliar;
            ControladorArticulo controladorArticulo = new ControladorArticulo();
            try
            {
                listaAuxiliar = controladorArticulo.Listar();
                if (busqueda.Length == 0)
                {
                    listaArticulos = listaAuxiliar;
                }
                else
                {
                    listaArticulos = listaAuxiliar.FindAll(j => j.Nombre.Contains(busqueda));
                }
            }
            catch (Exception excepcion)
            {
                Session.Add("Session_id_" + Session.SessionID + "_error", excepcion.Message);
                Response.Redirect("error.aspx");
            }
        }
    }
}