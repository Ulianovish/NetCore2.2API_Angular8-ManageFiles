import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BairesDevComponent } from './baires-dev/baires-dev.component';

const routes: Routes = [
  { path: '', component: BairesDevComponent, pathMatch: 'full' },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
