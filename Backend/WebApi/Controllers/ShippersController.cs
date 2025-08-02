using Application.UseCases.Shippers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly GetAllShippersUseCase _geAllShippersUseCase;

        public ShippersController(GetAllShippersUseCase getAllShippersUseCase)
        {
            _geAllShippersUseCase = getAllShippersUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEmployees()
        {
            var shippers = await _geAllShippersUseCase.ExecuteAsync();

            return Ok(shippers);
        }
    }
}
