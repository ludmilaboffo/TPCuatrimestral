﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class LugaresNegocio
    {

        public List<Lugar> ListaLugar;
        public List<Lugar> listar(string id = "")
        {
            List<Lugar> lista = new List<Lugar>();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            AccesoDatos datos = new AccesoDatos();
            SqlCommand comand = new SqlCommand();
            try
            {
                conexion = new SqlConnection("server =.\\SQLEXPRESS; database = StreetART; integrated security = true");
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT idLugar, Direccion, Descripcion, Nombre, Estado, UrlImagen FROM Lugares ";
                if (id != "")
                    comando.CommandText += " WHERE idLugar= " + id;
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Lugar aux = new Lugar();

                    aux.idLugar = (int)lector["idLugar"];
                    aux.Direccion = (string)lector["Direccion"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Disponibilidad = (bool)lector["Estado"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
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

        public void eliminarLogico(int id, bool disponible = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("UPDATE Lugares set Estado = @disponible Where idLugar = @idLugar");
                datos.setParametro("@idLugar", id);
                datos.setParametro("@disponible", disponible);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarConSP(Lugar lugar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimieto("StoredModificarLugar"); 
                datos.setParametro("@idLugar", lugar.idLugar);
                datos.setParametro("@Direccion", lugar.Direccion);
                datos.setParametro("@Descripcion", lugar.Descripcion);
                datos.setParametro("@Nombre", lugar.Nombre);
                datos.setParametro("@Estado", true);
                datos.setParametro("@UrlImagen", lugar.UrlImagen);

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

        public void alta(Lugar nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {


                datos.setConsulta("INSERT INTO Lugares ( Direccion, Descripcion, Nombre, Estado, UrlImagen) VALUES ( @Direccion, @Descripcion, @Nombre, @Estado, @Imagen )");
                datos.setParametro("@Descripcion", nuevo.Descripcion);
                datos.setParametro("@Direccion", nuevo.Direccion);
                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Imagen", nuevo.UrlImagen);
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


        public List<Lugar> listarSP()
        {
            List<Lugar> lista = new List<Lugar>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimieto("StoredListarLugares");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Lugar nuevo = new Lugar();

                    nuevo.idLugar = (int)datos.Lector["idLugar"];
                    nuevo.Direccion = (string)datos.Lector["Direccion"];
                    nuevo.Descripcion = (string)datos.Lector["Descripcion"];
                    nuevo.Nombre = (string)datos.Lector["Nombre"];
                    nuevo.UrlImagen = (string)datos.Lector["UrlImagen"];
                    nuevo.Disponibilidad = (bool)datos.Lector["Estado"];               
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

        public void eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("delete from Turnos where idLugares = @idLugar");
                datos.setParametro("@idLugar", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string buscarLugar(int id)
        {
            List<Lugar> ListaLugar;
            LugaresNegocio obj = new LugaresNegocio();
            ListaLugar = obj.listar();

            foreach (Lugar lugar in ListaLugar)
            {
                if (lugar.idLugar == id)
                {
                    return lugar.Nombre;
                }
            }
            return "No existe";
        }



    }
}