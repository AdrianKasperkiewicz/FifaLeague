import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-division-card',
  templateUrl: './division-card.component.html',
  styleUrls: ['./division-card.component.css']
})
export class DivisionCardComponent implements OnInit {

  @Input() divisionForm: FormGroup;
  @Input() seasonId: string;
  constructor() { }

  ngOnInit() {
    console.log(this.divisionForm);
  }

  onClick(){
    console.log(this.divisionForm);
  }
}
