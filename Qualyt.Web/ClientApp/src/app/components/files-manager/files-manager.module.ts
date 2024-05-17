import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule } from 'ng2-file-upload';
import { FilesManagerComponent } from './files-manager/files-manager.component';
import { MatButtonModule } from '@angular/material';
import { AuthenticationService } from '../../services/authentication.service';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Http, ConnectionBackend, RequestOptions, HttpModule } from '@angular/http';

@NgModule({
  imports: [
    CommonModule,
    FileUploadModule,
    MatButtonModule,
    FormsModule,
    HttpModule
  ],
  declarations: [FilesManagerComponent],
  exports: [FilesManagerComponent],
  providers: [AuthenticationService]
})
export class FilesManagerModule { }
