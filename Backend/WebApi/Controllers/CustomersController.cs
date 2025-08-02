using Application.UseCases.Customers;
using Application.UseCases.Employees;
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

        [HttpGet()]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _getSalesDatePredictionUseCase.ExecuteAsync();

            return Ok(employees);
        }
    }
}
