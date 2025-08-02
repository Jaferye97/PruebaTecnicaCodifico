using System.Data;
using Application.Ports;
using Dapper;
using Domain.Model.Employees;
using ReporitorySqlServer.Dapper.Config;

namespace ReporitorySqlServer.Dapper.Repositories
{
    public class EmployeesDapperRepository : IEmployeesRepositorySqlServerPort
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public EmployeesDapperRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<EmployeesReadModel>> GetAllAsync()
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string query = @"SELECT empid, CONCAT(firstname, ' ', lastname) fullName FROM [HR].[Employees]";

            return await db.QueryAsync<EmployeesReadModel>(query);
        }
    }
}
