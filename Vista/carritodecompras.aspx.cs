using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class carritodecompras : System.Web.UI.Page
    {
        public List<Articulo> ListaCarrito;
        public List<Articulo> ListaCarritoaux;
        public Dictionary<int, int> listaCarrito { get; set; }
        ControladorArticulo controlador;
        public int ContCantidad { get; set; }
        public decimal AcumuladorTotal { get; set; }
        public Articulo articuloAux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                controlador = new ControladorArticulo();
                listaCarrito = (Dictionary<int, int>)Session["Session_id_" + Session.SessionID + "_ListaCarrito"];
                if (listaCarrito == null)
                {
                    ListaCarrito = new List<Articulo>();
                }
                else
                {
                    ListaCarrito = new List<Articulo>();
                    ListaCarritoaux = controlador.Listar();
                    foreach(int idAux in listaCarrito.Keys)
                    {
                        articuloAux = ListaCarritoaux.Find(j => j.Id == idAux);
                        ListaCarrito.Add(articuloAux);
                        AcumuladorTotal += listaCarrito[idAux] * articuloAux.Precio;
                    }
                    ContCantidad = listaCarrito.Values.Sum();
                }
                
                //listaCarrito = (Dictionary<int, int>)Session["Session_id_" + Session.SessionID + "_ListaCarrito"];
            }
            catch (Exception excepcion)
            {
                Session.Add("Session_id_" + Session.SessionID + "_error", excepcion.Message);
                Response.Redirect("error.aspx");
            }

        }
    }
}