using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{

    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo articuloDetalle { get; set; }
        public List<Articulo> listaArticulosCarrito { get; set; }

        Dictionary<int, int> listaCarrito = new Dictionary<int, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ControladorArticulo controladorAux = new ControladorArticulo();
            List<Articulo> listaAux;
            try
            {
                listaAux = controladorAux.Listar();
                int idAux = Convert.ToInt32(Request.QueryString["idArticulo"]);
                articuloDetalle = listaAux.Find(i => i.Id == idAux);
                listaCarrito = (Dictionary<int, int>)Session["Session_id_" + Session.SessionID + "_ListaCarrito"];
                if (listaCarrito == null)
                {
                    listaCarrito = new Dictionary<int, int>();
                }
            }
            catch (Exception excepcion)
            {
                Session.Add("Session_id_" + Session.SessionID + "_error", excepcion.Message);
                Response.Redirect("error.aspx");
            }
        }

        protected void btnCArgarCArrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (!listaCarrito.ContainsKey(articuloDetalle.Id))
                {
                    listaCarrito.Add(articuloDetalle.Id, 1);
                }
                else
                {
                    listaCarrito[articuloDetalle.Id] += 1;
                }
                Session.Add("Session_id_" + Session.SessionID + "_ListaCarrito", listaCarrito);
            }
            catch (Exception excepcion)
            {
                Session.Add("Session_id_" + Session.SessionID + "_error", excepcion.Message);
                Response.Redirect("error.aspx");
            }
        }
    }
}