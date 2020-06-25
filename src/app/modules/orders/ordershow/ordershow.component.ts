import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/services/order/order.model';
import { MatTableDataSource } from '@angular/material/table';
import { OrdersService } from 'src/app/services/order/orders.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-ordershow',
  templateUrl: './ordershow.component.html',
  styleUrls: ['./ordershow.component.css']
})
export class OrdershowComponent implements OnInit {

  ELEMENT_DATA : Order[];
  displayedColumns: string[] = ['ID', 'CustomerName ', 'CustomerAddress', 'CustomerEmail','CustomerMobile','PaymentMethod','Status','Action'];
  dataSource = new MatTableDataSource<Order>(this.ELEMENT_DATA);
  //Order: any = [];

  constructor(
    public orderservice : OrdersService,
  ) { }

  ngOnInit() {
    this.loadOrder()
  }

  public loadOrder() {
    let productcate = this.orderservice.getAllOrders();
    productcate.subscribe(orderItem => this.dataSource.data = orderItem as Order[]);
  }

  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.orderservice.deleteOrderById(id).subscribe(data => {
        this.loadOrder()
      })
    }
  }

}
