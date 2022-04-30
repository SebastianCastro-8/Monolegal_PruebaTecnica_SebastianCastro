using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Repositories
{
    public interface IFacturaRepository
    {
        Task<IList<Factura>> GetAll();
        Task<Factura> Get(string id);
        Task<Factura> Create(Factura factura);
        Task<Factura> Update(Factura factura);
    }
}
