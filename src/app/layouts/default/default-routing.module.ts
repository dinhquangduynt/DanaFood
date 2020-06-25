import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultComponent } from './default.component';
import { PostshowComponent } from 'src/app/modules/posts/postshow/postshow.component';
import { DashboardComponent } from 'src/app/modules/dashboard/dashboard.component';
import { ProductsComponent } from 'src/app/modules/products/products.component';
import { PostaddComponent } from 'src/app/modules/posts/postadd/postadd.component';
import { PosteditComponent } from 'src/app/modules/posts/postedit/postedit.component';
import { OrdershowComponent } from 'src/app/modules/orders/ordershow/ordershow.component';
import { PostListshowComponent } from 'src/app/modules/post-list/post-listshow/post-listshow.component';
import { AuthGuard } from 'src/app/helpers/login-active.service';
import { ProductlistshowComponent } from 'src/app/modules/productlist/productlistshow/productlistshow.component';


const routes: Routes = [
  { path: '', component: DefaultComponent,
    children: [
      { path: 'das', component: DashboardComponent,canActivate: [AuthGuard] },
      { path: 'products', component: ProductsComponent, canActivate: [AuthGuard] },
      { path: 'orders', component: OrdershowComponent, canActivate: [AuthGuard] },
      { path: 'posts', component: PostshowComponent, canActivate: [AuthGuard] },
      { path: 'addpostcate', component: PostaddComponent, canActivate: [AuthGuard] },
      { path: 'editpostcate/:id', component: PosteditComponent, canActivate: [AuthGuard] },
      { path: 'postlist/:id', component: PostListshowComponent, canActivate: [AuthGuard] },
      { path: 'postitem', component: PostListshowComponent, canActivate: [AuthGuard] },
      { path: 'productlist/:id', component: ProductlistshowComponent, canActivate: [AuthGuard] },


    ]
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultRoutingModule { }
