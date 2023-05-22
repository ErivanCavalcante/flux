import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AppService } from 'src/app/shared/services/app.service.';
import { DialogDatepickerComponent } from './dialogs/dialog-datepicker-component/dialog-datepicker.component';
import { ConsolidadoService } from '../../services/consolidado.service';
import { ConsolidadoListDto } from '../../models/consolidado-list.dto';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent {
  dadosAnuaisSource: ConsolidadoListDto[] = [];

  dadosDiariosSource: any[] = [];

  constructor(
    private appService: AppService,
    public dialog: MatDialog,
    private consolidadoService: ConsolidadoService,
  ) {

  }

  ngOnInit(): void {
    this.appService.setPageTitle('Dashboard');

    this.pegarPorAno();
    this.pegarPorDia();
  }

  pegarPorAno(data?: Date) {
    this.consolidadoService.getByAno(data).subscribe(result => {
      this.dadosAnuaisSource = result;
    });
  }

  pegarPorDia(data?: Date) {
    this.consolidadoService.getByDay(data).subscribe(result => {
      this.dadosDiariosSource = [
        {
          name: "Saldo consolidado",
          "series": result as any,
        },
      ];
    });
  }

  public abrirDialogo(filtro: string): void {
    const dialogRef = this.dialog.open(DialogDatepickerComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const date = new Date(result);

        console.log(date);
        if (filtro == 'ANO') {
          this.pegarPorAno(date);
        }
        else {
          this.pegarPorDia(date);
        }
      }
    });
  }
}
