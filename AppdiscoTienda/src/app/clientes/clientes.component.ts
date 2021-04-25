import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { Cliente } from '../models/cliente';
import { ApiClienteService } from '../services/api-cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  crearCliente:boolean=false;
  lstCliente:any;
  dtOptions:DataTables.Settings={};
  cliente:Cliente={}as Cliente;

  constructor(private formbuilder:FormBuilder,private apiCliente:ApiClienteService) { }
  formulario=this.formbuilder.group({
    nombrecli:['',Validators.required],
    cedulacli:['',Validators.required],
    telefonocli:['',Validators.required],
    direccioncli:['',Validators.required],
   
  });

  ngOnInit(): void {
    this.dtOptions={
      pagingType:'full_numbers',
      pageLength:10
    };
    this.GetCliente();
  }

  /* Metodo para  leer los clientes */
  GetCliente(){
    this.apiCliente.getCliente().subscribe(response=>{
      console.log(response.data)
    this.lstCliente=response.data;
    })
  }
  /* TERMINA Metodo para leer los clientes */

  //Metodo que me recibe un cliente y sus valores se los asigna a los controles del formulario 

    deleteCliente(oCliente:Cliente){
    this.formulario.controls.nombrecli.setValue(oCliente.nombrecli)
    this.formulario.controls.cedulacli.setValue(oCliente.cedulacli)
    this.formulario.controls.telefonocli.setValue(oCliente.telefonocli)
    this.formulario.controls.direccioncli.setValue(oCliente.direccioncli)
    this.crearCliente=true;
      this.cliente.id=oCliente.id
     }
    
 /* Metodo para eliminar un cliente */   
    Deletecliente(){
      this.cliente=Object.assign(this.cliente,this.formulario.value);
      this.apiCliente.deletecliente(this.cliente).subscribe(response=>{
        if(response.codEx==0){
          console.log(response.mensaje);
        }
        alert(response.codEx);
        this.GetCliente();
        this.crearCliente=false;
        this.limpieza();
      })
    }
/* TERMINA Metodo para eliminar cliente */

//Metodo para agregar clientes
 Addcliente(){
   console.log(this.formulario.value)   
   this.cliente=Object.assign(this.cliente,this.formulario.value);
   console.log(this.cliente);
   this.apiCliente.addCliente(this.cliente).subscribe(response=>{
     if(response.codEx==0){
       console.log(response.mensaje);
     }
     alert(response.codEx)
     this.GetCliente();
    this.crearCliente=false;
     this.limpieza();
   })
 }
//Termina metodo para agregar clientes

 //Metodo que me recibe un cliente y sus valores se los asigna a los controles del formulario 

 editCliente(oCliente:Cliente){
  this.formulario.controls.nombrecli.setValue(oCliente.nombrecli)
  this.formulario.controls.cedulacli.setValue(oCliente.cedulacli)
  this.formulario.controls.telefonocli.setValue(oCliente.telefonocli)
  this.formulario.controls.direccioncli.setValue(oCliente.direccioncli)
  this.crearCliente=true;
  this.cliente.id=oCliente.id
  }

//Metodo para actualizar clientes

 Updatecliente(){
  this.cliente=Object.assign(this.cliente,this.formulario.value);
  this.apiCliente.updateCliente(this.cliente).subscribe(response=> {
    if(response.codEx==0){
      alert("Ocurrio un error por"+response.mensaje);
    }
    alert(response.codEx)
    this.GetCliente();
    this.crearCliente=false;
    this.limpieza();
  })
 }
//Termina Metodo para acutalizar cliente
 
// metodo que me ayuda a limipiar los valores del formulario 
limpieza(){
  this.formulario.controls.nombrecli.setValue("")
    this.formulario.controls.cedulacli.setValue("")
    this.formulario.controls.telefonocli.setValue("")
    this.formulario.controls.direccioncli.setValue("")
}

}
