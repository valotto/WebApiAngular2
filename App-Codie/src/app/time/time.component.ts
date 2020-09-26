import { Component, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-time',
  templateUrl: './time.component.html',
  styleUrls: ['./time.component.css']
})
export class TimeComponent implements OnInit {

  timescodies: any = [];


  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTimes();
  }

  getTimes(){
    this.http.get('https://localhost:44355/api/timescodies').subscribe( response => 
    {this.timescodies = response;
      console.log()

    }, 
    
    error => {
      console.log(error)
    }
      
    );


}
}