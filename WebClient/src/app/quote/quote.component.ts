import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Quote } from '../quote';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent implements OnInit {
    item: any = {};
    busy: boolean = true;

  constructor(private httpService: HttpService) { }

  ngOnInit() {
      this.getQuote();
  }

  getQuote() {
      this.httpService.getQuote()
          .subscribe(data => {
              this.item = data;
              this.busy = false;
          },
          err => {
              console.log("Error occured while trying to retrieve quote");
          }
      );
  }

}
