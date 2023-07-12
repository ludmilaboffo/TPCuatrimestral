﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArtistasNegocio
    {



        public bool Loguearse(Artista user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT Id, Mail, Contrasena, TipoUsuario from Usuarios WHERE Mail = @email AND Contrasena = @pass");
                datos.setParametro("@email", user.mailArtista);
                datos.setParametro("@pass", user.contrasenaArtista);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.idArtista = (int)datos.Lector["Id"];
                    user.mailArtista = (string)datos.Lector["Mail"];
                    user.contrasenaArtista = (string)datos.Lector["Contrasena"];
                    user.idArtista= (int)datos.Lector["Id"];
                    user.esArtista = (int)datos.Lector["TipoUsuario"] == 2 ? true : false;
                    return true;
                }
                return false;
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

    public List<Artista> listar(string id = "")
        {

            List<Artista> lista = new List<Artista>();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion = new SqlConnection("server =.\\SQLEXPRESS; database = StreetART; integrated security = true");
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT  Id, Dni, Contrasena, Mail, Telefono, TipoEspectaculo, RedesSociales, Nombre, Apellido, TipoUsuario, Estado FROM Usuarios ";
                if (id != "")
                    comando.CommandText += " WHERE Id= " + id;
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Artista nuevo = new Artista();
                   
                   
                    nuevo.idArtista = (int)lector["Id"];
                    nuevo.nombreArtista= (string)lector["Nombre"];
                    nuevo.mailArtista = (string)lector["Mail"];
                    nuevo.apellidoArtista = (string)lector["Apellido"];
                    nuevo.contrasenaArtista = (string)lector["Contrasena"];
                    nuevo.dniArtista = lector["Dni"] != DBNull.Value ? (string)lector["Dni"] : null;
                    nuevo.telefonoArtista = lector["Telefono"] != DBNull.Value ? (string)lector["Telefono"] : null;
                    nuevo.tipoEspectaculo= lector["TipoEspectaculo"] != DBNull.Value ? (string)lector["TipoEspectaculo"] : null;
                    nuevo.redesSociales = lector["RedesSociales"] != DBNull.Value ? (string)lector["RedesSociales"] : null;
                    // if (!(lector["RedesSociales"] is DBNull))
                    //  nuevo.nombreArtista = (string)lector["RedesSociales"];
                    nuevo.esArtista = true;
                    nuevo.estadoArtista = (bool)lector["Estado"];
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

        public List<Artista> ListarConSp()
        {
            List<Artista> lista = new List<Artista>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimieto("StoredListarUsuarios"); // HACER PROCEDURE
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Artista nuevo = new Artista();

                    nuevo.idArtista = (int)datos.Lector["Id"];
                    nuevo.nombreArtista= (string)datos.Lector["Nombre"];
                    nuevo.mailArtista = (string)datos.Lector["Mail"];
                    nuevo.apellidoArtista = (string)datos.Lector["Apellido"];
                    nuevo.contrasenaArtista = (string)datos.Lector["Contrasena"];
                    nuevo.dniArtista = datos.Lector["Dni"] != DBNull.Value ? (string)datos.Lector["Dni"] : null;
                    nuevo.telefonoArtista = datos.Lector["Telefono"] != DBNull.Value ? (string)datos.Lector["Telefono"] : null;
                    nuevo.tipoEspectaculo = datos.Lector["TipoEspectaculo"] != DBNull.Value ? (string)datos.Lector["TipoEspectaculo"] : null;
                    nuevo.redesSociales = datos.Lector["RedesSociales"] != DBNull.Value ? (string)datos.Lector["RedesSociales"] : null;
                    nuevo.esArtista = true;
                    nuevo.estadoArtista = (bool)datos.Lector["Estado"];
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

        public void eliminarLogico(int Id, bool estado = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("UPDATE Usuarios SET Estado = @estado where Id = @id");
                datos.setParametro("@id", Id);
                datos.setParametro("@estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string buscarArtista(int id)
        {
            List<Artista> ListaArtista;
            ArtistasNegocio art = new ArtistasNegocio();
            ListaArtista = art.listar();

            foreach (Artista artista in ListaArtista)
            {
                if (artista.idArtista == id)
                {
                    return artista.nombreArtista;
                }
            }
            return " ";
        }

        public void actualizar(Artista user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
    
                datos.setConsulta("update usuarios set UrlImgPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, RedesSociales = @redes, TipoEspectaculo = @tipoShow, Telefono = @telefono, Dni = @dni where id = @id");//agregar todas las propiedades del perfil
                datos.setParametro("@imagen", (object)user.imgPerfil ?? DBNull.Value);
                datos.setParametro("@nombre", (object)user.nombreArtista ?? DBNull.Value);
                datos.setParametro("@apellido", (object)user.apellidoArtista ?? DBNull.Value);
                datos.setParametro("@tiposhow", (object)user.tipoEspectaculo ?? DBNull.Value);
                datos.setParametro("@redes", (object)user.redesSociales ?? DBNull.Value);
                datos.setParametro("telefono", (object)user.telefonoArtista ?? DBNull.Value);
                datos.setParametro("@dni", (object)user.dniArtista ?? DBNull.Value);
                datos.setParametro("@id", (object)user.idArtista ?? DBNull.Value);
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

        public int insertarNuevo(Artista nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimieto("InsertarNuevo"); // AL INSERTAR, SE ROMPE POR NO TENER CARGADO LOS NOT NULL DE USUARIO, HACER UPDATE Y PERMITIR DATOS EN NULL EN BASE DE DATOS DE USUARIO
                datos.setParametro("@email", nuevo.mailArtista);
                datos.setParametro("@pass", nuevo.contrasenaArtista);
                return datos.EjecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { 
                datos.cerrarConexion(); 
            }
        }
    }
}

