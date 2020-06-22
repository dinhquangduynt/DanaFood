import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { PostsService } from 'src/app/services/post/posts.service';
import { PostsComponent } from '../posts.component';
import { NotificationService } from 'src/app/services/notification/notification.service';
import { FormBuilder, Validators } from '@angular/forms';
import { PostCategory } from 'src/app/services/post/post.model';


@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.css']
})
export class PostItemComponent implements OnInit {
  dataSaved = false;
  postForm: any;
  postIdUpdate = null;
  massage = null;

  constructor(private service: PostsService,
    private notificationService: NotificationService,
    private formbulider: FormBuilder,
    public dialogRef: MatDialogRef<PostsComponent>) { }



  ngOnInit() {
    this.postForm = this.formbulider.group({
      Name: ['', [Validators.required]],
      CreatedDate: ['', [Validators.required]],
      CreatedBy: ['', [Validators.required]],
      Image: ['', [Validators.required]],
      Alias: ['', [Validators.required]],
      Description: ['', [Validators.required]],
    });
    this.service.getAllPosts();
  }

  onClear() {
    this.postForm.reset();
    //this.service.initializeFormGroup();
    this.notificationService.success(':: Submitted successfully');
  }

  onSubmit() {
    this.dataSaved = false;
    const post = this.postForm.value;
    this.createPost(post);
    this.postForm.reset();
    }
  createPost(post: PostCategory) {
    if (this.postIdUpdate == null) {
      this.service.createPost(post).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          //this.loadAllEmployees();
          this.postIdUpdate = null;
          this.postForm.reset();
        }
      );
    } else {
      post.ID = this.postIdUpdate;
      this.service.updatePost(post).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        //this.loadAllEmployees();
        this.postIdUpdate = null;
        this.postForm.reset();
      });
    }
  }
  resetForm() {
    this.postForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }
  loadPostToEdit(Id : number) {
    this.service.getPostById(Id).subscribe(post=> {
      this.massage = null;
      this.dataSaved = false;
      this.postIdUpdate = post.ID;
      this.postForm.controls['EmpName'].setValue(post.Name);
      this.postForm.controls['DateOfBirth'].setValue(post.CreatedDate);
      this.postForm.controls['EmailId'].setValue(post.CreatedBy);
      this.postForm.controls['Gender'].setValue(post.Image);
      this.postForm.controls['Address'].setValue(post.Alias);
      this.postForm.controls['PinCode'].setValue(post.Description);
    });
  }

  }
