using Microsoft.AspNetCore.Mvc;
using Monolegal_PruebaTecnica_SebastianCastro.Aplicacion;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using Monolegal_PruebaTecnica_SebastianCastro.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController:ControllerBase
    {
        private IUsuarioService usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("getById/{id}")]

        public async Task<UsuarioDto> Get(string id)
        {
            return await usuarioService.GetUsuario(id);
        }


        [HttpGet]
        [Route("GetAllUsuarios")]

        public async Task<IList<UsuarioDto>> GetAllUsuarios()
        {
            return await usuarioService.GetAllUsuarios();
        }


        [HttpPost]
        public async Task<UsuarioDto> Post(UsuarioDto dto)
        {
            return await usuarioService.CreateUsuario(dto);
        }


        [HttpPut]
        [Route("putById/{id}")]
        public async Task<UsuarioDto> Put(string id, UsuarioDto dto)
        {
            
            return await usuarioService.UpdateUsuario(id, dto);
        }
    }
}

