import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetidorDetailComponent } from './competidor-detail.component';

describe('CompetidorDetailComponent', () => {
  let component: CompetidorDetailComponent;
  let fixture: ComponentFixture<CompetidorDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetidorDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetidorDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
