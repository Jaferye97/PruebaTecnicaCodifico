using Application.Ports;
using Domain.Model.Orders;

namespace Application.UseCases.Orders
{
    public class NewOrderWithDetailUseCase
    {
        private readonly IOrdersRepositorySqlServerPort _repository;

        public NewOrderWithDetailUseCase(IOrdersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<int> ExecuteAsync(NewOrderWithDetailModel model)
        {
            return await _repository.AddNewOrderWithDetailAsync(model);
        }
    }
}
