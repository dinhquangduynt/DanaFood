import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ProductItem } from 'src/app/services/product/product-item';
import { ProductItemService } from 'src/app/services/product/product-item.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-productlistedit',
  templateUrl: './productlistedit.component.html',
  styleUrls: ['./productlistedit.component.css']
})
export class ProductlisteditComponent implements OnInit {
  editPost : FormGroup;
  currentPostCate : ProductItem;
  constructor(private cateService: ProductItemService,
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
       Description: [''],
       Price : [],
       Content : ['']
    })
  }
   uploadFile(event) {
    const FILE = (event.target as HTMLInputElement).files[0];
    this.imageObj = FILE;
  }

  onSubmit(){
        this.cateService.updateProduct(this.editPost.value).subscribe((data: any) => {
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
        Price: [this.currentPostCate.Price],
        Content: [this.currentPostCate.Content],

      })
    });
  }
}
