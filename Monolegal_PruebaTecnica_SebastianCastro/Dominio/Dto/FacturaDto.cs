using System;

namespace Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto
{
    public class FacturaDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string Ciudad { get; set; }
        public string Nit { get; set; }
        public double TotalFactura { get; set; }
        public double SubTotal { get; set; }
        public double Iva { get; set; }
        public double Retencion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public bool Pagada { get; set; }
        public DateTime FechaDePago { get; set; }
    }
}
