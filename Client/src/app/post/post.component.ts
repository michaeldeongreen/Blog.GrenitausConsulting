import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

    constructor(private httpService: HttpService) { }
    html: string;

    ngOnInit() {
        this.setPage(1);
  }

  setPage(page: number) {
      this.httpService.getTest()
          .subscribe(data => {
              // get pager object from service
              this.html = data;
          });
  }
}
