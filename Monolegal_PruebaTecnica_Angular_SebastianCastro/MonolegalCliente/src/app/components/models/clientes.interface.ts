export interface usuarios {
  _id: string;
  codigoDeFactura: string;
  cliente: string;
  ciudad: string;
  nit: string;
  factura: number;
  subTotal: number;
  iva: number;
  retencion: number;
  fechaCreacion: Date;
  estado: string;
  pagada: boolean;
  fechaDePago: string;
}
