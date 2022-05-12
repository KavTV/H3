import { TestBed } from '@angular/core/testing';

import { DictatorService } from './dictator.service';

describe('DictatorService', () => {
  let service: DictatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DictatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
