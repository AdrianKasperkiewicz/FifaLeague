import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FixtureService } from '../../shared/services/fixture.service';
import { IFixtureMatch } from '../../shared/models/fixture-match.viewmodel';

@Component({
  selector: 'app-fixture-tab',
  templateUrl: './fixture-tab.component.html',
  styleUrls: ['./fixture-tab.component.css']
})
export class FixtureTabComponent implements OnInit {
  currentFixtures: Observable<IFixtureMatch[]>;
  constructor(private fixture: FixtureService) {
    this.currentFixtures = fixture.getCurrent();
   }

  ngOnInit() {
  }

}
