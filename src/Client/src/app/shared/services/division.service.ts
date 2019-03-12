import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IDivision } from '../models/division.viewmodel';
import { IDivisionTeam } from '../models/DivisionTeam.viewmodel';

@Injectable({ providedIn: 'root' })
export class DivisionService {
  constructor(private httpClient: HttpClient) { }

  readonly baseUrl = environment.api;

  searchForDivision(searchphrase: string) {
    const searchDivisionUrl = this.baseUrl + 'division/' + searchphrase;
    return this.httpClient.get<IDivision[]>(searchDivisionUrl);
  }
  addTeamToDivision(form: any): any {
    const postDivisionUrl = this.baseUrl + 'division/assignteam';

    return this.httpClient.post(postDivisionUrl, form);
  }

  getDivisions(): Observable<IDivision[]> {
    const searchDivisionUrl = this.baseUrl + 'division';

    return this.httpClient.get<IDivision[]>(searchDivisionUrl);
  }

  getByDivision(divisionId: string): Observable<IDivisionTeam[]> {
    const getTeamUrl = this.baseUrl + 'division/' + divisionId + '/teams';

    return this.httpClient.get<IDivisionTeam[]>(getTeamUrl);
  }
}
