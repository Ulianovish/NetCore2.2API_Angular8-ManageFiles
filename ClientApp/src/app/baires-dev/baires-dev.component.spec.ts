import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BairesDevComponent } from './baires-dev.component';

describe('BairesDevComponent', () => {
  let component: BairesDevComponent;
  let fixture: ComponentFixture<BairesDevComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BairesDevComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BairesDevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
