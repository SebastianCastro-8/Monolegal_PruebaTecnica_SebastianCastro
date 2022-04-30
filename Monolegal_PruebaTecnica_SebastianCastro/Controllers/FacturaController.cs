using Microsoft.AspNetCore.Mvc;
using Monolegal_PruebaTecnica_SebastianCastro.Aplicacion;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController:ControllerBase
    {

        private IFacturaService FacturaService;

        public FacturaController(IFacturaService facturaService)
        {
            FacturaService = facturaService;
        }

        [HttpGet]
        [Route("getById/{id}")]

        public async Task<FacturaDto> Get(string id)
        {
            return await FacturaService.GetFacturaById(id);
        }


        [HttpPost]
        public async Task<FacturaDto> Post(FacturaDto dto,string idUsuario)
        {
            return await FacturaService.CrearFactura(dto ,idUsuario);
        }

        [HttpGet]
        [Route("GetAllFacturas")]

        public async Task<IList<FacturaDto>> GetAllFacturas()
        {
            return await FacturaService.GetAllFacturas();
        }



        [HttpPut]
        public async Task<FacturaDto> Put(string idFactura)
        {
            return await FacturaService.UpdateFactura(idFactura);
        }
    }
}
