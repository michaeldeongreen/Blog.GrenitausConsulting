import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { Post } from '../post';
import { HttpService } from '../http.service';

@Component({
    moduleId: module.id,
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [HttpService]
})
export class SearchComponent implements OnInit {
    posts: Observable<Post[]>;
    p: number;

  constructor(private httpService: HttpService, private router: Router) { }

  ngOnInit() {
  }

  gotoSearchResults(textBox: HTMLInputElement): void {
      let link = ['/searchResults', textBox.value]
      textBox.value = null;
      this.router.navigate(link);
  }
}
