import { Component, OnInit } from '@angular/core';
import { Archive } from '../archive';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-archives',
  templateUrl: './archives.component.html',
  styleUrls: ['./archives.component.css']
})
export class ArchivesComponent implements OnInit {
    archives: Observable<Archive>;
  constructor(private httpService: HttpService) { }

  ngOnInit() {
      this.getArchives();
  }

  getArchives() {
      this.httpService.getArchives()
          .subscribe(data => {
              this.archives = data;
          });
  }
}
