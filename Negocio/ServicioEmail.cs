using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class ServicioEmail
    {
        private MailMessage email;
        private SmtpClient servidor;

        public ServicioEmail()
        {
            servidor = new SmtpClient();
            servidor.Credentials = new NetworkCredential("artistasdebsas@gmail.com", "cxbdyjbxdfawepih");
            servidor.EnableSsl = true;
            servidor.Port = 587;
            servidor.Host = "smtp.gmail.com";
        }

        public void correoAEnviar(string destino, string asunto, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponderciudadbsas@address.com");
            email.To.Add(destino);
            email.Subject = asunto;
            email.Body = mensaje;
        }
        public void enviarCorreo()
        {
            try
            {
                servidor.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}