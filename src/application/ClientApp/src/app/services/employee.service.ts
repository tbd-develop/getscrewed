import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Http } from '@angular/http';

@Injectable()
export class EmployeeService {
  constructor(
    private http: HttpClient) {
  }

  public createEmployee = (employee: Employee) => {
    return this.http.post('api/employee/createEmployee', employee).pipe(map(data => {
      console.log('employee created');
    }))
  }

}

interface Employee {
  FirstName: string;
  LastName: string;
  PersonalAccountNumber: string;
  Email: string;
  Password: string;
}
 
