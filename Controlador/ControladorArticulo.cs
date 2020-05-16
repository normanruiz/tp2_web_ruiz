using Modelo;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorArticulo
    {
        public List<Articulo> Listar()
        {
            List<Articulo> listadoArticulo;
            Articulo articulo;
            AccesoDatos conexion = null;
            try
            {
                listadoArticulo = new List<Articulo>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion, a.IdCategoria, c.Descripcion, a.ImagenUrl, a.Precio, a.Estado from ARTICULOS a left join MARCAS m on a.IdMarca = m.Id left join CATEGORIAS c on a.IdCategoria = c.Id where a.Estado = 1");
                while (conexion.lector.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = conexion.lector.GetInt32(0);
                    articulo.Codigo = conexion.lector.GetString(1);
                    articulo.Nombre = conexion.lector.GetString(2);
                    articulo.Descripcion = conexion.lector.GetString(3);
                    articulo.Imagen = conexion.lector.GetString(8);
                    articulo.Precio = (decimal)conexion.lector["Precio"];
                    articulo.Estado = conexion.lector.GetBoolean(10);

                    articulo.marca = new Marca();
                    articulo.marca.Id = conexion.lector.GetInt32(4);
                    articulo.marca.Descripcion = conexion.lector.GetString(5);

                    articulo.categoria = new Categoria();
                    articulo.categoria.Id = conexion.lector.GetInt32(6);
                    articulo.categoria.Descripcion = conexion.lector.GetString(7);

                    listadoArticulo.Add(articulo);
                }

                return listadoArticulo;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }

        }

        public List<Articulo> ListarFiltrado(string[] listaArgs)
        {
            List<Articulo> listadoArticulo;
            Articulo articulo;
            AccesoDatos conexion = null;
            string cadena = "select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion, a.IdCategoria, c.Descripcion, a.ImagenUrl, a.Precio, a.Estado from ARTICULOS a left join MARCAS m on a.IdMarca = m.Id left join CATEGORIAS c on a.IdCategoria = c.Id where a.Estado = 1";
            try
            {
                if (listaArgs[0] != "Filtrar por Codigo...")
                {
                    cadena += " and a.Codigo like '" + listaArgs[0] + "%'";
                }
                if (listaArgs[1] != "Filtrar por Nombre...")
                {
                    cadena += " and a.Nombre like '" + listaArgs[1] + "%'";
                }
                if (listaArgs[2].Length != 0)
                {
                    cadena += " and a.IdMarca = " + listaArgs[2];
                }
                if (listaArgs[3].Length != 0)
                {
                    cadena += " and a.IdCategoria = " + listaArgs[3];
                }

                listadoArticulo = new List<Articulo>();
                conexion = new AccesoDatos();

                conexion.Conectar();

                conexion.EjecutarConsulta(cadena);
                while (conexion.lector.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = conexion.lector.GetInt32(0);
                    articulo.Codigo = conexion.lector.GetString(1);
                    articulo.Nombre = conexion.lector.GetString(2);
                    articulo.Descripcion = conexion.lector.GetString(3);
                    articulo.Imagen = conexion.lector.GetString(8);
                    articulo.Precio = (decimal)conexion.lector["a.Precio"];
                    articulo.Estado = conexion.lector.GetBoolean(10);

                    articulo.marca = new Marca();
                    articulo.marca.Id = conexion.lector.GetInt32(4);
                    articulo.marca.Descripcion = conexion.lector.GetString(5);

                    articulo.categoria = new Categoria();
                    articulo.categoria.Id = conexion.lector.GetInt32(6);
                    articulo.categoria.Descripcion = conexion.lector.GetString(7);

                    listadoArticulo.Add(articulo);
                }

                return listadoArticulo;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }

        }

        public void AgregarNuevo(Articulo articulo)
        {
            AccesoDatos conexion = null;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();

                conexion.AgregarParametro("@Codigo", articulo.Codigo);
                conexion.AgregarParametro("@Nombre", articulo.Nombre);
                conexion.AgregarParametro("@Descripcion", articulo.Descripcion);
                conexion.AgregarParametro("@idMarca", articulo.marca.Id.ToString());
                conexion.AgregarParametro("@idCategoria", articulo.categoria.Id.ToString());
                conexion.AgregarParametro("@urlImagen", articulo.Imagen);
                conexion.AgregarParametro("@Precio", articulo.Precio.ToString());

                conexion.EjecutarAccion("insert into ARTICULOS values (@Codigo, @Nombre, @Descripcion, @idMarca, @idCategoria, @urlImagen, @Precio, 1)");
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }

        }

        public void GuardarModificado(Articulo articulo)
        {
            AccesoDatos conexion = null;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();

                conexion.AgregarParametro("@Id", articulo.Id.ToString());
                conexion.AgregarParametro("@Codigo", articulo.Codigo);
                conexion.AgregarParametro("@Nombre", articulo.Nombre);
                conexion.AgregarParametro("@Descripcion", articulo.Descripcion);
                conexion.AgregarParametro("@idMarca", articulo.marca.Id.ToString());
                conexion.AgregarParametro("@idCategoria", articulo.categoria.Id.ToString());
                conexion.AgregarParametro("@urlImagen", articulo.Imagen);
                conexion.AgregarParametro("@Precio", articulo.Precio.ToString());

                conexion.EjecutarAccion("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, idMarca = @idMarca, idCategoria = @idCategoria, ImagenUrl = @urlImagen, Precio = @Precio where Id = @Id");
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }

        }

        public void EliminarLogico(Articulo articulo)
        {
            AccesoDatos conexion = null;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@Id", articulo.Id.ToString());

                conexion.EjecutarAccion("update ARTICULOS set Estado = 0 where Id = @Id");
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }

        }
    }
}