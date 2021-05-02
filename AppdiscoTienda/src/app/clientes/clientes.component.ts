import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { Cliente } from '../models/cliente';
import { ApiClienteService } from '../services/api-cliente.service';
import Swal from 'sweetalert2';

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
  btneditar:boolean=false;
  submitted:boolean=false;

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

  //estamos renombrando el formulario para dejarlo con este alias para citarlo con mas facilidad en el html
get f() {return this.formulario.controls}

  mostrarclinete(){
     this.btneditar=false;
     this.crearCliente=true;
     this.resetformulario();
  }

  resetformulario(){
    this.formulario.reset();
  }

  /* Metodo para  leer los clientes */
  GetCliente(){
    this.apiCliente.getCliente().subscribe(response=>{
      console.log(response.data)
    this.lstCliente=response.data;
    })
  }
  /* TERMINA Metodo para leer los clientes */


    
 /* Metodo para edesactivar un cliente */   
 DesactivarCliente(cliente:Cliente){
  Swal.fire({
    title: 'Cliente',
    text: '¿Desea cambiar el estado del cliente?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Si, Cambiar',
    cancelButtonText: 'No, cancelar'
  }).then((result) => {
    if (result.value) {
    
      this.apiCliente.desactivarcliente(cliente.id).subscribe(response=>{
        if(response.codEx==0){
          console.log(response.mensaje);
   
        }
        Swal.fire({
          title: 'Disco',
          text: 'El estado del disco se cambió con exito',
          icon: 'success',
          showCancelButton: false,
        })
        
        this.GetCliente();
        this.crearCliente=false;
        
      })

    }
  })
  

}
/* TERMINA Metodo para eliminar cliente */

//Metodo para agregar clientes
 Addcliente(){
   this.submitted=true;
   if(this.formulario.invalid){
     return 
   }
   this.cliente=Object.assign(this.cliente,this.formulario.value);
   Swal.fire({
    title: 'Cliente',
    text: '¿Desea guardar el cliente?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Si, guardar',
    cancelButtonText: 'No, cancelar'
  }).then((result) => {
    if (result.value) {

      this.apiCliente.addCliente(this.cliente).subscribe(response=>{
        if(response.codEx==0){
          console.log(response.mensaje);
        }
        
        Swal.fire({
          title: 'Cliente',
          text: 'El cliente se guardo con exito',
          icon: 'success',
          showCancelButton: false,
        })
        
        this.GetCliente();
       this.crearCliente=false;
        this.resetformulario();
      })


  
    }
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
  this.btneditar=true;
  }

 
//Metodo para actualizar clientes
 Updatecliente(){
  

  this.submitted=true;
   if(this.formulario.invalid){
     return 
   }

   this.cliente=Object.assign(this.cliente,this.formulario.value);

  Swal.fire({
    title: 'Cliente',
    text: '¿Desea actualizar la información del cliente?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Si, guardar',
    cancelButtonText: 'No, cancelar'
  }).then((result) => {
    if (result.value) {
      this.apiCliente.updateCliente(this.cliente).subscribe(response=> {
        if(response.codEx==0){
          alert("Ocurrio un error por"+response.mensaje);
        }
        Swal.fire({
          title: 'Cliente',
          text: 'El cliente se actualizó con exito',
          icon: 'success',
          showCancelButton: false,
        })
        this.GetCliente();
        this.crearCliente=false;
      
      })

    }
  })
 
 }
//Termina Metodo para acutalizar cliente
 


}
