import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { SeasonService } from '../../../shared/services/season.service';

@Component({
  selector: 'app-new-season',
  templateUrl: './new-season.component.html',
  styleUrls: ['./new-season.component.css']
})
export class NewSeasonComponent {
  isLinear = true;
  seasonFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private seasonService: SeasonService) { }

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
    this.seasonService
      .create(this.seasonFormGroup.value)
      .subscribe(x => console.log('created: ' + x));
  }
}
