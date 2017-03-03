import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.css']
})
export class PreviewComponent implements OnInit {
    html: string;
    parameter: string;
    item: any = {};
    busy: boolean = true;

    constructor(private httpService: HttpService,
        private route: ActivatedRoute) { }

    ngOnInit() {
        this.parameter = this.route.snapshot.params['title'];
        this.getPost(this.parameter);
        this.getHtml(this.parameter);
    }

    getPost(title: string) {
        this.httpService.getPostPreview(title)
            .subscribe(data => {
                // get pager object from service
                this.item = data;
            });
    }

    getHtml(title: string) {
        this.httpService.getPostPreviewHtml(title)
            .subscribe(data => {
                // get pager object from service
                this.html = data;
                this.busy = false;
            });
    }

}
