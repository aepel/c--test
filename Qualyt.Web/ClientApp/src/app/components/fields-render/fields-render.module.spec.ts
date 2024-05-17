import { FieldsRenderModule } from './fields-render.module';

describe('FieldsRenderModule', () => {
  let fieldsRenderModule: FieldsRenderModule;

  beforeEach(() => {
    fieldsRenderModule = new FieldsRenderModule();
  });

  it('should create an instance', () => {
    expect(fieldsRenderModule).toBeTruthy();
  });
});
