import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountModel } from '../account/account.model';

@Injectable({
  providedIn: 'root',
})
export class AccountTypesService {
  baseUrl = 'https://localhost:5001/';
  endpoint = 'accounttype';

  constructor(private http: HttpClient) {}

  getAccountTypes(): Observable<any> {
    return this.http.get(`${this.baseUrl}${this.endpoint}`);
  }
}
