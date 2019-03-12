import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
    providedIn: 'root'
})
export class RoomOccupationService {
    readonly baseUrl = environment.api;

    private hubConnection: HubConnection

    public startConnection = () => {
        this.hubConnection = new HubConnectionBuilder()
            .withUrl('http://localhost:52266/' + 'roomoccupied')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err))
    }

    public addOccupationListener = () => {
        this.hubConnection.on('OccupationChange', (isOccupied: boolean) => {
            console.log('change to: ' + isOccupied);
        });
    }
}