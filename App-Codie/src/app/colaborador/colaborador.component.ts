import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-colaborador',
  templateUrl: './colaborador.component.html',
  styleUrls: ['./colaborador.component.css']
})
export class ColaboradorComponent implements OnInit {

colaboradores: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getColaboradores();
  }


getColaboradores(){
  this.http.get('https://localhost:44355/api/colaboradors').subscribe( response => 
  {this.colaboradores = response;
    console.log()
  }, error => {
    console.log(error)
  }
    
  );
  
}

}
