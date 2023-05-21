import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { MovimentacaoListDto } from '../models/movimentacao-list.dto';
import { MovimentacaoCreateDto } from '../models/movimentacao-create.dto';
import { environment } from '../../../environments/environment';
import { MovimentacaoUpdateDto } from '../models/movimentacao-update.dto';

@Injectable({
  providedIn: 'root'
})
export class MovimentacaoService {
  private BASE_API: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<MovimentacaoListDto[]> {
    return this.http.get(`${this.BASE_API}/movimentacao`)
      .pipe(
        map((response: any) => {
          return response.data.map((movimentacao: any) => { return new MovimentacaoListDto(movimentacao); });
        }),
      );
  }

  public create(dto: MovimentacaoCreateDto) {
    return this.http.post(`${this.BASE_API}/movimentacao`, dto);
  }

  public update(dto: MovimentacaoUpdateDto) {
    return this.http.put(`${this.BASE_API}/movimentacao`, dto);
  }

  public delete(id: string) {
    return this.http.delete(`${this.BASE_API}/movimentacao/${id}`);
  }
}
