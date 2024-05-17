import { TestBed } from '@angular/core/testing';

import { DbKeysService } from './db-keys.service';

describe('DbKeysService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DbKeysService = TestBed.get(DbKeysService);
    expect(service).toBeTruthy();
  });
});
