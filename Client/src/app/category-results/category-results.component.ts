import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { PagerService } from '../pager.service';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { SharedEmitterService } from '../shared-emitter.service';

@Component({
  selector: 'app-category-results',
  templateUrl: './category-results.component.html',
  styleUrls: ['./category-results.component.css']
})
export class CategoryResultsComponent implements OnInit {
    category: string;

    constructor(private http: Http,
        private httpService: HttpService,
        private pagerService: PagerService,
        private route: ActivatedRoute,
        private sharedEmitterService: SharedEmitterService) {

        this.sharedEmitterService.categoryChanged.subscribe(category => {
            this.category = category;
            this.setCategory();
        });
    }

    // pager object
    pager: any = {};

    // paged items
    pagedItems: Observable<Post[]>;

    pageNumber: number;

    ngOnInit() {
        this.category = this.route.snapshot.params['category'];
        this.setPage(1);
  }

    setCategory() {
        if (this.category != 'undefined' && this.category) {
            this.setPage(1);
        }
    }

    setPage(page: number) {
        //let criteria = this.route.snapshot.params['criteria'];

        if (page < 1 || page > this.pager.totalPages) {
            return;
        }

        this.httpService.getPostsByCategory(this.category, page)
            .subscribe(data => {
                // get pager object from service
                this.pager = this.pagerService.getPager(data.total, page);

                // get current page of items
                this.pagedItems = data.posts;
            });
    }
}
