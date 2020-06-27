import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductItem } from 'src/app/services/product/product-item';
import { MatTableDataSource } from '@angular/material/table';
import { ProductItemService } from 'src/app/services/product/product-item.service';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/services/shared.service';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-productlistshow',
  templateUrl: './productlistshow.component.html',
  styleUrls: ['./productlistshow.component.css']
})
export class ProductlistshowComponent implements OnInit {

  ELEMENT_DATA : ProductItem[];
  displayedColumns: string[] = ['ID', 'ProductName', 'Alias','CategoryID','Image','Price','Description','Action'];
  dataSource = new MatTableDataSource<ProductItem>(this.ELEMENT_DATA);

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  //PostCategory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(
    public postCate : ProductItemService,
    private route: ActivatedRoute,
    private service: SharedService,
  ) { }

  ngOnInit() {
    this.loadPosts()
    this.dataSource.sort = this.sort
    this.dataSource.paginator = this.paginator
  }

  public loadPosts() {
    const id = this.route.snapshot.paramMap.get('id');
    //this.service.send(id);
    localStorage.setItem("CateID", id);
    let productcate = this.postCate.getAllProductByCategory(id);
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as ProductItem[]);
  }
  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postCate.deleteProductById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}

