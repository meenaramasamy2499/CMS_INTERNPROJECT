import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-issue',
  templateUrl: './add-issue.component.html',
  styleUrls: ['./add-issue.component.css']
})
export class AddIssueComponent implements OnInit {

  
  issue= new FormGroup({});


  constructor(private http:HttpClient,private fb :FormBuilder) {
    this.issue=this.fb.group({
      UserId:['',[Validators.required]],
      Description:['',[Validators.required]]

    
    });
   }

  ngOnInit(): void {
  }

  addissue(){
    const iss={
      UserId:this.issue.get("UserId")?.value,
      Description:this.issue.get("Description")?.value
     
    }
    this.http.post('http://localhost:51535/api/issue/raiseissue', iss).subscribe(
      (data)=>{alert('saved successfully');},
      (err)=>{console.log(err);
        alert('Error saving data');
    });
        
    
  }

}
