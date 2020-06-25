import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DefaultModule } from './layouts/default/default.module';
import { UsershowComponent } from './modules/user/usershow/usershow.component';
import { FeedbackComponent } from './modules/feedback/feedback.component';
import { PostlistDetailComponent } from './modules/post-list/postlist-detail/postlist-detail.component';
import { AdminManagementComponent } from './modules/user/admin-management/admin-management.component';





@NgModule({
  declarations: [
    AppComponent,
    UsershowComponent,
    FeedbackComponent,
    PostlistDetailComponent,
    AdminManagementComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    DefaultModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
