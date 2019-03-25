import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IPlayerViewModel } from '../../../../shared/models/player.viewmodel';
import { FootballPlayerService } from '../../../../shared/services/football-player.service';

@Component({
  selector: 'app-add-goal-scorer',
  templateUrl: './add-goal-scorer.component.html',
  styleUrls: ['./add-goal-scorer.component.css']
})
export class AddGoalScorerComponent implements OnInit {
  players: Observable<IPlayerViewModel[]>;

  constructor(private footballPlayerService: FootballPlayerService) { }

  ngOnInit() {
    //TODO implement real method
    this.players = this.footballPlayerService.find('rona');
  }
}
