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

        public async Task<IEnumerable<CustomersReadSalesDatePredictionModel>> GetSalesDatePredictionAsync(string? companyName = null)
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string procedure = "sp_GetSalesDatePrediction";

            var parameters = new DynamicParameters();
            parameters.Add("@FilterCompanyName", companyName, DbType.String);

            return await db.QueryAsync<CustomersReadSalesDatePredictionModel>(
                procedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
