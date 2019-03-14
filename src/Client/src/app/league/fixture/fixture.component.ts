import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DivisionService } from '../../shared/services/division.service';
import { IDivision } from '../../shared/models/division.viewmodel';
import { FixtureService } from '../../shared/services/fixture.service';

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
