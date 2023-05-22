import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/shared/services/app.service.';
import { MovimentacaoService } from '../../services/movimentacao.service';
import { MovimentacaoListDto } from '../../models/movimentacao-list.dto';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfirmarDeletarComponent } from 'src/app/shared/dialogs/dialog-confirmar-deletar/dialog-confirmar-deletar.component';

@Component({
  selector: 'app-movimentacao-list-page',
  templateUrl: './movimentacao-list-page.component.html',
  styleUrls: ['./movimentacao-list-page.component.scss']
})
export class MovimentacaoListPageComponent implements OnInit {
  displayedColumns: string[] = ['data', 'tipoMovimentacao', 'descricao', 'valor', 'acoes'];
  dataSource: MovimentacaoListDto[] = [];

  constructor(
    private appService: AppService,
    private movimentacaoService: MovimentacaoService,
    public dialog: MatDialog,
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

  public confirmarRemocao(item: MovimentacaoListDto) {
    const dialogRef = this.dialog.open(DialogConfirmarDeletarComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result == true) {
        this.movimentacaoService.delete(item.id).subscribe(deleted => {
          this.getAll();
        });
      }
    });
  }
}
