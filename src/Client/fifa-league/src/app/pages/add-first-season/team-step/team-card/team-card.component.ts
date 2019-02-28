import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DivisionService } from 'src/app/shared/services/division.service';
import { debounceTime, flatMap } from 'rxjs/operators';

import { IDivision } from 'src/app/shared/models/division-viewmodel';

@Component({
  selector: 'app-team-card',
  templateUrl: './team-card.component.html',
  styleUrls: ['./team-card.component.css']
})
export class TeamCardComponent implements OnInit {
  @Input() teamForm: FormGroup;
  constructor(private divisionservice: DivisionService) {}

  searchResult = [] as IDivision[];

  ngOnInit() {
    this.divisionservice
      .getDivisions()
      .subscribe(resp => (
        this.searchResult = resp));





    // this.teamForm
    //   .get('division')
    //   .valueChanges.pipe(
    //   debounceTime(400),
    //   flatMap(input =>  this.divisionservice.searchForDivision(input))
    //   )
    //   .subscribe(resp => console.log(resp)) ;
  }
}
