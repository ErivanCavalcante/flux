import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ConsolidadoListDto } from '../models/consolidado-list.dto';

@Injectable({
  providedIn: 'root'
})
export class ConsolidadoService {
  private BASE_API: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  public getByAno(data?: Date): Observable<ConsolidadoListDto[]> {
    return this.http.get(`${this.BASE_API}/consolidado/ano`)
      .pipe(
        map((response: any) => {
          return response.data.map((consolidado: any) => { return new ConsolidadoListDto(consolidado); });
        }),
      );
  }

  public getByDay(data?: Date): Observable<ConsolidadoListDto[]> {
    return this.http.get(`${this.BASE_API}/consolidado/dia`)
      .pipe(
        map((response: any) => {
          return response.data.map((consolidado: any) => { return new ConsolidadoListDto(consolidado); });
        }),
      );
  }
}
