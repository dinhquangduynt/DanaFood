import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { PostItem } from './post-item.model';


@Injectable({
  providedIn: 'root'
})
export class PostItemService {
  url =  'https://danafoodapp.azurewebsites.net/api/post';
  constructor(private http: HttpClient) { }
  formData : PostItem;
  getAllPosts(): Observable<PostItem[]> {
    return this.http.get<PostItem[]>(this.url + '/getall');
  }
  getAllPostByCategory(postId : any): Observable<PostItem[]> {
    return this.http.get<PostItem[]>(this.url + '/getallbycategory/' + postId);
  }
  getPostById(postId : any): Observable<PostItem> {
    return this.http.get<PostItem>(this.url + '/getsinglebyid/' + postId);
  }
  createPost(data : any): Observable<PostItem> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<PostItem>(this.url + '/add',
    data, httpOptions);
  }
  updatePost(postCate : PostItem): Observable<PostItem> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<PostItem>(this.url + '/update',
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
