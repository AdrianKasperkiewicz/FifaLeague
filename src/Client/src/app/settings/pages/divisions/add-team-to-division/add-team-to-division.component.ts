import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormArray, FormBuilder } from '@angular/forms';
import { ITeam } from '../../../../shared/models/team.viewmodel';
import { MatDialog } from '@angular/material';
import { TeamService } from '../../../../shared/services/team.service';
import { DialogNewTeamComponent } from '../../teams/dialog-new-team/dialog-new-team.component';
import { IDivision } from '../../../../shared/models/division.viewmodel';
import { AddTeamToDivisionDialogComponent } from '../add-team-to-division-dialog/add-team-to-division-dialog.component';
import { IDivisionTeam } from '../../../../shared/models/DivisionTeam.viewmodel';

@Component({
  selector: 'app-add-team-to-division',
  templateUrl: './add-team-to-division.component.html',
  styleUrls: ['./add-team-to-division.component.css']
})
export class AddTeamToDivisionComponent implements OnInit {
  @Input() division: IDivision;
  displayedColumns: string[] = ['name', 'email'];
  teams: IDivisionTeam[];

  constructor(private formBuilder: FormBuilder, public dialog: MatDialog, private teamService: TeamService) {

  }

  private getTeams() {
    this.teamService
      .getByDivision(this.division.id)
      .subscribe(x => this.teams = x);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddTeamToDivisionDialogComponent, {
      width: '250px',
      data: { division: this.division}
    });

    dialogRef.afterClosed().subscribe(isCompleted => {
      console.log('The dialog was closed');

      if (isCompleted) {
        this.getTeams();
      }
    });
  }
  ngOnInit() {
    this.getTeams();
  }


  // get teamsArray(): FormArray {
  //   return this.divisionForm.controls['teams'] as FormArray;
  // }

  // public addTeam() {
  //   const teams = this.divisionForm.controls['teams'] as FormArray;

  //   teams.push(this.formBuilder.group({ id: '' }));
  // }
}
