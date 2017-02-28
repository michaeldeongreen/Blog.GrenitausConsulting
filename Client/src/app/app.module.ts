import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Ng2PaginationModule } from 'ng2-pagination';
import { AppRoutingModule } from './app-routing/app-routing.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SearchComponent } from './search/search.component';
import { CategoriesComponent } from './categories/categories.component';
import { SideWidgetComponent } from './side-widget/side-widget.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { HttpService } from './http.service';
import { PagerService } from './pager.service';
import { SearchResultsComponent } from './search-results/search-results.component';
import { SharedEmitterService } from './shared-emitter.service';
import { PostComponent } from './post/post.component';
import { AboutComponent } from './about/about.component';
import { CategoryComponent } from './category/category.component';
import { TagComponent } from './tag/tag.component';
import { SeoService } from './seo.service';
import { ArchivesComponent } from './archives/archives.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SearchComponent,
    CategoriesComponent,
    SideWidgetComponent,
    FooterComponent,
    HomeComponent,
      SearchResultsComponent,
      PostComponent,
      AboutComponent,
      CategoryComponent,
      TagComponent,
      ArchivesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
      HttpModule,
      Ng2PaginationModule,
      AppRoutingModule
      
  ],
  providers: [HttpService, PagerService, SharedEmitterService, SeoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
