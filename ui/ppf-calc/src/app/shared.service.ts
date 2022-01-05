import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  apiUrl = 'https://localhost:44329/api/PPFCalc/';
  constructor(private http: HttpClient) { }

  getCompleteDetails(parameters: any): Observable<any[]> {
      return this.http.post<any>(this.apiUrl + 'getCompleteDetails', parameters)
  }

  GetMaturityAmount(parameters: any): Observable<any[]> {
    return this.http.post<any>(this.apiUrl + 'GetMaturityAmount', parameters)
}

}
