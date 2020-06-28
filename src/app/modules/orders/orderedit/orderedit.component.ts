import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Order } from 'src/app/services/order/order.model';
import { OrdersService } from 'src/app/services/order/orders.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-orderedit',
  templateUrl: './orderedit.component.html',
  styleUrls: ['./orderedit.component.css']
})
export class OrdereditComponent implements OnInit {

  editCate : FormGroup;
  currentPostCate : Order;
  checkboxFlag : boolean;
  constructor(private cateService: OrdersService,
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
      ID : [],
      CustomerName : [''],
      CustomerAddress : [''],
      CustomerEmail : [''],
      CustomerMobile : [''],
      PaymentMethod : [''],
      Status: this.checkboxFlag
    })
  }
   uploadFile(event) {
    const FILE = (event.target as HTMLInputElement).files[0];
    this.imageObj = FILE;
  }

  onSubmit(){
        this.cateService.updateOrder(this.editCate.value).subscribe((data: any) => {
          this.router.navigateByUrl('orders');
        });
      (error: HttpErrorResponse) => {
        console.log(error.error);
      }
      this.cateService.updateStatus(this.editCate.value).subscribe((data: any) => {
        this.checkboxFlag = data;
        this.router.navigateByUrl('orders');
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
        CustomerName: [this.currentPostCate.CustomerName],
        CustomerAddress: [this.currentPostCate.CustomerAddress],
        CustomerEmail: [this.currentPostCate.CustomerEmail],
        CustomerMobile: [this.currentPostCate.CustomerMobile],
        PaymentMethod: [this.currentPostCate.PaymentMethod],


      })
    });
  }
}
