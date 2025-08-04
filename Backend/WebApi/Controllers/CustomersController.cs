using Application.UseCases.Customers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly GetSalesDatePredictionUseCase _getSalesDatePredictionUseCase;

        public CustomersController(GetSalesDatePredictionUseCase getSalesDatePredictionUseCase)
        {
            _getSalesDatePredictionUseCase = getSalesDatePredictionUseCase;
        }

        [HttpGet("GetSalesDatePrediction")]
        public async Task<IActionResult> GetSalesDatePrediction([FromQuery] string? companyName)
        {
            var result = await _getSalesDatePredictionUseCase.ExecuteAsync(companyName);
            return Ok(result);
        }
    }
}
