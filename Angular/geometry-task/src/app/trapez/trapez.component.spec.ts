import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrapezComponent } from './trapez.component';

describe('TrapezComponent', () => {
  let component: TrapezComponent;
  let fixture: ComponentFixture<TrapezComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrapezComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrapezComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
