import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { HttpService } from '../http.service';
import { IPagedResponse } from '../ipaged-response.pagedresponse';

@Component({
  selector: 'app-previews',
  templateUrl: './previews.component.html',
  styleUrls: ['./previews.component.css']
})
export class PreviewsComponent implements OnInit {

    constructor(private httpService: HttpService) { }

    busy: boolean = true;

    // paged items
    pagedItems: Observable<Post[]>;

    ngOnInit() {
        this.loadPreviews();
  }

  loadPreviews() {
      this.httpService.getPreviews()
          .subscribe(data => {
              // get current page of items
              this.pagedItems = data.posts;
              this.busy = false;
          },
          err => {
              console.log("Error while retrieving previews");
          }
      );
  }
}
