import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
    html: string;
    parameter: string;
    item: any = {};

    constructor(private httpService: HttpService,
        private route: ActivatedRoute) { }


    ngOnInit() {
        this.parameter = this.route.snapshot.params['title'];
        this.getPost(this.parameter);
        this.getHtml(this.parameter);
  }

    
    getPost(title: string) {
        this.httpService.getPost(title)
            .subscribe(data => {
                // get pager object from service
                this.item = data;
            });
    }

  getHtml(title: string) {
      this.httpService.getPostHtml(title)
          .subscribe(data => {
              // get pager object from service
              this.html = data;
          });
  }
}
