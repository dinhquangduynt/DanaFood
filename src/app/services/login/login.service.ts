import { map } from 'highcharts';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private url = "https://danafoodapp.azurewebsites.net";
  //private url = "http://localhost:50094/token";

  constructor(private http: HttpClient) { }
  login(username, password){

     let headers = new HttpHeaders({
      'Content-type': 'application/x-www-form-urlencoded'
    });
    var body =  new HttpParams().set('UserName', username).set('Password', password).set('grant_type', "password");

    return this.http.post(this.url + '/token', body, {headers: headers});


  //   //let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
  //   const options = {
  //     //headers: new HttpHeaders().append('key', 'value'),
  //     params: new HttpParams().set({ 'Content-Type': 'application/x-www-form-urlencoded' });
  //   }
  //   //here I am setting username and password which I got from html form
  //   var body = "grant_type=password&username="+ username +
  //              "&password=" + password;

  //   return this.http.get(this.url +'/token', body, options);
  // }
  // login(data : any) {
  //   var headers = new Headers();
  //   headers.append('Content-Type', 'application/x-www-form-urlencoded');
  //   const body = new HttpParams()
  //     .set('grant_type', 'password')
  //   return this.http.get(this.url + '/token', data, { headers: headers })
  //   .subscribe((res) => token = res.json());
      // body.toString(),
      // {
      //   headers: new HttpHeaders()
      //     .set('Content-Type', 'application/x-www-form-urlencoded')

      // }
  }

  login2(username: string, password: string): Observable<any> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let body = new URLSearchParams();
    body.set('username', username);
    body.set('password', password);
    body.set('grant_type', "password");
    body.set('client_id', "angular.client");
    body.set('client_secret', "secret");

    return this.http.post<any>(this.url + '/token', body.toString(), {
      headers: headers
    });
  }
}
