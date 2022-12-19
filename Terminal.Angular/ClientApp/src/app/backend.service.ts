import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  constructor(private http : HttpClient, @Inject('BASE_URL') private baseUri : string) {}

  post(endpoint : string, data : any) {
    this.http.post(this.baseUri + endpoint, data);
  }

  cancel(endpoint : string) {
    this.http.delete(this.baseUri + endpoint);
  }
}
