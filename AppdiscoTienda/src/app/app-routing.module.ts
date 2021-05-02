import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClientesComponent} from './clientes/clientes.component';
import { DiscosComponent } from './discos/discos.component';

const routes: Routes = [
  {path:"home",component:HomeComponent},
  {path:"Cliente",component:ClientesComponent},
  {path:"Disco",component:DiscosComponent},
  {path:"",component:HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
