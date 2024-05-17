import { InfoTreatmentModule } from './info-treatment.module';

describe('InfoTreatmentModule', () => {
  let infoTreatmentModule: InfoTreatmentModule;

  beforeEach(() => {
    infoTreatmentModule = new InfoTreatmentModule();
  });

  it('should create an instance', () => {
    expect(infoTreatmentModule).toBeTruthy();
  });
});
