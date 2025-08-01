using Application.UseCases.Orders;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly GetOrdersByCustIdUseCase _getOrdersByCustIdUseCase;

        public OrdersController(GetOrdersByCustIdUseCase getOrdersByCustIdUseCase)
        {
            _getOrdersByCustIdUseCase = getOrdersByCustIdUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientOrders(int id)
        {
            var orders = await _getOrdersByCustIdUseCase.ExecuteAsync(id);

            return Ok(orders);
        }
    }
}
