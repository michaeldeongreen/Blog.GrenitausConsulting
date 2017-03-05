import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post';
import { Observable } from 'rxjs/Observable';
import { SeoService } from '../seo.service';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { MetaService } from '@nglibs/meta';

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
    busy: boolean = true;

    constructor(private httpService: HttpService,
        private route: ActivatedRoute,
        private seoService: SeoService,
        private location: Location,
        private readonly metaService: MetaService) {
        this.path = location.prepareExternalUrl(location.path(true));
    }


    ngOnInit() {
        this.parameter = this.route.snapshot.params['title'];
        this.getPost(this.parameter);
        this.getHtml(this.parameter);
  }

    
    getPost(title: string) {
        this.httpService.getPost(title)
            .subscribe(data => {
                this.item = data;
                this.url = `${window.location.protocol}//${window.location.host}/${this.item.staticHtml}`;
                this.setSEO();
            });
    }

  getHtml(title: string) {
      this.httpService.getPostHtml(title)
          .subscribe(data => {
              this.html = data;
              this.busy = false;
          });
  }

  setSEO() {
      this.metaService.setTitle(this.item.title);
      this.metaService.setTag('description', this.item.snippet);
      this.metaService.setTag('og:type', 'article');
      this.metaService.setTag('og:title', this.item.title);
      this.metaService.setTag('og:description', this.item.snippet);
      this.metaService.setTag('og:url', this.url);
      this.metaService.setTag('og:image', `${window.location.protocol}//${window.location.host}/${this.item.images[0].url}`);
      this.metaService.setTag('twitter:description', this.item.snippet);
      this.metaService.setTag('twitter:title', this.item.title);
      this.metaService.setTag('twitter:image', `${window.location.protocol}//${window.location.host}/${this.item.images[0].url}`);
      for (let tag of this.item.tags) {
          this.metaService.setTag('article:tag', tag.name);
      }
      for (let category of this.item.categories) {
          this.metaService.setTag('article:section', category.name);
      }
  }

}
