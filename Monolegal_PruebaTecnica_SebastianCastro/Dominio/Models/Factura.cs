using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using System;

namespace Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models
{
    [BsonIgnoreExtraElements]
    public class Factura
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }
        public string Codigo { get; protected set; }
        public string Cliente { get; protected set; }
        public string ClienteId { get; protected set; }
        public string Ciudad { get; protected set; }
        public string Nit { get; protected set; }
        public double TotalFactura { get; protected set; }
        public double SubTotal { get; protected set; }
        public double Iva { get; protected set; }
        public double Retencion { get; protected set; }
        public DateTime FechaCreacion { get; protected set; }
        public string Estado { get; protected set; }
        public bool Pagada { get; protected set; }
        public DateTime FechaDePago { get; protected set; }

        public Factura(FacturaDto dto, Usuario usuario)
        {
            Codigo = dto.Codigo;
            Cliente = usuario.Name;
            ClienteId = usuario.Id;
            Ciudad = dto.Ciudad;
            Nit = dto.Nit;
            TotalFactura = dto.TotalFactura ;
            SubTotal = dto.SubTotal;
            Iva = dto.Iva;
            Retencion = dto.Retencion ;
            FechaCreacion = dto.FechaCreacion;
            Estado = "PrimerRecordatorio";
            Pagada = false;
        }

        internal Factura ActualizarEstado(string estado)
        {
            this.Estado = estado;
            return this;
            
        }

        internal Factura ActualizarPago(bool pagada)
        {
            this.Pagada = pagada;
            this.FechaDePago = DateTime.Now;
            return this;

        }

    }
}
