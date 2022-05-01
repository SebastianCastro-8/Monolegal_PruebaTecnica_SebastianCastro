import { Component, OnInit } from '@angular/core';
import { usuarios } from '../../models/clientes.interface';
import { ApiService } from '../../services/api/api.service';
import { SendMailService } from '../../services/mail/send-mail.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {
  _clientes:usuarios[] = [];
  _clientesUP:usuarios[] = [];

  constructor(private api:ApiService, private _messageService: SendMailService) { }

  ngOnInit(): void {
    this.cargarData();    
  }
  cargarData(){
    this.api.get().subscribe(data =>{
      this._clientes = data;
      console.log(this._clientes);
     
    });
  }

  UpdateClient(_id:string){

    
    const result = this._clientes.filter(client_ => client_._id == _id);
    let resultEmail = result;
    
    console.log(resultEmail[0]);
    this._messageService.sendMessage(resultEmail).subscribe(()=>{});

    alert('El Mensaje Fue Enviado');
    setTimeout(() =>{
      
        if(result[0].estado == 'primerRecordatorio'){ 
          result[0].estado = 'segundoRecordatorio';
        }
        else if(result[0].estado == 'segundoRecordatorio'){ 
          result[0].estado = 'desactivado'; 
        }

        console.log(resultEmail[0]);
        this.api.update(result[0],_id).subscribe();
      },1000);

  
  }

}
