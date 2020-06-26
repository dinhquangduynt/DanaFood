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
import { PostlistEditComponent } from 'src/app/modules/post-list/postlist-edit/postlist-edit.component';
import { ProductshowComponent } from 'src/app/modules/products/productshow/productshow.component';
import { ProducteditComponent } from 'src/app/modules/products/productedit/productedit.component';
import { ProductaddComponent } from 'src/app/modules/products/productadd/productadd.component';
import { OrdereditComponent } from 'src/app/modules/orders/orderedit/orderedit.component';
import { PostlistAddComponent } from 'src/app/modules/post-list/postlist-add/postlist-add.component';
import { ProductlisteditComponent } from 'src/app/modules/productlist/productlistedit/productlistedit.component';
import { FeedbackComponent } from 'src/app/modules/feedback/feedback.component';


const routes: Routes = [
  { path: '', component: DefaultComponent,
    children: [
      { path: 'das', component: DashboardComponent,canActivate: [AuthGuard] },
      { path: 'products', component: ProductshowComponent, canActivate: [AuthGuard] },
      { path: 'orders', component: OrdershowComponent, canActivate: [AuthGuard] },
      { path: 'posts', component: PostshowComponent, canActivate: [AuthGuard] },
      { path: 'feedback', component: FeedbackComponent, canActivate: [AuthGuard] },
      { path: 'addpostcate', component: PostaddComponent, canActivate: [AuthGuard] },
      { path: 'addproduct', component: ProductaddComponent, canActivate: [AuthGuard] },
     // { path: 'addorder', component: OrderaddComponent, canActivate: [AuthGuard] },
      { path: 'addpostlist', component: PostlistAddComponent, canActivate: [AuthGuard] },
      { path: 'editpostcate/:id', component: PosteditComponent, canActivate: [AuthGuard] },
      { path: 'editorder/:id', component: OrdereditComponent, canActivate: [AuthGuard] },
      { path: 'editproductlist/:id', component: ProductlisteditComponent, canActivate: [AuthGuard] },
      { path: 'editproductcate/:id', component: ProducteditComponent, canActivate: [AuthGuard] },
      { path: 'postlist/:id', component: PostListshowComponent, canActivate: [AuthGuard] },
      { path: 'postitem', component: PostListshowComponent, canActivate: [AuthGuard] },
      { path: 'productlist/:id', component: ProductlistshowComponent, canActivate: [AuthGuard] },
      { path: 'editpostlist/:id', component: PostlistEditComponent, canActivate: [AuthGuard] },


    ]
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultRoutingModule { }
