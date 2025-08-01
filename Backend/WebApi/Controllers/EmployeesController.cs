using Application.UseCases.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly GetAllEmployeesUseCase _getAllEmployeesUseCase;

        public EmployeesController(GetAllEmployeesUseCase getAllEmployeesUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEmployees()
        {
            var orders = await _getAllEmployeesUseCase.ExecuteAsync();

            return Ok(orders);
        }
    }
}
