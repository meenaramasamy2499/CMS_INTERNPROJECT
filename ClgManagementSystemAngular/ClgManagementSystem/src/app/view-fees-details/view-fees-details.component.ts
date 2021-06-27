import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FeesDetail } from '../add-assignment/FeesDetails';

@Component({
  selector: 'app-view-fees-details',
  templateUrl: './view-fees-details.component.html',
  styleUrls: ['./view-fees-details.component.css']
})
export class ViewFeesDetailsComponent implements OnInit {
  
  feesdetails: FeesDetail[] = [];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
   
    this.http.get('http://localhost:51535/api/fee/viewfees').subscribe(
      response=>{
        this.feesdetails=response as FeesDetail[];

      },
      error=>{
        alert('error fetching data');

      });
  }

}

