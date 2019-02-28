import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ITeam } from '../models/team-viewmodel';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) { }

  add(teamForm: any): Observable<string> {
    const registerUrl = this.baseUrl + 'team';

    return this.httpClient
    .post<string>(registerUrl, teamForm)
  }

  get():Observable<Array<ITeam>>{
    const getTeamUrl = this.baseUrl + 'team';

    return this.httpClient.get<Array<ITeam>>(getTeamUrl);
  }
}
