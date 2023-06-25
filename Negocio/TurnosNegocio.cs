using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Negocio
{
    public class TurnosNegocio
    {
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

                    nuevo.idTurno = (int)datos.Lector["idTurnos"];
                    Lugar lugar = new Lugar();
                    lugar.idLugar = (int)datos.Lector["idLugar"];
                    nuevo.nombreLugar = buscarLugar(lugar.idLugar);
                    nuevo.idFecha = (int)datos.Lector["idFecha"];
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

        public string buscarLugar(int id)
        {
            List<Lugar> ListaLugar;
            LugaresNegocio obj = new LugaresNegocio();
            ListaLugar = obj.listar();
            
            foreach(Lugar  lugar in ListaLugar)
            {
                if(lugar.idLugar == id)
                {
                    return lugar.Nombre;
                }
            }
            return "No existe";
        }
    }

}