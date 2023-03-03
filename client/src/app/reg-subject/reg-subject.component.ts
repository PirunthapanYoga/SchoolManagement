import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { subject } from '../_models/entityModels';

@Component({
  selector: 'app-reg-subject',
  templateUrl: './reg-subject.component.html',
  styleUrls: ['./reg-subject.component.css']
})
export class RegSubjectComponent implements OnInit{
  baseurl = "https://localhost:7217/api/"
  subject : subject | any = {};
  subjects : subject[] | any = {};
  valid=true;
  message = "Fields with * are Required";
  
  constructor(private http: HttpClient){}ngOnInit(): void {
    this.getSubjects();
  }

  getSubjects(){
    this.http.get(this.baseurl + 'subject/').subscribe({
      next : response => {
        this.subjects = response;
        console.log(response);
      },
      error: () => console.log(console.error()),
    })
  }
;

  register(){
    this.validation();
    if(this.valid && this.subject.name!=null){
      this.http.post<subject>(this.baseurl + "subject/register/" , this.subject).subscribe({});
      this.message ="Subject Registed"
    }
    this.valid=true; 
  }

  validation(){
    this.subjects.forEach((element : subject) => {
      if(this.subject.name == element.name){
        this.valid=false;
        this.message="Subject is already registred";
      }
    });

  }
}
