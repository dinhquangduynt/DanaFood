import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Feedback } from './feedback';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
  url =  'https://danafoodapp.azurewebsites.net/api/feedback';
  constructor(private http: HttpClient) { }
  formData : Feedback;
  getAllFeedbacks(): Observable<Feedback[]> {
    return this.http.get<Feedback[]>(this.url + '/getall');
  }
  getFeedbackById(FeedbackId : any): Observable<Feedback> {
    return this.http.get<Feedback>(this.url + '/getbyid/' + FeedbackId);
  }
  updateFeedback(Feedback : Feedback): Observable<Feedback> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<Feedback>(this.url + '/reply',
    Feedback, httpOptions);
  }


}
