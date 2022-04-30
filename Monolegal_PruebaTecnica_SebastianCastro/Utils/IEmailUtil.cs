using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Utils
{
    public interface IEmailUtil
    {
        Task SendMail (Factura factura, string facturaPrev);

    }
}
