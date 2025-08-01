using System.Data;
using Application.Ports;
using Dapper;
using Domain.Model.Orders;
using ReporitorySqlServer.Dapper.Config;

namespace ReporitorySqlServer.Dapper.Repositories
{
    public class OrdersDapperRepository : IOrdersRepositorySqlServerPort
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public OrdersDapperRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<OrdersReadModel>> GetOrdersByCustIdAsync(int id)
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
