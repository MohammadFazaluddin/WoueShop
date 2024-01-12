using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WoueShop.Data.Interfaces;
using WouShop.Database.Entities;

namespace WoueShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsRepository productsRepository, ILogger<ProductsController> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productsRepository.GetAll();

            if (result == null || !result.Any())
            {
                return Problem("Not found", statusCode: StatusCodes.Status404NotFound);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel product)
        {
            try
            {

                product.Id = Guid.NewGuid();
                var result = await _productsRepository.Add(product);

                return CreatedAtAction(nameof(GetProduct),
                                new { id = product.Id },
                                result);
            }
            catch (Exception ex)
            {

                return Problem("Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productsRepository.GetById(id);

            if (product == null)
            {
                return NotFound("Not found");
            }

            return Ok(product);
        }

    }
}
