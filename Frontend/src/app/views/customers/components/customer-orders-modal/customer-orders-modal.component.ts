import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';

import { CustomersService } from '../../services/salesDatePrediction.service';

@Component({
  selector: 'app-customer-orders-modal',
  standalone: true,
  imports: [
    CommonModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
  ],
  templateUrl: './customer-orders-modal.component.html',
  styleUrls: ['./customer-orders-modal.component.css'],
})
export class CustomerOrdersModalComponent implements OnInit {
  displayedColumns: string[] = [
    'orderId',
    'requiredDate',
    'shippedDate',
    'shipName',
    'shipAddress',
    'shipCity',
  ];
  dataSource = new MatTableDataSource<any>();
  loading = true;
  error = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    public dialogRef: MatDialogRef<CustomerOrdersModalComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { customerId: string; customerName: string },
    private service: CustomersService
  ) {}

  ngOnInit(): void {
    this.service.GetOrdersByIdCustomer(Number(this.data.customerId)).subscribe({
      next: (orders) => {
        this.dataSource.data = orders;
        this.loading = false;
        setTimeout(() => {
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        });
      },
      error: (err) => {
        this.error = 'Error loading orders';
        this.loading = false;
      },
    });
  }

  close(): void {
    this.dialogRef.close();
  }
}
