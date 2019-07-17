import { Competidor } from "@/_models";
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable()
export class PrismaService extends BaseService<Competidor> {

    constructor(http: HttpClient) {
        super(http);
    }

    public getAllCompetidor(): Observable<Array<Competidor>> {
        this.path = "competidor";
        return this.get();
    }

    public getCompetidorById(compId: number): Observable<Competidor> {
        this.path = "competidor";
        return this.getById(compId);
    }

    public createCompetidor(compObj: Competidor): Observable<Competidor> {
        this.path = "competidor";
        return this.post(compObj);
    }

    public updateCompetidor(compObj: Competidor): Observable<boolean> {
        this.path = "competidor";
        return this.put(compObj.id, compObj);
    }

    public deleteCompetidor(compId: number): Observable<boolean> {
        this.path = "competidor";
        return this.delete(compId);
    }
}