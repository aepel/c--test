import { LaboratoriesModule } from './laboratories.module';

describe('LaboratoriesModule', () => {
  let laboratoriesModule: LaboratoriesModule;

  beforeEach(() => {
    laboratoriesModule = new LaboratoriesModule();
  });

  it('should create an instance', () => {
    expect(laboratoriesModule).toBeTruthy();
  });
});
