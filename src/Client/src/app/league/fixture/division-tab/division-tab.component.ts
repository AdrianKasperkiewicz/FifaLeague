import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { RescheduleDialogComponent } from '../reschedule-dialog/reschedule-dialog.component';
import { FixtureService } from '../../../shared/services/fixture.service';
import { IFixtureMatch } from '../../../shared/models/fixture-match.viewmodel';

@Component({
  selector: 'app-division-tab',
  templateUrl: './division-tab.component.html',
  styleUrls: ['./division-tab.component.css']
})
export class DivisionTabComponent implements OnInit {
  @Input() divisionId: string;
  fixture: IFixtureMatch[];
  displayedColumns: string[] = ['weekNumber', 'homeTeam', 'awayTeam', 'endDate', 'reschedule'];
  constructor(private fixtureService: FixtureService, public dialog: MatDialog) { }

  ngOnInit() {
    this.fixtureService.get(this.divisionId).subscribe(x =>
      this.fixture = x);
  }

  reschedule(id: string) {
    const dialogRef = this.dialog.open(RescheduleDialogComponent, {
      width: '250px',
      data: {
        matchId: id,
        orginFixtureId: this.fixture[0].fixtureId
      }
    });

    dialogRef.afterClosed().subscribe(isCompleted => {
      if (isCompleted) {
        console.log(isCompleted);
      }
    });
  }
}
