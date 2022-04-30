using AutoMapper;
using MongoDB.Driver;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using Monolegal_PruebaTecnica_SebastianCastro.Repositories.Mongo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IMongoDb mongoDb;
       

        public FacturaRepository(IMongoDb mongoDb)
        {
            this.mongoDb = mongoDb;
           
        }

        public async Task<Factura> Create(Factura factura)
        {
           await mongoDb.Factura.InsertOneAsync(factura);
            return factura;
        }

        public async Task<Factura> Get(string id)
        {
           var factura = await mongoDb.Factura.Find(x => x.Id == id).FirstOrDefaultAsync();
            return factura;
        }

        public async Task<IList<Factura>> GetAll()
        {
            var factura = await mongoDb.Factura.Find(_=>true).ToListAsync();
            return factura;
        }

        public async Task<Factura> Update(Factura factura)
        {
            await mongoDb.Factura.ReplaceOneAsync(filter: x => x.Id == factura.Id,factura);
            return factura;
        }
    }
}
