import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { TeamService } from '../../../../shared/services/team.service';
import { IDivision } from '../../../../shared/models/division.viewmodel';
import { AddTeamToDivisionDialogComponent } from '../add-team-to-division-dialog/add-team-to-division-dialog.component';
import { IDivisionTeam } from '../../../../shared/models/DivisionTeam.viewmodel';
import { DivisionService } from '../../../../shared/services/division.service';

@Component({
  selector: 'app-add-team-to-division',
  templateUrl: './add-team-to-division.component.html',
  styleUrls: ['./add-team-to-division.component.css']
})
export class AddTeamToDivisionComponent implements OnInit {
  @Input() division: IDivision;
  displayedColumns: string[] = ['name', 'email'];
  teams: IDivisionTeam[];

  constructor(
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    private divisionService: DivisionService) {
  }

  private getTeams() {
    this.divisionService
      .getByDivision(this.division.id)
      .subscribe(x => this.teams = x);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddTeamToDivisionDialogComponent, {
      width: '250px',
      data: { division: this.division }
    });

    dialogRef.afterClosed().subscribe(isCompleted => {
      if (isCompleted) {
        this.getTeams();
      }
    });
  }
  ngOnInit() {
    this.getTeams();
  }
}
