import { CompetidoresComponent, CompetidorDetailComponent } from '@/_pages';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
    {
        path: '', pathMatch: 'full',
        component: CompetidoresComponent
    },
    {
        path: 'competidor',
        component: CompetidoresComponent
    },
    {
        path: 'competidor/:id',
        component: CompetidorDetailComponent
    },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);