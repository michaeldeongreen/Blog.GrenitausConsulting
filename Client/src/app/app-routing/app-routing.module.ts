import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../home/home.component';

const routes: Routes = [
    { path: '', redirectTo: '/home/1', pathMatch: 'full' },
    //{ path: 'home', component: HomeComponent },
    { path: 'home/:id', component: HomeComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
