import { Component, OnInit } from '@angular/core';
import { Archive } from '../archive';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../http.service';
import { SharedEmitterService } from '../shared-emitter.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-archives',
  templateUrl: './archives.component.html',
  styleUrls: ['./archives.component.css']
})
export class ArchivesComponent implements OnInit {
    archives: Observable<Archive>;
    constructor(private httpService: HttpService,
        public sharedEmitterService: SharedEmitterService,
        private router: Router) { }

  ngOnInit() {
      this.getArchives();
  }

  getArchives() {
      this.httpService.getArchives()
          .subscribe(data => {
              this.archives = data;
          },
          err => {
              console.log("Error occurred while retrieving the archives");
          }
      );
  }

  gotoArchive(month: number, year: number): void {
      this.sharedEmitterService.archiveChangedEvent({month:month,year:year});
      let link = ['/archive', month, year]
      this.router.navigate(link);
  }
}
