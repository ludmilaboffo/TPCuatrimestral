using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;

namespace TP_Programacion3
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int id)
        {
            this.ID = id;
        }
        public string nombre { get; set; }
        public string Apellido { get; set; }
        public int ID { get; set; }
        public string DNI { get; set; }
        public MailAddress Mail { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public bool estado { get; set; }
        public string URLimagen { get; set; }
        public string contraseña { get; set; }

    }
}