import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-score',
  templateUrl: './add-score.component.html',
  styleUrls: ['./add-score.component.css']
})
export class AddScoreComponent implements OnInit {
  scoreForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { }
  ngOnInit() {
    this.scoreForm = this.formBuilder.group({
      matchType: ['', Validators.required],
      date: ['', Validators.required],
      teamscore: this.formBuilder.array([
        this.preapereTeamScoreFormGroup(),
        this.preapereTeamScoreFormGroup()
      ])
    });
  }

  onSubmit() {
    console.log(this.scoreForm.value);
  }

  private preapereTeamScoreFormGroup(): FormGroup {
    return this.formBuilder.group({
      teamId: ['', Validators.required],
      goals: ['', Validators.required]
    });
  }
}
