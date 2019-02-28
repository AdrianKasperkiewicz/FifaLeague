import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { TeamService } from 'src/app/shared/services/team.service';

@Component({
  selector: 'app-team-step',
  templateUrl: './team-step.component.html',
  styleUrls: ['./team-step.component.css']
})
export class TeamStepComponent implements OnInit {
  @Input() seasonId: string;
  frmStepThree: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private teamService: TeamService
  ) {}

  ngOnInit() {
    this.frmStepThree = this.formBuilder.group({
      seasonId: [''],
      teams: this.formBuilder.array([])
    });
  }

  get f() {
    return this.frmStepThree.controls;
  }

  addTeam() {
    console.log('team addeded...');
    this.createTeam();
  }

  createTeam() {
    const teamsArray = this.frmStepThree.get('teams') as FormArray;

    teamsArray.push(
      this.formBuilder.group({
        name: '',
        email: '',
        divisionId: ''
      })
    );
  }

  onSubmit() {
    this.frmStepThree.patchValue({ seasonId: this.seasonId });
    this.teamService
      .createTeams(this.frmStepThree.value)
      .subscribe(resp =>
        console.log('process finished // show user modal or sth else')
      );
  }
}
