import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
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
