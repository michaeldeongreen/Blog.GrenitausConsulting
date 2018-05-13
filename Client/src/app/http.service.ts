import { Injectable } from '@angular/core';
import { Post } from './post';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../environments/environment';
import { IPagedResponse } from './ipaged-response.pagedresponse';


@Injectable()
export class HttpService {
    private baseUrl: string;
    
    private headers = new Headers({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    });

    constructor(private http: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    public getPosts(page: Number): any {
        return this.http.get<IPagedResponse>(`${this.baseUrl}/posts/page/${page}`);
    }

    public getSearchResults(page: Number, criteria: string): any {
        let url = `${this.baseUrl}/search/${encodeURIComponent(criteria)}/page/${page}`;
        return this.http.get(url)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPostHtml(title: string): any {
        return this.http.get(`${this.baseUrl}/html/${title}`)
            .map((response: Response) => response.text())
            .catch((error: any) => Observable.throw(error.text().error) || 'Server Error');
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

    public getArchives(): any {
        return this.http.get(`${this.baseUrl}/archives`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPostsByMonthAndYear(month: number, year: number, page: number): any {
        return this.http.get(`${this.baseUrl}/posts/month/${month}/year/${year}/page/${page}`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getQuote(): any {
        return this.http.get(`${this.baseUrl}/quote`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPostPreviewHtml(title: string): any {
        return this.http.get(`${this.baseUrl}/html/${title}/preview`)
            .map((response: Response) => response.text())
            .catch((error: any) => Observable.throw(error.text().error) || 'Server Error');
    }

    public getPostPreview(title: string): any {
        return this.http.get(`${this.baseUrl}/post/${title}/preview`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getAlsoOn(id: number): any {
        return this.http.get(`${this.baseUrl}/post/${id}/alsoon`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }

    public getPreviews(): any {
        return this.http.get(`${this.baseUrl}/post/previews`)
            .map((response: Response) => response.json())
            .catch((error: any) => Observable.throw(error.json().error) || 'Server Error');
    }
}
