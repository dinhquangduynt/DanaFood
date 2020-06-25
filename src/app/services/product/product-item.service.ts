import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductItem } from './product-item';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductItemService {

  url =  'https://danafoodapp.azurewebsites.net/api/product';
  constructor(private http: HttpClient) { }
  formData : ProductItem;
  getAllProduct(): Observable<ProductItem[]> {
    return this.http.get<ProductItem[]>(this.url + '/getall');
  }
  getAllProductByCategory(productId : any): Observable<ProductItem[]> {
    return this.http.get<ProductItem[]>(this.url + '/getallbycategory/' + productId);
  }
  getProductById(productId : any): Observable<ProductItem> {
    return this.http.get<ProductItem>(this.url + '/getsinglebyid/' + productId);
  }
  createProduct(data : any): Observable<ProductItem> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<ProductItem>(this.url + '/add',
    data, httpOptions);
  }
  updateProduct(productCate : ProductItem): Observable<ProductItem> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<ProductItem>(this.url + '/update',
    productCate, httpOptions);
  }
  deleteProductById(productId : number) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete/' + productId, httpOptions);
  }
  getDetail(productId : any){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<any>(this.url + '/detail/' + productId, httpOptions);
  }
  private _listners = new Subject<any>();
  filter(filterBy: string){
    this._listners.next(filterBy);
  }
}
