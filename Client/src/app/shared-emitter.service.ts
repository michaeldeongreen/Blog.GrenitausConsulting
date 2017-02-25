import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class SharedEmitterService {

    searchCriteriaChanged = new EventEmitter();

    categoryChanged = new EventEmitter();

    constructor() { }

    searchCriteriaChangedEvent(value) {
        this.searchCriteriaChanged.emit(value);
    }

    categoryChangedEvent(value) {
        this.categoryChanged.emit(value);
    }
}
