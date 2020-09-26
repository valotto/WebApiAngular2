import { Component, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cargo',
  templateUrl: './cargo.component.html',
  styleUrls: ['./cargo.component.css']
})
export class CargoComponent implements OnInit {

  cargos: any = [];


  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCargos();
  }

  getCargos(){
    this.http.get('https://localhost:44355/api/cargos').subscribe( response => 
    {this.cargos = response;
      console.log()

    }, 
    
    error => {
      console.log(error)
    }
      
    );


}
}