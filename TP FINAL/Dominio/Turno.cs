using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Turno
    {
            public DateTime Fecha { get; set; }
            public Lugar Lugar { get; set; }
            public Usuario Usuario { get; set; }
    }
}