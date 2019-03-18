import { Component, OnInit } from '@angular/core';
import { TeamService } from '../../../../shared/services/team.service';
import { ITeam } from '../../../../shared/models/team.viewmodel';
import { Observable } from 'rxjs';
import { FormBuilder, Form, FormGroup } from '@angular/forms';
import { startWith, flatMap } from 'rxjs/operators';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {
  teams: Observable<ITeam[]>;
  teamScore: FormGroup;
  constructor(private teamService: TeamService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.teams = this.teamService.getTopFive();

    this.teamScore = this.formBuilder.group({
      teamId: '',
      goals: ''
    });

    this.teams = this.teamScore.controls['teamId'].valueChanges
      .pipe(
        startWith(''),
        flatMap(x => this.teamService.filterByName(x))
      );

  }
}
