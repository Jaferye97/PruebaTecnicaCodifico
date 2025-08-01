using Domain.Model.Orders;

namespace Application.Ports
{
    public interface IOrdersRepositorySqlServerPort
    {
        Task<IEnumerable<OrdersReadModel>> GetOrdersByCustIdAsync(int id);
    }
}
