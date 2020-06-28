import { Component, OnInit, ViewChild } from '@angular/core';
import { Orderdetail } from 'src/app/services/order/orderdetail';
import { OrdersService } from 'src/app/services/order/orders.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-orderdetail',
  templateUrl: './orderdetail.component.html',
  styleUrls: ['./orderdetail.component.css']
})
export class OrderdetailComponent implements OnInit {

  ELEMENT_DATA : Orderdetail[];
  displayedColumns: string[] = ['ProductID', 'Quantity', 'Price'];
  dataSource = new MatTableDataSource<Orderdetail>(this.ELEMENT_DATA);
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  //servicegory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(
    public service : OrdersService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.loadPosts();
    this.dataSource.paginator = this.paginator;
  }

  public loadPosts() {
    const id = this.route.snapshot.paramMap.get('id');
    let order = this.service.getOrderById(id);
    order.subscribe(postCateItem => this.dataSource.data = postCateItem as Orderdetail[]);
  }

  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.service.deleteOrderById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}

