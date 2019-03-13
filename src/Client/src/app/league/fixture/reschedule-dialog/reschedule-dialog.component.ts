import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FixtureService } from '../../../shared/services/fixture.service';
import { Observable } from 'rxjs';
import { IFixture } from '../../../shared/models/fixture.viewmodel';
import { IRescheduleRequest } from '../../../shared/models/reschedule.request';

@Component({
  selector: 'app-reschedule-dialog',
  templateUrl: './reschedule-dialog.component.html',
  styleUrls: ['./reschedule-dialog.component.css']
})
export class RescheduleDialogComponent implements OnInit {
  availableFixtures: Observable<IFixture[]>;
  matchId: string;
  orginFixtureId: string;

  constructor(
    private fixtureService: FixtureService,
    public dialogRef: MatDialogRef<RescheduleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any) {
    this.matchId = data.matchId;
    this.orginFixtureId = data.orginFixtureId;
  }

  ngOnInit() {
    this.availableFixtures = this.fixtureService.findPossibleRescheduleFixtires(this.matchId);
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  reschedule(fixtureId: string) {
    this.fixtureService.rescheduleMatch({
      matchId: this.matchId,
      orginFixtureId: this.orginFixtureId,
      destinationFixtureId: fixtureId
    } as IRescheduleRequest).subscribe(() => this.dialogRef.close());
  }
}
