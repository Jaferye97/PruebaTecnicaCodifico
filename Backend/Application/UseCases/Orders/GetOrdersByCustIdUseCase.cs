using Application.Ports;
using Domain.Model.Orders;

namespace Application.UseCases.Orders
{
    public class GetOrdersByCustIdUseCase
    {
        private readonly IOrdersRepositorySqlServerPort _repository;

        public GetOrdersByCustIdUseCase(IOrdersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrdersReadModel>> ExecuteAsync(int id)
        {
            return await _repository.GetOrdersByCustIdAsync(id);
        }
    }
}
