import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllocateClassroomComponent } from './allocate-classroom/allocate-classroom.component';
import { AllocateSubjectComponent } from './allocate-subject/allocate-subject.component';
import { HomeComponent } from './home/home.component';
import { RegClassRoomComponent } from './reg-class-room/reg-class-room.component';
import { RegStudentComponent } from './reg-student/reg-student.component';
import { RegSubjectComponent } from './reg-subject/reg-subject.component';
import { RegTeacherComponent } from './reg-teacher/reg-teacher.component';
import { ReportComponent } from './report/report.component';

const routes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'allocateSubject'   , component:AllocateSubjectComponent},
  {path: 'allocateClassroom' , component:AllocateClassroomComponent},
  {path: 'regClassroom'      , component:RegClassRoomComponent},
  {path: 'regStudent'        , component:RegStudentComponent},
  {path: 'regTeacher'        , component:RegTeacherComponent},
  {path: 'regSubject'        , component:RegSubjectComponent},
  {path: 'report'            , component:ReportComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
