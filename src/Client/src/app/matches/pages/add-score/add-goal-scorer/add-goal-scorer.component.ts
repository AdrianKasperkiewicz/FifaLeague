import { Component, OnInit, Input } from '@angular/core';
import { IPlayerViewModel } from '../../../../shared/models/player.viewmodel';
import { FootballPlayerService } from '../../../../shared/services/football-player.service';
import { FormGroup } from '@angular/forms';
import { startWith, flatMap } from 'rxjs/operators';

@Component({
  selector: 'app-add-goal-scorer',
  templateUrl: './add-goal-scorer.component.html',
  styleUrls: ['./add-goal-scorer.component.css']
})
export class AddGoalScorerComponent implements OnInit {
  @Input() goalScorerForm: FormGroup;
  players: IPlayerViewModel[];

  constructor(private footballPlayerService: FootballPlayerService) { }

  ngOnInit() {
    this.goalScorerForm
      .controls['playerId']
      .valueChanges
      .pipe(
        startWith(''),
        flatMap(x => this.footballPlayerService.find(x))
      ).subscribe(x => this.players = x);
  }
}
