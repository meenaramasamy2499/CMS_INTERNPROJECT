import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-leave-request',
  templateUrl: './leave-request.component.html',
  styleUrls: ['./leave-request.component.css']
})
export class LeaveRequestComponent implements OnInit {

  leave= new FormGroup({});
  constructor(private http:HttpClient,private fb :FormBuilder) {
    this.leave=this.fb.group({

      UserId:['',[Validators.required]],
      
      DateOfLeave:['',[Validators.required]],
   
      Reason:['',[Validators.required]]
    
    });
  }

  ngOnInit(): void {
  }

  addleave(){
    const lv={
      UserId:this.leave.get("UserId")?.value,
      DateOfLeave:this.leave.get("DateOfLeave")?.value,
    
      Reason:this.leave.get("Reason")?.value
    }
    this.http.post('http://localhost:51535/api/leavedetails/leaverequest', lv).subscribe(
      (data)=>{alert('saved successfully');},
      (err)=>{console.log(err);
        alert('Error saving data');
    });
        
    
  }

}
