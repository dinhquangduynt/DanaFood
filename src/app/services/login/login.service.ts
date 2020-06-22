import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private url = "https://danafoodapp.azurewebsites.net"
  constructor(private http: HttpClient) { }
  login(username, password): Observable<any> {
    const body = new HttpParams()
      .set('grant_type', 'password')
      .set('Username', username)
      .set('Password', password);

    return this.http.post(this.url + '/token',
      body.toString(),
      {
        headers: new HttpHeaders()
          .set('Content-Type', 'application/x-www-form-urlencoded')

      }
    );
  }
}
