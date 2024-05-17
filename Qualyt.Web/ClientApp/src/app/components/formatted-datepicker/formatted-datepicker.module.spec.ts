import { FormattedDatepickerModule } from './formatted-datepicker.module';

describe('FormattedDatepickerModule', () => {
  let formattedDatepickerModule: FormattedDatepickerModule;

  beforeEach(() => {
    formattedDatepickerModule = new FormattedDatepickerModule();
  });

  it('should create an instance', () => {
    expect(formattedDatepickerModule).toBeTruthy();
  });
});
