import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe, of, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public doLogin = (details: LoginDetails) => {
    return this.http.post('api/login', details).pipe(map(data => {
      console.log('Logged in');
    }));
  }
}

interface LoginDetails {
  email: string;
  password: string;
}
