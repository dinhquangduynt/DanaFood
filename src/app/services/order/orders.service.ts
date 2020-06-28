import { Injectable } from '@angular/core';
import { Order } from './order.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Orderdetail } from './orderdetail';


@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  url =  'https://danafoodapp.azurewebsites.net/api/order';
  constructor(private http: HttpClient) { }
  formData : Order;
  getAllOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.url + '/getall');
  }
  getOrderById(OrderId : any): Observable<Orderdetail[]> {
    return this.http.get<Orderdetail[]>(this.url + '/getorderdetailbyid/' + OrderId);
  }
  createOrder(data : any): Observable<Order> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<Order>(this.url + '/add',
    data, httpOptions);
  }
  updateStatus(order : Order): Observable<Order> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<Order>(this.url + '/updatestatus',
    order, httpOptions);
  }
  updateOrder(order : Order): Observable<Order> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<Order>(this.url + '/update',
    order, httpOptions);
  }
  deleteOrderById(OrderId : number) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<number>(this.url + '/delete/' + OrderId, httpOptions);
  }
  getDetail(OrderId : any){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.get<any>(this.url + '/getbyid/' + OrderId, httpOptions);
  }
  private _listners = new Subject<any>();
  filter(filterBy: string){
    this._listners.next(filterBy);
  }
}

