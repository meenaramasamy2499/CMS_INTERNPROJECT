import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Leave } from '../add-assignment/leave';

@Component({
  selector: 'app-leave-history',
  templateUrl: './leave-history.component.html',
  styleUrls: ['./leave-history.component.css']
})
export class LeaveHistoryComponent implements OnInit {

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