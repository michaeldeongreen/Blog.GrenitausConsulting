import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { PagerService } from '../pager.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { IPagedResponse } from '../ipaged-response.pagedresponse';

@Component({
    moduleId: module.id,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

})
export class HomeComponent implements OnInit {

    constructor(private http: HttpClient,
        private httpService: HttpService,
        private pagerService: PagerService,
        private route: ActivatedRoute) {
    }

    busy: boolean = true;

    // pager object
    pager: any = {};

    // paged items
    pagedItems: Observable<Post[]>;

    pageNumber: number;

    ngOnInit() {

        let pageNumber = Number(this.route.snapshot.params['id']) ? Number(this.route.snapshot.params['id']): 1;
        this.setPage(pageNumber);
    }

    setPage(page: number) {
        if (page < 1 || page > this.pager.totalPages) {
            return;
        }

        this.httpService.getPosts(page)
            .subscribe(data => {
                // get pager object from service
                this.pager = this.pagerService.getPager(data.total, page);
                // get current page of items
                this.pagedItems = data.posts;
                this.busy = false;
            },
            err => {
                console.log("Error occured while trying to retrieve posts.");
            }
        );
    }
}


