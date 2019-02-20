import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SeasonService } from 'src/app/shared/services/season.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-first-season',
  templateUrl: './add-first-season.component.html',
  styleUrls: ['./add-first-season.component.css']
})
export class AddFirstSeasonComponent implements OnInit {
  seasonForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private seasonService: SeasonService, private router: Router) { }

  ngOnInit() {
    this.seasonForm = this.formBuilder.group({
      name: ['', Validators.required]
    });

  }

  get f() { return this.seasonForm.controls; }


  onSubmit() {
    if (this.seasonForm.invalid) {
      console.log("invalid")
      return;
    }

    this.seasonService.create(this.seasonForm.value).subscribe(x => this.router.navigate(['/season']));
  }
}
