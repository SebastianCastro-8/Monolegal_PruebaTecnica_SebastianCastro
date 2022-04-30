using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using System;

namespace Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models
{
    public class Factura
    {
        public Guid Id { get; protected set; }
        public string Codigo { get; protected set; }
        public string Cliente { get; protected set; }
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

        public Factura(FacturaDto dto)
        {
            Codigo = dto.Codigo;
            Cliente = dto.Cliente;
            Ciudad = dto.Ciudad;
            Nit = dto.Nit;
            TotalFactura = dto.TotalFactura ;
            SubTotal = dto.SubTotal;
            Iva = dto.Iva;
            Retencion = dto.Retencion ;
            FechaCreacion = dto.FechaCreacion;
            Estado = dto.Estado;
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
