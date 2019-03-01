import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';

@Component({
  selector: 'app-new-season',
  templateUrl: './new-season.component.html',
  styleUrls: ['./new-season.component.css']
})
export class NewSeasonComponent {
  isLinear = true;
  seasonFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.seasonFormGroup = this.formBuilder.group({
      startdate: ['', Validators.required],
      divisions: this.formBuilder.array([])
    });
  }

  addNewDivision() {
    const divisionArray = this.seasonFormGroup.get('divisions') as FormArray;

    divisionArray.push(
      this.formBuilder.group({
        name: ['', Validators.required],
        hierarchy: divisionArray.controls.length + 1,
        numberOfDegraded: [''],
        numberOfPromoted: ['']
      }));
  }

  onSubmit() {
    console.log(this.seasonFormGroup.value);
  }
}
