import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovimentacaoListPageComponent } from './pages/movimentacao-list-page/movimentacao-list-page.component';
import { MovimentacaoCreatePageComponent } from './pages/movimentacao-create-page/movimentacao-create-page.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MovimentacaoListPageComponent,
    MovimentacaoCreatePageComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
  ]
})
export class MovimentacaoModule { }
