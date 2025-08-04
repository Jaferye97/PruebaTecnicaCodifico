export interface DetailsOrder {
  orderId: number;
  requiredDate?: Date | null;
  shippedDate?: Date | null;
  shipName: string;
  shipAddress: string;
  shipCity: string;
}
