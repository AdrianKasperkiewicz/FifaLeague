import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ITeam } from '../models/team.viewmodel';
import { IDivisionTeam } from '../models/DivisionTeam.viewmodel';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  readonly baseUrl = environment.api;

  constructor(private httpClient: HttpClient) {}

  add(teamForm: any): Observable<string> {
    const registerUrl = this.baseUrl + 'team';

    return this.httpClient.post<string>(registerUrl, teamForm);
  }

  get(): Observable<ITeam[]> {
    const getTeamUrl = this.baseUrl + 'team';

    return this.httpClient.get<ITeam[]>(getTeamUrl);
  }

  filterByName(name: any): Observable<ITeam[]> {
    const getTeamsUrl = this.baseUrl + 'team/'+ name;
    
    return this.httpClient.get<ITeam[]>(getTeamsUrl);
  }

  getByDivision(divisionId: string): Observable<IDivisionTeam[]> {
    const getTeamUrl = this.baseUrl + 'division/' + divisionId + "/teams";

    return this.httpClient.get<IDivisionTeam[]>(getTeamUrl);
  }

  getTopFive(): Observable<ITeam[]> {
    const getTeamsUrl = this.baseUrl + 'team/top';

    return this.httpClient.get<ITeam[]>(getTeamsUrl);
  }

  createTeam(teamForm: any): Observable<any> {
    const postTeamsUrl = this.baseUrl + 'team';

    return this.httpClient.post<any>(postTeamsUrl, teamForm);
  }
}
