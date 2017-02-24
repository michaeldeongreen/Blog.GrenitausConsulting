import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class SharedEmitterService {

    searchCriteriaChanged = new EventEmitter();

    constructor() { }

    searchCriteriaChangedEvent(value) {
        this.searchCriteriaChanged.emit(value);
    }


}
