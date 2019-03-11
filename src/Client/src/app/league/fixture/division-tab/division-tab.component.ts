import { Component, OnInit, Input } from '@angular/core';
import { FixtureService } from '../../../shared/services/fixture.services';
import { IFixture } from '../../../shared/models/fixture.viewmodel';

@Component({
  selector: 'app-division-tab',
  templateUrl: './division-tab.component.html',
  styleUrls: ['./division-tab.component.css']
})
export class DivisionTabComponent implements OnInit {
  @Input() divisionId: string;
  fixture: IFixture[];
  displayedColumns: string[] = ['weekNumber', 'homeTeam', 'awayTeam', 'endDate'];
  constructor(private fixtureService: FixtureService) { }

  ngOnInit() {
    this.fixtureService.get(this.divisionId).subscribe(x => this.fixture = x);
  }
}
