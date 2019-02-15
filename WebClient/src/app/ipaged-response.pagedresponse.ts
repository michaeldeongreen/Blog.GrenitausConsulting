import { Observable } from 'rxjs/Observable';
import { Post } from './post';

export interface IPagedResponse {
    total: number;
    posts: Observable<Post[]>;
    archiveMonth: string;
    archiveYear: number;
}
