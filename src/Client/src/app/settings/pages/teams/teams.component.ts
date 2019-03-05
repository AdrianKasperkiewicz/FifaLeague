import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { IDivision } from '../../../shared/models/division.viewmodel';
import { DivisionService } from '../../../shared/services/division.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  divisions: Observable<IDivision[]>;

  divisionsFormGroup: FormGroup;

  constructor(private divisionService: DivisionService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.divisions = this.divisionService.getDivisions();

    this.divisionsFormGroup = this.formBuilder.group({
      seasonId: [''],
      divisions: this.formBuilder.array([])
    });

    const divisionsFormArray = <FormArray>this.divisionsFormGroup.controls['divisions'];

    this.divisions.subscribe(x => x.forEach(division => {
      divisionsFormArray.push(this.formBuilder.group({
        divisionId: [division.id],
        teams: this.formBuilder.array([])
      }));
    }));
  }

  teamsformArray(id: string): FormArray {
    const divi = this.divisionsFormGroup.controls['divisions'] as FormArray;
    const divisionForm = divi.controls.filter(x => x.get('divisionId').value === id)[0] as FormGroup;

    return <FormArray>divisionForm.controls['teams'];
  }

  addNewTeam(id: string) {
    const divi = this.divisionsFormGroup.controls['divisions'] as FormArray;

    const divisionForm = divi.controls.filter(x => x.get('divisionId').value === id)[0] as FormGroup;
    const teams = <FormArray>divisionForm.controls['teams'];
    teams.controls.push(this.formBuilder.group({
      name: 'fakeName',
      email: ''
    }));
  }

  onSubmit() {
  }
}
