import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/services/user/user';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.css']
})
export class AdminManagementComponent implements OnInit {
  ad : User;
  admin : FormGroup;
  password : FormGroup;
  date : string;


  constructor(
    private userservice : UserService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private http : HttpClient) { }

  ngOnInit(): void {
    //this.date = localStorage.getItem('BirthDay');
    //this.ad.BirthDay = new Date(this.date);
    this.ad.FullName = localStorage.getItem('FullName');
    this.ad.Address = localStorage.getItem('Address');
    this.ad.PhoneNumber = localStorage.getItem('PhoneNumber');
    this.getProfile();
    this.admin = this.fb.group({
     // UserName: [''],
      FullName: [''],
      //Birthday: [''],
      PhoneNumber: [''],
      Address: [''],

   })
    this.password = this.fb.group({
      Password : [''],
      NewPass :[''],
      RepeatNew : ['']
    })
    //localStorage.removeItem("UserName");
    localStorage.removeItem("FullName");
    //localStorage.removeItem("Birthday");
    localStorage.removeItem("PhoneNumber");
    localStorage.removeItem("Address");

  }
  onSubmit(){
    this.userservice.updateUser(this.admin.value).subscribe((data: any) => {
      this.router.navigateByUrl('admin');
    });
  (error: HttpErrorResponse) => {
    console.log(error.error);
  }
  }
  onChange(){

  }
  getProfile() {
    //this.ad.UserName = localStorage.getItem('UserName');
      this.admin = this.fb.group({
        //UserName: [this.ad.UserName],
        FullName: [this.ad.FullName],
        //Birthday: [this.ad.BirthDay.toDateString],
        Address: [this.ad.Address],
        PhoneNumber: [this.ad.PhoneNumber]
      })
    }
  }

