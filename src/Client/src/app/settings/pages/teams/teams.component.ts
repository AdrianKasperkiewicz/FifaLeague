import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogNewTeamComponent } from './dialog-new-team/dialog-new-team.component';
import { TeamService } from '../../../shared/services/team.service';
import { ITeam } from '../../../shared/models/team.viewmodel';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent {
  displayedColumns: string[] = ['name', 'email'];
  teams: ITeam[];

  constructor(public dialog: MatDialog, private teamService: TeamService) {
    this.getTeams();
  }

  private getTeams() {
    this.teamService
      .get()
      .subscribe(x => this.teams = x);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogNewTeamComponent, {
      width: '250px',
      data: {}
    });

    dialogRef.afterClosed().subscribe(isCompleted => {
      console.log('The dialog was closed');

      if (isCompleted) {
        this.getTeams();
      }
    });
  }
}
