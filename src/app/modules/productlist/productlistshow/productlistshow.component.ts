import { Component, OnInit } from '@angular/core';
import { ProductItem } from 'src/app/services/product/product-item';
import { MatTableDataSource } from '@angular/material/table';
import { ProductItemService } from 'src/app/services/product/product-item.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productlistshow',
  templateUrl: './productlistshow.component.html',
  styleUrls: ['./productlistshow.component.css']
})
export class ProductlistshowComponent implements OnInit {

  ELEMENT_DATA : ProductItem[];
  displayedColumns: string[] = ['ID', 'ProductName', 'Alias','CategoryID','Image','Price','Description','Content','Action'];
  dataSource = new MatTableDataSource<ProductItem>(this.ELEMENT_DATA);
  //PostCategory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(
    public postCate : ProductItemService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.loadPosts()
  }

  public loadPosts() {
    const id = this.route.snapshot.paramMap.get('id');
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

