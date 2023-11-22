using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPIDemo.Data;
using ShopAPIDemo.Models;

namespace ShopAPIDemo.Controllers
{
    [Route("api/")] //product
    [ApiController]
    public class ProductController : ControllerBase //ControllerBase no view
    {
        private readonly WebAPIContext _context;
        public ProductController(WebAPIContext context) {
            _context = context;
        }
        [HttpGet]
        [Route("xxx")]
        public IActionResult GetAll()
        {
            return Ok("yes");
        }
        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }


        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> PutProduct(Product product) { 
            
            Product tempProduct = new Product ();

            tempProduct.Title = product.Title;
            tempProduct.Description = product.Description;
            tempProduct.Price = product.Price;
            _context.Add(tempProduct);
            await _context.SaveChangesAsync();
            Console.WriteLine(tempProduct);

            return Ok(tempProduct);
        }

    }
}
