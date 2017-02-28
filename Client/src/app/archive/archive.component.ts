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

    constructor(private httpService: HttpService,
        private pagerService: PagerService,
        private route: ActivatedRoute,
        private sharedEmitterService: SharedEmitterService) {

        this.sharedEmitterService.archiveChanged.subscribe(archive => {
            this.month = archive.month;
            this.year = archive.year;
        });
    }

  ngOnInit() {
      this.month = this.route.snapshot.params['month'];
      this.year = this.route.snapshot.params['year'];
  }

}
