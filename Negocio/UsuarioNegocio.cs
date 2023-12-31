﻿using System;
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
                datos.setConsulta("SELECT Id, Mail, Contrasena, TipoUsuario from Usuarios WHERE Mail = @email AND Contrasena = @pass");
                datos.setParametro("@email", user.email);
                datos.setParametro("@pass", user.password);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.idUsuario = (int)datos.Lector["Id"];                   

                    user.userTipo = (int)(datos.Lector["TipoUsuario"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.ARTISTA;
                    return true;
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