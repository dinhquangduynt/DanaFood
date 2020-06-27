import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductCategory } from 'src/app/services/product/product.model';
import { MatTableDataSource } from '@angular/material/table';
import { ProductsService } from 'src/app/services/product/products.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { from } from 'rxjs';

@Component({
  selector: 'app-productshow',
  templateUrl: './productshow.component.html',
  styleUrls: ['./productshow.component.css']
})
export class ProductshowComponent implements OnInit {

  ELEMENT_DATA : ProductCategory[];
  displayedColumns: string[] = ['ID', 'ProductCategoryName', 'CreatedDate', 'CreatedBy','Alias', 'Action'];
  dataSource = new MatTableDataSource<ProductCategory>(this.ELEMENT_DATA);

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  //ProductCategory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(
    public ProductCate : ProductsService,
    private dialog: MatDialog,
  ) { }



  ngOnInit() {
    this.loadProducts()
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public loadProducts() {
    //  return this.ProductCate.getAllProducts().subscribe((ProductCateItem: {}) => {
    //   this.dataSource.data = ProductCateItem;
    //  })
    let productcate = this.ProductCate.getAllProductCategory();
    productcate.subscribe(ProductCateItem => this.dataSource.data = ProductCateItem as ProductCategory[]);
  }
  // onEdit(row){
  //   //this.ProductCate.populateForm(row);
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.disableClose = true;
  //   dialogConfig.autoFocus = true;
  //   dialogConfig.width = "60%";
  //   this.dialog.open(ProductItemComponent,dialogConfig);
  // }
  // onCreate() {
  //   //this.service.initializeFormGroup();
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.disableClose = true;
  //   dialogConfig.autoFocus = true;
  //   dialogConfig.width = "60%";
  //   this.dialog.open(ProductItemComponent,dialogConfig);
  // }

  onDelete(Id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.ProductCate.deleteProductById(Id).subscribe(() => {
        this.loadProducts();
      });
    }
  }

}

