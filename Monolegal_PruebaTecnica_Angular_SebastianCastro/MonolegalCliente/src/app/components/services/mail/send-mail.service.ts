import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SendMailService {

  private url:string = 'http://localhost:3000/formulario';

  constructor(private _http: HttpClient) { }

  sendMessage(body:any) {
    return this._http.post(this.url, body);
    }
}
