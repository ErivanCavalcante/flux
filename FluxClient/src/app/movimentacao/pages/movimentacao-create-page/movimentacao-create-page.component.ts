import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/shared/services/app.service.';

@Component({
  selector: 'app-movimentacao-create-page',
  templateUrl: './movimentacao-create-page.component.html',
  styleUrls: ['./movimentacao-create-page.component.scss']
})
export class MovimentacaoCreatePageComponent implements OnInit {
  constructor(private appService: AppService) {

  }

  ngOnInit(): void {
    this.appService.setPageTitle('Movimentação');
  }

  public adicionar(): void {

  }
}
