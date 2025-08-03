import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';
import { CustomerSalesDatePrediction } from '../interfaces/CustomerSalesDatePrediction';

@Injectable({
  providedIn: 'root',
})
export class SalesDatePredictionService {
  constructor(private http: HttpClient) {}

  GetAllCustomerSalesDatePrediction(): Observable<
    CustomerSalesDatePrediction[]
  > {
    const urlConsulta = `${environment.urlInicial}${urlServices.customers}`;
    return this.http.get<CustomerSalesDatePrediction[]>(urlConsulta);
  }
}
