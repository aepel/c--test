import { ControlTrackingsModule } from './control-trackings.module';

describe('ControlTrackingsModule', () => {
  let controlTrackingsModule: ControlTrackingsModule;

  beforeEach(() => {
    controlTrackingsModule = new ControlTrackingsModule();
  });

  it('should create an instance', () => {
    expect(controlTrackingsModule).toBeTruthy();
  });
});
