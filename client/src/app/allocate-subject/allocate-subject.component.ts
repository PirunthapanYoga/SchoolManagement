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
      
      this.selectedTeacher.subjects=[];
      this.selectedTeacher.subjects.push(this.selectedSubject);   
      this.allocateSubject(this.selectedTeacher)
      
    }else{
      this.message="Already Allocated";
      this.valid=true
    }
    return;
  }

  allocateSubject(teacher: teacher){

    return this.http.put<teacher>(this.baseurl + 'Teacher/updateSubject/' , teacher).subscribe({
      next : response => {
          
      },
      complete : () => {
        this.message=""
        this.getTeacher()
      }
      
    }
    );
    
  }

  deleteSubjects(subjectId : number){
    //Repository Is not Updating the delete action due to singelton approach of DbContext Usage. So I skipped to implement the method here
    //API Teacher Controller Delete action works well untill .remove section
    //Thrown error is unique constrains of classroomID and TeacherId when update directly with Teacher enitity . 
    //Without unique contrains there is nothing to change.......
    //due to time constrain i am wrapping up from this section
  }


}
