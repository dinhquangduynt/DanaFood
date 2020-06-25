import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostlistDetailComponent } from './postlist-detail.component';

describe('PostlistDetailComponent', () => {
  let component: PostlistDetailComponent;
  let fixture: ComponentFixture<PostlistDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostlistDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostlistDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
