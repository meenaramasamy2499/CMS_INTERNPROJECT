import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Calendar } from '../Calender';

@Component({
  selector: 'app-view-calender',
  templateUrl: './view-calender.component.html',
  styleUrls: ['./view-calender.component.css']
})
export class ViewCalenderComponent implements OnInit {


  calenders: Calendar[] = [];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
   
    this.http.get('http://localhost:51535/api/calendar/getall').subscribe(
      response=>{
        this.calenders=response as Calendar[];

      },
      error=>{
        alert('error fetching data');

      });
  }

}
