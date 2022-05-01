import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api/api.service';
import { usuarios } from '../../models/clientes.interface';

@Component({
  selector: 'app-crear',
  templateUrl: './crear.component.html',
  styleUrls: ['./crear.component.scss']
})
export class CrearComponent implements OnInit {
  
  titulo = 'Agregar Factura';


  ngCodigoDeFactura:string = '';
  ngCliente:string = '';
  ngCiudad:string = '';
  ngNit:string = '';
  ngFactura:string = '';
  ngSubTotal:string = '';
  ngIva:string = '';
  ngRetencion:string = '';
  ngFechaCreacion:string = '';

  newCliente = new FormGroup({

    CodigoFactura   : new FormControl('',Validators.required),
    cliente           : new FormControl('',Validators.required),
    ciudad            : new FormControl('',Validators.required),
    nit               : new FormControl('',Validators.required),
    factura           : new FormControl('',Validators.required),
    subTotal          : new FormControl('',Validators.required),
    iva               : new FormControl('',Validators.required),
    retencion         : new FormControl('',Validators.required),
    fechaCreacion     : new FormControl('',Validators.required),
    estado            : new FormControl('primerRecordatorio',Validators.required),
    pagada            : new FormControl(false,Validators.required),
    fechaDePago       : new FormControl('',Validators.required),

  });



  constructor(private api:ApiService) { 

  }

  ngOnInit(): void {
  }
  
  onCreated(form:usuarios){
    var date_ = new Date();
    var id_generate = `${date_.getMonth()}${date_.getFullYear()}${date_.getDay()}${date_.getMilliseconds()}`;

    form._id = id_generate;

    this.api.create(form).subscribe(
      data=>{
        console.log(data);
      }
    );
    alert('Nuevo Cliente Agregado');
    this.clearAllinputs();
  }

  clearAllinputs(){
    this.ngCodigoDeFactura = '';
    this.ngCliente = '';
    this.ngCiudad = '';
    this.ngNit = '';
    this.ngFactura = '';
    this.ngSubTotal = '';
    this.ngIva = '';
    this.ngRetencion = '';
    this.ngFechaCreacion = '';
  }


}
