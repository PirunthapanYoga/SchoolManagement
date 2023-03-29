import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { subject, teacher } from '../_models/entityModels';

@Component({
  selector: 'app-allocate-subject',
  templateUrl: './allocate-subject.component.html',
  styleUrls: ['./allocate-subject.component.css']
})

export class AllocateSubjectComponent implements OnInit{
  baseurl = "https://localhost:7217/api/"
  teachers : teacher[] | any ={}
  subjects: subject[] | any = {};
  valid = true;

  selectedTeacher : teacher | any;
  selectedSubject : subject | any;

  message ="";
  isLoaded = false;
  
  constructor (private http: HttpClient) {}
  
  ngOnInit(): void {
    this.getTeacher();
  }

  getTeacher(){
    this.http.get(this.baseurl + 'teacher/').subscribe({
      next : response => {
        this.teachers = response;
        this.getSubject()
      },
      error: () => console.log(console.error()),
      complete: () => {
        if(this.selectedTeacher){
          this.teachers.forEach((e : teacher)=> {
            if(e.teacherId==this.selectedTeacher.teacherId){
              this.selectedTeacher=e;
            }
          })
        }
      }
    })
  }

  getSubject(){
    this.http.get(this.baseurl + 'subject/').subscribe({
      next : response => {
        this.subjects = response;
        this.isLoaded=true;
      },
      error: () => console.log(console.error()),
    })
  }

  setTeacher(teacher : teacher){
    this.selectedTeacher=teacher;
  }

  setSubject(subject : subject){
    this.selectedSubject=subject;
  }

  validate(){
    this.selectedTeacher.subjects.forEach((e : subject) => {
      if(e.id==this.selectedSubject.id){
        this.valid=false;
      }
    })

    if(this.valid){
      this.allocateSubject(this.selectedSubject.id);
    }else{
      this.message="Already Allocated";
      this.valid=true
    }
    return;
  }

  allocateSubject(subjectId : Number ){

    this.http.put(this.baseurl + 'Teacher/updateSubject/' + this.selectedTeacher.teacherId + '/' + subjectId , null).subscribe({
      complete : () => {
        this.message=""
        this.getTeacher()
      }
    }
    );
    
  }

  deleteSubjects(subjectId : number){

    this.http.delete(this.baseurl + "Teacher/deleteSubject/" + this.selectedTeacher.teacherId + '/' + subjectId ).subscribe({
      next : () => {
        this.getTeacher();
      }
    })
  }
}
