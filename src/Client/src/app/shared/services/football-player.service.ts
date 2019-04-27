import { environment } from '../../../environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPlayerViewModel } from '../models/player.viewmodel';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class FootballPlayerService {

  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) { }

  find(name: any): Observable<IPlayerViewModel[]> {
    if (!name) {
      name = 'a';
    }

    const url = this.baseUrl + 'footballplayer/search/' + name;

    return this.httpClient.get<IPlayerViewModel[]>(url);
  }

  get(id: number): Observable<IPlayerViewModel> {
    const url = this.baseUrl + 'footballplayer/' + id;

    return this.httpClient.get<IPlayerViewModel>(url);
  }
}
