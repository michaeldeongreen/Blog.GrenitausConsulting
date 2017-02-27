import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { PagerService } from '../pager.service';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tag-results',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})
export class TagComponent implements OnInit {
    tag: string;

    constructor(private http: Http,
        private httpService: HttpService,
        private pagerService: PagerService,
        private route: ActivatedRoute) { }

    // pager object
    pager: any = {};

    // paged items
    pagedItems: Observable<Post[]>;

    pageNumber: number;

    ngOnInit() {
        this.tag = this.route.snapshot.params['tag'];
        this.setPage(1);
    }

    setTag() {
        if (this.tag != 'undefined' && this.tag) {
            this.clearPager();
            this.setPage(1);
        }
    }

    clearPager() {
        this.pager = {};
    }

    setPage(page: number) {
        //let criteria = this.route.snapshot.params['criteria'];

        if (page < 1 || page > this.pager.totalPages) {
            return;
        }

        this.httpService.getPostsByTag(this.tag, page)
            .subscribe(data => {
                // get pager object from service
                this.pager = this.pagerService.getPager(data.total, page);

                // get current page of items
                this.pagedItems = data.posts;
            });
    }


}
