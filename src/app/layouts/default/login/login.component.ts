import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),

  });
  email = new FormControl('', [Validators.required, Validators.email]);

  getErrorMessage() {
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
  constructor( private loginService : LoginService,
    public fb: FormBuilder,
    private router: Router) {}

  ngOnInit(): void {
  }
  onSubmit(){
 //this.loginService.login(this.login.get('email').value, this.login.get('password').value).subscribe((d:any => {a.statusCode});)
    this.loginService.login(this.login.get('email').value, this.login.get('password').value)
    .subscribe((data: any) => {

      localStorage.setItem('token', data.access_token);
      //localStorage.setItem('UserName', data.UserName);
      localStorage.setItem('FullName' , data.FullName);
      localStorage.setItem('PhoneNumber', data.PhoneNumber);
      //localStorage.setItem('BirthDay', data.BirthDay);
      localStorage.setItem('Address', data.Address);
      this.router.navigateByUrl('das');

    }, (error: HttpErrorResponse) => {
      //console.log(error.error);
      console.log("sai thông tin đăng nhập");
      this.router.navigateByUrl('');
      location.reload();
      console.log("bbb");
    });


  }

}
