import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { facturas } from '../../models/clientes.interface';
import {HttpClient} from '@angular/common/http';
import { usuarios } from '../../models/usuario.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  url:string = "https://localhost:44375";

  constructor(private http:HttpClient) { }

  get():Observable<facturas[]>{
    let getUrl = `${this.url}/api/Factura/GetAllFacturas`;
    return this.http.get<facturas[]>(getUrl);
  }

  getAllUser():Observable<usuarios[]>{
    let getUrl = `${this.url}/api/Usuarios/GetAllUsuarios`;
    return this.http.get<usuarios[]>(getUrl);
  }

  create(cliente:facturas,_id:string):Observable<facturas>{
    let getUrl = `${this.url}/api/Factura?idUsuario=${_id}`;
    return this.http.post<facturas>(getUrl,cliente);
  }

  update(_id:string):Observable<any>{
    let getUrl = `${this.url}/api/Factura?idFactura=${_id}`;
    return this.http.put(getUrl, _id);
  }
}
