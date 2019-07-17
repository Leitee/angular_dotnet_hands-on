import { AppComponent } from '@/app.component';
import { routing } from '@/app.routing';
import { SharedModule } from '@/shared.module';
import { ErrorInterceptor } from '@/_commons';
import { CompetidorDetailComponent, CompetidoresComponent } from '@/_pages';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoaderInterceptor } from './_commons/loader.interceptor';
import { AppConfigService } from '@/_services';

export function initConfig(config: AppConfigService) {
    return () => config.load();
}

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        routing,
        BrowserAnimationsModule,
        SharedModule
       ],
    declarations: [
        AppComponent,
        CompetidorDetailComponent,
        CompetidoresComponent
    ],
    providers: [
        AppConfigService,
        {
            provide: APP_INITIALIZER,
            useFactory: initConfig,
            deps: [AppConfigService],
            multi: true
        },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }