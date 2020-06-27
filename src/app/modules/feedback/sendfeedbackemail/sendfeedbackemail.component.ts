import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Feedback } from 'src/app/services/feedback/feedback';
import { FeedbackService } from 'src/app/services/feedback/feedback.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sendfeedbackemail',
  templateUrl: './sendfeedbackemail.component.html',
  styleUrls: ['./sendfeedbackemail.component.css']
})
export class SendfeedbackemailComponent implements OnInit {

  getfeedback : FormGroup;
  sendfeedback : FormGroup;
  currentFeedback : Feedback;
  constructor(private service: FeedbackService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private http : HttpClient) {

  }
  imageObj: File;
  imageUrl: string;
  ngOnInit(): void {
    this.getProfile();
    this.getfeedback = this.fb.group({
       ID : [],
       Name: [''],
       Email: [''],
       Message: [''],
       Title : [''],
       EmailContent: [''],
    })
  }
   uploadFile(event) {
    const FILE = (event.target as HTMLInputElement).files[0];
    this.imageObj = FILE;
  }

  onSubmit(){
        this.service.updateFeedback(this.getfeedback.value).subscribe((data: any) => {
          this.router.navigateByUrl('feedback');
        }, (error: HttpErrorResponse) => {
          console.log(error.error);
        });

  }
  getProfile() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getFeedbackById(id).subscribe(reponse => {
      console.log(reponse);
      this.currentFeedback = reponse;
      this.getfeedback = this.fb.group({
        ID: [id],
        Name: [this.currentFeedback.Name],
        Email: [this.currentFeedback.Email],
        Message : [this.currentFeedback.Message],
        Title : [this.currentFeedback.Title],
        EmailContent: [this.currentFeedback.EmailContent],

      })
    });
  }
}
