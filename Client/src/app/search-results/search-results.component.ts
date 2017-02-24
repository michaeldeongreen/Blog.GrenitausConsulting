import { ChangeDetectionStrategy, Component, OnInit} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { PagerService } from '../pager.service';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { SearchComponent } from '../search/search.component';
import { SharedEmitterService } from '../shared-emitter.service';

@Component({
    moduleId: module.id,
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {
    criteria: string;

    constructor(private http: Http,
        private httpService: HttpService,
        private pagerService: PagerService,
        private route: ActivatedRoute,
        private sharedEmitterService: SharedEmitterService) {

        this.sharedEmitterService.searchCriteriaChanged.subscribe(criteria => {
            this.criteria = criteria;
            this.setCriteria();
        });
    }

    // pager object
    pager: any = {};

    // paged items
    pagedItems: Observable<Post[]>;

    pageNumber: number;

    ngOnInit() {
        this.criteria = this.route.snapshot.params['criteria'];
        this.setCriteria();
  }

  setCriteria() {
      if (this.criteria != 'undefined' && this.criteria) {
          this.setPage(1);
      }
  }


  setPage(page: number) {
      //let criteria = this.route.snapshot.params['criteria'];

      if (page < 1 || page > this.pager.totalPages) {
          return;
      }

      this.httpService.getSearchResults(page, this.criteria)
          .subscribe(data => {
              // get pager object from service
              this.pager = this.pagerService.getPager(data.total, page);

              // get current page of items
              this.pagedItems = data.posts;
          });
  }
}
