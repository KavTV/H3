import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDictatorComponent } from './create-dictator.component';

describe('CreateDictatorComponent', () => {
  let component: CreateDictatorComponent;
  let fixture: ComponentFixture<CreateDictatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDictatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDictatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
