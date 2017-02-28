import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../home/home.component';
import { SearchResultsComponent } from '../search-results/search-results.component'
import { PostComponent } from '../post/post.component';
import { AboutComponent } from '../about/about.component';
import { CategoryComponent } from '../category/category.component'
import { TagComponent } from '../tag/tag.component'
import { ArchiveComponent } from '../archive/archive.component'

const routes: Routes = [
    { path: '', redirectTo: '/home/1', pathMatch: 'full' },
    { path: 'home/:id', component: HomeComponent },
    { path: 'searchResults/:criteria', component: SearchResultsComponent },
    { path: 'post/:title', component: PostComponent },
    { path: 'about', component: AboutComponent },
    { path: 'category/:category', component: CategoryComponent },
    { path: 'tag/:tag', component: TagComponent },
    { path: 'archive/:month/:year', component: ArchiveComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
