import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SeasonService } from 'src/app/shared/services/season.service';
import { Router } from '@angular/router';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'app-add-first-season',
  templateUrl: './add-first-season.component.html',
  styleUrls: ['./add-first-season.component.css']
})
export class AddFirstSeasonComponent implements OnInit {
  seasonFormGroup: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private seasonService: SeasonService,
    private router: Router
  ) {}

  ngOnInit() {
    this.seasonFormGroup = this.formBuilder.group({
      name: ['', Validators.required]
    });
  }

  get seasonForm() {
    return this.seasonFormGroup.controls;
  }

  onLeagueSubmit(stepper: MatStepper) {
    if (this.seasonFormGroup.invalid) {
      console.log('invalid');
      return;
    }
    this.seasonService
      .create(this.seasonFormGroup.value).subscribe();
  }
}
