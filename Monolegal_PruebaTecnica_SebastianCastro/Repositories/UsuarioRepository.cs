using AutoMapper;
using MongoDB.Driver;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using Monolegal_PruebaTecnica_SebastianCastro.Repositories.Mongo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoDb mongoDb;
    

        public UsuarioRepository(IMongoDb mongoDb)
        {
            this.mongoDb = mongoDb;
           
        }
        public async Task<Usuario> Create(Usuario usuario)
        {
            await mongoDb.Usuario.InsertOneAsync(usuario);
            return usuario;
        }

        public async Task<Usuario> Get(string id)
        {
            var usuario = await mongoDb.Usuario.Find(x => x.Id == id).FirstOrDefaultAsync();
            return usuario;
        }
        public async Task<IList<Usuario>> GetAll()
        {
            var usuario = await mongoDb.Usuario.Find(_ => true).ToListAsync();
            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            await mongoDb.Usuario.ReplaceOneAsync(filter: x => x.Id == usuario.Id, usuario);
            return usuario;
        }
    }
}
