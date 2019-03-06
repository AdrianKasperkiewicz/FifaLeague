import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { IDivision } from '../../../shared/models/division.viewmodel';
import { DivisionService } from '../../../shared/services/division.service';

@Component({
  selector: 'app-divisions',
  templateUrl: './divisions.component.html',
  styleUrls: ['./divisions.component.css']
})
export class DivisionsComponent implements OnInit {
  divisions: Observable<IDivision[]>;

  divisionsFormGroup: FormGroup;
  constructor(private divisionService: DivisionService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.divisions = this.divisionService.getDivisions();

    this.divisionsFormGroup = this.formBuilder.group({
      seasonId: [''],
      divisions: this.formBuilder.array([])
    });

    this.setupDivisionsControl();


  }

  private setupDivisionsControl() {
    const divisionsFormArray = <FormArray>this.divisionsFormGroup.controls['divisions'];
    this.divisions.subscribe(x => {
      if (x.length > 0) {
        this.divisionsFormGroup.patchValue({ seasonId: x[0].seasonId });
      }
      x.forEach(division => {
        divisionsFormArray.push(this.formBuilder.group({
          divisionId: [division.id],
          teams: this.formBuilder.array([])
        }));
      });
    });
  }

  getDivisionForm(id: string): FormGroup {
    const divisionsForm = this.divisionsFormGroup.controls['divisions'] as FormArray;

    return divisionsForm
      .controls
      .filter(x => x.get('divisionId').value === id)[0] as FormGroup;
  }

  onSubmit() {
    console.log('sdsdsd');
    if (this.divisionsFormGroup.valid) {
      this.divisionService.createTeamsForDivisions(this.divisionsFormGroup.value).subscribe();
    }
  }
}
