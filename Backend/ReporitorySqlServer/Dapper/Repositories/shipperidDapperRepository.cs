using Application.Ports;
using Dapper;
using Domain.Model.Shippers;
using ReporitorySqlServer.Dapper.Config;
using System.Data;

namespace ReporitorySqlServer.Dapper.Repositories
{
    public class ShipperidDapperRepository : IShippersRepositorySqlServerPort
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public ShipperidDapperRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ShippersReadModel>> GetAllAsync()
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string query = @"SELECT shipperid, Companyname FROM [Sales].[Shippers]";

            return await db.QueryAsync<ShippersReadModel>(query);
        }
    }
}
