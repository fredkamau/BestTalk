import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:5001/';
  endpoint = 'accounts';

  constructor(private http: HttpClient) {}

  getAccounts(): Observable<any> {
    return this.http.get(`${this.baseUrl}${this.endpoint}`);
  }
}
