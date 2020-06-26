import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ProductsService } from 'src/app/services/product/products.service';

@Component({
  selector: 'app-productadd',
  templateUrl: './productadd.component.html',
  styleUrls: ['./productadd.component.css']
})
export class ProductaddComponent implements OnInit {

  addCate : FormGroup;
  constructor(
    private postcateservice: ProductsService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private http : HttpClient) {
    this.addCate = this.fb.group({
      Name: [''],
      Alias: [''],
      Image: [''],
      Description: [''],
      Homeflag: false,
    })
  }
  imageObj: File;
  imageUrl: string;
  ngOnInit(): void {
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
        this.postcateservice.createProduct(this.addCate.value).subscribe((data: any) => {
          this.router.navigateByUrl('products');
      (error: HttpErrorResponse) => {
        console.log(error.error);
      };
  });
}
}
