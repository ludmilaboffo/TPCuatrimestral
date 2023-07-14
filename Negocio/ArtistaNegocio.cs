
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
                datos.setConsulta("SELECT Id, Mail, Contrasena, Estado, TipoUsuario, ImgPerfil from Usuarios WHERE Mail = @email AND Contrasena = @pass");
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
                    user.estadoArtista = (bool)datos.Lector["Estado"];
                    if (!(datos.Lector["ImgPerfil"]is DBNull))
                        user.imgPerfil = (string)datos.Lector["ImgPerfil"];
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
                comando.CommandText = "SELECT  Id, Dni, Contrasena, Mail, ImgPerfil, Telefono, TipoEspectaculo, RedesSociales, Nombre, Apellido, TipoUsuario, Estado FROM Usuarios ";
                if (id != "")
                    comando.CommandText += " WHERE Id= " + id;
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Artista nuevo = new Artista();
                   
                   
                    nuevo.idArtista = (int)lector["Id"];
                    nuevo.nombreArtista= lector["Nombre"] != DBNull.Value ? (string)lector["Nombre"] : null;
                    nuevo.mailArtista = (string)lector["Mail"];
                    nuevo.apellidoArtista = lector["Apellido"] != DBNull.Value ? (string)lector["Apellido"] : null;
                    nuevo.contrasenaArtista = (string)lector["Contrasena"];
                    nuevo.dniArtista = lector["Dni"] != DBNull.Value ? (string)lector["Dni"] : null;
                    nuevo.telefonoArtista = lector["Telefono"] != DBNull.Value ? (string)lector["Telefono"] : null;
                    nuevo.tipoEspectaculo= lector["TipoEspectaculo"] != DBNull.Value ? (string)lector["TipoEspectaculo"] : null;
                    nuevo.redesSociales = lector["RedesSociales"] != DBNull.Value ? (string)lector["RedesSociales"] : null;
                    nuevo.imgPerfil = lector["ImgPerfil"] != DBNull.Value ? (string)lector["ImgPerfil"] : null;
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
                    nuevo.nombreArtista= datos.Lector["Nombre"] != DBNull.Value ? datos.Lector["Nombre"].ToString() : null;
                    nuevo.mailArtista = (string)datos.Lector["Mail"];
                    nuevo.apellidoArtista = datos.Lector["Apellido"] != DBNull.Value ? datos.Lector["Apellido"].ToString() : null;
                    nuevo.contrasenaArtista = (string)datos.Lector["Contrasena"];
                    nuevo.dniArtista = datos.Lector["Dni"] != DBNull.Value ? datos.Lector["Dni"].ToString() : null;
                    nuevo.telefonoArtista = datos.Lector["Telefono"] != DBNull.Value ? datos.Lector["Telefono"].ToString() : null;
                    nuevo.tipoEspectaculo = datos.Lector["TipoEspectaculo"] != DBNull.Value ? datos.Lector["TipoEspectaculo"].ToString() : null;
                    nuevo.redesSociales = datos.Lector["RedesSociales"] != DBNull.Value ? datos.Lector["RedesSociales"].ToString() : null;
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
    
                datos.setConsulta("update usuarios set ImgPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, RedesSociales = @redes, TipoEspectaculo = @tipoShow, Telefono = @telefono, Dni = @dni where id = @id");//agregar todas las propiedades del perfil
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

