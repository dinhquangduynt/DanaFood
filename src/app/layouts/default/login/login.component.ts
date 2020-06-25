import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });

  constructor( private loginservice : LoginService,
    public fb: FormBuilder,
    private router: Router) {}

  ngOnInit(): void {
  }
  onSubmit(){
    this.loginservice.login(this.login.get('email').value, this.login.get('password').value).subscribe((data: any) => {
       if (data && data.status === 200) {
        localStorage.setItem('token', data.data.token);
         console.log(localStorage);
        this.router.navigateByUrl('das');
       }
       else if (data && data.status === 400) {
         console.log("sai thông tin đăng nhập");
         this.router.navigateByUrl('');
         location.reload();
       }
    });
    (error: HttpErrorResponse) => {
        console.log(error.error);
    }

  }

}
