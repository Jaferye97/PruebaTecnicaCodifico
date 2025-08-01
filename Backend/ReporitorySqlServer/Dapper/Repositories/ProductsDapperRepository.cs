using Application.Ports;
using Dapper;
using Domain.Model.Products;
using ReporitorySqlServer.Dapper.Config;
using System.Data;

namespace ReporitorySqlServer.Dapper.Repositories
{
    public class ProductsDapperRepository : IProductsRepositorySqlServerPort
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public ProductsDapperRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ProductsReadModel>> GetAllAsync()
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string query = @"SELECT productid, productname FROM [Production].[Products]";

            return await db.QueryAsync<ProductsReadModel>(query);
        }
    }
}
 