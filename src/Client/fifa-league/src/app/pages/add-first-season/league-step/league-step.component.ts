import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material';
import { SeasonService } from 'src/app/shared/services/season.service';

@Component({
  selector: 'app-league-step',
  templateUrl: './league-step.component.html',
  styleUrls: ['./league-step.component.css']
})
export class LeagueStepComponent implements OnInit {
  leagueStepForm: FormGroup;
  public imagePath;
  imgURL: any;
  public message: string;

  constructor(private formBuilder: FormBuilder, private seasonService: SeasonService) {}

  ngOnInit() {
    this.leagueStepForm = this.formBuilder.group({
      name: ['', Validators.required]
    });
  }

  @Input() stepper: MatStepper;

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
      console.log('step 1 saved');
      this.stepper.next();
    });
  }
}
