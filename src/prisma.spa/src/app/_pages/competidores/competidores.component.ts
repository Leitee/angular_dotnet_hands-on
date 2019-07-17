import { Component, OnInit } from '@angular/core';
import { PrismaService } from '@/_services';
import { Observable } from 'rxjs';
import { Competidor } from '@/_models';

@Component({
  selector: 'app-competidores',
  templateUrl: './competidores.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [PrismaService]
})
export class CompetidoresComponent implements OnInit {

  private compListAsync: Observable<Array<Competidor>>;

  constructor(private prismaSvc: PrismaService) { }

  ngOnInit() {
    this.compListAsync = this.prismaSvc.getAllCompetidor();
  }

  update(c: Competidor){
    console.log(c)
    return false;
  }

  delete(c: Competidor){
    console.log(c)
    return false;
  }

}
