import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Technology } from '../models/technology.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TechnologyService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.apiBaseUrl}/technologies`;

  getTechnologies(): Observable<Technology[]> {
    return this.http.get<Technology[]>(this.baseUrl);
  }

  getTechnologyById(id: number): Observable<Technology> {
    return this.http.get<Technology>(`${this.baseUrl}/${id}`);
  }
}
