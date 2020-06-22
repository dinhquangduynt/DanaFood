import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginadmindata = {
    'Username' : "",
    'Password' : ""
  };

  constructor( private loginservice : LoginService) {}

  ngOnInit(): void {
  }
  loginUser(){
    this.loginservice.login(this.loginadmindata.Username, this.loginadmindata.Password).subscribe();
  }

}
