using Domain.Model.Customers;

namespace Application.Ports
{
    public interface ICustomersRepositorySqlServerPort
    {
        Task<IEnumerable<CustomersReadSalesDatePredictionModel>> GetSalesDatePredictionAsync(string? companyName = null);
    }
}
