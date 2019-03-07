import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IDivision } from '../../../shared/models/division.viewmodel';
import { DivisionService } from '../../../shared/services/division.service';

@Component({
  selector: 'app-divisions',
  templateUrl: './divisions.component.html',
  styleUrls: ['./divisions.component.css']
})
export class DivisionsComponent implements OnInit {
  divisions: Observable<IDivision[]>;

  constructor(private divisionService: DivisionService) { }

  ngOnInit() {
    this.divisions = this.divisionService.getDivisions();
  }
}
