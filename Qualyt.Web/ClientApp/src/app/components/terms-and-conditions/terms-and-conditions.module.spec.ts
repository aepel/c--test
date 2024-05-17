import { TermsAndConditionsModule } from './terms-and-conditions.module';

describe('TermsAndConditionsModule', () => {
  let termsAndConditionsModule: TermsAndConditionsModule;

  beforeEach(() => {
    termsAndConditionsModule = new TermsAndConditionsModule();
  });

  it('should create an instance', () => {
    expect(termsAndConditionsModule).toBeTruthy();
  });
});
