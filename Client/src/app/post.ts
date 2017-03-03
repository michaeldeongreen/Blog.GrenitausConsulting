import { Category } from './category';
import { Tag } from './tag';
import { Image } from './image';
import { Observable } from 'rxjs/Observable';

export class Post {
    id: number;
    title: string;
    author: string;
    postDate: Date;
    snippet: string;
    link: string;
    isActive: boolean;
    categories: Observable<Category>;
    tags: Observable<Tag>;
    images: Observable<Image>;
    canPreview: boolean;
    previewExpirationDate: Date;
}
