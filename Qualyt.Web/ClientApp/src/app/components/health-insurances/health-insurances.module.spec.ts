import { HealthInsurancesModule } from './health-insurances.module';

describe('HealthInsurancesModule', () => {
  let healthInsurancesModule: HealthInsurancesModule;

  beforeEach(() => {
    healthInsurancesModule = new HealthInsurancesModule();
  });

  it('should create an instance', () => {
    expect(healthInsurancesModule).toBeTruthy();
  });
});
