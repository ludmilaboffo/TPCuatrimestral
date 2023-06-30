using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguearse(Usuario user)
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
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}