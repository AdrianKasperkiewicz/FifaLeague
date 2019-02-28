import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { MatStepper } from '@angular/material';
import { DivisionService } from 'src/app/shared/services/division.service';

@Component({
  selector: 'app-division-step',
  templateUrl: './division-step.component.html',
  styleUrls: ['./division-step.component.css']
})
export class DivisionStepComponent implements OnInit {
  @Input() stepper: MatStepper;
  @Input() seasonId: string;
  frmStepTwo: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private divisionService: DivisionService
  ) {}

  ngOnInit() {
    this.frmStepTwo = this.formBuilder.group({
      seasonId: '',
      divisions: this.formBuilder.array([])
    });
  }

  addDivision() {
    this.createDivision();
  }

  onSubmit() {
    this.frmStepTwo.patchValue({ seasonId: this.seasonId });

    this.divisionService
      .createDivisions(this.frmStepTwo.value)
      .subscribe(() => this.stepper.next());
  }

  createDivision() {
    const divisionArray = this.frmStepTwo.get('divisions') as FormArray;

    divisionArray.push(
      this.formBuilder.group({
        name: '',
        hierarchy: divisionArray.controls.length + 1
      })
    );
  }
}
