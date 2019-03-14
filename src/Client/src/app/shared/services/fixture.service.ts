import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { IFixtureMatch } from '../models/fixture-match.viewmodel';
import { IFixture } from '../models/fixture.viewmodel';
import { IRescheduleRequest } from '../models/reschedule.request';

@Injectable({ providedIn: 'root' })
export class FixtureService {
  constructor(private httpClient: HttpClient) { }

  get(divisionId: string) {
    const url = environment.api + 'fixture/' + divisionId;

    return this.httpClient.get<IFixtureMatch[]>(url);
  }

  getCurrent(): Observable<IFixtureMatch[]> {
    const url = environment.api + 'fixture/next';

    return this.httpClient.get<IFixtureMatch[]>(url);
  }

  findPossibleRescheduleFixtires(fixtureMatchId: string): Observable<IFixture[]> {
    const url = environment.api + 'fixture/possiblereschedulefixtures/' + fixtureMatchId;

    return this.httpClient.get<IFixture[]>(url);
  }

  rescheduleMatch(request: IRescheduleRequest) {
    const url = environment.api + 'fixture/reschedule/';

    return this.httpClient.post(url, request);
  }
}
