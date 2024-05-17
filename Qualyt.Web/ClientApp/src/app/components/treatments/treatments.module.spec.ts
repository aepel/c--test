import { TreatmentsModule } from './treatments.module';

describe('TreatmentsModule', () => {
  let treatmentsModule: TreatmentsModule;

  beforeEach(() => {
    treatmentsModule = new TreatmentsModule();
  });

  it('should create an instance', () => {
    expect(treatmentsModule).toBeTruthy();
  });
});
