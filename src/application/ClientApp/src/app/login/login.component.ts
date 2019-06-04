import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from "../services/authentication.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  constructor(private auth: AuthenticationService, private router: Router) { }

  ngOnInit() {
  }

  public doLogin() {
    if (this.loginForm.valid) {
      this.auth.doLogin(this.loginForm.value).subscribe(result => {
        this.router.navigate(['/']);
      });
    }
  }
}
