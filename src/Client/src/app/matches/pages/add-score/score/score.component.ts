import { Component, OnInit, Input, } from '@angular/core';
import { TeamService } from '../../../../shared/services/team.service';
import { ITeam } from '../../../../shared/models/team.viewmodel';
import { FormBuilder, FormGroup } from '@angular/forms';
import { startWith, flatMap} from 'rxjs/operators';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {
  @Input() scoreForm: FormGroup;
  @Input() fgName: string;

  teams: ITeam[];
  constructor(private teamService: TeamService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.teamService.getTopFive().subscribe(x => this.teams = x);

    (this.scoreForm
      .get(this.fgName) as FormGroup)
      .controls['teamId']
      .valueChanges
      .pipe(
        startWith(''),
        flatMap(x => this.teamService.filterByName(x))
      ).subscribe(x => this.teams = x);
  }

  displayTeam() {
    return (val: string) => {
      if (val) {
        return this.teams.filter(x => x.id === val)[0].firstName;
      }
      return undefined;
    };
  }
}
