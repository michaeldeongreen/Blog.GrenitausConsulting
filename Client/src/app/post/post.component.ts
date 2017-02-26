import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post';
import { Observable } from 'rxjs/Observable';
import { SeoService } from '../seo.service';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
    html: string;
    parameter: string;
    item: any = {};
    url: string;
    path: string;

    constructor(private httpService: HttpService,
        private route: ActivatedRoute,
        private seoService: SeoService,
        private location: Location) {
        this.path = location.prepareExternalUrl(location.path(true));
        this.url = `${window.location.protocol}//${window.location.host}/${this.path}`;
    }


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
                this.seoService.setTitle(this.item.title);
                this.seoService.setMetaDescription(this.item.snippet);
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
