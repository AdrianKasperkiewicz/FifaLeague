import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LeagueStepComponent } from './league-step/league-step.component';
import { DivisionStepComponent } from './division-step/division-step.component';
import { TeamStepComponent } from './team-step/team-step.component';

@Component({
  selector: 'app-add-first-season',
  templateUrl: './add-first-season.component.html',
  styleUrls: ['./add-first-season.component.css']
})
export class AddFirstSeasonComponent implements OnInit {

  seasonFormGroup: FormGroup;


  @ViewChild(LeagueStepComponent) stepOneComponent: LeagueStepComponent;
  @ViewChild(DivisionStepComponent) stepTwoComponent: DivisionStepComponent;
  @ViewChild(TeamStepComponent) stepThreeComponent: TeamStepComponent;

  ngOnInit(): void {
  }

  get leagueStepForm() {
     return this.stepOneComponent ? this.stepOneComponent.leagueStepForm : null;
  }

  get frmStepTwo() {
     return this.stepTwoComponent ? this.stepTwoComponent.frmStepTwo : null;
  }

  get frmStepThree() {
     return this.stepThreeComponent ? this.stepThreeComponent.frmStepThree : null;
  }

  constructor(private fb: FormBuilder) { }
}
