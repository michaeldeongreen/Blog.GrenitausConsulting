import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../home/home.component';
import { SearchResultsComponent } from '../search-results/search-results.component'
const routes: Routes = [
    { path: '', redirectTo: '/home/1', pathMatch: 'full' },
    //{ path: 'home', component: HomeComponent },
    { path: 'home/:id', component: HomeComponent },
    { path: 'searchResults/:criteria', component: SearchResultsComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
