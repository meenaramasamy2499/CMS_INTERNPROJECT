import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-calender',
  templateUrl: './add-calender.component.html',
  styleUrls: ['./add-calender.component.css']
})
export class AddCalenderComponent implements OnInit {

  calender= new FormGroup({});


  constructor(private http:HttpClient,private fb :FormBuilder) {
    this.calender=this.fb.group({
      DateOfEdit:['',[Validators.required]],
      Status:['',[Validators.required]],
      Reason:['',[Validators.required]]
    
    });
   }
  ngOnInit(): void {
  }
  addcalender(){
    const cal={
      DateOfEdit:this.calender.get("DateOfEdit")?.value,
      Status:this.calender.get("Status")?.value,
      Reason:this.calender.get("Reason")?.value
    }
    this.http.post('http://localhost:51535/api/calendar', cal).subscribe(
      (data)=>{alert('saved successfully');},
      (err)=>{console.log(err);
        alert('Error saving data');
    });
        
    
  }

}