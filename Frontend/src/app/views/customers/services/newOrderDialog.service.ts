import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { Observable } from 'rxjs';

import {
  EmployeesReadSelect,
  NewOrderWithDetail,
  ProductsReadSelect,
  ShippersReadSelect,
} from '../interfaces/NewOrderDialog';

@Injectable({
  providedIn: 'root',
})
export class NewOrderDialogService {
  constructor(private http: HttpClient) {}

  GetAllProducts(): Observable<ProductsReadSelect[]> {
    const urlConsulta = `${environment.urlInicial}${urlServices.products}`;
    return this.http.get<ProductsReadSelect[]>(urlConsulta);
  }

  GetAllEmployees(): Observable<EmployeesReadSelect[]> {
    const urlConsulta = `${environment.urlInicial}${urlServices.employees}`;
    return this.http.get<EmployeesReadSelect[]>(urlConsulta);
  }

  GetAllShippers(): Observable<ShippersReadSelect[]> {
    const urlConsulta = `${environment.urlInicial}${urlServices.shippers}`;
    return this.http.get<ShippersReadSelect[]>(urlConsulta);
  }

  SaveNewOrderWithDetails(order: NewOrderWithDetail): Observable<number> {
    const urlConsulta = `${environment.urlInicial}${urlServices.orders}/NewOrderWithDetail`;
    return this.http.post<number>(urlConsulta, order);
  }
}
