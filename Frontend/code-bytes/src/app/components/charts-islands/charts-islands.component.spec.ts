import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartsIslandsComponent } from './charts-islands.component';

describe('ChartsIslandsComponent', () => {
  let component: ChartsIslandsComponent;
  let fixture: ComponentFixture<ChartsIslandsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChartsIslandsComponent]
    });
    fixture = TestBed.createComponent(ChartsIslandsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
