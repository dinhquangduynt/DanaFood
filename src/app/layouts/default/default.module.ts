import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default.component';
import { DashboardComponent } from 'src/app/modules/dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { PostsComponent } from 'src/app/modules/posts/posts.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatSidenavModule} from '@angular/material/sidenav';
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DashboardService } from 'src/app/modules/dashboard.service';
import { ProductsComponent } from 'src/app/modules/products/products.component';
import { OrdersComponent } from 'src/app/modules/orders/orders.component';
import { LoginComponent } from './login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { BrowserModule }    from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { PostshowComponent } from 'src/app/modules/posts/postshow/postshow.component';
import { DefaultRoutingModule } from './default-routing.module';
import { PostaddComponent } from 'src/app/modules/posts/postadd/postadd.component';
import { PosteditComponent } from 'src/app/modules/posts/postedit/postedit.component';
import { OrdershowComponent } from 'src/app/modules/orders/ordershow/ordershow.component';
import { PostListshowComponent } from 'src/app/modules/post-list/post-listshow/post-listshow.component';




@NgModule({
  declarations: [
    DefaultComponent,
    DashboardComponent,
    PostsComponent,
    ProductsComponent,
    OrdersComponent,
    LoginComponent,
    PostshowComponent,
    PostaddComponent,
    PosteditComponent,
    OrdershowComponent,
    PostListshowComponent,

  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    MatSidenavModule,
    MatDividerModule,
    FlexLayoutModule,
    MatCardModule,
    MatPaginatorModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    BrowserModule,
    HttpClientModule,
    MatDatepickerModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    DefaultRoutingModule,
    HttpClientModule,

  ],
  providers: [
    DashboardService,

  ],
  // entryComponents: [
  //   PosteditComponent,
  //   PostaddComponent
  // ]

})
export class DefaultModule { }
