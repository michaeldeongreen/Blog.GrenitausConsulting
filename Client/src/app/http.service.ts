import { Injectable } from '@angular/core';
import { Post } from './post';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../environments/environment';
import { IPagedResponse } from './ipaged-response.pagedresponse';
import { Quote } from './quote';
import { Category } from './category';
import { Archive } from './archive';
import { IPostSummary } from './ipost-summary.postsummary';

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
        return this.http.get<IPagedResponse>(url)
    }

    public getPostHtml(title: string): any {
        return this.http.get(`${this.baseUrl}/html/${title}`, {responseType: 'text'})
    }

    public getPost(title: string): any {
        return this.http.get<IPostSummary>(`${this.baseUrl}/post/${title}`)
    }

    public getCategories(): any {
        return this.http.get<Observable<Category>>(`${this.baseUrl}/categories`)
    }

    public getPostsByCategory(category: string, page: number): any {
        return this.http.get<IPagedResponse>(`${this.baseUrl}/posts/category/${category}/page/${page}`)
    }

    public getPostsByTag(tag: string, page: number): any {
        return this.http.get<IPagedResponse>(`${this.baseUrl}/posts/tag/${tag}/page/${page}`)
    }

    public getArchives(): any {
        return this.http.get<Observable<Archive>>(`${this.baseUrl}/archives`)
    }

    public getPostsByMonthAndYear(month: number, year: number, page: number): any {
        return this.http.get<IPagedResponse>(`${this.baseUrl}/posts/month/${month}/year/${year}/page/${page}`)
    }

    public getQuote(): any {
        return this.http.get<Quote>(`${this.baseUrl}/quote`);
    }

    public getPostPreviewHtml(title: string): any {
        return this.http.get(`${this.baseUrl}/html/${title}/preview`, {responseType: "text"})
    }

    public getPostPreview(title: string): any {
        return this.http.get<IPostSummary>(`${this.baseUrl}/post/${title}/preview`)
    }

    public getAlsoOn(id: number): any {
        return this.http.get<IPagedResponse>(`${this.baseUrl}/post/${id}/alsoon`)
    }

    public getPreviews(): any {
        return this.http.get<IPagedResponse>(`${this.baseUrl}/post/previews`)
    }
}
