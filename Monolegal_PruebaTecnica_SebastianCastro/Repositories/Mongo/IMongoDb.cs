using MongoDB.Driver;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;

namespace Monolegal_PruebaTecnica_SebastianCastro.Repositories.Mongo
{
    public interface IMongoDb
    {
        IMongoCollection<Usuario> Usuario { get; }
        IMongoCollection<Factura> Factura { get; }
    }
}
