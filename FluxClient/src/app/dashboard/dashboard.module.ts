import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DialogDatepickerComponent } from './pages/dashboard-page/dialogs/dialog-datepicker-component/dialog-datepicker.component';

@NgModule({
  declarations: [
    DashboardPageComponent,
    DialogDatepickerComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    BrowserAnimationsModule,
    NgxChartsModule
  ]
})
export class DashboardModule { }
