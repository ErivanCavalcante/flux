import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-datepicker-component',
  templateUrl: './dialog-datepicker.component.html',
  styleUrls: ['./dialog-datepicker.component.scss']
})
export class DialogDatepickerComponent {
  constructor(public dialogRef: MatDialogRef<DialogDatepickerComponent>) {

  }

  public filtrar(): void {
    this.dialogRef.close('result');
  }
}
