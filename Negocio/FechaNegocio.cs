﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Negocio
{
    public class FechaNegocio
    {
        public List<Fecha> listar(string id = "")
        {
            List<Fecha> lista = new List<Fecha>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "  SELECT idFecha, numeroDia, descripcionDia FROM FECHAS";

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Fecha nuevo = new Fecha();

                    nuevo.idFecha = (int)datos.Lector["idFecha"];               
                    nuevo.numeroFecha = (int)datos.Lector["numeroDia"];
                    nuevo.descripcionFecha = (string)datos.Lector["descripcionDia"];
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
    }
}