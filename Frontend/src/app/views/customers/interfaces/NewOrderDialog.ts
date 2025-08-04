export interface EmployeesReadSelect {
  empId: number;
  fullName: string;
}

export interface ProductsReadSelect {
  productId: number;
  productName: string;
}

export interface ShippersReadSelect {
  shipperId: number;
  companyName: string;
}

export interface NewOrderWithDetail {
  empId: number;
  custId: number;
  shipperId: number;
  shipName: string;
  shipAddress: string;
  shipCity: string;
  orderDate: Date;
  requiredDate: Date;
  shippedDate: Date;
  freight: number;
  shipCountry: string;

  productId: number;
  unitPrice: number;
  qty: number;
  discount: number;
}
