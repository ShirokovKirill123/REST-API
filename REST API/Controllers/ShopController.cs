using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IShopService _shopService;

        public ShopController(ILogger<ShopController> logger, IShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
        }

        // Получить все продукты
        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _shopService.GetProducts();
        }

        // Добавить новый продукт
        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            await _shopService.AddProduct(newProduct);
            return Ok();
        }

        // Обновить продукт по идентификатору
        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product updatedProduct)
        {
            await _shopService.UpdateProduct(id, updatedProduct);
            return Ok();
        }

        // Удалить продукт по идентификатору
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _shopService.DeleteProduct(id);
            return Ok();
        }

        // Аналогично, добавляем действия для покупателей и продавцов
        [HttpGet("buyers")]
        public IEnumerable<Buyer> GetBuyers()
        {
            return _shopService.GetBuyers();
        }

        [HttpPost("buyers")]
        public async Task<IActionResult> AddBuyer([FromBody] Buyer newBuyer)
        {
            await _shopService.AddBuyer(newBuyer);
            return Ok();
        }

        [HttpPut("buyers/{id}")]
        public async Task<IActionResult> UpdateBuyer(Guid id, [FromBody] Buyer updatedBuyer)
        {
            await _shopService.UpdateBuyer(id, updatedBuyer);
            return Ok();
        }

        [HttpDelete("buyers/{id}")]
        public async Task<IActionResult> DeleteBuyer(Guid id)
        {
            await _shopService.DeleteBuyer(id);
            return Ok();
        }

        [HttpGet("sellers")]
        public IEnumerable<Seller> GetSellers()
        {
            return _shopService.GetSellers();
        }

        [HttpPost("sellers")]
        public async Task<IActionResult> AddSeller([FromBody] Seller newSeller)
        {
            await _shopService.AddSeller(newSeller);
            return Ok();
        }

        [HttpPut("sellers/{id}")]
        public async Task<IActionResult> UpdateSeller(Guid id, [FromBody] Seller updatedSeller)
        {
            await _shopService.UpdateSeller(id, updatedSeller);
            return Ok();
        }

        [HttpDelete("sellers/{id}")]
        public async Task<IActionResult> DeleteSeller(Guid id)
        {
            await _shopService.DeleteSeller(id);
            return Ok();
        }
    }
}