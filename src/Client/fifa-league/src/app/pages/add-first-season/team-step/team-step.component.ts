import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';

@Component({
  selector: 'app-team-step',
  templateUrl: './team-step.component.html',
  styleUrls: ['./team-step.component.css']
})
export class TeamStepComponent implements OnInit {

  frmStepThree: FormGroup;
  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit() {
      this.frmStepThree = this.formBuilder.group({
          id: ['', Validators.required],
          teams: this.formBuilder.array([])
      });

  }

  get f() { return this.frmStepThree.controls; }

  addTeam(){
    console.log('team addeded...');
    this.createTeam();
  }

  createTeam() {
    const teamsArray =  this.frmStepThree.get('teams') as FormArray;

    teamsArray.push(
      this.formBuilder.group({
        name: '',
        email: ''
      })
    );
  }

  onSubmit(){
    // redirect
  }
}
