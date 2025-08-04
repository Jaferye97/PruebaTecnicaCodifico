import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ViewChild } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { CustomerOrdersModalComponent } from '../components/customer-orders-modal/customer-orders-modal.component';

import { CustomersService } from '../services/salesDatePrediction.service';

import { CustomerSalesDatePrediction } from '../interfaces/CustomerSalesDatePrediction';
import { NewOrderDialogComponent } from '../components/new-order-dialog/new-order-dialog.component';

@Component({
  selector: 'app-sales-date-prediction',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
  ],
  templateUrl: './sales-date-prediction.component.html',
  styleUrls: ['./sales-date-prediction.component.css'],
})
export class SalesDatePredictionComponent implements OnInit {
  loadingSearch = false;
  customers: MatTableDataSource<CustomerSalesDatePrediction> =
    new MatTableDataSource();
  form: FormGroup;

  displayedColumns: string[] = [
    'companyName',
    'lastOrderDate',
    'nextPredictedOrder',
    'actions',
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private fb: FormBuilder,
    private service: CustomersService,
    private dialog: MatDialog
  ) {
    this.form = this.fb.group({
      search: [''],
    });
  }

  ngOnInit(): void {
    this.getDataCustomers('');
  }

  ngAfterViewInit(): void {
    this.customers.paginator = this.paginator;
    this.customers.sort = this.sort;
  }

  getDataCustomers(companyName: string): void {
    this.service
      .GetAllCustomerSalesDatePrediction(companyName)
      .subscribe((data) => {
        this.customers.data = data;
        this.loadingSearch = false;
      });
  }

  applyFilter(filterValue: string) {
    this.customers.filter = filterValue.trim().toLowerCase();
  }

  onSearch(): void {
    const searchTerm = this.form.get('search')?.value;
    this.loadingSearch = true;
    this.getDataCustomers(searchTerm);
    this.loadingSearch = false;
  }

  openOrders(customerId: string, customerName: string) {
    this.dialog.open(CustomerOrdersModalComponent, {
      width: '90%',
      data: { customerId, customerName },
    });
  }

  openNewOrder(custId: string, customerName: string) {
    this.dialog.open(NewOrderDialogComponent, {
      width: '800px',
      data: { custId, customerName },
    });
  }
}
