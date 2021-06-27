import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Attendance } from '../add-assignment/Attendance';

@Component({
  selector: 'app-view-attendance',
  templateUrl: './view-attendance.component.html',
  styleUrls: ['./view-attendance.component.css']
})
export class ViewAttendanceComponent implements OnInit {
  
  
  attendances: Attendance[] = [];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
   
    this.http.get('http://localhost:51535/api/attendance/getattendance').subscribe(
      response=>{
        this.attendances=response as Attendance[];

      },
      error=>{
        alert('error fetching data');

      });
  }

}

