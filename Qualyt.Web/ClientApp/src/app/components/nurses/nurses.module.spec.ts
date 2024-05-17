import { NursesModule } from './nurses.module';

describe('NursesModule', () => {
  let nursesModule: NursesModule;

  beforeEach(() => {
    nursesModule = new NursesModule();
  });

  it('should create an instance', () => {
    expect(nursesModule).toBeTruthy();
  });
});
