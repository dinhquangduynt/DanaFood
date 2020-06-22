import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostItem } from './post-item';


@Injectable({
  providedIn: 'root'
})
export class PostsService {
  url =  'https://danafoodapp.azurewebsites.net/api/post';
  constructor(private http: HttpClient) { }
  getAllPosts(): Observable<PostItem[]> {
    return this.http.get<PostItem[]>(this.url + '/getall');
  }
  getPostById(postId): Observable<PostItem> {
    return this.http.get<PostItem>(this.url + '/getsinglebyid' + postId);
  }
  createPost(post: PostItem): Observable<PostItem> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<PostItem>(this.url + '/add',
    post, httpOptions);
  }
  updatePost(post: PostItem): Observable<PostItem> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<PostItem>(this.url + '/update',
    post, httpOptions);
  }
  deletePostById(postId) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete?id=' + postId,
 httpOptions);
  }
}
