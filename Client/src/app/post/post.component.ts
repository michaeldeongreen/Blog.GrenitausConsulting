import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post';
import { Observable } from 'rxjs/Observable';
import { SeoService } from '../seo.service';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { MetaService } from '@nglibs/meta';
import { SharedEmitterService } from '../shared-emitter.service';
import { Router } from '@angular/router';

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
    alsoOn: Observable<Post>;
    alsoOnTotal: number;

    constructor(private httpService: HttpService,
        private route: ActivatedRoute,
        private seoService: SeoService,
        private location: Location,
        private readonly metaService: MetaService,
        private sharedEmitterService: SharedEmitterService,
        private router: Router) {
        this.path = location.prepareExternalUrl(location.path(true));

        this.sharedEmitterService.alsoOnChanged.subscribe(title => {
            this.parameter = title;
            this.getPost(this.parameter);
            this.getHtml(this.parameter);
        });
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
                this.getAlsoOn(this.item.id);
            });
    }

  getHtml(title: string) {
      this.httpService.getPostHtml(title)
          .subscribe(data => {
              this.html = data;
              this.busy = false;
          });
  }

  getAlsoOn(id: number) {
      this.httpService.getAlsoOn(id)
          .subscribe(data => {
              this.alsoOnTotal = data.total;
              this.alsoOn = data.posts;
              //this.busy = false;
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

  gotoPost(title: string): void {
      this.sharedEmitterService.alsoOnChangedEvent(title);
      let link = ['/post', title];
      this.router.navigate(link);
  }

}
