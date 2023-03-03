import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { classRoom, student } from '../_models/entityModels';

@Component({
  selector: 'app-reg-student',
  templateUrl: './reg-student.component.html',
  styleUrls: ['./reg-student.component.css']
})
export class RegStudentComponent implements OnInit{
  baseurl = "https://localhost:7217/api/"
  student : student | any = {} ;
  classRoom : classRoom[] | any;
  classRoomID: number | any;

  message="Fields with * are Required"

  bsValue = new Date();
  maxDate = new Date();

  constructor(private http: HttpClient) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
  }

  ngOnInit(): void {
    this.getClassroom()
  }

  getClassroom(){
    this.http.get(this.baseurl + 'classRoom/').subscribe({
      next : response => {
        this.classRoom = response;
      },
      error: () => console.log(console.error()),
      complete: () => console.log('Requse has Been Completed')
    })
  }

  register(){
    this.student.dateOfBirth=moment(this.bsValue).format("YYYY-MM-DD");
    this.student.classRoomId=this.classRoomID;
    this.http.post<student>(this.baseurl + "student/register/" , this.student).subscribe({
      next : response =>{
        this.student='';
        this.bsValue=new Date();
      }
    })
  }

  setClassRoomID(classRoomID : number){
    this.classRoomID=classRoomID;
  }
}
