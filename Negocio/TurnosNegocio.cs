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

        public void altaSP(Turno nuevo) /// ESTE DA EL ALTA PARA LOS USUARIOS ARTISTAS
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimieto("StoredAltaTurno");
                datos.setParametro("@idFecha", nuevo.Fecha.idFecha);
                datos.setParametro("@idLugar", nuevo.Lugar.idLugar);
                datos.setParametro("@idUsuario", nuevo.idUsuario);
                datos.setParametro("@Estado", true);
                datos.setParametro("@Ocupado", true);
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
                datos.setParametro("@Ocupado", false);
                datos.ejecutarAccion();
                /// Este procedimiento tiene una subconsulta: si la fecha existe en la tabla de turnos
                /// y se relaciona con ese id de Lugar, da de baja esa fecha para ese lugar
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
                comando.CommandText = "SELECT T.idTurnos, T.Ocupado, T.idFecha, T.idLugar, T.idUsuario, T.Estado, L.Nombre, F.numeroDia, F.descripcionDia FROM Turnos T INNER JOIN Fechas F ON F.idFecha = T.idFecha INNER JOIN Lugares L ON L.idLugar = T.idLugar ";
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
                    nuevo.Lugar.Nombre = (string)lector["Nombre"];
                    nuevo.Lugar.Disponibilidad = (bool)lector["Estado"];
                    nuevo.Fecha = new Fecha();
                    nuevo.Fecha.idFecha = (int)lector["idFecha"];
                    nuevo.Fecha.descripcionFecha = (string)lector["descripcionDia"];
                    nuevo.Fecha.numeroFecha = (int)lector["numeroDia"];
                    nuevo.Fecha.Estado = (bool)lector["Estado"];
                    nuevo.idUsuario = (int)lector["idUsuario"];
                    nuevo.disponibilidad = (bool)lector["Estado"];
                    nuevo.ocupado = (bool)lector["Ocupado"];
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
                datos.setProcedimieto("StoredListarTurnos"); /// STORE PROCEDURE CON INNER JOIN A AMBAS TABLAS
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno nuevo = new Turno();


                    nuevo.idTurno = (int)datos.Lector["idTurnos"];
                    nuevo.Lugar = new Lugar();
                    nuevo.Lugar.idLugar = (int)datos.Lector["idLugar"];
                    nuevo.Lugar.Nombre = (string)datos.Lector["Nombre"];
                    nuevo.Lugar.Disponibilidad = (bool)datos.Lector["Estado"];
                    nuevo.Fecha = new Fecha();
                    nuevo.Fecha.idFecha = (int)datos.Lector["idFecha"];
                    nuevo.Fecha.descripcionFecha = (string)datos.Lector["descripcionDia"];
                    nuevo.Fecha.numeroFecha = (int)datos.Lector["numeroDia"];
                    nuevo.Fecha.Estado=(bool)datos.Lector["Estado"];
                    nuevo.idUsuario = (int)datos.Lector["idUsuario"];
                    nuevo.disponibilidad = (bool)datos.Lector["Estado"];
                    nuevo.ocupado = (bool)datos.Lector["Ocupado"];
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
            datos.setParametro("@Ocupado", false);
            datos.ejecutarAccion();
        }

        public void eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("delete from Turnos where idTurnos = @id");
                datos.setParametro("@id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void eliminarLogico(int Id, bool disponible = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("UPDATE Turnos SET Estado = @disponible where idTurnos = @id");
                datos.setParametro("@id", Id);
                datos.setParametro("@disponible", disponible);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void bajaFecha(int lugar)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setProcedimieto("SP_BajaFecha");
            datos.setParametro("@idLugarParam", lugar);
            datos.ejecutarAccion();
            datos.cerrarConexion();
        }
    }

}