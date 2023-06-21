using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dominio
{
        public enum TipoUsuario
        {
           ADMIN=1,
           ARTISTA=2,
        }
        public class Usuario
        {
            public string password { get; set; }
            public string email { get; set; }
            public int idUsuario { get; set; }
            public TipoUsuario userTipo {get; set; }

            public Usuario(string uemail, string pass, bool admin)
            {
                email = uemail;
                password = pass;
                userTipo = admin ? TipoUsuario.ADMIN : TipoUsuario.ARTISTA; // True o false segun sea admin o artista
            }

        public bool isAdmin()
        {
            if (((Dominio.Usuario)HttpContext.Current.Session["user"]).userTipo == Dominio.TipoUsuario.ADMIN)
            {
                return true;
            }
            return false;
        }
        public bool isArtista()
        {
            if (((Dominio.Usuario)HttpContext.Current.Session["user"]).userTipo == Dominio.TipoUsuario.ARTISTA)
            {
                return true;
            }
            return false;
        }
       
    }
}