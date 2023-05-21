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
      console.log(result);
      this.dadosAnuaisSource = result;
    });
  }

  pegarPorDia(data?: Date) {
    this.consolidadoService.getByDay(data).subscribe(result => {
      console.log(result);
      this.dadosDiariosSource = [
        {
          name: "Saldo consolidado",
          "series": result as any,
        },
      ];
      this.dadosAnuaisSource = result;
    });
  }

  public abrirDialogo(): void {
    const dialogRef = this.dialog.open(DialogDatepickerComponent);

    dialogRef.afterClosed().subscribe(result => {

    });
  }
}
