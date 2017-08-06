import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class RestService {
  constructor (
    private http: Http
  ) {}

  getValues() {
    return this.http.get(`http://ec2-52-91-192-126.compute-1.amazonaws.com/api/Xss/1`)
    .map((res:Response) => res.json());
  }

}