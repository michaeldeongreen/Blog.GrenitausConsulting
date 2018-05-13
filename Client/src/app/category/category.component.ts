import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { PagerService } from '../pager.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { SharedEmitterService } from '../shared-emitter.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
    category: string;
    busy: boolean = true;

    constructor(private http: HttpClient,
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

    clearPager() {
        this.pager = {};
    }

    setCategory() {
        if (this.category != 'undefined' && this.category) {
            this.clearPager();
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
                this.busy = false;
            },
            err => {
                console.log("Error occurred while trying to retrieve posts by category");
            }
        );
    }
}
