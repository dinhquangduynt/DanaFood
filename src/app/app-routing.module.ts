import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultComponent } from './layouts/default/default.component';



const routes: Routes = [
  { path: '', component: DefaultComponent},
  { path: 'home', loadChildren: () => import('./layouts/default/default.module').then((m) => m.DefaultModule)}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
