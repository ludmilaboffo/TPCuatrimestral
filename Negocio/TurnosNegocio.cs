using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Negocio
{
    public class TurnosNegocio
    {

        public void altaSP(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimieto("ST_AltaTurno");
                datos.setParametro("@idFecha", nuevo.Fecha.idFecha);
                datos.setParametro("@idLugar", nuevo.Lugar.idLugar);
                datos.setParametro("@idUsuario", nuevo.idUsuario);
                datos.setParametro("@Estado", true);
                datos.ejecutarAccion();
            }
            catch(Exception ex){
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void alta(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO Turnos (idFecha, idLugar, idUsuario, Estado) VALUES (@idFecha, @idLugar, @idUsuario, @Estado)");
                datos.setParametro("@idFecha", nuevo.Fecha.idFecha);
                datos.setParametro("@idLugar", nuevo.Lugar.idLugar);
                datos.setParametro("@idUsuario", nuevo.idUsuario);
                datos.setParametro("@Estado", true);
                datos.ejecutarAccion();
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

        public List<Turno> listar(string id = "")
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "  SELECT idTurnos, idFecha, idLugar, idUsuario, Estado FROM Turnos";

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno nuevo = new Turno();
                    LugaresNegocio nov = new LugaresNegocio();
                    FechaNegocio date = new FechaNegocio();

                    nuevo.idTurno = (int)datos.Lector["idTurnos"];
                    nuevo.Lugar = new Lugar();
                    nuevo.Lugar.idLugar = (int)datos.Lector["idLugar"];
                    nuevo.Lugar.Nombre= nov.buscarLugar(nuevo.Lugar.idLugar);
                    nuevo.Fecha = new Fecha();
                    nuevo.Fecha.idFecha = (int)datos.Lector["idFecha"];
                    nuevo.Fecha.descripcionFecha = date.retornarNombreDia(nuevo.Fecha.idFecha);
                    nuevo.Fecha.numeroFecha = date.retornarNumeroDia(nuevo.Fecha.idFecha);
                    nuevo.idUsuario = (int)datos.Lector["idUsuario"];
                    nuevo.disponibilidad = (bool)datos.Lector["Estado"];
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

    }

}