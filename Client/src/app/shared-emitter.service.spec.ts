import { TestBed, inject } from '@angular/core/testing';
import { SharedEmitterService } from './shared-emitter.service';

describe('SharedEmitterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SharedEmitterService]
    });
  });

  it('should ...', inject([SharedEmitterService], (service: SharedEmitterService) => {
    expect(service).toBeTruthy();
  }));
});
