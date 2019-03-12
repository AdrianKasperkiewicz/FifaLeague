import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoomOccupationService {
  private hubConnection: HubConnection;
  public message = new Subject<boolean>();

  getConnection(): HubConnection {
    return this.hubConnection;
  }

  connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.roomOccupationService)
      .build();

    this.hubConnection.on(
      'OccupationChange', (occupated: boolean) => this.message.next(occupated));
    this.hubConnection.start().catch(err => console.error(err));
  }

  disconnect() {
    if (this.hubConnection) {
      this.hubConnection.stop();
      this.hubConnection = null;
    }

  }
}
