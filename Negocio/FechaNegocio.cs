using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Negocio
{
    public class FechaNegocio
    {
        public List<Fecha> listar(string id = "")
        {
            List<Fecha> lista = new List<Fecha>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "  SELECT idFecha, numeroDia, descripcionDia FROM FECHAS";

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Fecha nuevo = new Fecha();

                    nuevo.idFecha = (int)datos.Lector["idFecha"];               
                    nuevo.numeroFecha = (int)datos.Lector["numeroDia"];
                    nuevo.descripcionFecha = (string)datos.Lector["descripcionDia"];
                    lista.Add(nuevo);
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

        public List<Fecha> listarFiltrado(string id = "", int ocupado = 0)
        {
            List<Fecha> lista = new List<Fecha>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimieto("StoredFechaFiltrada");
                datos.setParametro("@id", id);
                datos.setParametro("@ocupado", ocupado);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Fecha nuevo = new Fecha();

                    nuevo.idFecha = (int)datos.Lector["idFecha"];
                    nuevo.numeroFecha = (int)datos.Lector["numeroDia"];
                    nuevo.descripcionFecha = (string)datos.Lector["descripcionDia"];
                    nuevo.Estado = (bool)datos.Lector["Estado"];
                    lista.Add(nuevo);
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


        public List<Fecha> listarFiltradoPorTurno(string id = "")
        {
            List<Fecha> lista = new List<Fecha>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimieto("StoredFechaFiltradaPorTurno");
                datos.setParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Fecha nuevo = new Fecha();

                    nuevo.idFecha = (int)datos.Lector["idFecha"];
                    nuevo.numeroFecha = (int)datos.Lector["numeroDia"];
                    nuevo.descripcionFecha = (string)datos.Lector["descripcionDia"];
                    nuevo.Estado = (bool)datos.Lector["Estado"];
                    lista.Add(nuevo);
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

        public string fechaReservada(int id)
        {
            FechaNegocio fecha = new FechaNegocio();
            List<Fecha> listaFecha;
            listaFecha = fecha.listar();
            foreach(Fecha date in listaFecha)
            {
                if(date.idFecha == id)
                {
                    string reservada = date.numeroFecha + " " + date.descripcionFecha;
                    return reservada;
                }
            }
            return " ";
        }
    }
}