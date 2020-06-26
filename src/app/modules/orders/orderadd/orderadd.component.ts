import { Component, OnInit } from '@angular/core';
import { OrdersService } from 'src/app/services/order/orders.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-orderadd',
  templateUrl: './orderadd.component.html',
  styleUrls: ['./orderadd.component.css']
})
export class OrderaddComponent implements OnInit {

  addorder : FormGroup;
  constructor(
    private postcateservice: OrdersService,
    private route: ActivatedRoute,
    private router: Router ,
    public fb: FormBuilder,
    private http : HttpClient) {
    this.addorder = this.fb.group({
      CustomerName : [''],
      CustomerAddress : [''],
      CustomerEmail : [''],
      CustomerMobile : [''],
      PaymentMethod : [''],
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
        this.postcateservice.createOrder(this.addorder.value).subscribe((data: any) => {
          this.router.navigateByUrl('orders');
      (error: HttpErrorResponse) => {
        console.log(error.error);
      };
  });
}
}
