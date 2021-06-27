import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';


import { HomeComponent } from './home/home.component';
import { ParentComponent } from './parent/parent.component';
import { FacultyComponent } from './faculty/faculty.component';
import { AdminComponent } from './admin/admin.component';
import { StudentComponent } from './student/student.component';

import {  FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './auth.service';
import { UserloginComponent } from './userlogin/userlogin.component';
import { AddCalenderComponent } from './add-calender/add-calender.component';
import { ViewCalenderComponent } from './view-calender/view-calender.component';
import { AddAssignmentComponent } from './add-assignment/add-assignment.component';
import { AddAttendanceComponent } from './add-attendance/add-attendance.component';
import { AddIssueComponent } from './add-issue/add-issue.component';
import { AddFeesDetailsComponent } from './add-fees-details/add-fees-details.component';
import { LeaveRequestComponent } from './leave-request/leave-request.component';
import { ViewAssignmentComponent } from './view-assignment/view-assignment.component';
import { ViewAttendanceComponent } from './view-attendance/view-attendance.component';
import { ViewIssueComponent } from './view-issue/view-issue.component';
import { ViewFeesDetailsComponent } from './view-fees-details/view-fees-details.component';
import { ViewLeaveComponent } from './view-leave/view-leave.component';
import { LeaveHistoryComponent } from './leave-history/leave-history.component';

@NgModule({
  declarations: [
        AppComponent,
        UserloginComponent,
        HomeComponent,
        ParentComponent,
        FacultyComponent,
        AdminComponent,
        StudentComponent,
        AddCalenderComponent,
        ViewCalenderComponent,
        AddAssignmentComponent,
        AddAttendanceComponent,
        AddIssueComponent,
        AddFeesDetailsComponent,
        LeaveRequestComponent,
        ViewAssignmentComponent,
        ViewAttendanceComponent,
        ViewIssueComponent,
        ViewFeesDetailsComponent,
        ViewLeaveComponent,
        LeaveHistoryComponent
       
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule
   
   
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
