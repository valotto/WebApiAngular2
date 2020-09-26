import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ColaboradorComponent } from './colaborador/colaborador.component';
import { HttpClientModule} from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { TimeComponent } from './time/time.component';
import { CargoComponent } from './cargo/cargo.component'

@NgModule({
  declarations: [
    AppComponent,
    ColaboradorComponent,
    NavComponent,
    TimeComponent,
    CargoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
