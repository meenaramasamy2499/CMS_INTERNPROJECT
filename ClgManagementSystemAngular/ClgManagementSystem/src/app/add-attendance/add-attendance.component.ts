import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-attendance',
  templateUrl: './add-attendance.component.html',
  styleUrls: ['./add-attendance.component.css']
})
export class AddAttendanceComponent implements OnInit {

  attendance= new FormGroup({});

  constructor(private http:HttpClient,private fb :FormBuilder) {
    this.attendance=this.fb.group({
      AttendanceId:['',[Validators.required]],
      FacultyId:['',[Validators.required]],
      StudentId:['',[Validators.required]],
      AttendanceDate:['',[Validators.required]],
      IsPresent:['',[Validators.required]]
    
    });
   }

  ngOnInit(): void {
  }

  addattendance(){
    const at={
      FacultyId:this.attendance.get("FacultyId")?.value,
      StudentId:this.attendance.get("StudentId")?.value,
      AttendanceDate:this.attendance.get("AttendanceDate")?.value,
      IsPresent:this.attendance.get("IsPresent")?.value

    }
    this.http.post('http://localhost:51535/api/attendance/addattendanceentry', at).subscribe(
      (data)=>{alert('saved successfully');},
      (err)=>{console.log(err);
        alert('Error saving data');
    });
        
    
  }

}