import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { BairesDev } from '../models/bairesdev';
import { saveAs } from 'file-saver';

@Injectable({
  providedIn: 'root'
})
export class BairesDevService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/BairesDev/';
  }

  public downloadFile(file: string): Observable<HttpEvent<Blob>> {
    return this.http.request(new HttpRequest(
      'GET',
      `${this.myAppUrl + this.myApiUrl}download?file=${file}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

  public uploadFile(files): Observable<HttpEvent<void>> {
    const formData = new FormData();
    for (const file of files) {
      formData.append(file.name, file);
    }
 
    return this.http.request(new HttpRequest(
      'POST',
      this.myAppUrl + this.myApiUrl,
      formData,
      {
        reportProgress: true
      }));
  }

  getBairesDev(): Observable<BairesDev[]> {
    return this.http.get<BairesDev[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
