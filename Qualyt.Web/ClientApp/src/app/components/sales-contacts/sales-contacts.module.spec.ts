import { SalesContactsModule } from './sales-contacts.module';

describe('SalesContactsModule', () => {
  let salesContactsModule: SalesContactsModule;

  beforeEach(() => {
    salesContactsModule = new SalesContactsModule();
  });

  it('should create an instance', () => {
    expect(salesContactsModule).toBeTruthy();
  });
});
