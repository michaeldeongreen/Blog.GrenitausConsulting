import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Ng2PaginationModule } from 'ng2-pagination';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SearchComponent } from './search/search.component';
import { CategoriesComponent } from './categories/categories.component';
import { SideWidgetComponent } from './side-widget/side-widget.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SearchComponent,
    CategoriesComponent,
    SideWidgetComponent,
    FooterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
      HttpModule,
    Ng2PaginationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
