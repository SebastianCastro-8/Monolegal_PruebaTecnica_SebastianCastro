using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Utils
{
    public class EmailUtil : IEmailUtil
    {
        private static string email = "sendmail@triunfandojuntosmtp.com.co";
        private static string password = "Sendmail123@";
        public async Task SendMail(Factura factura , string facturaPrev)
        {
           
                string subject = "Cambio de estado de factura";
                string body = GetHtml(factura, facturaPrev);
                MailMessage message = new MailMessage(email, "jhocastro@uniboyaca.edu.co", subject, body);
                message.IsBodyHtml = true;
               // message.BodyEncoding = UTF8Encoding.UTF8;
                SmtpClient smtpClient = new SmtpClient("smtp-relay.gmail.com");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(email, password);
                smtpClient.Send(message);
                smtpClient.Dispose();
            
        }

        private string GetHtml(Factura factura , string facturaPrev)
        {
            string html;

            using (StreamReader reader = new StreamReader("Utils/Template/Template.html"))
            {
                html = reader.ReadToEnd();

                html = html.Replace("{nombreCliente}", factura.Cliente);
                html = html.Replace("{codigoFactura}", factura.Codigo);
                html = html.Replace("{valorTotal}", factura.TotalFactura.ToString());
                html = html.Replace("{EstadoPrev}", facturaPrev);
                html = html.Replace("{NewEstado}", factura.Estado);

            }
            return html;
        }
    }
}
