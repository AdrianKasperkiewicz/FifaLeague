import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { IFixture } from '../models/fixture.viewmodel';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FixtureService {
  constructor(private httpClient: HttpClient) { }

  get(divisionId: string) {
    const url = environment.api + 'fixture/' + divisionId;

    return this.httpClient.get<IFixture[]>(url);
  }

  getCurrent(): Observable<IFixture[]> {
    const url = environment.api + 'fixture/next';

    return this.httpClient.get<IFixture[]>(url);
  }
}
