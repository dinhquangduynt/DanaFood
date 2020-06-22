import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostCategory } from './post.model';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  url =  'https://danafoodapp.azurewebsites.net/api/postcategory';
  constructor(private http: HttpClient) { }
  getAllPosts(): Observable<PostCategory[]> {
    return this.http.get<PostCategory[]>(this.url + '/getall');
  }
  getPostById(postId : number): Observable<PostCategory> {
    return this.http.get<PostCategory>(this.url + '/getsinglebyid' + postId);
  }
  createPost(post: PostCategory): Observable<PostCategory> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<PostCategory>(this.url + '/add',
    post, httpOptions);
  }
  updatePost(post: PostCategory): Observable<PostCategory> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<PostCategory>(this.url + '/update',
    post, httpOptions);
  }
  deletePostById(postId : number) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete?id=' + postId, httpOptions);
  }
}
