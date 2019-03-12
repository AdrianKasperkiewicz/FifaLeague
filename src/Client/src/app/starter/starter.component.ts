import { Component, AfterViewInit, OnInit } from '@angular/core';
import { RoomOccupationService } from '../shared/services/room-occupation.service';

@Component({
  selector: 'app-starter',
  templateUrl: './starter.component.html',
  styleUrls: ['./starter.component.scss']
})
export class StarterComponent implements AfterViewInit, OnInit {
  constructor(private occupationService: RoomOccupationService){}

  ngOnInit(): void {
    this.occupationService.startConnection();
    this.occupationService.addOccupationListener();
  }
  ngAfterViewInit() {}
}
