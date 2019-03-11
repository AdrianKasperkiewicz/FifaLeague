import { Component, OnInit } from '@angular/core';
import { SeasonService } from '../../shared/services/season.service';
import { FixtureService } from '../../shared/services/fixture.services';
import { ISeason } from '../../shared/models/season.viewmodel';
import { Observable } from 'rxjs';
import { DivisionService } from '../../shared/services/division.service';
import { IDivision } from '../../shared/models/division.viewmodel';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrls: ['./fixture.component.css']
})
export class FixtureComponent implements OnInit {
  divisions: Observable<IDivision[]>;
  constructor(private divisionService: DivisionService, private fixtureService: FixtureService) { }

  ngOnInit() {
    this.divisions = this.divisionService.getDivisions();
  }

}
