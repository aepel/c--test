import { PivotTableModule } from './pivot-table.module';

describe('PivotTableModule', () => {
  let pivotTableModule: PivotTableModule;

  beforeEach(() => {
    pivotTableModule = new PivotTableModule();
  });

  it('should create an instance', () => {
    expect(pivotTableModule).toBeTruthy();
  });
});
