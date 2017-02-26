import { Injectable } from '@angular/core';

import { Post } from './post';

import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class HttpService {
    private baseUrl = 'http://localhost:49529/api';
    private headers = new Headers({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    });

    constructor(private http: Http) { }

    public getPosts(page: Number): any {
        return this.http.get(`${this.baseUrl}/posts/page/${page}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getSearchResults(page: Number, criteria: string): any {
        return this.http.get(`${this.baseUrl}/search/${criteria}/page/${page}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPostHtml(title: string): any {
        return this.http.get(`${this.baseUrl}/html/${title}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPost(title: string): any {
        return this.http.get(`${this.baseUrl}/post/${title}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getCategories(): any {
        return this.http.get(`${this.baseUrl}/categories`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPostsByCategory(category: string, page: number): any {
        return this.http.get(`${this.baseUrl}/posts/category/${category}/page/${page}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPostsByTag(tag: string, page: number): any {
        return this.http.get(`${this.baseUrl}/posts/tag/${tag}/page/${page}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }
}
