using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Aplicacion
{
    public interface IFacturaService
    {
        Task<FacturaDto> CrearFactura(FacturaDto dto, string idUsuario);
        Task<FacturaDto> GetFacturaById(string id);
        Task<IList<FacturaDto>> GetAllFacturas();
        Task<FacturaDto> UpdateFactura(string id);
    }
}
