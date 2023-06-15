using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{ 
    public class Lugar
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }

        //  public string URLimagen {get; set; }
    }
}