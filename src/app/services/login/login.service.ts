import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private url = "https://danafoodapp.azurewebsites.net";

  constructor(private http: HttpClient) { }
  login(username, password){
    const headers = {
      'Content-type': 'application/x-www-form-urlencoded',
      // 'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, PATCH, OPTIONS',
      // 'Access-Control-Allow-Headers': 'X-Requested-With, content-type, Authorization'
    }
    const body =  new HttpParams()
      .set('username', username)
      .set('password', password)
      .set('grant_type', 'password');

    return this.http.post(this.url + '/token', body, {headers});


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
}
