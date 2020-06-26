import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductCategory } from './product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  url =  'https://danafoodapp.azurewebsites.net/api/productcategory';
  constructor(private http: HttpClient) { }
  getAllProductCategory(): Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(this.url + '/getall');
  }
  getProductById(productId : number): Observable<ProductCategory> {
    return this.http.get<ProductCategory>(this.url + '/getsinglebyid/' + productId);
  }
  getDetail(productId : any){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<any>(this.url + '/detail/' + productId, httpOptions);
  }
  createProduct(product: ProductCategory): Observable<ProductCategory> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<ProductCategory>(this.url + '/add',
    product, httpOptions);
  }
  updateProduct(product: ProductCategory): Observable<ProductCategory> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<ProductCategory>(this.url + '/update',
    product, httpOptions);
  }
  deleteProductById(productId : number) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete/' + productId, httpOptions);
  }
}

