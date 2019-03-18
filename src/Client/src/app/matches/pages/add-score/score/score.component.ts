import { Component, OnInit, Input } from '@angular/core';
import { TeamService } from '../../../../shared/services/team.service';
import { ITeam } from '../../../../shared/models/team.viewmodel';
import { Observable } from 'rxjs';
import { FormBuilder, Form, FormGroup } from '@angular/forms';
import { startWith, flatMap, mergeMap, skip } from 'rxjs/operators';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {
  @Input() teamScore: FormGroup;

  teams: ITeam[];
  constructor(private teamService: TeamService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.teamService.getTopFive().subscribe(x => this.teams = x);

    this.teamScore = this.formBuilder.group({
      teamId: '',
      goals: ''
    });

    this.teamScore.controls['teamId'].valueChanges
      .pipe(
        startWith(''),
        flatMap(x => this.teamService.filterByName(x))
      ).subscribe(x => this.teams = x);

  }

  displayTeam() {
    return (val) => {
      if (val) {
        return this.teams.filter(x => x.id === val)[0].firstName;
      }
      return undefined;
    };
  }

}
