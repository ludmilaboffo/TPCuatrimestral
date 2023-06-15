using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Programacion3
{
    public class TurnosClass
    {

        public TurnosClass() { }
        public DateTime Fecha { get; set; }
        public Lugares Lugar { get; set; }
        public Usuario Usuario { get; set; }
    }
}