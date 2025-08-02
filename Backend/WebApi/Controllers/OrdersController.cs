using Application.UseCases.Orders;
using Domain.Model.Orders;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly GetOrdersByCustIdUseCase _getOrdersByCustIdUseCase;
        private readonly NewOrderWithDetailUseCase _newOrderWithDetailUseCase;

        public OrdersController(GetOrdersByCustIdUseCase getOrdersByCustIdUseCase, NewOrderWithDetailUseCase newOrderWithDetailUseCase)
        {
            _getOrdersByCustIdUseCase = getOrdersByCustIdUseCase;
            _newOrderWithDetailUseCase = newOrderWithDetailUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientOrders(int id)
        {
            var orders = await _getOrdersByCustIdUseCase.ExecuteAsync(id);

            return Ok(orders);
        }

        [HttpPost("NewOrderWithDetail")]
        public async Task<IActionResult> NewOrderWithDetailAsync([FromBody] NewOrderWithDetailModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            int orderId = await _newOrderWithDetailUseCase.ExecuteAsync(model);

            return Ok(orderId);
        }
    }
}
