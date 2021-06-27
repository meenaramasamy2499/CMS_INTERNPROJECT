import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-assignment',
  templateUrl: './add-assignment.component.html',
  styleUrls: ['./add-assignment.component.css']
})
export class AddAssignmentComponent implements OnInit {
  
  assignment= new FormGroup({});

constructor(private http:HttpClient,private fb :FormBuilder) {
  this.assignment=this.fb.group({
    AssignmentId:['',[Validators.required]],
    StudentId:['',[Validators.required]],
    CourseCode:['',[Validators.required]],
    SubmissionTime:['',[Validators.required]],
    Question:['',[Validators.required]]
  
  });
 }

ngOnInit(): void {
}

addassignment(){
  const ass={
    AssignmentId:this.assignment.get("AssignmentId")?.value,
    StudentId:this.assignment.get("StudentId")?.value,
    CourseCode:this.assignment.get("CourseCode")?.value,
    SubmissionTime:this.assignment.get("SubmissionTime")?.value,
    Question:this.assignment.get("Question")?.value
  }
  this.http.post('http://localhost:51535/api/assignment/uploadassignmentques', ass).subscribe(
    (data)=>{alert('saved successfully');},
    (err)=>{console.log(err);
      alert('Error saving data');
  });
      
  
}

}