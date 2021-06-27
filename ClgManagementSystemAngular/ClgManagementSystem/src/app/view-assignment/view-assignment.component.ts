import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Assignment } from '../add-assignment/Assignment';

@Component({
  selector: 'app-view-assignment',
  templateUrl: './view-assignment.component.html',
  styleUrls: ['./view-assignment.component.css']
})
export class ViewAssignmentComponent implements OnInit {
  
  assignments: Assignment[] = [];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
   
    this.http.get('http://localhost:51535/api/assignment/viewassignment').subscribe(
      response=>{
        this.assignments=response as Assignment[];

      },
      error=>{
        alert('error fetching data');

      });
  }

}