import { MultidropdownWithFilterModule } from "./multidropdown-with-filter.module";

describe('MultidropdownWithFilterModule', () => {
  let multidropdownWithFilterModule: MultidropdownWithFilterModule;

  beforeEach(() => {
    multidropdownWithFilterModule = new MultidropdownWithFilterModule();
  });

  it('should create an instance', () => {
    expect(multidropdownWithFilterModule).toBeTruthy();
  });
});
