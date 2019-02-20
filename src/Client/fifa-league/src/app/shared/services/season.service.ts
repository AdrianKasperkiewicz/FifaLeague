import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ISeason } from '../models/season-viewmodel';

@Injectable({
  providedIn: 'root'
})
export class SeasonService {
  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) { }

  get(): Observable<Array<ISeason>>{
    const getSeasonsUrl = this.baseUrl + 'season';

    return this.httpClient.get<Array<ISeason>>(getSeasonsUrl);
  }

  create(form): Observable<any>{
    const postSeasonsUrl = this.baseUrl + 'season';

    return this.httpClient.post<string>(postSeasonsUrl, form);
  }
}
