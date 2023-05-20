import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/shared/services/app.service.';

@Component({
  selector: 'app-movimentacao-list-page',
  templateUrl: './movimentacao-list-page.component.html',
  styleUrls: ['./movimentacao-list-page.component.scss']
})
export class MovimentacaoListPageComponent implements OnInit {
  displayedColumns: string[] = ['data', 'tipo_movimentacao', 'valor'];
  dataSource = [
    {
      data: '20/05/2023',
      tipo_movimentacao: 'RETIRADA',
      valor: 200
    }
  ];

  constructor(private appService: AppService) {

  }

  ngOnInit(): void {
    this.appService.setPageTitle('Movimentação');
  }
}
