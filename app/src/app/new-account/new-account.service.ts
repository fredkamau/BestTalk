import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NewAccountService {
  baseUrl = 'https://localhost:5001/';
  endpoint = 'accounts';
  constructor(private http: HttpClient) {}

  CreateAccount(requestPayload: any): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.endpoint}`, requestPayload);
  }
}
