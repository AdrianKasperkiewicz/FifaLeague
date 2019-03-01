import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })
export class SeasonService {
    readonly baseUrl = environment.api;

    constructor(private httpClient: HttpClient) {}
  
    create(seasonForm: any): Observable<string> {
      const registerUrl = this.baseUrl + 'season';
  
      return this.httpClient.post<string>(registerUrl, seasonForm);
    }
}