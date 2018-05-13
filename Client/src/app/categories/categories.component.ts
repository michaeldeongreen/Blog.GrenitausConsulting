import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Category } from '../category';
import { Observable } from 'rxjs/Observable';
import { SharedEmitterService } from '../shared-emitter.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
    categories: Observable<Category>;

    constructor(private httpService: HttpService,
        public sharedEmitterService: SharedEmitterService,
    private router: Router) { }

    ngOnInit() {
        this.getCategories();
  }

  getCategories() {
      this.httpService.getCategories()
          .subscribe(data => {
              this.categories = data;
          },
          err => {
              console.log("Error occurred while trying to retrieve categories");
          }
      );
  }

  gotoCategory(category: string): void {
      this.sharedEmitterService.categoryChangedEvent(category);
      let link = ['/category', category]
      this.router.navigate(link);
  }
}
