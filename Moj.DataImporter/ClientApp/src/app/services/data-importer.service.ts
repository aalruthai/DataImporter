import { Observable } from 'rxjs';
import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderDto } from '../models/OrderDto.model';

@Injectable({
  providedIn: 'root'
})
export class DataImporterService {
  EXCEL_URL = '/api/Orders/upload';
  constructor(private http: HttpClient) { }

  uploadFile(file): Observable<HttpEvent<OrderDto[]>> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post<OrderDto[]>(this.EXCEL_URL, formData, {
      reportProgress: true,
      observe: 'events'
    });
  }
}
