import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormArray, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-team-to-division',
  templateUrl: './add-team-to-division.component.html',
  styleUrls: ['./add-team-to-division.component.css']
})
export class AddTeamToDivisionComponent implements OnInit {
  @Input() divisionForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
  }

  get teamsArray(): FormArray {
    return this.divisionForm.controls['teams'] as FormArray;
  }

  public addTeam() {
    const teams = this.divisionForm.controls['teams'] as FormArray;

    teams.push(this.formBuilder.group({ id: '' }));
  }
}
