using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Utils
{
    public class EmailUtil : IEmailUtil
    {
        private static string email = "1y3enviossas@gmail.com";
        private static string password = "envios1y3*";
        public async Task SendMail(Factura factura , string facturaPrev)
        {
            try
            {
                string subject = "Cambio de estado de factura";
                string body = GetHtml(factura, facturaPrev);
                MailMessage message = new MailMessage(email, "jhocastro@uniboyaca.edu.co", subject, body);
                message.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 25;
                smtpClient.Credentials = new NetworkCredential(email, password);
                await smtpClient.SendMailAsync(message);
                smtpClient.Dispose();
            }
            catch (Exception e)
            {

                throw e;
            }
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
