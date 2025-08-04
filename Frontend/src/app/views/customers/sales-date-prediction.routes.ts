import { Routes } from '@angular/router';
import { SalesDatePredictionComponent } from './sales-date-prediction/sales-date-prediction.component';

export const CustomersRoutes: Routes = [
  {
    path: '',
    children: [{ path: '', component: SalesDatePredictionComponent }],
  },
];
