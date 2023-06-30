using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Dominio
{
    public class Artista
    {
        public int idArtista { get; set; }
        public string dniArtista { get; set; }
        public string contrasenaArtista { get; set; }
        public string mailArtista { get; set; }
        public string telefonoArtista { get; set; }
        public string direccionArtista { get; set; }
        public string nombreArtista { get; set; }
        public string apellidoArtista { get; set; }
        public bool estadoArtista { get; set; }
        public bool esArtista { get; set; }
    }
}