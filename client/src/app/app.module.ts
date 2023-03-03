import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from  '@angular/common/http'
import { MatSelectModule } from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { ReportComponent } from './report/report.component';
import { HomeComponent } from './home/home.component';
import { RegClassRoomComponent } from './reg-class-room/reg-class-room.component';
import { RegStudentComponent } from './reg-student/reg-student.component';
import { RegSubjectComponent } from './reg-subject/reg-subject.component';
import { RegTeacherComponent } from './reg-teacher/reg-teacher.component';
import { AllocateSubjectComponent } from './allocate-subject/allocate-subject.component';
import { AllocateClassroomComponent } from './allocate-classroom/allocate-classroom.component';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ReportComponent,
    HomeComponent,
    RegClassRoomComponent,
    RegStudentComponent,
    RegSubjectComponent,
    RegTeacherComponent,
    AllocateSubjectComponent,
    AllocateClassroomComponent,
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSelectModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    MatDatepickerModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
