import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HostPageComponent } from './shared/pages/host-page/host-page.component';
import { MovimentacaoListPageComponent } from './movimentacao/pages/movimentacao-list-page/movimentacao-list-page.component';
import { MovimentacaoCreatePageComponent } from './movimentacao/pages/movimentacao-create-page/movimentacao-create-page.component';

const routes: Routes = [
  {
    path: '',
    component: HostPageComponent,
    children: [
      {
        path: 'movimentacao',
        component: MovimentacaoListPageComponent,
      },
      {
        path: 'movimentacao/criar',
        component: MovimentacaoCreatePageComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
