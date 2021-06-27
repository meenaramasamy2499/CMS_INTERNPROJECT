import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Issue } from '../add-assignment/issue';

@Component({
  selector: 'app-view-issue',
  templateUrl: './view-issue.component.html',
  styleUrls: ['./view-issue.component.css']
})
export class ViewIssueComponent implements OnInit {

  issues: Issue[] = [];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
   
    this.http.get('http://localhost:51535/api/issue/getall').subscribe(
      response=>{
        this.issues=response as Issue[];

      },
      error=>{
        alert('error fetching data');

      });
  }

}
