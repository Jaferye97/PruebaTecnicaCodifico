import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ViewChild, AfterViewInit } from '@angular/core';

import { SalesDatePredictionService } from '../services/salesDatePrediction.service';

import { CustomerSalesDatePrediction } from '../interfaces/CustomerSalesDatePrediction';

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
export class SalesDatePredictionComponent {
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
    private service: SalesDatePredictionService
  ) {
    this.form = this.fb.group({
      search: [''],
    });
  }

  ngOnInit(): void {
    this.getDataCustomers();
  }

  ngAfterViewInit(): void {
    this.customers.paginator = this.paginator;
    this.customers.sort = this.sort;
  }

  getDataCustomers(): void {
    this.service.GetAllCustomerSalesDatePrediction().subscribe((data) => {
      this.customers.data = data;
      this.loadingSearch = false;
    });
  }

  applyFilter(filterValue: string) {
    this.customers.filter = filterValue.trim().toLowerCase();
  }

  onSearch(): void {
    const searchTerm = this.form.get('search')?.value;
    this.applyFilter(searchTerm);
  }
}
