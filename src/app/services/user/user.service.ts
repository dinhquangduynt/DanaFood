import { Injectable } from '@angular/core';
import { User } from './user';
import { Observable, Subject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url =  'https://danafoodapp.azurewebsites.net/api/user';
  constructor(private http: HttpClient) { }
  formData : User;
  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.url + '/getall');
  }
  getUserById(UserId : number): Observable<User> {
    return this.http.get<User>(this.url + '/getsinglebyid/' + UserId);
  }
  createUser(data : any): Observable<User> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<User>(this.url + '/add',
    data, httpOptions);
  }
  updateUser(User : User): Observable<User> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<User>(this.url + '/update',
    User, httpOptions);
  }
  deleteUserById(UserId : number) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete/' + UserId, httpOptions);
  }
  getDetail(UserId : any){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<any>(this.url + '/getbyid/' + UserId, httpOptions);
  }
  private _listners = new Subject<any>();
  filter(filterBy: string){
    this._listners.next(filterBy);
  }
}
