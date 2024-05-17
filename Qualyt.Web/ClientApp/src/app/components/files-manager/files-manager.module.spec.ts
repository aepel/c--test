import { FilesManagerModule } from './files-manager.module';

describe('FilesManagerModule', () => {
  let filesManagerModule: FilesManagerModule;

  beforeEach(() => {
    filesManagerModule = new FilesManagerModule();
  });

  it('should create an instance', () => {
    expect(filesManagerModule).toBeTruthy();
  });
});
