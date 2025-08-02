namespace Domain.Model.Orders
{
    public class NewOrderWithDetailModel
    {
        public int EmpId { get; set; }
        public int CustId { get; set; }
        public int ShipperId { get; set; }
        public string ShipName { get; set; } = null!;
        public string ShipAddress { get; set; } = null!;
        public string ShipCity { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipCountry { get; set; } = null!;

        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
