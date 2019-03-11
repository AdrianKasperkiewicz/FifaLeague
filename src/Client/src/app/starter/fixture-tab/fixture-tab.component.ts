import { Component, OnInit } from '@angular/core';
import { FixtureService } from '../../shared/services/fixture.services';
import { IFixture } from '../../shared/models/fixture.viewmodel';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-fixture-tab',
  templateUrl: './fixture-tab.component.html',
  styleUrls: ['./fixture-tab.component.css']
})
export class FixtureTabComponent implements OnInit {
  currentFixtures: Observable<IFixture[]>;
  constructor(private fixture: FixtureService) {
    this.currentFixtures = fixture.getCurrent();
   }

  ngOnInit() {
  }

}
