import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
    html: string;
    title: string;

    constructor(private httpService: HttpService,
        private route: ActivatedRoute) { }


    ngOnInit() {
        this.title = this.route.snapshot.params['title'];
        this.getTitle(this.title);
  }

  getTitle(title: string) {
      this.httpService.getBlog(title)
          .subscribe(data => {
              // get pager object from service
              this.html = data;
          });
  }
}
