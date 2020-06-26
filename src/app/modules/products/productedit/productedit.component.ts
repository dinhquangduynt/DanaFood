import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ProductCategory } from 'src/app/services/product/product.model';
import { ProductsService } from 'src/app/services/product/products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-productedit',
  templateUrl: './productedit.component.html',
  styleUrls: ['./productedit.component.css']
})
export class ProducteditComponent implements OnInit {

  editCate : FormGroup;
  currentPostCate : ProductCategory;
  constructor(private cateService: ProductsService,
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
        this.cateService.updateProduct(this.editCate.value).subscribe((data: any) => {
          this.router.navigateByUrl('products');
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
