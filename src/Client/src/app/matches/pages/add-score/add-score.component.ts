import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatchService } from '../../../shared/services/match.service';
import { CustomValidators } from '../../../shared/validators/guid.validator';

@Component({
  selector: 'app-add-score',
  templateUrl: './add-score.component.html',
  styleUrls: ['./add-score.component.css']
})
export class AddScoreComponent implements OnInit {
  scoreForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private matchService: MatchService) { }
  ngOnInit() {
    this.scoreForm = this.formBuilder.group({
      matchType: ['', Validators.required],
      date: ['', Validators.required],
      homeTeam: this.preapereTeamScoreFormGroup(),
      awayTeam: this.preapereTeamScoreFormGroup(),
      statistic: this.preapereStatisticFormGroup()
    });
  }
  preapereStatisticFormGroup(): FormGroup {
    return this.formBuilder.group({
      imgId: ['']
    });
  }

  onSubmit() {
    console.log(this.scoreForm.value);
    this.matchService.add(this.scoreForm.value).subscribe();
  }

  private preapereTeamScoreFormGroup(): FormGroup {
    return this.formBuilder.group({
      teamId: ['', [Validators.required, CustomValidators.GUID]],
      goals: ['', Validators.required],
      scorers: this.formBuilder.array([])
    });
  }
}
