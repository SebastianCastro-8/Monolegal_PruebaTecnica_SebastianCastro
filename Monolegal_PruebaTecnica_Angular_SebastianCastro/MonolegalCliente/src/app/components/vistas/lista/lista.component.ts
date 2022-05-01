import { Component, OnInit } from '@angular/core';
import { facturas } from '../../models/clientes.interface';
import { ApiService } from '../../services/api/api.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
})
export class ListaComponent implements OnInit {
  _clientes: facturas[] = [];
  _clientesUP: facturas[] = [];

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.cargarData();
  }

  cargarData() {
    this.api.get().subscribe((data) => {
      this._clientes = data;
      console.log(this._clientes);
    });
  }


  UpdateClient(_id:string){
    console.log("id",_id);
    this.api.update(_id).subscribe(data=>{
      console.log("sffsdfsf",data);
      
    });
    window.location.reload();    
  }


  
}
