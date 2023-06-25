using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Turno
    {
        public Fecha Fecha { get; set; }
        public int idTurno { get; set; }
        public Lugar Lugar { get; set; }        
        public int idUsuario { get; set; }
        public bool disponibilidad { get; set; }

        /// POR DEFECTO EL ID USUARIO SE CARGA EN 1 QUE ES EL ADMIN. Mientras este en 1,
        /// estara disponible también
    }
}
