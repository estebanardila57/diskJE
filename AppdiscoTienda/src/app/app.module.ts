import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';
import { HomeComponent } from './home/home.component';
import { InfoserviceComponent } from './infoservice/infoservice.component';
import { NavbarComponent } from './navbar/navbar.component';
import {DataTablesModule} from "angular-datatables";
import {FormsModule} from "@angular/forms";
import{ReactiveFormsModule}from "@angular/forms";
import {HttpClientModule} from '@angular/common/http';
import { DiscosComponent } from './discos/discos.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    HomeComponent,
    InfoserviceComponent,
    NavbarComponent,
    DiscosComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DataTablesModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
