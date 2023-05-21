import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-confirmar-deletar',
  templateUrl: './dialog-confirmar-deletar.component.html',
  styleUrls: ['./dialog-confirmar-deletar.component.scss']
})
export class DialogConfirmarDeletarComponent {
  constructor(public dialogRef: MatDialogRef<DialogConfirmarDeletarComponent>) { }

  remover() {
    this.dialogRef.close(true);
  }
}
