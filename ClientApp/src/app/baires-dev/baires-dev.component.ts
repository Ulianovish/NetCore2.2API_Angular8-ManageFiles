import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BairesDevService } from '../services/baires-dev.service';
import { BairesDev } from '../models/bairesdev';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-baires-dev',
  templateUrl: './baires-dev.component.html',
  styleUrls: ['./baires-dev.component.scss']
})
export class BairesDevComponent {
  blogPosts$: Observable<BairesDev[]>;
  public progress: number;
  public message;
  myAppUrl: string;
  loading = false;

  constructor(private blogPostService: BairesDevService, private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
  }

  loadBairesDev() {
    this.blogPosts$ = this.blogPostService.getBairesDev();
  }

  upload(files) {
    this.loading = true;
    this.blogPosts$ = new Observable<BairesDev[]>();
    this.blogPostService.uploadFile(files).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.loading = true;
      } else if (event.type === HttpEventType.Response) {
        this.message = event.body;
        this.loadBairesDev();
        this.loading = false;
      }
    });
  }

  getFile(){
    this.blogPostService.downloadFile('people.in').subscribe(
      data => {
        switch (data.type) {
          case HttpEventType.DownloadProgress:
            break;
          case HttpEventType.Response:
            const downloadedFile = new Blob([data.body], { type: data.body.type });
            const a = document.createElement('a');
            a.setAttribute('style', 'display:none;');
            document.body.appendChild(a);
            a.download = 'people.out';
            a.href = URL.createObjectURL(downloadedFile);
            a.target = '_blank';
            a.click();
            document.body.removeChild(a);
            break;
        }
      },
      error => {
        console.log('download failed');
      }
    );
  }
}
