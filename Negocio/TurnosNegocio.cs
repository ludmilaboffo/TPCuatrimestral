using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.SqlClient;
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

        public List<Turno> listar(string id = " ")
        {
            List<Turno> lista = new List<Turno>();     
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion = new SqlConnection("server =.\\SQLEXPRESS; database = FreeShowMusic; integrated security = true");
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText= "SELECT idTurnos, idLugar, idUsuario, idFecha, Estado FROM Turnos ";
                if (id != "")       
                comando.CommandText += " WHERE idTurnos= " + id;
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();                
                while (lector.Read())
                {
                    Turno nuevo = new Turno();
                    LugaresNegocio nov = new LugaresNegocio();
                    FechaNegocio date = new FechaNegocio();

                    nuevo.idTurno = (int)lector["idTurnos"];
                    nuevo.Lugar = new Lugar();
                    nuevo.Lugar.idLugar = (int)lector["idLugar"];
                    nuevo.Lugar.Nombre= nov.buscarLugar(nuevo.Lugar.idLugar);
                    nuevo.Fecha = new Fecha();
                    nuevo.Fecha.idFecha = (int)lector["idFecha"];
                    nuevo.Fecha.descripcionFecha = date.retornarNombreDia(nuevo.Fecha.idFecha);
                    nuevo.Fecha.numeroFecha = date.retornarNumeroDia(nuevo.Fecha.idFecha);
                    nuevo.idUsuario = (int)lector["idUsuario"];
                    nuevo.disponibilidad = (bool)lector["Estado"];
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
                conexion.Close();
            }

        }
        public List<Turno> listarSP()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimieto("ST_ListarTurnos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno nuevo = new Turno();
                    LugaresNegocio nov = new LugaresNegocio();
                    FechaNegocio date = new FechaNegocio();

                    nuevo.idTurno = (int)datos.Lector["idTurnos"];
                    nuevo.Lugar = new Lugar();
                    nuevo.Lugar.idLugar = (int)datos.Lector["idLugar"];
                    nuevo.Lugar.Nombre = nov.buscarLugar(nuevo.Lugar.idLugar);
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
        public void modificarConSP(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setProcedimieto("ST_ModificarTurnos");
            datos.setParametro("@idTurnos", nuevo.idTurno);
            datos.setParametro("@idFecha", nuevo.Fecha.idFecha);
            datos.setParametro("@idLugar", nuevo.Lugar.idLugar);
            datos.setParametro("@idUsuario", nuevo.idUsuario);
            datos.setParametro("@Estado", true);
            datos.ejecutarAccion();
        }
    }

}