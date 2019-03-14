import { Component, OnInit } from '@angular/core';
import { SeasonService } from '../../../shared/services/season.service';
import { Observable } from 'rxjs';
import { ISeason } from '../../../shared/models/season.viewmodel';

@Component({
  selector: 'app-start-season',
  templateUrl: './start-season.component.html',
  styleUrls: ['./start-season.component.css']
})
export class StartSeasonComponent implements OnInit {
  seasons: Observable<ISeason[]>;

  constructor(private seasonService: SeasonService) { }

  ngOnInit() {
    this.seasons = this.seasonService.get();
  }
  start(id: string) {
    this.seasonService.startSeason(id).subscribe();
  }
}
