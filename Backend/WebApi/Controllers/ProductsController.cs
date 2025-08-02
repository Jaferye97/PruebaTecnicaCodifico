using Application.UseCases.Products;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetAllProductsUseCase _geAllProductsUseCase;

        public ProductsController(GetAllProductsUseCase getAllProductsUseCase)
        {
            _geAllProductsUseCase = getAllProductsUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEmployees()
        {
            var products = await _geAllProductsUseCase.ExecuteAsync();

            return Ok(products);
        }
    }
}
