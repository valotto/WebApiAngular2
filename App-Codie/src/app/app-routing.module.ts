import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ColaboradorComponent } from './colaborador/colaborador.component';
import { TimeComponent } from './time/time.component';
import { CargoComponent } from './cargo/cargo.component';

const routes: Routes = [
  { path : 'colaborador', component: ColaboradorComponent },
  { path : 'time', component: TimeComponent },
  { path : 'cargo', component: CargoComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
