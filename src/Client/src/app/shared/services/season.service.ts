import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ISeason } from '../models/season.viewmodel';

@Injectable({
  providedIn: 'root'
})
export class SeasonService {
  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) { }

  create(seasonForm: any): Observable<string> {
    const registerUrl = this.baseUrl + 'season';

    return this.httpClient.post<string>(registerUrl, seasonForm);
  }

  get(): Observable<ISeason[]> {

    const getUrl = this.baseUrl + 'season';

    return this.httpClient.get<ISeason[]>(getUrl);
  }

  startSeason(id: string): any {
    const startSeasonrUrl = this.baseUrl + 'season/start/' + id;

    return this.httpClient.post<string>(startSeasonrUrl, null);
  }
}
