using System.Data;
using Application.Ports;
using Application.UseCases.Orders;
using Dapper;
using Domain.Model.Customers;
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

        public async Task<int> AddNewOrderWithDetailAsync(NewOrderWithDetailModel model)
        {
            using IDbConnection db = _connectionFactory.CreateConnection();

            const string procedure = "sp_AddNewOrderWithDetail";

            var parameters = new DynamicParameters();

            // Parámetros de la orden
            parameters.Add("@EmpId", model.EmpId);
            parameters.Add("@CustId", model.CustId);
            parameters.Add("@ShipperId", model.ShipperId);
            parameters.Add("@ShipName", model.ShipName);
            parameters.Add("@ShipAddress", model.ShipAddress);
            parameters.Add("@ShipCity", model.ShipCity);
            parameters.Add("@OrderDate", model.OrderDate);
            parameters.Add("@RequiredDate", model.RequiredDate);
            parameters.Add("@ShippedDate", model.ShippedDate);
            parameters.Add("@Freight", model.Freight);
            parameters.Add("@ShipCountry", model.ShipCountry);

            // Parámetros del detalle
            parameters.Add("@ProductId", model.ProductId);
            parameters.Add("@UnitPrice", model.UnitPrice);
            parameters.Add("@Qty", model.Qty);
            parameters.Add("@Discount", model.Discount);

            // Output: Id de la orden creada
            parameters.Add("@OrderId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await db.ExecuteAsync(
                procedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("@OrderId");
        }
    }
}
