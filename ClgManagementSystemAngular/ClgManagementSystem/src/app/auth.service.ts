
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {HttpClient} from '@angular/common/http';
import { BehaviorSubject, Observable, Subject, throwError } from 'rxjs';
import {catchError, map, retry} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url : string = "http://localhost:51535/api/login";
 

  private isLoggedIn = new BehaviorSubject<boolean> (false);
  private CallMethodSource  = new Subject<any>();
  CallMethodSource$ = this.CallMethodSource.asObservable();
  
  SetAuthenticated()
   {
    this.CallMethodSource.next();
  }
  OnLoggedIn = this.isLoggedIn.asObservable();
  flag: any;
  
  constructor(private http : HttpClient, 
    private router: Router) {
    }
    
   isAuthenticated(status : boolean) {
     this.isLoggedIn.next(status);
   }

  Validate(userDetails: any) {
    return this.http.post(this.url, userDetails).pipe(map((response) => {
      this.flag=response;
      console.log(this.flag);
  return response;
     }
    ));
  }
}
