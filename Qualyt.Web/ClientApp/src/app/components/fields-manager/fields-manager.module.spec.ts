import { FieldsManagerModule } from './fields-manager.module';

describe('FieldsManagerModule', () => {
  let fieldsManagerModule: FieldsManagerModule;

  beforeEach(() => {
    fieldsManagerModule = new FieldsManagerModule();
  });

  it('should create an instance', () => {
    expect(fieldsManagerModule).toBeTruthy();
  });
});
