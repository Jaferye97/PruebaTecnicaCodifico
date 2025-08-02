using Application.Ports;
using Domain.Model.Customers;

namespace Application.UseCases.Customers
{
    public class GetSalesDatePredictionUseCase
    {
        private readonly ICustomersRepositorySqlServerPort _repository;

        public GetSalesDatePredictionUseCase(ICustomersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomersReadSalesDatePredictionModel>> ExecuteAsync()
        {
            return await _repository.GetGetSalesDatePredictionAsync();
        }
    }
}
