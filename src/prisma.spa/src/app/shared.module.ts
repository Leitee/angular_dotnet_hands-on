import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';
import { MessageDialogComponent, ContentWrapperComponent, LoaderComponent } from './_components';
import { DataTableComponent } from './_components/data-table/data-table.component';

@NgModule({
  entryComponents: [MessageDialogComponent],
  declarations: [
    ContentWrapperComponent,
    MessageDialogComponent,
    LoaderComponent,
    DataTableComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    CommonModule,
    MaterialModule,
    ContentWrapperComponent,
    LoaderComponent,
    DataTableComponent
  ]
})
export class SharedModule { }
