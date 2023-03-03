import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { classRoom } from '../_models/entityModels';

@Component({
  selector: 'app-reg-class-room',
  templateUrl: './reg-class-room.component.html',
  styleUrls: ['./reg-class-room.component.css']
})
export class RegClassRoomComponent implements OnInit {
  baseurl = "https://localhost:7217/api/"

  divitions = ["A", "B", "C", "D", "E", "F", "G", "H", "I" , "J", "K", "L",
            "M", "N", "O", "P", "Q", "S" ,"T", "U", "V", "W", "X", "Y", "Z"]
  grades = [1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 11 , 12 , 13]

  classRoom : classRoom | any = {};
  classRooms : classRoom[] | any;
  
  grade : number | any;
  divition = "";
  validate = "";
  valid=true;


  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.getClassroom();
  }

  register(){
    this.validateName();

    if(this.valid && this.divition !="" && this.grade!=""){
        this.http.post<classRoom>(this.baseurl + "classRoom/register/" , this.classRoom).subscribe({});
        this.validate= "Classroom '"+ this.classRoom.name +"' Added"
    }
    this.valid=true;

  }

  validateName(){
    this.classRoom.name = "Grade" + " " + this.grade + " " + this.divition;
    if(this.grade=="" || this.divition==""){
      this.validate = "Fields with * are Required"
    }

    this.classRooms.forEach((element : classRoom) => {
      if(this.classRoom.name == element.name){
        this.validate = "Class room '" + this.classRoom.name + "' already registred. Check again and register"
        this.valid=false;
      }
    });
  }

  getClassroom(){
    this.http.get(this.baseurl + 'classRoom/').subscribe({
      next : response => {
        this.classRooms = response;
      },
      error: () => console.log(console.error()),
      complete: () => console.log('Requse has Been Completed')
    })
  }

  setGrade(grade : number){
    this.grade=grade;
  }

  setDivition(divition : string){
    this.divition=divition;
  }

}
