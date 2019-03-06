import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IDivision } from '../models/division.viewmodel';

@Injectable({ providedIn: 'root' })
export class DivisionService {
  constructor(private httpClient: HttpClient) {}

  readonly baseUrl = environment.api;

  createTeamsForDivisions(form: any) {
    const postDivisionUrl = this.baseUrl + 'division';

    return this.httpClient.post(postDivisionUrl, form);
  }

  searchForDivision(searchphrase: string) {
    const searchDivisionUrl = this.baseUrl + 'division/' + searchphrase;
    return this.httpClient.get<IDivision[]>(searchDivisionUrl);
  }

  getDivisions(): Observable<IDivision[]> {
    const searchDivisionUrl = this.baseUrl + 'division';

    return this.httpClient.get<IDivision[]>(searchDivisionUrl);
  }
}
