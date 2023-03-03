import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { classRoom, student, teacher } from '../_models/entityModels';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  baseurl = "https://localhost:7217/api/"
  students : student[] | any;
  classRoom: classRoom | any;
  teachers : teacher[] | any;

  selectedStudent!: student;
  isLoaded = false;
  
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents(){
    this.http.get(this.baseurl + 'student/').subscribe({
      next : response => {
        this.students = response;
        this.isLoaded=true;
      },
      error: () => console.log(console.error()),
    })
  }

  getClassroom(){
    this.http.get(this.baseurl + 'classRoom/' + this.selectedStudent.classRoomId + "/").subscribe({
      next : response => {
        this.classRoom = response;
      },
      error: () => console.log(console.error()),
    })
  }

}
