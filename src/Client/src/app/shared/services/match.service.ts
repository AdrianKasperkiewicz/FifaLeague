import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IMatchViewModel } from '../models/match.viewmodel';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) { }

  add(matchForm: any): Observable<string> {
    const registerUrl = this.baseUrl + 'match';

    return this.httpClient.post<string>(registerUrl, matchForm);
  }

  getLastMatches(numberOfMatches: number): Observable<IMatchViewModel[]> {
    const url = this.baseUrl + 'match/last/' + numberOfMatches;

    return this.httpClient.get<IMatchViewModel[]>(url);
  }
}
