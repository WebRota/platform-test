import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class JsonService {
  private jsonUrl = 'https://raw.githubusercontent.com/WebRota/platform-test/master/positions.json';

  constructor(private http: HttpClient) { }

  getJsonData() {
    return this.http.get(this.jsonUrl);
  }
}
