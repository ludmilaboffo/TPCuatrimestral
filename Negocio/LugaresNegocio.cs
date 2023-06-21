using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class LugaresNegocio
    {


        public List<Lugar> listar(string id = "")
        {
            List<Lugar> lista = new List<Lugar>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT Id, Direccion, Descripcion, Nombre, Estado, UrlImagen FROM Lugares";

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Lugar aux = new Lugar();

                    aux.idLugar = (int)datos.Lector["Id"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Disponibilidad = (bool)datos.Lector["Estado"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}