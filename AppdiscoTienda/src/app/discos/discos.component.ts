import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import {Discos} from '../models/discos';
import {ApiDiscosService} from '../services/api-discos.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-discos',
  templateUrl: './discos.component.html',
  styleUrls: ['./discos.component.css']
})
export class DiscosComponent implements OnInit {
  crearDisco:boolean=false;
  lstDisco:any;
  dtOptions:DataTables.Settings={};
  disco:Discos={}as Discos;
  btneditar:boolean=false;
  submitted:boolean=false;

  constructor(private formbuilder:FormBuilder,private apiDisco:ApiDiscosService) { }
  
  formulario=this.formbuilder.group({
    genero:['',Validators.required],
    descripcioncd:['',Validators.required],
    cantidad:['',Validators.required]
   
  });

  ngOnInit(): void {
    this.dtOptions={
      pagingType:'full_numbers',
      pageLength:10
    };
    this.GetDisco();
  }

   //estamos renombrando el formulario para dejarlo con este alias para citarlo con mas facilidad en el html
get f() {return this.formulario.controls}


mostrarDisco(){
  this.btneditar=false;
  this.crearDisco=true;
  this.resetformulario();
}

resetformulario(){
  this.formulario.reset();
}

GetDisco(){
  this.apiDisco.getDisco().subscribe(response=>{
  this.lstDisco=response.data;
  })
}

AddDisco(){
  this.submitted=true;
  if(this.formulario.invalid){
    return 
  }
  this.disco=Object.assign(this.disco,this.formulario.value);
  Swal.fire({
   title: 'Discos',
   text: '¿Desea guardar el Disco?',
   icon: 'warning',
   showCancelButton: true,
   confirmButtonText: 'Si, guardar',
   cancelButtonText: 'No, cancelar'
 }).then((result) => {
   if (result.value) {

     this.apiDisco.addDisco(this.disco).subscribe(response=>{
       if(response.codEx==0){
         console.log(response.mensaje);
       }
       
       Swal.fire({
         title: 'Discos',
         text: 'El Disco se guardo con exito',
         icon: 'success',
         showCancelButton: false,
       })
       
       this.GetDisco();
      this.crearDisco=false;
       this.resetformulario();
     })


 
   }
 })
 
}

editDisco(oDisco:Discos){
  this.formulario.controls.genero.setValue(oDisco.genero)
  this.formulario.controls.descripcioncd.setValue(oDisco.descripcioncd)
  this.formulario.controls.cantidad.setValue(oDisco.cantidad)
  this.crearDisco=true;
  this.disco.id=oDisco.id
  this.btneditar=true;
  }

  UpdateDisco(){

    this.submitted=true;
     if(this.formulario.invalid){
       return 
     }
  
     this.disco=Object.assign(this.disco,this.formulario.value);
  
    Swal.fire({
      title: 'Discos',
      text: '¿Desea actualizar la información del Disco?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si, Actualizar',
      cancelButtonText: 'No, cancelar'
    }).then((result) => {
      if (result.value) {
        this.apiDisco.updateDisco(this.disco).subscribe(response=> {
          if(response.codEx==0){
            alert("Ocurrio un error por"+response.mensaje);
          }
          Swal.fire({
            title: 'Discos',
            text: 'El Disco se actualizó con exito',
            icon: 'success',
            showCancelButton: false,
          })
          this.GetDisco();
          this.crearDisco=false;
        
        })  
      }
    })
   
   }

    DesactivarDisco(discos:Discos){
      Swal.fire({
        title: 'Disco',
        text: '¿Desea cambiar el estado del disco?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, Cambiar',
        cancelButtonText: 'No, cancelar'
      }).then((result) => {
        if (result.value) {
        
          this.apiDisco.desactivardisco(discos.id).subscribe(response=>{
            if(response.codEx==0){
              console.log(response.mensaje);
       
            }
            Swal.fire({
              title: 'Disco',
              text: 'El estado del disco se cambió con exito',
              icon: 'success',
              showCancelButton: false,
            })
            
            this.GetDisco();
            this.crearDisco=false;
            
          })
    
        }
      })
      
    
    }
  
}
