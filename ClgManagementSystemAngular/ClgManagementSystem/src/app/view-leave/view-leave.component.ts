import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Leave } from '../add-assignment/leave';

@Component({
  selector: 'app-view-leave',
  templateUrl: './view-leave.component.html',
  styleUrls: ['./view-leave.component.css']
})
export class ViewLeaveComponent implements OnInit {

  leaves: Leave[] = [];

  constructor(private http:HttpClient) { }
  

  ngOnInit(): void {
   
    this.http.get('http://localhost:51535/api/leavedetails/getattendance').subscribe(
      response=>{
        this.leaves=response as Leave[];

      },
      error=>{
        alert('error fetching data');

      });
  }

}