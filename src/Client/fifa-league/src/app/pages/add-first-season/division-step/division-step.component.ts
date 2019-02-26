import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { MatStepper } from '@angular/material';

@Component({
  selector: 'app-division-step',
  templateUrl: './division-step.component.html',
  styleUrls: ['./division-step.component.css']
})
export class DivisionStepComponent implements OnInit {
  @Input() stepper: MatStepper;
  frmStepTwo: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.frmStepTwo = this.formBuilder.group({
      id: 1,
      divisions: this.formBuilder.array([])
    });
  }

  addDivision() {
    this.createDivision();
  }

  onSubmit() {
    this.stepper.next();
  }

  createDivision() {
    const divisionArray =  this.frmStepTwo.get('divisions') as FormArray;

    divisionArray.push(
      this.formBuilder.group({
        name: '',
        hierarchy: divisionArray.controls.length + 1
      })
    );
  }
}
