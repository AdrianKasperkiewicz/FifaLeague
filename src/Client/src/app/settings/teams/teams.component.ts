import { Component, OnInit } from '@angular/core';
import { DivisionService } from '../../shared/services/division.service';
import { Observable } from 'rxjs';
import { IDivision } from '../../shared/models/division.viewmodel';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  divisions: Observable<IDivision[]>;

  constructor(private divisionService: DivisionService) { }

  ngOnInit() {
    this.divisions = this.divisionService.getDivisions();
  }
}
