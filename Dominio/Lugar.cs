using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{ 
    public class Lugar
    {
        public int idLugar { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public bool Disponibilidad { get; set;}
        public string UrlImagen { get; set; }

    }
}