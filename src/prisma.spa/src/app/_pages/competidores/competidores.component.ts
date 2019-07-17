import { Component, OnInit } from '@angular/core';
import { PrismaService } from '@/_services';
import { Observable } from 'rxjs';
import { Competidor } from '@/_models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-competidores',
  templateUrl: './competidores.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [PrismaService]
})
export class CompetidoresComponent implements OnInit {

  private compListAsync: Observable<Array<Competidor>>;

  constructor(
    private prismaSvc: PrismaService,
    private router: Router
  ) { }

  ngOnInit() {
    this.loadList();
  }

  loadList() {
    this.compListAsync = this.prismaSvc.getAllCompetidor();
  }

  update(compet: Competidor) {
    this.router.navigate(['/competidor/' + compet.id, compet])
  }

  delete(compet: Competidor) {
    this.prismaSvc.deleteCompetidor(compet.id).subscribe(
      (value: boolean) => {
        if (value)
          this.loadList();
      }
    );
  }
}
