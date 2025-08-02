using Application.Ports;
using Domain.Model.Shippers;

namespace Application.UseCases.Shippers
{
    public class GetAllShippersUseCase
    {
        private readonly IShippersRepositorySqlServerPort _repository;

        public GetAllShippersUseCase(IShippersRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ShippersReadModel>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
