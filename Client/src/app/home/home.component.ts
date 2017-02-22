import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    collection = [];
    constructor() {
        for (let i = 1; i <= 100; i++) {
            this.collection.push(`item ${i}`);
        }
    }

  ngOnInit() {
  }

}
