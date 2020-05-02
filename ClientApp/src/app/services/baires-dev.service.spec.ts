import { TestBed } from '@angular/core/testing';

import { BairesDevService } from './baires-dev.service';

describe('BairesDevService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BairesDevService = TestBed.get(BairesDevService);
    expect(service).toBeTruthy();
  });
});
