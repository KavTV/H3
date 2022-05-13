import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DictatorComponent } from './dictator.component';

describe('DictatorComponent', () => {
  let component: DictatorComponent;
  let fixture: ComponentFixture<DictatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DictatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DictatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
