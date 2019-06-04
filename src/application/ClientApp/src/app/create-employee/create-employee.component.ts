import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {

  output: any;
  public createForm: FormGroup = new FormGroup({
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    PersonalAccountNumber: new FormControl(''),
    Email: new FormControl(''),
    Password: new FormControl('')
  });
  public deleteForm: FormGroup = new FormGroup({
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    PersonalAccountNumber: new FormControl(''),
    Email: new FormControl(''),
  });
  constructor(private employeeService: EmployeeService, private router: Router) { }

  ngOnInit() {
  }
  public createEmployee() {
    if (this.createForm.valid) {
      this.employeeService.createEmployee(this.createForm.value).subscribe(result => {
        this.output = result
        if (this.output == 'Employee Already Exists!') {
          alert('Employee Already Exists!');
        }
        else if (this.output.StatusCode == "200") {
          alert('Employee Saved Successfully');
          this.router.navigate(['create-employee']);
        }
        else {
          alert('Something went wrong!')
        }
      })
    }
  }
 

}
