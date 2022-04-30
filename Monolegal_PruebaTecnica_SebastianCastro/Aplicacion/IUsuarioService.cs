using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Aplicacion
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> GetUsuario(string id);
        Task<UsuarioDto> CreateUsuario(UsuarioDto dto);
        Task<UsuarioDto> UpdateUsuario(string id , UsuarioDto dto);
    }
}
