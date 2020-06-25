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
  displayedColumns: string[] = ['ID', 'CustomerName', 'CustomerAddress', 'CustomerEmail','CustomerMobile','Action'];
  dataSource = new MatTableDataSource<Order>(this.ELEMENT_DATA);
  //PostCategory: any = [];

  constructor(
    public postCate : OrdersService,
  ) { }

  ngOnInit() {
    this.loadPosts()
  }

  public loadPosts() {
    let productcate = this.postCate.getAllOrders();
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as Order[]);
  }

  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postCate.deleteOrderById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}
