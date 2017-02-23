import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Post } from '../post';
import { PostService } from '../post.service';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/delay';

interface IServerResponse {
    items: Post[];
    total: number;
}

@Component({
    moduleId: module.id,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
    posts: Post[] = [];
    asyncPosts: Observable<Post[]>;
    p: number = 1;
    total: number;
    loading: boolean;

    constructor(private postService: PostService) {
    }

    ngOnInit() {
        this.getPage(1);
  }

  getPage(page: number) {
      this.loading = true;

      this.postService.getPosts().then(response => {
          this.asyncPosts = serverCall(response, page)
              .do(results => {
                  this.total = results.total;
                  this.p = page;
                  this.loading = false;              
              })
              .map(t => t.items);
      });
  }
}

function serverCall(posts: Post[], page: number): Observable<IServerResponse> {
    const perPage = 5;
    const start = (page - 1) * perPage;
    const end = start + perPage;

    return Observable
        .of({
            items: posts.slice(start, end),
            total: 30
        });
}

