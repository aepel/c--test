import { GeocodingModule } from './geocoding.module';

describe('GeocodingModule', () => {
  let geocodingModule: GeocodingModule;

  beforeEach(() => {
    geocodingModule = new GeocodingModule();
  });

  it('should create an instance', () => {
    expect(geocodingModule).toBeTruthy();
  });
});
