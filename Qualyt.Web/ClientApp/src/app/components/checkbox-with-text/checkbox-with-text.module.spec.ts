import { CheckboxWithTextModule } from './checkbox-with-text.module';

describe('CheckboxWithTextModule', () => {
  let checkboxWithTextModule: CheckboxWithTextModule;

  beforeEach(() => {
    checkboxWithTextModule = new CheckboxWithTextModule();
  });

  it('should create an instance', () => {
    expect(checkboxWithTextModule).toBeTruthy();
  });
});
