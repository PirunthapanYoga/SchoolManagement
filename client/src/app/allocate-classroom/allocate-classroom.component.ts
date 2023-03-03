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
      
      this.selectedTeacher.classRooms=[];
      this.selectedTeacher.classRooms.push(this.selectedClassRoom);  
      this.allocateClassroom(this.selectedTeacher)
      
    }else{
      this.message="Already Allocated";
      this.valid=true
    }
    return;
  }

  allocateClassroom(teacher: teacher){

    return this.http.put<teacher>(this.baseurl + 'Teacher/updateClassRoom/' , teacher).subscribe({
      next : response => {
        console.log(response)
      },
      complete : () => {
        this.message=""
        this.getTeacher()
      }
    }
    );
    
  }

  deleteClassroom(classRoomId : number){
    //Repository Is not Updating the delete action due to singelton approach of DbContext Usage. So I skipped to implement the method here
    //API Teacher Controller Delete action works well untill .remove section
    //Thrown error is unique constrains of classroomID and TeacherId when update directly with Teacher enitity . 
    //Without unique contrains there is nothing to change.......
    //due to time constrain i am wrapping up from this section
  }

}

