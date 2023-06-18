using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguearse (Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT Id, Contrasena, TipoUsuario from Usuarios WHERE Mail = @email AND Contrasena = @pass");
                datos.setParametro("@email", user.email);
                datos.setParametro("@pass", user.password);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    user.idUsuario = (int)datos.Lector["Id"];
                    user.userTipo = (int)(datos.Lector["TipoUsuario"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.ARTISTA;
                    return true; // Si devuelve true es porque leyo una sola vez y me devuelve ese usuario                }
                }
                return false;
            }
            catch(Exception ex){
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        //public List<Usuario> listar(string id = "")
        //{
        //    List<Usuario> lista = new List<Usuario>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        string consulta = "SELECT Dni, Contrasena, Mail, Telefono, Direccion, Estado, Nombre, Apellido FROM Usuarios";

        //        datos.setConsulta(consulta);
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            Usuario aux = new Usuario();

        //            aux.DNI = (string)datos.Lector["Dni"];
        //            aux.contraseña = (string)datos.Lector["Contrasena"];
        //            aux.Mail = (MailAddress)datos.Lector["Mail"];
        //            aux.telefono = (string)datos.Lector["Telefono"];
        //            aux.direccion = (string)datos.Lector["Direccion"];
        //            aux.estado = (bool)datos.Lector["Estado"];
        //            aux.nombre = (string)datos.Lector["Nombre"];
        //            aux.apellido = (string)datos.Lector["Apellido"];

        //            lista.Add(aux);
        //        }

        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        }
}