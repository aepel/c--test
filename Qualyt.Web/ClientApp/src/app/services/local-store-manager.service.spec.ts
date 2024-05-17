import { TestBed } from '@angular/core/testing';

import { LocalStoreManagerService } from './local-store-manager.service';

describe('LocalStoreManagerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LocalStoreManagerService = TestBed.get(LocalStoreManagerService);
    expect(service).toBeTruthy();
  });
});
