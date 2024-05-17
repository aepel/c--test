import { PlanCardModule } from './plan-card.module';

describe('PlanCardModule', () => {
  let planCardModule: PlanCardModule;

  beforeEach(() => {
    planCardModule = new PlanCardModule();
  });

  it('should create an instance', () => {
    expect(planCardModule).toBeTruthy();
  });
});
