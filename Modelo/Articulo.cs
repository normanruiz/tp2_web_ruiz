using System;

namespace Modelo
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}
