using System.Data;
using Dapper;
using Domain.Model.Orders;
using ReporitorySqlServer.Dapper.Config;

namespace ReporitorySqlServer.Dapper.Repositories
{
    public class OrdersDapperRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public OrdersDapperRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<OrdersReadModel>> GetAsync(int id)
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string query = @"
            SELECT
                orderid,
                requireddate,
                shippeddate,
                shipname,
                shipaddress,
                shipcity
            FROM [Sales].[Orders]
            WHERE custid = @Id";

            return await db.QueryAsync<OrdersReadModel>(query, new { Id = id });
        }
    }
}
