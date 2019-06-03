import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import {
  MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule
} from '@angular/material';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { CreateEmployeeComponent } from './create-employee/create-employee.component'

import { AuthenticationService } from './services/authentication.service';
import { EmployeeService } from './services/employee.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    CreateEmployeeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'create-employee', component: CreateEmployeeComponent },
      { path: '**', component: HomeComponent }
    ]),
    BrowserAnimationsModule,
    MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule
  ],
  providers: [AuthenticationService, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
