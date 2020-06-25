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


const routes: Routes = [
  { path: '', component: DefaultComponent,
    children: [
      { path: 'das', component: DashboardComponent },
      { path: 'products', component: ProductsComponent },
      { path: 'orders', component: OrdershowComponent },
      { path: 'posts', component: PostshowComponent },
      { path: 'addpostcate', component: PostaddComponent },
      { path: 'editpostcate/:id', component: PosteditComponent },
      { path: 'postlist/:id', component: PostListshowComponent },
      { path: 'postitem', component: PostListshowComponent },


    ]
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultRoutingModule { }
