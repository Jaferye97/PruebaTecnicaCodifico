using System.Data;
using Application.Ports;
using Dapper;
using Domain.Model.Customers;
using ReporitorySqlServer.Dapper.Config;

namespace ReporitorySqlServer.Dapper.Repositories
{
    public class CustomersDapperRepository : ICustomersRepositorySqlServerPort
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public CustomersDapperRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<CustomersReadSalesDatePredictionModel>> GetGetSalesDatePredictionAsync()
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string procedure = "sp_GetSalesDatePrediction";

            return await db.QueryAsync<CustomersReadSalesDatePredictionModel>(procedure, commandType: CommandType.StoredProcedure);
        }
    }
}
