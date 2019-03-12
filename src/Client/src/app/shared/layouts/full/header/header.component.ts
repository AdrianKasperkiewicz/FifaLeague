import { Component, OnInit } from '@angular/core';
import { RoomOccupationService } from '../../../services/room-occupation.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: []
})
export class AppHeaderComponent implements OnInit {
  isRoomOccupied: Observable<boolean>;
  constructor(private occupationService: RoomOccupationService) { }

  ngOnInit(): void {
    this.isRoomOccupied = this.occupationService.message;
    this.occupationService.connect();
  }
}
