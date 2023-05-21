import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AppService } from 'src/app/shared/services/app.service.';
import { DialogDatepickerComponent } from './dialogs/dialog-datepicker-component/dialog-datepicker.component';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent {
  dadosAnuaisSource = [
    { name: "Jan", value: 105000 },
    { name: "Fev", value: 55000 },
    { name: "Mar", value: 15000 },
    { name: "Abr", value: 150000 },
    { name: "Mai", value: 20000 },
    { name: "Jun", value: 20000 },
    { name: "Jul", value: 20000 },
    { name: "Ago", value: 20000 },
    { name: "Set", value: 20000 },
    { name: "Out", value: 20000 },
    { name: "Nov", value: 20000 },
    { name: "Dez", value: 20000 },
  ];

  dadosDiariosSource = [
    {
      name: "Saldo consolidado",
      "series": [
        { name: "7:00", value: 105000 },
        { name: "8:00", value: 55000 },
        { name: "9:00", value: 15000 },
        { name: "10:00", value: 150000 },
        { name: "11:00", value: 20000 },
        { name: "12:00", value: 20000 },
        { name: "12:00", value: 20000 },
        { name: "13:00", value: 20000 },
        { name: "13:00", value: 20000 },
        { name: "18:00", value: 10000 },
        { name: "20:00", value: 12000 },
        { name: "21:00", value: 50000 },
      ]
    },
  ];

  constructor(private appService: AppService, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.appService.setPageTitle('Dashboard');
  }

  public abrirDialogo(): void {
    const dialogRef = this.dialog.open(DialogDatepickerComponent);

    dialogRef.afterClosed().subscribe(result => {

    });
  }
}
