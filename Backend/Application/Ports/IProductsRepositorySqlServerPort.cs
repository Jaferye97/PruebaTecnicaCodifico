using Domain.Model.Products;

namespace Application.Ports
{
    public interface IProductsRepositorySqlServerPort
    {
        Task<IEnumerable<ProductsReadModel>> GetAllAsync();
    }
}
