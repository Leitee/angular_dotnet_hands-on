import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatIcon, MatDialogRef } from '@angular/material';
import { DialogData, DialogIconEnum } from '@/_models';

@Component({
  selector: 'app-message-dialog',
  templateUrl: './message-dialog.component.html',
  styleUrls: ['./message-dialog.component.scss']
})
export class MessageDialogComponent implements OnInit {

  @ViewChild('iconElem', { static: true }) iconElem: MatIcon;

  constructor(public dialogRef: MatDialogRef<MessageDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  ngOnInit() {
    let stylesElem = this.iconElem._elementRef.nativeElement.style;

    switch (this.data.icon) {
      case DialogIconEnum.ERROR:
        stylesElem.color = '#dc3545';
        break;
      case DialogIconEnum.WARN:
        stylesElem.color = '#c7ad3f';
        break;
      case DialogIconEnum.INFO:
        stylesElem.color = 'blue';
        break;

      default:
        //this.iconElem.color
        break;
    }
  }

  onNoClick(): void {
    this.dialogRef.close(false);
  }

}
