import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { DefaultComponent } from './layouts/default/default.component';
import { LoginComponent } from './layouts/default/login/login.component';



const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'home', loadChildren: () => import('./layouts/default/default.module').then((m) => m.DefaultModule)}];

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
