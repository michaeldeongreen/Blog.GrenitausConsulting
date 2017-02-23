import { Injectable } from '@angular/core';

import { Post } from './post';

import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class PostService {
    private apiUrl = 'http://localhost:49964/api/posts';
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    getPosts(): Promise<Post[]> {
        return this.http.get(this.apiUrl)
            .toPromise()
            .then(response => response.json() as Post[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
