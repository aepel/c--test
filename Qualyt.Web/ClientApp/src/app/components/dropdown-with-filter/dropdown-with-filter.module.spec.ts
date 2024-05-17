import { DropdownWithFilterModule } from './dropdown-with-filter.module';

describe('DropdownWithFilterModule', () => {
  let dropdownWithFilterModule: DropdownWithFilterModule;

  beforeEach(() => {
    dropdownWithFilterModule = new DropdownWithFilterModule();
  });

  it('should create an instance', () => {
    expect(dropdownWithFilterModule).toBeTruthy();
  });
});
