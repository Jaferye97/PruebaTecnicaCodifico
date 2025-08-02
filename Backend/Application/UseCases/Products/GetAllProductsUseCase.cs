using Application.Ports;
using Domain.Model.Products;

namespace Application.UseCases.Products
{
    public class GetAllProductsUseCase
    {
        private readonly IProductsRepositorySqlServerPort _repository;

        public GetAllProductsUseCase(IProductsRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductsReadModel>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
