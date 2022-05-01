import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { usuarios } from '../../models/clientes.interface';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  url:string = "https://localhost:27017/";

  constructor(private http:HttpClient) { }

  get():Observable<usuarios[]>{
    let getUrl = `${this.url}/clientes`;
    return this.http.get<usuarios[]>(getUrl);
  }

  create(cliente:usuarios):Observable<usuarios>{
    let getUrl = `${this.url}/clientes`;
    return this.http.post<usuarios>(getUrl,cliente);
  }

  update(cliente:usuarios, _id:string):Observable<usuarios>{
    let getUrl = `${this.url}/clientes/${_id}`;
    return this.http.put<usuarios>(getUrl,cliente);
  }
}
