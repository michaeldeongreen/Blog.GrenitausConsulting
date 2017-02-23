import { Injectable } from '@angular/core';

import { Post } from './post';

import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class HttpService {
    private baseUrl = 'http://localhost:49964/api/posts';
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    public getPosts(page: Number): any {
        return this.http.get(this.baseUrl)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }
}
