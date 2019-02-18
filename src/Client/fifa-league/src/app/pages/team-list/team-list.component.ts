import { Component, OnInit } from '@angular/core';
import { TeamService } from 'src/app/shared/services/team.service';
import { ITeam } from 'src/app/shared/models/team-viewmodel';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css']
})
export class TeamListComponent implements OnInit {
  teams = [] as Array<ITeam>;

  constructor(private teamService: TeamService) { }

  ngOnInit() {
   this.teamService.get().subscribe(x => this.teams = x);
  }
}
