import { Routes } from '@angular/router';
import { CustomersRoutes } from './views/customers/sales-date-prediction.routes';

export const routes: Routes = [
  ...CustomersRoutes,
  { path: '**', redirectTo: '' },
];
