import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TagResultsComponent } from './tag-results.component';

describe('TagResultsComponent', () => {
  let component: TagResultsComponent;
  let fixture: ComponentFixture<TagResultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TagResultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TagResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
