import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Category } from '../category';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
    categories: Observable<Category>;

    constructor(private httpService: HttpService) {}

    ngOnInit() {
        this.getCategories();
  }

  getCategories() {
      this.httpService.getCategories()
          .subscribe(data => {
              this.categories = data;
          });
  }
}
