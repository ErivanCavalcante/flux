import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-datepicker-component',
  templateUrl: './dialog-datepicker.component.html',
  styleUrls: ['./dialog-datepicker.component.scss']
})
export class DialogDatepickerComponent implements OnInit {
  form!: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<DialogDatepickerComponent>,
    private fb: FormBuilder
  ) {

  }

  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.form = this.fb.group({
      'data': [null, [Validators.required,]],
    });
  }

  public ativiarBotaoFiltrar(): boolean {
    return this.form.valid;
  }

  public filtrar(): void {
    const data = this.form.get('data')!.value;

    this.dialogRef.close(data);
  }
}
