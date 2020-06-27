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
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClientJsonpModule } from '@angular/common/http';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { PostshowComponent } from 'src/app/modules/posts/postshow/postshow.component';
import { DefaultRoutingModule } from './default-routing.module';
import { PostaddComponent } from 'src/app/modules/posts/postadd/postadd.component';
import { PosteditComponent } from 'src/app/modules/posts/postedit/postedit.component';
import { OrdershowComponent } from 'src/app/modules/orders/ordershow/ordershow.component';
import { PostListshowComponent } from 'src/app/modules/post-list/post-listshow/post-listshow.component';
import { TokenInterceptor } from 'src/app/helpers/token-interceptor';
import {MatTooltipModule} from '@angular/material/tooltip';
import { ProductlistshowComponent } from 'src/app/modules/productlist/productlistshow/productlistshow.component';
import { UsershowComponent } from 'src/app/modules/user/usershow/usershow.component';
import { FeedbackComponent } from 'src/app/modules/feedback/feedback.component';
import { PostlistDetailComponent } from 'src/app/modules/post-list/postlist-detail/postlist-detail.component';
import { AdminManagementComponent } from 'src/app/modules/user/admin-management/admin-management.component';
import { PostlistEditComponent } from 'src/app/modules/post-list/postlist-edit/postlist-edit.component';
import { PostlistAddComponent } from 'src/app/modules/post-list/postlist-add/postlist-add.component';
import { ProductshowComponent } from 'src/app/modules/products/productshow/productshow.component';
import { ProductaddComponent } from 'src/app/modules/products/productadd/productadd.component';
import { ProducteditComponent } from 'src/app/modules/products/productedit/productedit.component';
import { OrdereditComponent } from 'src/app/modules/orders/orderedit/orderedit.component';
import { ProductlistaddComponent } from 'src/app/modules/productlist/productlistadd/productlistadd.component';
import { ProductlisteditComponent } from 'src/app/modules/productlist/productlistedit/productlistedit.component';
import { SharedService } from 'src/app/services/shared.service';
import { MatTabsModule} from '@angular/material/tabs';
import { SendfeedbackemailComponent } from 'src/app/modules/feedback/sendfeedbackemail/sendfeedbackemail.component';
import { FeedbackshowComponent } from 'src/app/modules/feedback/feedbackshow/feedbackshow.component';




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
    ProductlistshowComponent,
    UsershowComponent,
    FeedbackComponent,
    PostlistDetailComponent,
    AdminManagementComponent,
    PostlistEditComponent,
    PostlistAddComponent,
    ProductshowComponent,
    ProductaddComponent,
    ProducteditComponent,
    OrdershowComponent,
    OrdereditComponent,
    ProductlistaddComponent,
    ProductlisteditComponent,
    SendfeedbackemailComponent,
    FeedbackshowComponent,

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
    HttpClientJsonpModule,
    MatTooltipModule,
    MatPaginatorModule,
    MatTabsModule,

  ],
  providers: [
    SharedService,
    {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
    }

  ],
  // entryComponents: [
  //   PosteditComponent,
  //   PostaddComponent
  // ]

})
export class DefaultModule { }
