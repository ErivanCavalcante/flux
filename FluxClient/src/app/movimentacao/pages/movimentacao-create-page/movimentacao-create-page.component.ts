import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppService } from 'src/app/shared/services/app.service.';
import { MovimentacaoService } from '../../services/movimentacao.service';
import { MovimentacaoCreateDto } from '../../models/movimentacao-create.dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movimentacao-create-page',
  templateUrl: './movimentacao-create-page.component.html',
  styleUrls: ['./movimentacao-create-page.component.scss']
})
export class MovimentacaoCreatePageComponent implements OnInit {
  form!: FormGroup;

  constructor(private appService: AppService,
    private formBuilder: FormBuilder,
    private movimentacaoService: MovimentacaoService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.appService.setPageTitle('Movimentação');

    this.createForm();
  }

  private createForm(): void {
    this.form = this.formBuilder.group({
      'tipo': [null, Validators.required],
      'valor': [null, Validators.required],
      'descricao': [null, Validators.required],
    });
  }

  public adicionar(): void {
    var dto = new MovimentacaoCreateDto(this.form.value);
    this.movimentacaoService.create(dto).subscribe(
      res => {
        this.router.navigate(['/movimentacao']);
      }
    );
  }

  public podeAtivarBotaoCriar(): boolean {
    return this.form.valid;
  }
}
