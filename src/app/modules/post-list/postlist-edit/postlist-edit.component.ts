import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { PostItem } from 'src/app/services/post/post-item.model';
import { PostItemService } from 'src/app/services/post/post-item.service';

@Component({
  selector: 'app-postlist-edit',
  templateUrl: './postlist-edit.component.html',
  styleUrls: ['./postlist-edit.component.css']
})
export class PostlistEditComponent implements OnInit {

  editPost : FormGroup;
  currentPostCate : PostItem;
  constructor(private cateService: PostItemService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private http : HttpClient) {

  }
  imageObj: File;
  imageUrl: string;
  ngOnInit(): void {
    this.getProfile();
    this.editPost = this.fb.group({
       ID: [],
       Name: [''],
       Alias: [''],
       CategoryID: [''],
       Image: [''],
       Description: ['']
    })
  }
   uploadFile(event) {
    const FILE = (event.target as HTMLInputElement).files[0];
    this.imageObj = FILE;
  }

  onSubmit(){
        this.cateService.updatePost(this.editPost.value).subscribe((data: any) => {
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
      this.editPost = this.fb.group({
        ID: [id],
        Name: [this.currentPostCate.Name],
        Alias: [this.currentPostCate.Alias],
        CategoryID : [this.currentPostCate.CategoryID],
        Image: [this.currentPostCate.Image],
        Description: [this.currentPostCate.Description],

      })
    });
  }
}
