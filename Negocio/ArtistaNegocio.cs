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



        public List<Artista> listar(string id = "")
        {

            List<Artista> lista = new List<Artista>();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion = new SqlConnection("server =.\\SQLEXPRESS; database = FreeShowMusic; integrated security = true");
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT  Id, Dni, Contrasena, Mail, Telefono, Direccion, Nombre, Apellido, TipoUsuario, Estado FROM Usuarios ";
                if (id != "")
                    comando.CommandText += " WHERE Id= " + id;
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Artista nuevo = new Artista();

                    nuevo.idArtista = (int)lector["Id"];
                    nuevo.contrasenaArtista = (string)lector["Contrasena"];
                    nuevo.dniArtista = (string)lector["Dni"];
                    nuevo.mailArtista = (string)lector["Mail"];
                    nuevo.telefonoArtista = (string)lector["Telefono"];
                    nuevo.direccionArtista = (string)lector["Direccion"];
                    nuevo.nombreArtista = (string)lector["Nombre"];
                    nuevo.apellidoArtista = (string)lector["Apellido"];
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
                    nuevo.nombreArtista = (string)datos.Lector["Nombre"];
                    nuevo.apellidoArtista = (string)datos.Lector["Apellido"];
                    nuevo.mailArtista = (string)datos.Lector["Mail"];
                    nuevo.telefonoArtista = (string)datos.Lector["Telefono"];
                    nuevo.contrasenaArtista = (string)datos.Lector["Contraseña"];
                    nuevo.estadoArtista = (bool)datos.Lector["Estado"];
                    nuevo.direccionArtista = (string)datos.Lector["Direccion"];
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
                datos.setParametro("@stado", estado);
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

    }

}