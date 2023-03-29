import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { classRoom, teacher } from '../_models/entityModels';

@Component({
  selector: 'app-allocate-classroom',
  templateUrl: './allocate-classroom.component.html',
  styleUrls: ['./allocate-classroom.component.css']
})
export class AllocateClassroomComponent implements OnInit {
  baseurl = "https://localhost:7217/api/"
  teachers : teacher[] | any ={}
  classRooms: classRoom[] | any = {};

  selectedTeacher : teacher | any;
  selectedClassRoom : classRoom | any;

  valid = true;
  isLoaded = false;
  message ="";
  constructor (private http: HttpClient) {}
  
  ngOnInit(): void {
    this.getTeacher();
  }

  getTeacher(){
    this.http.get(this.baseurl + 'teacher/').subscribe({
      next : response => {
        this.teachers = response;
        this.getClassroom()
      },
      complete:() => {
        if(this.selectedTeacher){
          this.teachers.forEach((e : teacher)=> {
            if(e.teacherId==this.selectedTeacher.teacherId){
              this.selectedTeacher=e;
            }
          })
        }
      },
      error: () => console.log(console.error()),
    })
  }

  getClassroom(){
    this.http.get(this.baseurl + 'classRoom/basicDetails/').subscribe({
      next : response => {
        this.classRooms = response;
        this.isLoaded=true;
      },
      error: () => console.log(console.error()),
    })
  }

  setTeacher(teacher : teacher){
    this.selectedTeacher=teacher;
  }

  setClassroom(classRoom : classRoom){
    this.selectedClassRoom=classRoom;
  }

  validate(){
    this.selectedTeacher.classRooms.forEach((e : classRoom) => {
      if(e.classRoomId==this.selectedClassRoom.classRoomId){
        this.valid=false;
      }
    })

    if(this.valid){
      
      this.allocateClassroom(this.selectedClassRoom.classRoomId);
      
    }else{
      this.message="Already Allocated";
      this.valid=true
    }
    return;
  }

  allocateClassroom(classRoomId: number){

    return this.http.put(this.baseurl + 'Teacher/updateClassRoom/' + this.selectedTeacher.teacherId + '/' + classRoomId ,null).subscribe({
      complete : () => {
        this.message=""
        this.getTeacher()
      }
    }
    );   
  }

  deleteClassRoom(classRoomId : number){
    this.http.delete(this.baseurl + "Teacher/deleteClassRoom/" + this.selectedTeacher.teacherId + '/' + classRoomId ).subscribe({
      complete : () => {
        this.getTeacher();  
      }
    })
  }

}

