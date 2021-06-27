import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { User } from '../Types/User';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent implements OnInit {

  submitted : boolean =  false;
  loginForm= new FormGroup({});
  flag: any;

  selectedType: string = '';
  userID! : number;
  user! : User;
  constructor(private ls : AuthService, 
    private router: Router,
 
    public formBuilder:FormBuilder) { }
  ngOnInit(): void {
    this.loginForm=this.formBuilder.group({
      UserName: ['', [Validators.compose([Validators.required])]],
      Password: ['', [Validators.required, Validators.minLength(3)]],
       });
  }
  get f() { return this.loginForm.controls; }

  
 Login() 
 {

  this.submitted = true;
  const userDetails = {
   UserName:this.loginForm.get("UserName")?.value,
    Password: this.loginForm.get('Password')?.value
  }
  this.ls.Validate(userDetails)
      .subscribe(
        (res:any) => {
          if(res) {
            this.ls.isAuthenticated(true);
            this.flag=res;
            this.user = res;

          
           
            this.userID = res.UserId;

            if(res.UserType == 'student')
            {
              this.router.navigate(['/Student']);
            }
          
            else if(res.UserType == 'admin')
            {
              this.router.navigate(['/Admin']);
            }

            else if(res.UserType =='faculty')
            {
              this.router.navigate(['/Faculty'])
            }
            else if(res.UserType == 'parent')
            {
              this.router.navigate(['/Parent'])
            }
            else
            
             alert('Please Check Your Login Details');
          
           }
        },
        (err:any) => {
          this.ls.isAuthenticated(false);
          alert('Invalid username/password');
        }
      );
  
  }



}

