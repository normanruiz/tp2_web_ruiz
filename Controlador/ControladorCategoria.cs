using Modelo;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorCategoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listadoCategoria;
            Categoria categoria;
            AccesoDatos conexion = null;
            try
            {
                listadoCategoria = new List<Categoria>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select Id, Descripcion from CATEGORIAS");
                while (conexion.lector.Read())
                {
                    categoria = new Categoria();
                    categoria.Id = (int)conexion.lector["Id"];
                    categoria.Descripcion = (string)conexion.lector["Descripcion"];

                    listadoCategoria.Add(categoria);
                }

                return listadoCategoria;
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

        public void AgregarNuevo(Categoria categoria)
        {
            AccesoDatos conexion = null;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@Descripcion", categoria.Descripcion);
                conexion.EjecutarAccion("insert into CATEGORIAS values (@Descripcion)");
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

        public void EliminarFisico(Categoria categoria)
        {
            AccesoDatos conexion = null;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@Id", categoria.Id.ToString());

                conexion.EjecutarAccion("delete from CATEGORIAS where Id = @Id");
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
