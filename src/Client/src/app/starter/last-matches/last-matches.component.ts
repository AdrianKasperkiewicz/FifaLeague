import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../shared/services/match.service';
import { Observable } from 'rxjs';
import { IMatchViewModel } from '../../shared/models/match.viewmodel';

@Component({
  selector: 'app-last-matches',
  templateUrl: './last-matches.component.html',
  styleUrls: ['./last-matches.component.css']
})
export class LastMatchesComponent implements OnInit {

  constructor(private matchService: MatchService) { }
  matches:  Observable<IMatchViewModel[]>;

  ngOnInit() {
    this.matches = this.matchService.getLastMatches(5);
  }
}
