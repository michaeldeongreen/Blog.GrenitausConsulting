import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewsComponent } from './previews.component';

describe('PreviewsComponent', () => {
  let component: PreviewsComponent;
  let fixture: ComponentFixture<PreviewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreviewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
