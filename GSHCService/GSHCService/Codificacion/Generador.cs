using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace GSHCService.Codificacion
{
    public class Generador
    {
        private Random random = new Random();
        private String PIN;
        private char Frace;

        public string Generar(String Nombre, String APaterno, String AMaterno, String Telefono)
        {
            try
            {
                GC.Collect();
                do
                {
                    Frace = Nombre[random.Next(Nombre.Length)];
                    if (Frace.ToString() != " ")
                    {
                        PIN += Frace.ToString();
                    }
                } while (Frace.ToString() == " ");

                Frace = APaterno[random.Next(APaterno.Length)];
                PIN += Frace.ToString();
                Frace = AMaterno[random.Next(AMaterno.Length)];
                PIN += Frace.ToString();
                for (int x = 0; x < 3; x++)
                {
                    Frace = Telefono[random.Next(Telefono.Length)];
                    PIN += Frace.ToString();
                }
                GC.GetTotalMemory(true);
                return PIN;
            }
            catch (Exception _e)
            {
                return _e.Message;
            }
        }

        public void EnviarMensaje(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "karen.alv19@gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("karen.alv19@gmail.com", "truelove061215");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendEmail(string token, string correo)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(correo);
            msg.From = new MailAddress("karen.alv19@gmail.com", "Tokens", System.Text.Encoding.UTF8);
            msg.Subject = "PIN";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su PIN de acceso al sistema es la siguiente:" + "\n" +
                "Clave: " + token;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("karen.alv19@gmail.com", "truelove061215");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
               
            }
        }


        public void CuerpoMensaje(string token, string correo)
        {
            string from, to, bcc, cc, subject, body, bodyText;

            from = "karen.alv19@gmail.com";
            to = correo;
            bcc = "";
            cc = "";
            subject = "Envio de Token";
            bodyText = "Su Token de acceso es: " + token;

            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));

            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            EnviarMensaje(mail);

        }
    }
}
    