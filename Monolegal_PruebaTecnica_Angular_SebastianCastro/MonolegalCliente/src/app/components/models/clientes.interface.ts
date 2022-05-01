export interface facturas {
  id: string;
  codigo: string;
  cliente: string;
  ciudad: string;
  nit: string;
  totalFactura: number;
  subTotal: number;
  iva: number;
  retencion: number;
  fechaCreacion: Date;
  estado: string;
  pagada: boolean;
  fechaDePago: string;
}
