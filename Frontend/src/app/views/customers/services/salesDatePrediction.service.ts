import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';
import { CustomerSalesDatePrediction } from '../interfaces/CustomerSalesDatePrediction';
import { DetailsOrder } from '../interfaces/DetailsOrder';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  constructor(private http: HttpClient) {}

  GetAllCustomerSalesDatePrediction(): Observable<
    CustomerSalesDatePrediction[]
  > {
    const urlConsulta = `${environment.urlInicial}${urlServices.customers}`;
    return this.http.get<CustomerSalesDatePrediction[]>(urlConsulta);
  }

  GetOrdersByIdCustomer(id: number): Observable<DetailsOrder[]> {
    const urlConsulta = `${environment.urlInicial}${urlServices.orders}/${id}`;
    return this.http.get<DetailsOrder[]>(urlConsulta);
  }
}
