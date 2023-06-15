using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TP_Programacion3;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar (string id = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT Dni, Contrasena, Mail, Telefono, Direccion, Estado, Nombre, Apellido FROM Usuarios";

                datos.setConsulta (consulta);
                datos.ejecutarLectura(); 

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.DNI = (string)datos.Lector["Dni"];
                    aux.contraseña = (string)datos.Lector["Contrasena"];
                    aux.Mail = (MailAddress)datos.Lector["Mail"];
                    aux.telefono = (string)datos.Lector["Telefono"];
                    aux.direccion = (string)datos.Lector["Direccion"];
                    aux.estado = (bool)datos.Lector["Estado"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.apellido = (string)datos.Lector["Apellido"];

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
