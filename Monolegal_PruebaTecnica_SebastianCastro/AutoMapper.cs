using AutoMapper;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;

namespace Monolegal_PruebaTecnica_SebastianCastro
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Factura, FacturaDto>();
        }
    }
}
