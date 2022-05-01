using AutoMapper;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using Monolegal_PruebaTecnica_SebastianCastro.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Aplicacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioDto> CreateUsuario(UsuarioDto dto)
        {
            var usuario = new Usuario(dto.Name, dto.Email);
            var usuarioNuevo = await usuarioRepository.Create(usuario);
            return mapper.Map<UsuarioDto>(usuarioNuevo);
        }

        public async Task<UsuarioDto> GetUsuario(string id)
        {
            var usuario = await usuarioRepository.Get(id);
            return mapper.Map<UsuarioDto>(usuario);
        }
        public async Task<IList<UsuarioDto>> GetAllUsuarios()
        {
            return mapper.Map<IList<UsuarioDto>>(await usuarioRepository.GetAll());
        }
        public async Task<UsuarioDto> UpdateUsuario(string id, UsuarioDto dto)
        {
            var usuario = await usuarioRepository.Get(id);
            usuario.Actualizar(dto.Ciudad);
            var usuarioUpdate = await usuarioRepository.Update(usuario);
            return mapper.Map<UsuarioDto>(usuarioUpdate);
        }
    }
}
