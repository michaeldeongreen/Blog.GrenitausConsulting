import { Observable } from 'rxjs/Observable';
import { Category } from './category';
import { Tag } from './tag';
import { Image } from './image';

export interface IPostSummary {
    id: number;
    title: string;
    author: string;
    postDate: Date;
    snippet: string;
    link: string;
    isActive: boolean;
    categories: Observable<Category[]>;
    tags: Observable<Tag[]>;
    images: Observable<Image[]>;
    canPreview: boolean;
    previewExpirationDate: Date;
    staticHtml: string;
}
