import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { PostItemService } from 'src/app/services/post/post-item.service';
import { SharedService } from 'src/app/services/shared.service';
import { Subscription } from 'rxjs/internal/Subscription';


@Component({
  selector: 'app-postlist-add',
  templateUrl: './postlist-add.component.html',
  styleUrls: ['./postlist-add.component.css']
})
export class PostlistAddComponent implements OnInit {

  addpost : FormGroup;
  private cateID : any;
  subscription: Subscription;
  constructor(
    private postcateservice: PostItemService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private shared : SharedService,
    private http : HttpClient) {
    // this.subscription =  shared.subj$.subscribe(val=>{
    //   this.cateID = val;
    //     })
    this.cateID = localStorage.getItem("CateID");

    this.addpost = this.fb.group({
      Name: [''],
      Alias: [''],
      Image: [''],
      Description: [''],
      Homeflag: false,
      CategoryID : [this.cateID]
    })
  }
  imageObj: File;
  imageUrl: string;

  ngOnInit(): void {
    localStorage.removeItem("CateID");
  }
  uploadFile(event) {
    const FILE = (event.target as HTMLInputElement).files[0];
    this.imageObj = FILE;
  }
  onSubmit(){
  //  const imageForm = new FormData();
  //    imageForm.append('image', this.imageObj);
  //   const id = this.route.snapshot.paramMap.get('id');

  //    this.postcateservice.upload(imageForm).subscribe(
  //     (response: any) => {
  //       this.editCate.value.logo = response.data._id;
        this.postcateservice.createPost(this.addpost.value).subscribe((data: any) => {
          this.router.navigateByUrl('postlist/:id');
      (error: HttpErrorResponse) => {
        console.log(error.error);
      };
  });
}
}
