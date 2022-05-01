import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CrearComponent } from './components/vistas/crear/crear.component';
import { ListaComponent } from './components/vistas/lista/lista.component';

const routes: Routes = [
  {path: '', component: ListaComponent},
  {path: 'crear', component: CrearComponent},
  
  
  
  {path: '**',redirectTo:'', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
