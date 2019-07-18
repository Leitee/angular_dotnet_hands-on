import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Competidor } from '@/_models';
import { PrismaService } from '@/_services';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-competidor-detail',
  templateUrl: './competidor-detail.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [PrismaService]
})
export class CompetidorDetailComponent implements OnInit {

  private currentCompet: Competidor;
  public compForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private prismaSvc: PrismaService,
    private frmBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.createForm();

    this.route.params.subscribe(
      par => {
        if (par && !Number.isNaN(Number(par.id)))
          this.loadCompDetail(par.id);
      });
  }

  createForm() {
    this.compForm = this.frmBuilder.group({
      id: [''],
      codigo: ['', Validators.required],
      nombre: ['', Validators.required],
      calle: ['', Validators.required],
      latitud: [''],
      longitud: [''],
      marcador: [false, Validators.required],
      observar: [false, Validators.required],
      marcaId: new FormControl(),
      marca: this.frmBuilder.group({
        id: [''],
        codigo: ['', Validators.required],
        nombre: ['', Validators.required],
      }),
      zonaDePrecioId: new FormControl(),
      zonaDePrecio: this.frmBuilder.group({
        id: [''],
        codigo: ['', Validators.required],
        nombre: ['', Validators.required],
      })
    })
  }

  async loadCompDetail(compId: number) {
    this.currentCompet = await this.prismaSvc.getCompetidorById(compId).toPromise();

    this.compForm.setValue(this.currentCompet);
  }

  onSubmit(comp: Competidor) {

    if (this.isEditView) {
      this.prismaSvc.updateCompetidor(comp).subscribe(
        resul => { if (resul) this.router.navigate(['/competidor']); }
      );
    }
    else {
      this.prismaSvc.createCompetidor(comp).subscribe(
        resul => { if (resul.id > 0) this.router.navigate(['/competidor']); }
      );
    }
  }

  // convenience getter for easy access to form fields
  get getForm(): Competidor { return this.compForm.value; }

  get isEditView(): boolean { return this.currentCompet !== undefined; }

}
