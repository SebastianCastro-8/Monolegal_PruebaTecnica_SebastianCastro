using AutoMapper;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using Monolegal_PruebaTecnica_SebastianCastro.Repositories;
using Monolegal_PruebaTecnica_SebastianCastro.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Aplicacion
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository facturaRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper Mapper;
        private readonly IEmailUtil EmailUtil;

        public FacturaService(IFacturaRepository facturaRepository, IUsuarioRepository usuarioRepository, IMapper mapper, IEmailUtil emailUtil)
        {
            this.facturaRepository = facturaRepository;
            this.usuarioRepository = usuarioRepository;
            Mapper = mapper;
            EmailUtil = emailUtil;
        }

        public async Task<FacturaDto> CrearFactura(FacturaDto dto,string idUsuario)
        {
            var usuario = await usuarioRepository.Get(idUsuario);
            var newFactura = new Factura(dto, usuario);
            var factura =await facturaRepository.Create(newFactura);
            return Mapper.Map<FacturaDto>(factura);
        }

        public async Task<IList<FacturaDto>> GetAllFacturas()
        {
            return Mapper.Map<IList<FacturaDto>>(await facturaRepository.GetAll());
        }

        public async Task<FacturaDto> GetFacturaById(string id)
        {
            return Mapper.Map<FacturaDto>(await facturaRepository.Get(id));
        }

        public async Task<FacturaDto> UpdateFactura(string idFactura)
        {
            var factura = await facturaRepository.Get(idFactura);
            var newFactura = factura.ActualizarEstado(await ActualizarEstadoFactura(factura.Estado, factura));
            var updateFactura = await facturaRepository.Update(newFactura);
            return Mapper.Map<FacturaDto>(updateFactura);

        }

        private async Task<string> ActualizarEstadoFactura(string estadoActual , Factura factura)
        {
            if (estadoActual == "PrimerRecordatorio")
            {
                estadoActual = "SegundoRecordatorio";
               await EmailUtil.SendMail(factura, estadoActual);

            }else if (estadoActual == "SegundoRecordatorio")
            {
                estadoActual = "Desactivado";
               await  EmailUtil.SendMail(factura, estadoActual);
            }
            return estadoActual;
        }
    }
}
