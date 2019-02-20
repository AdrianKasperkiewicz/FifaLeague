import { Component, OnInit } from '@angular/core';
import { SeasonService } from 'src/app/shared/services/season.service';
import { ISeason } from 'src/app/shared/models/season-viewmodel';

@Component({
  selector: 'app-seasons',
  templateUrl: './seasons.component.html',
  styleUrls: ['./seasons.component.css']
})
export class SeasonsComponent implements OnInit {
  seasons = [] as Array<ISeason>;

  constructor(private seasonService: SeasonService) { }

  ngOnInit() {
    this.seasonService.get().subscribe(x => this.seasons = x);
   }
}
