import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { AuthenticationService } from '../../../services/authentication.service';
import { NgForm } from '@angular/forms';
import { Http, RequestOptionsArgs, RequestOptions } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { window } from 'rxjs-compat/operator/window';
import 'rxjs/Rx';
import { saveAs } from 'file-saver';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-files-manager',
  templateUrl: './files-manager.component.html',
  styleUrls: ['./files-manager.component.scss']
})
export class FilesManagerComponent implements OnInit {

  @Input() uploadRoute:string;
  @Input() downloadRoute:string;
  @Input() removeRoute:string;
  @Input() downloadsRoute: string;
  public uploader:FileUploader;
  public hasBaseDropZoneOver: boolean = false;
  @ViewChild('fileToUpload') fileInput: any;
  notShow: boolean;

  constructor(private authService: AuthenticationService,
    public alertService: AlertService,
    private http: HttpClient) { }
  

  ngOnInit() {
    this.uploader = new FileUploader(
      {
        url: this.uploadRoute,
        headers: [
          { name: "X-XSRF-TOKEN", value: this.getCookie("XSRF-TOKEN") },
          { name: 'Authorization', value: 'Bearer ' + this.authService.accessToken },
          { name: "Accept", value: "application/json" }
        ],
        isHTML5: true,
        allowedFileType: ['pdf', 'doc', 'xls', 'image'],
        removeAfterUpload: false,
        autoUpload: false,
        maxFileSize: 4 * 1024 * 1024
      }
    );
    var self = this;
    self.notShow = true;
    this.uploader.onWhenAddingFileFailed = (item, filter) => {
      if(!self.notShow)
        self.alertService.showMessage("Archivos", "Ha habido un error. Revise que el archivo corresponda a un documento/imagen y que su peso no supere los 4MB", MessageSeverity.error);
      self.notShow = false;
    };
    this.uploader.onCompleteItem = function () {
      self.uploader.clearQueue();
      let header = { headers: self.authService.getRequestHTTPHeaders() };
      return self.http.get<any[]>(self.downloadsRoute, header).subscribe(x => {
        self.mapearFiles(x);
      });
    }

    let header = { headers: this.authService.getRequestHTTPHeaders() };
    return this.http.get<any[]>(this.downloadsRoute, header).subscribe(x => {
      this.mapearFiles(x);
    });
  }
 
  public fileOverBase(e:any):void {
    this.hasBaseDropZoneOver = e;
  }

  submitForm(form: NgForm) {
    this.uploader.uploadAll();
  }

	remove(item) {
		if (item.isReady || item.isUploaded) {

			let header = this.authService.getRequestHTTPHeaders();
			
			return this.http.post(this.removeRoute, item.some.id, { headers: header }).subscribe(x => {
				item.remove();
			});
		}
		else {
			item.remove();
		}
	}

  changeInput() {
    this.fileInput.nativeElement.value = '';
  }


  getCookie(name: string): string {
    const value = "; " + document.cookie;
    const parts = value.split("; " + name + "=");
    if (parts.length === 2) {
      const lastItem = parts.pop();
      if (lastItem) {
        const uri = lastItem.split(";").shift();
        if (uri) {
          return decodeURIComponent(uri);
        }
      }
    }
    return "";
  }

  base64ToArrayBuffer(base64) {
    var binaryString = atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
      var ascii = binaryString.charCodeAt(i);
      bytes[i] = ascii;
    }
    return bytes;
  }

  download(item) {
    if (item.some.id) {
      let header = { headers: this.authService.getRequestHTTPHeaders() };
      return this.http.get<any[]>(this.downloadRoute + "?id=" + item.some.id, header).subscribe(x => {
        var blob = new Blob([this.base64ToArrayBuffer(x)], { type: item.some.type });
        var fileName = item.some.name;
        saveAs(blob, fileName);
      });
    }
    else {
      saveAs(item.some, item.some.name);
    }
    
  }


  mapearFiles(x) {
    let files: File[] = [];
    for (let item of x) {

      let f = new File([item.file], item.fileName, { type: item.type });
      f["id"] = item.id;
      f["fileSize"] = item.size;
      files.push(f);
    }
    this.uploader.addToQueue(files);
    this.uploader.queue.forEach(x => { x.progress = 100; x.isSuccess = true; x.isUploaded = true; });
    this.uploader.progress = 100;
  }
}
