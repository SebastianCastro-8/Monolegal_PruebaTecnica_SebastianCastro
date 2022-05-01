import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { facturas } from '../../models/clientes.interface';
import { usuarios } from '../../models/usuario.interface';
import { ApiService } from '../../services/api/api.service';

@Component({
  selector: 'app-crear',
  templateUrl: './crear.component.html',
  styleUrls: ['./crear.component.scss'],
})
export class CrearComponent implements OnInit {
  _clientes: usuarios[] = [];
  titulo = 'Agregar Factura';

  newCliente = new FormGroup({
    clientes : new FormControl('', Validators.required),
    codigo: new FormControl('', Validators.required),
    ciudad: new FormControl('', Validators.required),
    nit: new FormControl('', Validators.required),
    totalFactura: new FormControl('', Validators.required),
    subTotal: new FormControl('', Validators.required),
    iva: new FormControl('', Validators.required),
    retencion: new FormControl('', Validators.required),
    fechaCreacion: new FormControl('', Validators.required),
    
  });

  constructor(private api: ApiService) {}

  ngOnInit(): void {

    this.api.getAllUser().subscribe((data) => {
      this._clientes = data;
      console.log(data);
    });
  }

  onCreated(form: facturas) {
   var idCliente=this.newCliente.controls.clientes.value;


    this.api.create(form,idCliente).subscribe((data) => {
      console.log(data);
    });

    alert('Nuevo Cliente Agregado');
  }
}
