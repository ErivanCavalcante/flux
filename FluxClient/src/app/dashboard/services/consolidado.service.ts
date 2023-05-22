import { HttpClient, HttpParams } from '@angular/common/http';
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
    const isoDate = data?.toISOString();
    let queryParams = new HttpParams();

    if (isoDate) {
      queryParams = queryParams.append('data', isoDate);
    }

    return this.http.get(`${this.BASE_API}/consolidado/ano?` + queryParams.toString())
      .pipe(
        map((response: any) => {
          return response.data.map((consolidado: any) => { return new ConsolidadoListDto(consolidado); });
        }),
      );
  }

  public getByDay(data?: Date): Observable<ConsolidadoListDto[]> {
    const isoDate = data?.toISOString();
    let queryParams = new HttpParams();

    if (isoDate) {
      queryParams = queryParams.append('data', isoDate);
    }

    return this.http.get(`${this.BASE_API}/consolidado/dia?` + queryParams.toString())
      .pipe(
        map((response: any) => {
          return response.data.map((consolidado: any) => { return new ConsolidadoListDto(consolidado); });
        }),
      );
  }
}
