import { Component, Inject, OnInit } from '@angular/core';
import { NgFor } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';

import { NewOrderDialogService } from '../../services/newOrderDialog.service';
import {
  EmployeesReadSelect,
  ProductsReadSelect,
  ShippersReadSelect,
} from '../../interfaces/NewOrderDialog';

@Component({
  selector: 'app-new-order-dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatDialogModule,
    NgFor,
    MatButtonModule,
    MatNativeDateModule,
    ReactiveFormsModule,
  ],
  templateUrl: './new-order-dialog.component.html',
  styleUrl: './new-order-dialog.component.css',
})
export class NewOrderDialogComponent implements OnInit {
  orderForm!: FormGroup;

  employees: EmployeesReadSelect[] = [];
  shippers: ShippersReadSelect[] = [];
  products: ProductsReadSelect[] = [];

  constructor(
    private fb: FormBuilder,
    private newOrderDialogService: NewOrderDialogService,
    private dialogRef: MatDialogRef<NewOrderDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { custId: string; customerName: string }
  ) {}

  ngOnInit(): void {
    this.buildForm();
    this.loadDropdowns();
  }

  buildForm() {
    this.orderForm = this.fb.group({
      custId: [this.data.custId, Validators.required],
      empId: [null, Validators.required],
      shipperId: [null, Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],
      orderDate: [null, Validators.required],
      requiredDate: [null, Validators.required],
      shippedDate: [null, Validators.required],
      freight: [null, Validators.required],
      productId: [null, Validators.required],
      unitPrice: [null, [Validators.required, Validators.min(0.01)]],
      qty: [null, [Validators.required, Validators.min(1)]],
      discount: [null, [Validators.required, Validators.pattern(/^(0|1)$/)]],
    });
  }

  loadDropdowns() {
    this.newOrderDialogService
      .GetAllEmployees()
      .subscribe((res) => (this.employees = res));
    this.newOrderDialogService
      .GetAllShippers()
      .subscribe((res) => (this.shippers = res));
    this.newOrderDialogService
      .GetAllProducts()
      .subscribe((res) => (this.products = res));
  }

  saveOrder() {
    if (this.orderForm.invalid) return;

    const newOrder = this.orderForm.value;

    console.log('New Order:', newOrder);

    this.newOrderDialogService.SaveNewOrderWithDetails(newOrder).subscribe({
      next: (orderId) => {
        console.log('Order saved with ID:', orderId);
        this.dialogRef.close(true);
      },
      error: (err) => console.error('Error saving order:', err),
    });
  }

  close() {
    this.dialogRef.close();
  }
}
