namespace Domain.Model.Customers
{
    public class CustomersReadSalesDatePredictionModel
    {
        public int CustId { get; set; }
        public string CompanyName { get; set; } = null!;
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}
