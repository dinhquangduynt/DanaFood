import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { PostsService } from 'src/app/services/post/posts.service';
import { PostCategory } from 'src/app/services/post/post.model';

@Component({
  selector: 'app-postedit',
  templateUrl: './postedit.component.html',
  styleUrls: ['./postedit.component.css']
})
export class PosteditComponent implements OnInit {

  editCate : FormGroup;
  currentPostCate : PostCategory;
  constructor(private cateService: PostsService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private http : HttpClient) {

  }
  imageObj: File;
  imageUrl: string;
  ngOnInit(): void {
    this.getProfile();
    this.editCate = this.fb.group({
       ID: [],
       Name: [''],
       Alias: [''],
       Image: [''],
       Description: ['']
    })
  }
   uploadFile(event) {
    const FILE = (event.target as HTMLInputElement).files[0];
    this.imageObj = FILE;
  }

  onSubmit(){
        this.cateService.updatePost(this.editCate.value).subscribe((data: any) => {
          this.router.navigateByUrl('posts');
        });
      (error: HttpErrorResponse) => {
        console.log(error.error);
      }
  }
  getProfile() {
    const id = this.route.snapshot.paramMap.get('id');
    this.cateService.getDetail(id).subscribe(reponse => {
      console.log(reponse);
      this.currentPostCate = reponse;
      this.editCate = this.fb.group({
        ID: [id],
        Name: [this.currentPostCate.Name],
        Alias: [this.currentPostCate.Alias],
        Image: [this.currentPostCate.Image],
        Description: [this.currentPostCate.Description],

      })
    });
  }
}
