import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ProductItemService } from 'src/app/services/product/product-item.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/services/shared.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-productlistadd',
  templateUrl: './productlistadd.component.html',
  styleUrls: ['./productlistadd.component.css']
})
export class ProductlistaddComponent implements OnInit {

  addpost : FormGroup;
  private cateID : any;
  subscription: Subscription;
  constructor(
    private postcateservice: ProductItemService,
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
      Price : [],
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
        this.postcateservice.createProduct(this.addpost.value).subscribe((data: any) => {
          this.router.navigateByUrl('products');
          console.log("ádfas");
      (error: HttpErrorResponse) => {
        console.log(error.error);

        window.confirm('UnAuthorization!')
      };
  });
}
}
