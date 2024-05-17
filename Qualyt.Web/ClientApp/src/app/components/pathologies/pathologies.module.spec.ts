import { PathologiesModule } from './pathologies.module';

describe('PathologiesModule', () => {
  let pathologiesModule: PathologiesModule;

  beforeEach(() => {
    pathologiesModule = new PathologiesModule();
  });

  it('should create an instance', () => {
    expect(pathologiesModule).toBeTruthy();
  });
});
