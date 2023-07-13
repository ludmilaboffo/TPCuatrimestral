using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public static class seguridad
    {
        public static bool sesionActiva(object user)
        {
            Artista usuario = user != null ? (Artista)user : null;
            if (usuario != null && usuario.idArtista != 0)
            
                return true;
            else 
                return false; 
        }

        public static bool esAdministrador(object user)
        {
            Artista artista = user != null ? (Artista)user : null;

            return artista!=null ? artista.esArtista : false; /// SI ES ARTISTA RETORNA TRUE, SI ES ADMIN FALSE
        }
    }
}