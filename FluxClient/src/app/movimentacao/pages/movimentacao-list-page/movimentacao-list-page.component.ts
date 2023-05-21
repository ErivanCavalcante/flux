import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/shared/services/app.service.';
import { MovimentacaoService } from '../../services/movimentacao.service';
import { MovimentacaoListDto } from '../../models/movimentacao-list.dto';

@Component({
  selector: 'app-movimentacao-list-page',
  templateUrl: './movimentacao-list-page.component.html',
  styleUrls: ['./movimentacao-list-page.component.scss']
})
export class MovimentacaoListPageComponent implements OnInit {
  displayedColumns: string[] = ['data', 'tipoMovimentacao', 'descricao', 'valor',];
  dataSource: MovimentacaoListDto[] = [];

  constructor(
    private appService: AppService,
    private movimentacaoService: MovimentacaoService,
  ) {

  }

  ngOnInit(): void {
    this.appService.setPageTitle('Movimentação');

    this.getAll();
  }

  getAll(): void {
    this.movimentacaoService.getAll().subscribe(result => {
      this.dataSource = result;
    });
  }
}
