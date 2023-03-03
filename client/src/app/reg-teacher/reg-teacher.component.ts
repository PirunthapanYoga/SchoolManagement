import { HttpClient } from '@angular/common/http';
import { Component} from '@angular/core';
import { teacher } from '../_models/entityModels';

@Component({
  selector: 'app-reg-teacher',
  templateUrl: './reg-teacher.component.html',
  styleUrls: ['./reg-teacher.component.css']
})
export class RegTeacherComponent{
  baseurl = "https://localhost:7217/api/"
  teacher : teacher | any ={}; 

  constructor(private http: HttpClient){};

  register(){
    this.http.post<teacher>(this.baseurl + "teacher/register/" , this.teacher).subscribe({})
  }

}
