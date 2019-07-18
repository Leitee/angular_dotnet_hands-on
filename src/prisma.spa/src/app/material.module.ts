import { NgModule } from '@angular/core';
import { LayoutModule } from '@angular/cdk/layout';
import {
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatGridListModule,
    MatCardModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatButtonToggleModule,
    MatAutocompleteModule,
    MatStepperModule,
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MAT_DIALOG_DEFAULT_OPTIONS
} from '@angular/material';

@NgModule({
    imports: [
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatGridListModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatButtonToggleModule,
        MatAutocompleteModule,
        MatStepperModule,
        MatTabsModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule
    ],
    exports: [
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatGridListModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatButtonToggleModule,
        MatAutocompleteModule,
        MatStepperModule,
        MatTabsModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule
    ],
    providers: [
        { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: false } }
    ]
})
export class MaterialModule { }