import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultComponent } from './layouts/default/default.component';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { PostsComponent } from './modules/posts/posts.component';
import { ProductsComponent } from './modules/products/products.component';
import { OrdersComponent } from './modules/orders/orders.component';
import { LoginComponent } from './layouts/default/login/login.component';
import { PostItemComponent } from './modules/posts/post-item/post-item.component';

const routes: Routes = [{
  path: 'login',
  component: LoginComponent
  }, {
  path: '',
  component: DefaultComponent,
  children: [{
    path: '',
    component: DashboardComponent
  }, {
    path: 'posts',
    component: PostsComponent
  }, {
    path: 'products',
    component: ProductsComponent
  }, {
    path: 'orders',
    component: OrdersComponent
  },{
    path: 'postEdit',
    component: PostItemComponent
  }
]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
