import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {
    criteria: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
      let criteria = this.route.snapshot.params['criteria'];
  }

}
