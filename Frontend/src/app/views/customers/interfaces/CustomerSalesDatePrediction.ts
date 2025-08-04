export interface CustomerSalesDatePrediction {
  custId: number;
  companyName: string;
  lastOrderDate?: Date | null;
  nextPredictedOrder?: Date | null;
}
