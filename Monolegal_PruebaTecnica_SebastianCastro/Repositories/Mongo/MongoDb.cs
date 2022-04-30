using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;

namespace Monolegal_PruebaTecnica_SebastianCastro.Repositories.Mongo
{
    public class MongoDb : IMongoDb
    {
        public readonly IMongoDatabase _database;

        public MongoDb(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration["ConnectionString:mongoCont"]);
            _database = client.GetDatabase("MonolegalPrueba");
        }

        public IMongoCollection<Usuario> Usuario => _database.GetCollection<Usuario>("Usuarios");

        public IMongoCollection<Factura> Factura => _database.GetCollection<Factura>("Facturas");
    }

}
