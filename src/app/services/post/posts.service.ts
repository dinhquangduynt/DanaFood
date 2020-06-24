import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { PostCategory } from './post.model';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  url =  'https://danafoodapp.azurewebsites.net/api/postcategory';
  constructor(private http: HttpClient) { }
  formData : PostCategory;
  getAllPosts(): Observable<PostCategory[]> {
    return this.http.get<PostCategory[]>(this.url + '/getall');
  }
  getPostById(postId : number): Observable<PostCategory> {
    return this.http.get<PostCategory>(this.url + '/getsinglebyid/' + postId);
  }
  createPost(data : any): Observable<PostCategory> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<PostCategory>(this.url + '/add',
    data, httpOptions);
  }
  updatePost(postCate : PostCategory): Observable<PostCategory> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<PostCategory>(this.url + '/update',
    postCate, httpOptions);
  }
  deletePostById(postId : number) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete/' + postId, httpOptions);
  }
  getDetail(postId : any){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<any>(this.url + '/detail/' + + postId, httpOptions);
  }
  private _listners = new Subject<any>();
  filter(filterBy: string){
    this._listners.next(filterBy);
  }
}
