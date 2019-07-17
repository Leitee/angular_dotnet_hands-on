import { ApiResponse } from '@/_commons';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { AppConfigService } from '@/_services'


export abstract class BaseService<T> {

    /**
     * This param starts and ends with no slash `/`
     */
    protected path: string;
    private headerReq: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headerReq = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    protected get(): Observable<T[]> {
        let response = this.http.get<ApiResponse<T[]>>(`${AppConfigService.settings.server.apiUrl}/${this.path}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected getById(id: number): Observable<T> {
        let response = this.http.get<ApiResponse<T>>(`${AppConfigService.settings.server.apiUrl}/${this.path}/${id}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected post(body: T): Observable<T> {
        let response = this.http.post<ApiResponse<T>>(`${AppConfigService.settings.server.apiUrl}/${this.path}`, body, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected put(objId: number, body: T): Observable<boolean> {
        let response = this.http.put<ApiResponse<boolean>>(`${AppConfigService.settings.server.apiUrl}/${this.path}/${objId}`, body, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }

    protected delete(objId: number): Observable<boolean> {
        let response = this.http.delete<ApiResponse<boolean>>(`${AppConfigService.settings.server.apiUrl}/${this.path}/${objId}`, { headers: this.headerReq });
        return response.pipe(map(a => a.data));
    }
}