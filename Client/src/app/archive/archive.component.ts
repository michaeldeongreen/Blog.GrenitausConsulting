import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedEmitterService } from '../shared-emitter.service';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { PagerService } from '../pager.service';

@Component({
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.css']
})
export class ArchiveComponent implements OnInit {
    month: number;
    year: number;
    monthYear: string;

    constructor(private httpService: HttpService,
        private pagerService: PagerService,
        private route: ActivatedRoute,
        private sharedEmitterService: SharedEmitterService) {

        this.sharedEmitterService.archiveChanged.subscribe(archive => {
            this.month = archive.month;
            this.year = archive.year;
            this.clearPager();
            this.setPage(1);
        });
    }

    // pager object
    pager: any = {};

    // paged items
    pagedItems: Observable<Post[]>;

    pageNumber: number;

  ngOnInit() {
      this.month = this.route.snapshot.params['month'];
      this.year = this.route.snapshot.params['year'];
      this.clearPager();
      this.setPage(1);
  }

  clearPager() {
      this.pager = {};
  }

  setPage(page: number) {
      //let criteria = this.route.snapshot.params['criteria'];

      if (page < 1 || page > this.pager.totalPages) {
          return;
      }

      this.httpService.getPostsByMonthAndYear(this.month, this.year, page)
          .subscribe(data => {
              // get pager object from service
              this.pager = this.pagerService.getPager(data.total, page);

              // get current page of items
              this.pagedItems = data.posts;
              this.monthYear = `${data.archiveMonth} ${data.archiveYear}`;
          });
  }
}
