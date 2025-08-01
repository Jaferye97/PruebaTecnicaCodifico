using Domain.Model.Shippers;

namespace Application.Ports
{
    public interface IShippersRepositorySqlServerPort
    {
        Task<IEnumerable<ShippersReadModel>> GetAllAsync();
    }
}
