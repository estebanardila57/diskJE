import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Respuesta} from '../models/respuesta';
import {Discos } from  '../models/discos';
import { Observable } from 'rxjs';


const httpOption={
  headers:new HttpHeaders({
    'Contend-Type':'application/json'
  })
}


@Injectable({
  providedIn: 'root'
})
export class ApiDiscosService {
  url:string=environment.baseUrl;
  constructor(private _http:HttpClient) { }

  getDisco():Observable<Respuesta>{
    return this._http.get<Respuesta>(this.url+'Disco');
  }


  addDisco(discos:Discos):Observable<Respuesta>{
    return this._http.post<Respuesta>(this.url+'Disco',discos,httpOption);
  }

  updateDisco(discos:Discos):Observable<Respuesta>{
    return this._http.put<Respuesta>(this.url+'Disco',discos,httpOption)
  }
  
  desactivardisco(id:any):Observable<Respuesta>{
    return this._http.delete<Respuesta>(this.url+"Disco/"+id);
  }
}
