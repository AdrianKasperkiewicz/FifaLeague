import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material';
import { SeasonService } from 'src/app/shared/services/season.service';

@Component({
  selector: 'app-league-step',
  templateUrl: './league-step.component.html',
  styleUrls: ['./league-step.component.css']
})
export class LeagueStepComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private seasonService: SeasonService) {}
  leagueStepForm: FormGroup;
  public imagePath;
  imgURL: any;
  public message: string;

  @Input() stepper: MatStepper;
  @Output() seasonCreated = new EventEmitter<string>();

  ngOnInit() {
    this.leagueStepForm = this.formBuilder.group({
      name: ['', Validators.required]
    });
  }

  preview(files) {
    if (files.length === 0) {
      return;
    }

    var mimeType = files[0].type;
    if (mimeType.match(/image\/*/) == null) {
      this.message = 'Tylko obrazki są obsługiwane.';
      return;
    }

    var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]);
    reader.onload = _event => {
      this.imgURL = reader.result;
    };
  }

  onSubmit() {
    this.seasonService.create(this.leagueStepForm.value).subscribe(x => {
      this.seasonCreated.emit(x);
      console.log('step 1 saved id: ' + x);
      this.stepper.next();
    });
  }
}
